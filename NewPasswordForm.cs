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

namespace FrbaHotel
{
    public partial class NewPasswordForm : Form
    {
        public NewPasswordForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxPassword.Text.Trim()))
            {
                MessageBox.Show("Debe ingresar una nueva contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ret = 0;

            try
            {

                 ret = DBHandler.SPWithValue("MATOTA.UpdatePassword",
                    new List<SqlParameter> { 
                    new SqlParameter("@userid", Login.Login.LoggedUsedID),
                    new SqlParameter("@password", textBoxPassword.Text)
                }
                    );
            } catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al cambiar su contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }

            if(ret > 0)
                MessageBox.Show("Contraseña cambiada con exito.", "Infomarcion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Ocurrio un error al cambiar su contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }
    }
}
