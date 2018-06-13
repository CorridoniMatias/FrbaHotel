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
            this.dataSourceCliente(dataGridView1);
            if (!dataGridView1.Columns.Contains("Modificar")) 
            { 
                FormHandler.crearBotonesDataGridViewCliente(dataGridView1);
            }
        }

        private void dataSourceCliente(DataGridView dataGridView)
        {
            try
            {
                var filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                    Fields("c.nombre,c.apellido,td.nombre tipoDocumento,c.numeroDocumento,c.mail,c.telefono").Table("MATOTA.Cliente c").
                    AddJoin("JOIN MATOTA.TipoDocumento td ON (c.IdTipoDocumento = td.IdTipoDocumento)");

                if (!string.IsNullOrWhiteSpace(textBoxNombre.Text))
                    filtro.AddEquals("c.nombre", textBoxNombre.Text);
                if (!string.IsNullOrWhiteSpace(textBoxApellido.Text))
                    filtro.AddEquals("c.apellido", textBoxApellido.Text);
                if (!string.IsNullOrWhiteSpace(textBoxNumDoc.Text))
                    filtro.AddEquals("c.numeroDocumento", textBoxNumDoc.Text);
                if (!string.IsNullOrWhiteSpace(textBoxMail.Text))
                    filtro.AddEquals("c.mail", textBoxMail.Text);
                if (comboBoxTipoDoc.SelectedIndex != -1)
                    filtro.AddEquals("c.IdTipoDocumento", comboBoxTipoDoc.SelectedValue.ToString());

                dataGridView.DataSource = DBHandler.QueryForComboBox(filtro.Build());
            }
            catch (Exception)
            {
                MessageBox.Show("Error al listar los clientes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                var idTipoDoc = FormHandler.getIdTipoDoc(row.Cells["tipoDocumento"].Value.ToString());
                var nroDoc = row.Cells["numeroDocumento"].Value.ToString();
                if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index)
                {
                    var modificar = new Modificacion(row.Cells["tipoDocumento"].Value.ToString(), nroDoc);
                    modificar.ShowDialog();
                }
                else if (e.ColumnIndex == dataGridView1.Columns["Inhabilitar"].Index)
                {
                    try
                    {
                        var filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.UPDATE).Table("MATOTA.Cliente").AddEquals("idTipoDocumento", idTipoDoc).AddEquals("numeroDocumento", nroDoc);
                        var query = filtro.Fields("habilitado = 0").Build();
                        DBHandler.Query(query);
                        MessageBox.Show("Cliente inhabiliatdo");
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error al inhabilitar al cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                this.dataSourceCliente(dataGridView1);
                dataGridView1.Refresh();
            }
        }
    }
}
