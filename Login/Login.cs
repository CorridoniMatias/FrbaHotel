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

        /// <summary>
        /// El ID de usuario para el usuario actualmente logueado. Si esta en -1 es guest.
        /// </summary>
        public static int LoggedUsedID {get; private set;}

        /// <summary>
        /// El ID del ROL del usuario actualmente logueado.
        /// </summary>
        public static int LoggedUserRoleID { get; set; }

        /// <summary>
        /// Lista de permisos del usuario logueado por nombre de permiso.
        /// </summary>
        public static List<string> LoggedUserPermissions { get; set; }


        public Login()
        {
            InitializeComponent();
            LoggedUsedID = -1;
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
            else if (ret > 0)
            {
                LoggedUsedID = ret; // login correcto: llevar a proxima vista o algo
                var roles = DBHandler.Query("SELECT r.idRol, r.nombre FROM MATOTA.Rol r INNER JOIN MATOTA.RolesUsuario ru ON ru.idRol = r.idRol WHERE r.estado = 1 AND ru.idUsuario = " + LoggedUsedID);

                switch (roles.Count)
                {
                    case 0:
                        MessageBox.Show("Usted no dispone de roles. No puede operar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        break;
                    case 1:
                        LoggedUserRoleID = (int)roles.First()["idRol"];
                        //Entrar directamente al sistema.
                        break;
                    default:
                        SelectRol rolselector = new SelectRol(roles);
                        DialogResult re = rolselector.ShowDialog();
                        if (re == System.Windows.Forms.DialogResult.OK)
                            LoggedUserRoleID = rolselector.SelectedRole;
                        else
                        {
                            this.Close();
                            return;
                        }
                    break;
                }


                MenuPrincipal menu = new MenuPrincipal();
                this.Hide();
                menu.ShowDialog(this);
                this.Close();
            }
        }
    }
}
