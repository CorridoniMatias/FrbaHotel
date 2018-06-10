using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new NewPasswordForm().ShowDialog();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

            if (Login.Login.LoggedUsedID == -1)
                usuarioToolStripMenuItem.Visible = false;

            Login.Login.LoggedUserPermissions = DBHandler.Query("SELECT p.nombre FROM MATOTA.Permiso p INNER JOIN MATOTA.PermisosRol pr ON (p.idPermiso = pr.idPermiso)  WHERE pr.idRol = " + Login.Login.LoggedUserRoleID)
                                        .Select(p => p["nombre"].ToString()).ToList();

            if (!Login.Login.LoggedUserPermissions.Contains("ABM de Rol"))
                tabControlFunciones.TabPages.Remove(tabPageRoles);

            if (!Login.Login.LoggedUserPermissions.Contains("ABM Usuarios"))
                tabControlFunciones.TabPages.Remove(tabPageUsuarios);

            if (!Login.Login.LoggedUserPermissions.Contains("ABM de Cliente"))
                tabControlFunciones.TabPages.Remove(tabPageHuespedes);

            if (!Login.Login.LoggedUserPermissions.Contains("ABM de Hotel"))
                tabControlFunciones.TabPages.Remove(tabPageHoteles);

            if (!Login.Login.LoggedUserPermissions.Contains("Generar o Modificar un Reserva") || !Login.Login.LoggedUserPermissions.Contains("Cancelar Reserva"))
                tabControlFunciones.TabPages.Remove(tabPageReservas);

            if (!Login.Login.LoggedUserPermissions.Contains("Listado Estadístico"))
                tabControlFunciones.TabPages.Remove(tabPageEstadistica);

        }

        private void buttonLaunchHotelManager_Click(object sender, EventArgs e)
        {
            new AbmHotel.AltaHotel().ShowDialog(this);
        }

        private void cambiarHotelActualToolStripMenuItem_Click(object sender, EventArgs e)
        {
           new AbmHotel.Listado().ShowDialog(this);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            new AbmHotel.ListadoModificacionBaja().ShowDialog(this) ;
        }

        private void buttonCheckIn_Click(object sender, EventArgs e)
        {
            new RegistrarEstadia.ComprobadorReserva().ShowDialog(this);
        }
    }
}
