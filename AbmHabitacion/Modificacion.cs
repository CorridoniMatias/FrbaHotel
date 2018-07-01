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

namespace FrbaHotel.AbmHabitacion
{
    public partial class Modificacion : Form
    {
        bool hayError = false;
        private string idHotel;
        private string idTipoHabitacion;
        private string numHabitacionAnterior;

        public Modificacion(string idHotel, string numHabitacion, string piso,
            string ubicacion, string tipoHabitacion, string descripcion, string comodidades, bool habilitado)
        {
            InitializeComponent();
            
            FormHandler.listarTipoUbicacion(comboBoxUbicacion);
            
            this.idHotel = idHotel;
            var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", this.idHotel);

            try
            {
                this.textBoxHotel.Text = DBHandler.Query(nombreHotel.Build()).First()["nombre"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar agregar el nombre del hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.numHabitacionAnterior = numHabitacion;
            this.textBoxNumHabitacion.Text = numHabitacion;
            this.textBoxPiso.Text = piso;
            this.comboBoxUbicacion.SelectedValue = ubicacion;

            this.idTipoHabitacion = tipoHabitacion;
            var nombreTipoUbicacion = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                Fields("descripcion").Table("MATOTA.TipoHabitacion").AddEquals("idTipoHabitacion", this.idTipoHabitacion);

            try
            {
                this.textBoxTipoHabitacion.Text = DBHandler.Query(nombreTipoUbicacion.Build()).First()["descripcion"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar agregar la ubicación de la habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            this.textBoxDescripcion.Text = descripcion;
            this.textBoxComodidades.Text = comodidades;
            this.checkBoxHabilitado.Checked = habilitado;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            hayError = false;
            List<TextBox> textBoxes = new List<TextBox> { textBoxNumHabitacion, textBoxPiso, textBoxDescripcion, textBoxComodidades };
            if (textBoxes.Any(tbox => string.IsNullOrEmpty(tbox.Text) || comboBoxUbicacion.SelectedIndex == -1))
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(textBoxNumHabitacion.Text.Trim()))
            {
                try
                {
                    Int32.Parse(textBoxNumHabitacion.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("El número de habitación debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hayError = true;
                }
            }
            if (!string.IsNullOrEmpty(textBoxPiso.Text.Trim()))
            {
                try
                {
                    Int32.Parse(textBoxPiso.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("El piso debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hayError = true;
                }
            }
            if (hayError)
            {
                hayError = false;
                return;
            }

            try
            {
                var result = DBHandler.SPWithValue("MATOTA.UpdateHabitacion",
                     new List<SqlParameter> { 
                        new SqlParameter("@idHotel", this.idHotel),
                        new SqlParameter("@nroHabitacionAnterior", this.numHabitacionAnterior.Trim()),
                        new SqlParameter("@nroHabitacion", textBoxNumHabitacion.Text.Trim()),
                        new SqlParameter("@piso", textBoxPiso.Text.Trim()),
                        new SqlParameter("@idUbicacion", comboBoxUbicacion.SelectedValue),
                        new SqlParameter("@idTipoHabitacion", this.idTipoHabitacion),
                        new SqlParameter("@descripcion", textBoxDescripcion.Text),
                        new SqlParameter("@comodidades", textBoxComodidades.Text),
                        new SqlParameter("@habilitado", checkBoxHabilitado.Checked),
                    }
                     );
                if (result == 0)
                    MessageBox.Show("El número de habitación ingresado en este Hotel ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else if (result == -1)
                {
                    MessageBox.Show("Error al intentar cambiar el número de habitación, está reservada!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (result == 1)
                {
                    MessageBox.Show("Actualización realizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al intentar modificar la habitación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
