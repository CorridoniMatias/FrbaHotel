using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class Listado : Form
    {
        private PobladorUsuarios poblador;

        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            FormHandler.listarRoles(comboBoxRol);
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            comboBoxTipoDoc.SelectedIndex = -1;
            poblador = new PobladorUsuarios(new List<TextBox> { textBoxUsername, textBoxNombre, textBoxApellido, textBoxMail, textBoxNumDoc }, new List<ComboBox> { comboBoxRol, comboBoxTipoDoc }, checkBoxHabilitado, dataGridViewUsuarios, new List<String> { "Modificar", "Eliminar" });

        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxFiltros);

            dataGridViewUsuarios.Rows.Clear();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridViewUsuarios.Rows.Clear();

            poblador.Poblar();
        }

        private void dataGridViewUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Modificar"))
                {
                    new Modificacion(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()).ShowDialog(this);
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Eliminar"))
                {
                    try
                    {
                        DBHandler.Query("UPDATE MATOTA.Usuario SET habilitado=0 WHERE idUsuario =" + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    } 

                }
                dataGridViewUsuarios.Rows.Clear();
                poblador.Poblar();
            }
        }
    }
}
