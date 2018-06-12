using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class Listado : Form
    {
        private PobladorRoles poblador;

        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            poblador = new PobladorRoles(textBoxNombre, checkBoxEstado, dataGridViewRoles, new List<string> { "Modificar", "Eliminar" });
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxFiltros);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridViewRoles.Rows.Clear();
            poblador.Poblar();
        }

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Modificar"))
                {
                    new Alta(
                            senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(),
                            senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(),true).ShowDialog(this);
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("Eliminar"))
                {

                    try
                    {
                        DBHandler.Query("UPDATE MATOTA.Rol SET estado=0 WHERE idRol =" + senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Ocurrió un error al eliminar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    } 

                }
                dataGridViewRoles.Rows.Clear();
                poblador.Poblar();
            }
        }

     
    }
}
