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

namespace FrbaHotel.RegistrarEstadia
{
    public partial class AltaEstadia : Form
    {
        private string idReserva;
        private BindingList<AbmCliente.Cliente> huespedes = new BindingList<AbmCliente.Cliente>();
        private int cantTotal = 0;

        public AltaEstadia(string idReserva)
        {
            InitializeComponent();
            this.idReserva = idReserva;
            this.textBoxReserva.Text = idReserva;


            var cantPersonasP = new SqlParameter("@cantidadPersonas", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var idClienteP = new SqlParameter("@idCliente", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var nombreClienteP = new SqlParameter("@nombreCliente", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output };
            var apellidoClienteP = new SqlParameter("@apellidoCliente", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output };

            int ret = DBHandler.SPWithValue("MATOTA.DatosBaseCheckIn",
                new List<SqlParameter> { 
                            new SqlParameter("@idReserva", idReserva) { Direction = ParameterDirection.Input },
                            cantPersonasP,
                            idClienteP,
                            nombreClienteP,
                            apellidoClienteP
                        }
            );
            
            cantTotal = Convert.ToInt32(cantPersonasP.Value);

            if (cantTotal < 0)
            {
                textBoxHuespuedes.Text = "No especificado.";
            }
            else
            {
                textBoxHuespuedes.Text = cantTotal.ToString();
            }

            int idCliente = Convert.ToInt32(idClienteP.Value);

            if (idCliente > 0 && !string.IsNullOrEmpty(nombreClienteP.Value.ToString()) && !string.IsNullOrEmpty(nombreClienteP.Value.ToString()))
                huespedes.Add(new AbmCliente.Cliente { nombre = nombreClienteP.Value.ToString().Trim(), apellido = apellidoClienteP.Value.ToString().Trim(), idCliente = idCliente.ToString() });
        }

        private void AltaEstadia_Load(object sender, EventArgs e)
        {
            this.listBoxHuespedes.DataSource = huespedes;
            this.listBoxHuespedes.DisplayMember = "NombreCompleto";
            this.listBoxHuespedes.ValueMember = "idCliente";
        }

        private void AddHuesped(AbmCliente.Cliente cliente)
        {
            if(huespedes.ToList().Any(c => c.idCliente.Trim().Equals( cliente.idCliente.Trim() )))
            {
                MessageBox.Show("El huesped seleccionado ya se encuentra agregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.huespedes.Add(cliente);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new AbmCliente.ListadoSeleccion();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                AddHuesped(dialog.SelectedClient);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new AbmCliente.Alta();
            if (dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                AddHuesped(dialog.InsertedClient);
            }
        }

        private void buttonCheckin_Click(object sender, EventArgs e)
        {
            if (huespedes.Count == 0)
            {
                MessageBox.Show("No se puede hacer un check-in sin huespedes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cantTotal > 0 && (huespedes.Count < cantTotal))
            {
                MessageBox.Show("Para continuar debe añadir los restantes " + (cantTotal - huespedes.Count) + " huespedes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }
    }
}
