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

namespace FrbaHotel.AbmCliente
{
    public partial class Modificacion : Form
    {
        private string tipoDoc;
        private string numDoc;
        public Modificacion(string tipoDoc, string numDoc)
        {
            this.tipoDoc = tipoDoc;
            this.numDoc = numDoc;
            InitializeComponent();
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Table("MATOTA.Cliente");
            FormHandler.queryFiltradorSegunDoc(query, tipoDoc, numDoc);
            textBoxNombre.Text = DBHandler.Query(query.Fields("nombre").Build()).First().Values.First().ToString();
            textBoxApellido.Text = DBHandler.Query(query.Fields("apellido").Build()).First().Values.First().ToString();
            comboBoxTipoDoc.Text = DBHandler.SPWithResultSet("MATOTA.getTipoDoc", new List<SqlParameter> { new SqlParameter("@idTipoDoc", tipoDoc), }).First().Values.First().ToString();
            textBoxNumDoc.Text = DBHandler.Query(query.Fields("numeroDocumento").Build()).First().Values.First().ToString();
            textBoxMail.Text = DBHandler.Query(query.Fields("mail").Build()).First().Values.First().ToString();
            textBoxTelefono.Text = DBHandler.Query(query.Fields("telefono").Build()).First().Values.First().ToString();
            textBoxNacionalidad.Text = DBHandler.Query(query.Fields("nacionalidad").Build()).First().Values.First().ToString();
            dateTimePickerFechaNacimiento.Text = DBHandler.Query(query.Fields("fechaNacimiento").Build()).First().Values.First().ToString();
            textBoxCalle.Text = DBHandler.Query(query.Fields("calle").Build()).First().Values.First().ToString();
            textBoxNroCalle.Text = DBHandler.Query(query.Fields("nroCalle").Build()).First().Values.First().ToString();
            textBoxPiso.Text = DBHandler.Query(query.Fields("piso").Build()).First().Values.First().ToString();
            textBoxDepto.Text = DBHandler.Query(query.Fields("departamento").Build()).First().Values.First().ToString();
            textBoxLocalidad.Text = DBHandler.Query(query.Fields("localidad").Build()).First().Values.First().ToString();
            textBoxPais.Text = DBHandler.Query(query.Fields("pais").Build()).First().Values.First().ToString();
            checkBoxHabilitado.Checked = (bool)DBHandler.Query(query.Fields("habilitado").Build()).First().Values.First();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
            FormHandler.limpiar(groupBox2);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            var ret = DBHandler.SPWithValue("MATOTA.UpdateCliente",
                 new List<SqlParameter> { 
                    new SqlParameter("@nombre", textBoxNombre.Text),
                    new SqlParameter("@apellido", textBoxApellido.Text),
                    new SqlParameter("@tipoDoc", comboBoxTipoDoc.SelectedValue),
                    new SqlParameter("@numeroDocumento", textBoxNumDoc.Text),
                    new SqlParameter("@mail", textBoxMail.Text),
                    new SqlParameter("@telefono", textBoxTelefono.Text),
                    new SqlParameter("@calle", textBoxCalle.Text),
                    new SqlParameter("@nroCalle", textBoxNroCalle.Text),
                    new SqlParameter("@piso", textBoxPiso.Text),
                    new SqlParameter("@departamento", textBoxDepto.Text),
                    new SqlParameter("@localidad", textBoxLocalidad.Text),
                    new SqlParameter("@pais", textBoxPais.Text),
                    new SqlParameter("@nacionalidad", textBoxNacionalidad.Text),
                    new SqlParameter("@fechaNacimiento", dateTimePickerFechaNacimiento.Value),
                    new SqlParameter("@habilitado", checkBoxHabilitado.Checked),
                    new SqlParameter("@tipoDocOriginal", tipoDoc),
                    new SqlParameter("@numDoc", numDoc),
                }
                 );
            if (ret == -1)
                MessageBox.Show("El numero de documento ingresado ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ret == 0)
            {
                MessageBox.Show("El mail ingresado ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMail.Text = string.Empty;
            }
            else if (ret == 1)
            {
                MessageBox.Show("Actualización realizada con éxito");
                this.Close();
            }
        }
    }
}
