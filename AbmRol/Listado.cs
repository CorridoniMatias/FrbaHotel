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
        public Listado()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxFiltros);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridViewRoles.DataSource = this.dataSourceRol();
            FormHandler.crearBotonesDataGridView(dataGridViewRoles);
        }

        private DataTable dataSourceRol()
        {
            var filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("NOMBRE, estado").Table("MATOTA.Rol");

            if(!string.IsNullOrWhiteSpace(textBoxNombre.Text))
                filtro.AddLike("NOMBRE", textBoxNombre.Text);
            filtro.AddEquals("estado", Convert.ToInt32(checkBoxEstado.Checked).ToString());
            return DBHandler.QueryForComboBox(filtro.Build());
        }

        private void dataGridViewRoles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewRoles.Rows[e.RowIndex];

                if (e.ColumnIndex == dataGridViewRoles.Columns["Modificar"].Index)
                {
                    AbmRol.Alta(row);
                }
                else if (e.ColumnIndex == dataGridViewRoles.Columns["Eliminar"].Index)
                {
                    var query = new QueryBuilder(QueryBuilder.QueryBuilderType.DELETE).Table("MATOTA.Cliente").
                    AddEquals("IdTipoDocumento", row.Cells["IdTipoDocumento"].Value.ToString()).
                    AddEquals("numeroDocumento", row.Cells["numeroDocumento"].Value.ToString()).Build();
                    DBHandler.Query(query);
                }
                dataGridViewRoles.DataSource = this.dataSourceRol();
                dataGridViewRoles.Refresh();
            }
        }
    }
}
