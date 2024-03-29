﻿using System;
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
        private string idTipoDoc;
        bool hayError = false;
        public Modificacion(string tipoDoc, string numDoc)
        {
            this.tipoDoc = tipoDoc;
            this.numDoc = numDoc;
            InitializeComponent();
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            try
            {
                FormHandler.listarTipoDoc(comboBoxTipoDoc);
                idTipoDoc = FormHandler.getIdTipoDoc(tipoDoc);
                var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Table("MATOTA.Cliente").AddEquals("idTipoDocumento", idTipoDoc).AddEquals("numeroDocumento", numDoc);
                textBoxNombre.Text = DBHandler.Query(query.Fields("nombre").Build()).First().Values.First().ToString();
                textBoxApellido.Text = DBHandler.Query(query.Fields("apellido").Build()).First().Values.First().ToString();
                comboBoxTipoDoc.Text = tipoDoc;
                textBoxNumDoc.Text = numDoc;
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
            catch (Exception)
            {
                MessageBox.Show("Error al cargar al cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            hayError = false;
            List<TextBox> textBoxes = new List<TextBox> {textBoxApellido,textBoxCalle,textBoxDepto,textBoxLocalidad,textBoxMail,
                                                        textBoxNacionalidad,textBoxNombre,textBoxNroCalle,textBoxNumDoc,textBoxPais,textBoxPiso,textBoxTelefono};
            if (textBoxes.Any(tb => string.IsNullOrEmpty(tb.Text) || comboBoxTipoDoc.SelectedIndex == -1))
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
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
            if (hayError)
            {
                hayError = false;
                return;
            }
            try
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
                    new SqlParameter("@tipoDocOriginal", idTipoDoc),
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
                    MessageBox.Show("Actualización realizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al modificar al cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
