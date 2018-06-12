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

namespace FrbaHotel.AbmUsuario
{
    public partial class Alta : Form
    {
        bool hayError = false;
        public Alta()
        {
            InitializeComponent();
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            comboBoxTipoDoc.SelectedIndex = -1;
            FormHandler.listarRoles(comboBoxRol);
            dateTimePickerFechaNacimiento.Value = ConfigManager.FechaSistema;
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxUser);
            FormHandler.limpiar(groupBoxDatos);
            FormHandler.limpiar(groupBoxDireccion);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            hayError = false;

            List<TextBox> fields = new List<TextBox>
            {
                textBoxUsername,
                textBoxPassword,
                textBoxNombre,
                textBoxApellido,
                textBoxNumDoc,
                textBoxMail,
                textBoxTelefono,
                textBoxCalle,
                textBoxNroCalle,
                textBoxLocalidad,
                textBoxPais
            };

            if (fields.Any(f => string.IsNullOrEmpty(f.Text.Trim())) || comboBoxRol.SelectedIndex<0 || comboBoxTipoDoc.SelectedIndex<0)
            {
                fields.FindAll(f => string.IsNullOrEmpty(f.Text.Trim())).ForEach(f => f.BackColor = Color.Red);
                if (comboBoxRol.SelectedIndex < 0)
                {
                    comboBoxRol.BackColor = Color.Red;
                    comboBoxRol.DropDownStyle = ComboBoxStyle.DropDown;
                }
                if (comboBoxTipoDoc.SelectedIndex < 0)
                {
                    comboBoxTipoDoc.BackColor = Color.Red;
                    comboBoxTipoDoc.DropDownStyle = ComboBoxStyle.DropDown;
                }
                MessageBox.Show("Debe llenar todos los campos marcados en rojo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hayError = true;
            }
            if (!string.IsNullOrEmpty(textBoxNumDoc.Text.Trim()))
            {
                try
                {
                    Int32.Parse(textBoxNumDoc.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("El número de documento debe ser un número." + Environment.NewLine + "Ingrese su documento sin guiones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hayError = true;
                }
            }
            if (!string.IsNullOrEmpty(textBoxTelefono.Text.Trim()))
            {
                try
                {
                    Int32.Parse(textBoxTelefono.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("El teléfono debe ser un número." + Environment.NewLine + " Ingrese su teléfono sin los guiones ni el más.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hayError = true;
                }
            }

            if (!string.IsNullOrEmpty(textBoxNroCalle.Text.Trim()))
            {
                try
                {
                    Int32.Parse(textBoxNroCalle.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("El número de calle debe ser un número.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (dateTimePickerFechaNacimiento.Value.CompareTo(ConfigManager.FechaSistema) > 0) 
            {
                MessageBox.Show("La fecha de nacimiento no puede ser posterior a la fecha actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hayError = true;
            }
            if (!string.IsNullOrEmpty(textBoxUsername.Text.Trim()))
            {
                string queryValidar = "SELECT COUNT(*) FROM MATOTA.Usuario WHERE username = '" + textBoxUsername.Text + "'";

                int cant = DBHandler.QueryScalar(queryValidar);

                if (cant > 0)
                {
                    MessageBox.Show("Ya existe un usuario con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    hayError = true;
                }
            }

            if (hayError)
            {
                hayError = false;
                return;
            }

            List<SqlParameter> parametros = new List<SqlParameter> { 
                    new SqlParameter("@username", textBoxUsername.Text),
                    new SqlParameter("@password", textBoxPassword.Text),
                    new SqlParameter("@nombre", textBoxNombre.Text),
                    new SqlParameter("@apellido", textBoxApellido.Text),
                    new SqlParameter("@idTipoDocumento", comboBoxTipoDoc.SelectedValue),
                    new SqlParameter("@numeroDocumento", textBoxNumDoc.Text),
                    new SqlParameter("@mail", textBoxMail.Text),
                    new SqlParameter("@telefono", textBoxTelefono.Text),
                    new SqlParameter("@calle", textBoxCalle.Text),
                    new SqlParameter("@nroCalle", textBoxNroCalle.Text),
                    new SqlParameter("@localidad", textBoxLocalidad.Text),
                    new SqlParameter("@pais", textBoxPais.Text),
                    new SqlParameter("@fechaNacimiento", dateTimePickerFechaNacimiento.Value.ToString("yyyy-MM-dd"))
            };
            if(!String.IsNullOrEmpty(textBoxPiso.Text))
             parametros.Add(new SqlParameter("@piso", textBoxPiso.Text));
            if(!String.IsNullOrEmpty(textBoxDepto.Text))
             parametros.Add(new SqlParameter("@departamento", textBoxDepto.Text));
            int idUsuario = DBHandler.SPWithValue("MATOTA.CrearUsuario",parametros);

            if (idUsuario < 1)
            {
                MessageBox.Show("Error al agregar usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO MATOTA.RolesUsuario VALUES ("+idUsuario.ToString()+","+comboBoxRol.SelectedValue.ToString()+")";

            try
            {
                DBHandler.Query(query);
                MessageBox.Show("Usuario agregado con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al agregar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            textBoxUsername.BackColor = Color.White;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            textBoxPassword.BackColor = Color.White;
        }

        private void textBoxNombre_TextChanged(object sender, EventArgs e)
        {
            textBoxNombre.BackColor = Color.White;
        }

        private void textBoxApellido_TextChanged(object sender, EventArgs e)
        {
            textBoxApellido.BackColor = Color.White;
        }

        private void textBoxNumDoc_TextChanged(object sender, EventArgs e)
        {
            textBoxNumDoc.BackColor = Color.White;
        }

        private void textBoxMail_TextChanged(object sender, EventArgs e)
        {
            textBoxMail.BackColor = Color.White;
        }

        private void textBoxTelefono_TextChanged(object sender, EventArgs e)
        {
            textBoxTelefono.BackColor = Color.White;
        }

        private void textBoxCalle_TextChanged(object sender, EventArgs e)
        {
            textBoxCalle.BackColor = Color.White;
        }

        private void textBoxNroCalle_TextChanged(object sender, EventArgs e)
        {
            textBoxNroCalle.BackColor = Color.White;
        }

        private void textBoxLocalidad_TextChanged(object sender, EventArgs e)
        {
            textBoxLocalidad.BackColor = Color.White;
        }

        private void textBoxPais_TextChanged(object sender, EventArgs e)
        {
            textBoxPais.BackColor = Color.White;
        }

        private void comboBoxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRol.BackColor = Color.White;
        }

        private void comboBoxTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxTipoDoc.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTipoDoc.BackColor = Color.White;
        }
    }
}
