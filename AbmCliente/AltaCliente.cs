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
    public partial class Alta : Form
    {
        public Cliente InsertedClient { get; private set; }
        public Alta()
        {
            InsertedClient = null;
            InitializeComponent();
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            comboBoxTipoDoc.SelectedIndex = -1;
        }

        private void guardarCliente_Click(object sender, EventArgs e)
        {
            List<TextBox> textBoxes = new List<TextBox> {textBoxApellido,textBoxCalle,textBoxDepto,textBoxLocalidad,textBoxMail,
                                                        textBoxNacionalidad,textBoxNombre,textBoxNroCalle,textBoxNumDoc,textBoxPais,textBoxPiso,textBoxTelefono};

            if (textBoxes.Any(tb=>string.IsNullOrEmpty(tb.Text) || comboBoxTipoDoc.SelectedIndex == -1))
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ret = DBHandler.SPWithValue("MATOTA.altaCliente",
                new List<SqlParameter> { 
                    new SqlParameter("@nombre", textBoxNombre.Text.Trim()),
                    new SqlParameter("@apellido", textBoxApellido.Text.Trim()),
                    new SqlParameter("@tipoDoc", comboBoxTipoDoc.SelectedValue),
                    new SqlParameter("@numeroDocumento", textBoxNumDoc.Text.Trim()),
                    new SqlParameter("@mail", textBoxMail.Text.Trim()),
                    new SqlParameter("@telefono", textBoxTelefono.Text.Trim()),
                    new SqlParameter("@calle", textBoxCalle.Text.Trim()),
                    new SqlParameter("@nroCalle", textBoxNroCalle.Text.Trim()),
                    new SqlParameter("@piso", textBoxPiso.Text.Trim()),
                    new SqlParameter("@departamento", textBoxDepto.Text.Trim()),
                    new SqlParameter("@localidad", textBoxLocalidad.Text.Trim()),
                    new SqlParameter("@pais", textBoxPais.Text.Trim()),
                    new SqlParameter("@nacionalidad", textBoxNacionalidad.Text.Trim()),
                    new SqlParameter("@fechaNacimiento", dateTimePickerFechaNacimiento.Value),
                }
                );

            if (ret == -1)
                MessageBox.Show("El cliente ingresado ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ret == 0)
            {
                MessageBox.Show("El mail ingresado ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMail.Text = string.Empty;
            }
            else if (ret >= 1)
            {
                InsertedClient = new Cliente() { nombre = textBoxNombre.Text.Trim(), apellido = textBoxApellido.Text.Trim(), idCliente = ret.ToString()};
                MessageBox.Show("Cliente ingresado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this.groupBox1);
            FormHandler.limpiar(this.groupBox2);
        }

        
        
    }
}
