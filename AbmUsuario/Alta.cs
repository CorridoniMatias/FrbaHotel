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
            comboBoxRol.SelectedIndex = -1;
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

            //int ret = DBHandler.SPWithValue("MATOTA.loginUsuario",
            //    new List<SqlParameter> { 
            //        new SqlParameter("@username", textBoxUsername.Text),
            //        new SqlParameter("@password", textBoxPassword.Text)
            //    }
            //    );
            //string query = "INSERT INTO MATOTA.Usuario (username, password, nombre, apellido, idTipoDocumento, numeroDocumento, mail, telefono, calle, nroCalle, localidad, pais, fechaNacimiento";
            //if (!string.IsNullOrEmpty(textBoxPiso.Text.Trim()))
            //{
            //    query += ",piso";
            //    fields.Add(textBoxPiso);
            //}

            //if(!string.IsNullOrEmpty(textBoxDepto.Text.Trim()))
            //{
            //    query += ",departamento";
            //    fields.Add(textBoxDepto);
            //}

            //query += ") VALUES (";

            //query += String.Join(",", fields.Select(f => "'" + f.Text.Trim();) + "'").ToArray()) + ")";

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
    }
}
