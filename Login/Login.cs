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

namespace FrbaHotel.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBoxPassword.Text) || string.IsNullOrEmpty(textBoxUsername.Text))
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int ret = DBHandler.SPWithValue("MATOTA.loginUsuario",
                new List<SqlParameter> { 
                    new SqlParameter("@username", textBoxUsername.Text),
                    new SqlParameter("@password", textBoxPassword.Text)
                }
                );

            if (ret == 0)
            {
                MessageBox.Show("Usuario o contraseña incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxPassword.Text = string.Empty;
            }
            else if(ret == -1)
                MessageBox.Show("Su usuario se encuentra inhabilitado por haber ingresado incorrectamente su contraseña multiples veces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if(ret == 1)
                ; // login correcto: llevar a proxima vista o algo
        }
    }
}
