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
        public Alta()
        {
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
                }
                );

            if (ret == -1)
                MessageBox.Show("El cliente ingresado ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (ret == 0)
            {
                MessageBox.Show("El mail ingresado ya se encuentra registrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxMail.Text = string.Empty;
            }
            else if (ret == 1)
                MessageBox.Show("Cliente ingresado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this.groupBox1);
            FormHandler.limpiar(this.groupBox2);
        }

        
        
    }
}
