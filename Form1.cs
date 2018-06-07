using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login.Login login = new Login.Login();
            this.Hide();
            login.ShowDialog(this);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs events)
        {
            try
            {

                Login.Login.LoggedUserRoleID = DBHandler.SPWithValue("MATOTA.GetGuestRoleID");
            }
            catch (InvalidCastException e)
            {
                // Este tipo exc solo va a pasar si no se encontro el rol guest en la db
                MessageBox.Show("Ocurrio un error interno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            MenuPrincipal menu = new MenuPrincipal();
            this.Hide();
            menu.ShowDialog(this);
            this.Close();
        }
    }
}
