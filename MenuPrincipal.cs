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

        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            new GenerarModificacionReserva.GenerarReserva().ShowDialog(this);
        }

        private void buttonModificar_Click(object sender, EventArgs e)
        {
            new GenerarModificacionReserva.Listado().ShowDialog(this);
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            new CancelarReserva.Cancelar().ShowDialog(this);
        }

        private void buttonCrearRol_Click(object sender, EventArgs e)
        {
            new AbmRol.Alta().ShowDialog(this);
        }

        private void buttonModificarRol_Click(object sender, EventArgs e)
        {
            new AbmRol.Listado().ShowDialog(this);
        }

        private void buttonCrearUsuario_Click(object sender, EventArgs e)
        {
            new AbmUsuario.Alta().ShowDialog(this);
        }

        private void buttonModificarUsuario_Click(object sender, EventArgs e)
        {
            new AbmUsuario.Listado().ShowDialog(this);
        }

        private void buttonGenerarListado_Click(object sender, EventArgs e)
        {
            new ListadoEstadistico.SeleccionarListado().ShowDialog(this);
        }

        private void buttonCrearHabitacion_Click(object sender, EventArgs e)
        {
            new AbmHabitacion.Alta().ShowDialog(this);
        }

        private void buttonModificarHabitacion_Click(object sender, EventArgs e)
        {
            new AbmHabitacion.ListadoSeleccion().ShowDialog(this);
        }

        private void buttonAltaCliente_Click(object sender, EventArgs e)
        {
            new AbmCliente.Alta().ShowDialog(this);
        }

        private void buttonModificarCliente_Click(object sender, EventArgs e)
        {
            new AbmCliente.Listado().ShowDialog(this);
        }

    }
}
