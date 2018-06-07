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
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            listarTipoDoc();
        }
        private void listarTipoDoc()
        {
            comboBoxTipoDoc.DataSource = DBHandler.SPForComboBox("MATOTA.listarTipoDoc");
            comboBoxTipoDoc.DisplayMember = "nombre";
            comboBoxTipoDoc.ValueMember = "IdTipoDocumento";
        }

        private void guardarCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNombre.Text) || string.IsNullOrEmpty(textBoxApellido.Text))
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
                MessageBox.Show("Cliente ingresado con éxito");
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            ResetearForm.limpiar(this.groupBox1);
            ResetearForm.limpiar(this.groupBox2);
        }

        
        
    }
}
