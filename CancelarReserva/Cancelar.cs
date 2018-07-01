using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.CancelarReserva
{
    public partial class Cancelar : Form
    {
        private Boolean puedeCancelar;
        public Cancelar()
        {
            InitializeComponent();
        }

        private void Cancelar_Load(object sender, EventArgs e)
        {

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox> { textBoxIdReserva, textBoxMotivo };
            if (textBoxes.Any(tb => string.IsNullOrEmpty(tb.Text)))
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!string.IsNullOrEmpty(textBoxIdReserva.Text.Trim()))
            {
                try
                {
                    Int32.Parse(textBoxIdReserva.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("El número de reserva debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            try
            {
                puedeCancelar = DBHandler.SPWithBool("MATOTA.FechaCorrectaParaModificarReserva", new List<SqlParameter>{new SqlParameter("@idReserva",textBoxIdReserva.Text),
                                                                                                      new SqlParameter("@fechaSistema",ConfigManager.FechaSistema)});
            }
            catch (Exception excep)
            {
                MessageBox.Show("Error al chequear si puede modificar la reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (!puedeCancelar)
            {
                MessageBox.Show("Ya pasó la fecha límite para cancelar esta reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var ret = DBHandler.SPWithValue("MATOTA.CancelarReserva",
                    new List<SqlParameter>{
                        new SqlParameter("@idReserva",textBoxIdReserva.Text),
                        new SqlParameter("@motivo",textBoxMotivo.Text.Trim()),
                        new SqlParameter("@fecha",ConfigManager.FechaSistema),
                        new SqlParameter("@idUsuario",Login.Login.LoggedUsedID), });
                if (ret == 0)
                {
                    MessageBox.Show("La reserva " + textBoxIdReserva.Text + " ya se encuentra cancelada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxIdReserva.Text = string.Empty;
                }
                else if (ret == 1)
                {
                    MessageBox.Show("Reserva cancelada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar cancelar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}