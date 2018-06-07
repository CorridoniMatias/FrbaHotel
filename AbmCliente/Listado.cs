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
            var filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                            Fields("nombre,apellido,IdTipoDocumento,numeroDocumento,mail").Table("MATOTA.Cliente");
            
            if (!string.IsNullOrWhiteSpace(textBoxNombre.Text))
                filtro.AddLike("nombre", textBoxNombre.Text);
            if (!string.IsNullOrWhiteSpace(textBoxApellido.Text))
                filtro.AddLike("apellido", textBoxApellido.Text);
            if (!string.IsNullOrWhiteSpace(textBoxNumDoc.Text))
                filtro.AddEquals("numeroDocumento", textBoxNumDoc.Text);
            if (!string.IsNullOrWhiteSpace(textBoxMail.Text))
                filtro.AddLike("mail", textBoxMail.Text);
            filtro.AddEquals("IdTipoDocumento", comboBoxTipoDoc.SelectedValue.ToString());
           
            dataGridView1.DataSource = DBHandler.QueryForComboBox(filtro.Build());
            FormHandler.crearBotonesDataGridView(dataGridView1);
        }


        private void Listado_Load(object sender, EventArgs e)
        {
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox2);
        }
    }
}
