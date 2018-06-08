using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = this.dataSourceCliente();
            if (!dataGridView1.Columns.Contains("Modificar")) 
            { 
                FormHandler.crearBotonesDataGridView(dataGridView1);
            }
        }

        private DataTable dataSourceCliente()
        {
            var filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                Fields("nombre,apellido,IdTipoDocumento,numeroDocumento,mail").Table("MATOTA.Cliente");

            if (!string.IsNullOrWhiteSpace(textBoxNombre.Text))
                filtro.AddEquals("nombre", textBoxNombre.Text);
            if (!string.IsNullOrWhiteSpace(textBoxApellido.Text))
                filtro.AddEquals("apellido", textBoxApellido.Text);
            if (!string.IsNullOrWhiteSpace(textBoxNumDoc.Text))
                filtro.AddEquals("numeroDocumento", textBoxNumDoc.Text);
            if (!string.IsNullOrWhiteSpace(textBoxMail.Text))
                filtro.AddLike("mail", textBoxMail.Text);
            if (comboBoxTipoDoc.SelectedIndex != -1)
                filtro.AddEquals("IdTipoDocumento", comboBoxTipoDoc.SelectedValue.ToString());

            return DBHandler.QueryForComboBox(filtro.Build());
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            comboBoxTipoDoc.SelectedIndex = -1;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index)
                {
                    var modificar = new Modificacion(row.Cells["IdTipoDocumento"].Value.ToString(), row.Cells["numeroDocumento"].Value.ToString());
                    modificar.ShowDialog();
                }
                else if (e.ColumnIndex == dataGridView1.Columns["Eliminar"].Index)
                {
                    var query = new QueryBuilder(QueryBuilder.QueryBuilderType.DELETE).Table("MATOTA.Cliente").
                    AddEquals("IdTipoDocumento", row.Cells["IdTipoDocumento"].Value.ToString()).
                    AddEquals("numeroDocumento", row.Cells["numeroDocumento"].Value.ToString()).Build();
                    DBHandler.Query(query);
                }
                dataGridView1.DataSource = this.dataSourceCliente();
                dataGridView1.Refresh();
            }
        }
    }
}
