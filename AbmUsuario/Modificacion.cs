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
    public partial class Modificacion : Form
    {

        bool modificando;
        bool hayError;
        string idUsuario;
        private AbmHotel.Hotel hotel;
        List<TextBox> textBoxs;

        public Modificacion(string idUsuario)
        {
            this.idUsuario = idUsuario;
            hayError = false;

            InitializeComponent();
            textBoxs = new List<TextBox> { textBoxUsername, textBoxNombre, textBoxApellido, textBoxNumDoc, textBoxMail, textBoxTelefono, textBoxCalle, textBoxNroCalle, textBoxPiso, textBoxDepto, textBoxLocalidad, textBoxPais };
            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            comboBoxTipoDoc.SelectedIndex = -1;
            FormHandler.listarRoles(comboBoxRol);



            QueryBuilder query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
             .Fields("u.idUsuario, u.username, u.habilitado, ru.idRol, u.nombre, u.apellido, u.idTipoDocumento, u.numeroDocumento, u.mail, u.telefono, u.fechaNacimiento, u.calle, u.nroCalle, u.piso, u.departamento, u.localidad, u.pais")
             .Table("MATOTA.Usuario u").AddJoin("LEFT JOIN MATOTA.RolesUsuario ru ON u.idUsuario = ru.idUsuario").AddEquals("u.idUsuario", idUsuario);

            //try
            //{
                Dictionary<string, object> datos = DBHandler.Query(query.Build())[0];

                textBoxs.ForEach(tf => tf.Text = datos[tf.Tag.ToString()].ToString());
                checkBoxHabilitado.Checked = Boolean.Parse(datos["habilitado"].ToString());
                dateTimePickerFechaNacimiento.Value = DateTime.Parse(datos["fechaNacimiento"].ToString());
                for (int i = 0; i < comboBoxRol.Items.Count; i++)
                {
                    if (((DataRowView)comboBoxRol.Items[i])["idRol"].ToString() == datos["idRol"].ToString())
                    {
                        comboBoxRol.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < comboBoxTipoDoc.Items.Count; i++)
                {
                    if (((DataRowView)comboBoxTipoDoc.Items[i])["idTipoDocumento"].ToString() == datos["idTipoDocumento"].ToString())
                    {
                        comboBoxTipoDoc.SelectedIndex = i;
                        break;
                    }
                }

                List<Dictionary<string,object>> h = DBHandler.Query("SELECT h.nombre, h.idHotel FROM MATOTA.Hotel h INNER JOIN MATOTA.HotelesUsuario hu ON h.idHotel = hu.idHotel WHERE hu.idUsuario =" + idUsuario);
                if(h.Count>0)
                    hotel = new AbmHotel.Hotel(){nombre=h[0]["nombre"].ToString(),idHotel=h[0]["idHotel"].ToString()};
            //}
            //catch
            //{
            //    MessageBox.Show("No se pudo cargar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    hayError = true;
            //}



        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            hayError = false;

            List<TextBox> fields = new List<TextBox>
            {
                textBoxUsername,
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

            if (fields.Any(f => string.IsNullOrEmpty(f.Text.Trim())) || comboBoxRol.SelectedIndex < 0 || comboBoxTipoDoc.SelectedIndex < 0)
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
            if (!String.IsNullOrEmpty(textBoxMail.Text.Trim()))
                if (!FormHandler.verificarMail(textBoxMail))
                {
                    MessageBox.Show("El mail tiene un formato invalido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (hotel == null)
            {
                MessageBox.Show("Debe seleccionar un hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hayError = true;
            }

            if (!string.IsNullOrEmpty(textBoxUsername.Text.Trim()))
            {
                string queryValidar = "SELECT COUNT(*) FROM MATOTA.Usuario WHERE username = '" + textBoxUsername.Text + "' AND idUsuario <>" + idUsuario;


                try
                {
                    int cant = DBHandler.QueryScalar(queryValidar);

                    if (cant > 0)
                    {
                        MessageBox.Show("Ya existe un usuario con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        hayError = true;
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al agregar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }

            if (hayError)
            {
                hayError = false;
                return;
            }

            string query = "UPDATE MATOTA.Usuario SET ";
            query += String.Join(",", fields.Select(f => f.Tag.ToString() + "='" + f.Text.ToString() + "'").ToArray());

            if (!String.IsNullOrEmpty(textBoxPiso.Text.Trim()))
                query += ", piso ='" + textBoxPiso.Text.ToString() + "'";
            else if (DBHandler.Query("SELECT piso FROM MATOTA.Usuario WHERE idUsuario=" + idUsuario).Count > 0)
                DBHandler.Query("UPDATE MATOTA.Usuario SET piso = NULL WHERE idUsuario = " + idUsuario);

            if (!String.IsNullOrEmpty(textBoxDepto.Text.Trim()))
                query += ", departamento ='" + textBoxDepto.Text.ToString() + "'";
            else if (DBHandler.Query("SELECT departamento FROM MATOTA.Usuario WHERE idUsuario=" + idUsuario).Count > 0)
                DBHandler.Query("UPDATE MATOTA.Usuario SET departamento = NULL WHERE idUsuario = " + idUsuario);

            query += ", habilitado =" + Convert.ToInt32(checkBoxHabilitado.Checked);

            query += ", idTipoDocumento =" + comboBoxTipoDoc.SelectedValue.ToString();

            query += ", fechaNacimiento = '" + dateTimePickerFechaNacimiento.Value.ToString("yyyy-MM-dd") + "'";

            query += " WHERE idUsuario=" + idUsuario;

            try
            {
                DBHandler.Query(query);

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al guardar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            query = "UPDATE MATOTA.RolesUsuario SET idRol=" + comboBoxRol.SelectedValue.ToString() + "WHERE idUsuario =" + idUsuario;

            try
            {
                DBHandler.Query(query);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al guardar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
            MessageBox.Show(hotel.idHotel.ToString());
                if (DBHandler.Query("SELECT hu.idHotel FROM MATOTA.HotelesUsuario hu WHERE hu.idUsuario =" + idUsuario).Count == 0)
                {
                    DBHandler.Query("INSERT INTO MATOTA.HotelesUsuario VALUES (" + idUsuario.ToString() + "," + hotel.idHotel.ToString() + ")");
                }
                else DBHandler.Query("UPDATE MATOTA.HotelesUsuario SET idHotel = " + hotel.idHotel.ToString() + " WHERE idUsuario =" + idUsuario.ToString());
                MessageBox.Show("Usuario guardado con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al guardar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            textBoxUsername.BackColor = Color.White;
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

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            if(hayError)
                this.Close();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            var selector = new AbmHotel.Listado(false);

            if (selector.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                hotel = selector.SelectedHotel;
                textBoxHotel.Text = hotel.nombre;

            }
        }
    }
}
