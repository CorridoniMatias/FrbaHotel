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
            try{

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
            catch (Exception exc)
            {
                MessageBox.Show("Error al obtener datos para el check-in!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AltaEstadia_Load(object sender, EventArgs e)
        {
            this.listBoxHuespedes.DataSource = huespedes;
            this.listBoxHuespedes.DisplayMember = "NombreCompleto";
            this.listBoxHuespedes.ValueMember = "idCliente";
            CheckAmt();
        }

        private void AddHuesped(AbmCliente.Cliente cliente)
        {
            if(huespedes.ToList().Any(c => c.idCliente.Trim().Equals( cliente.idCliente.Trim() )))
            {
                MessageBox.Show("El huesped seleccionado ya se encuentra agregado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.huespedes.Add(cliente);
            CheckAmt();

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

        private void CheckAmt()
        {
            if (cantTotal == 0)
                return;

            if (listBoxHuespedes.Items.Count == cantTotal)
            {
                button1.Enabled = false;
                button2.Enabled = false;
                labelCuposFull.Visible = true;
            }
        }

        private void RollBack(int idEstadia)
        {
            QueryBuilder builder = new QueryBuilder(QueryBuilder.QueryBuilderType.DELETE).Table("MATOTA.ClientesEstadia");

            huespedes.ToList().ForEach(h => builder.AddAndFilter("idEstadia=" + idEstadia.ToString(), "idCliente=" + h.idCliente));

            try
            {
                DBHandler.Query(builder.Build());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error al remover clientes de la estadia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            builder = new QueryBuilder(QueryBuilder.QueryBuilderType.DELETE).Table("MATOTA.Estadia").AddEquals("idEstadia", idEstadia.ToString());

            try
            {
                DBHandler.Query(builder.Build());
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error al remover estadia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


            var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.INSERT)
                                .Table("MATOTA.Estadia")
                                .Fields("idReserva,fechaIngreso,idUsuario")
                                .AddValues(idReserva, ConfigManager.FechaSistema.ToString("yyyy-MM-dd"), Login.Login.LoggedUsedID.ToString());

            int idEstadia = -1;
            try{
                idEstadia = DBHandler.QueryScalar(builder.Build(true));
            } catch(Exception ex)
            {
                MessageBox.Show("Error al agregar Estadia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Clientes para la estadia
            builder = new QueryBuilder(QueryBuilder.QueryBuilderType.INSERT)
                                .Table("MATOTA.ClientesEstadia")
                                .Fields("idEstadia,idCliente");

            huespedes.ToList().ForEach(h => builder.AddValues(idEstadia.ToString(), h.idCliente));

            var count = 0;

            try
            {
                count = DBHandler.QueryRowCount(builder.Build());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar los clientes en la estadia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                RollBack(idEstadia);

                return;
            }

            if (count != huespedes.Count)
            {
                MessageBox.Show("Error al registrar los clientes en la estadia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                RollBack(idEstadia);

                return;
            }
            
            // Actualizar la reserva como efectivizada!
            int ret = DBHandler.SPWithValue("MATOTA.EfectivizarReserva",
                new List<SqlParameter> { 
                    new SqlParameter("@idReserva", idReserva)
                }
                );

            if (ret == 0)
            {
                MessageBox.Show("Error al efectivizar la reserva!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                RollBack(idEstadia);

                return;
            }

            MessageBox.Show("Check-in registrado con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
