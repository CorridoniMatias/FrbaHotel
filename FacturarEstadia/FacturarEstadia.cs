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

namespace FrbaHotel.FacturarEstadia
{
    public partial class FacturarEstadia : Form
    {
        private List<string> idEstadias = new List<string>();
        private List<string> idReservaHabitaciones = new List<string>();
        private List<string> nroHabitacionValidas = new List<string>();

        public FacturarEstadia()
        {
            InitializeComponent();
        }

        private void buttonCargar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No se han agregado habitaciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            /*if (!string.IsNullOrEmpty(textBoxHabitaciones.Text.Trim()))
            {
                string[] nroHabitaciones = textBoxHabitaciones.Text.Split(';');
                for (int i = 0; i < nroHabitaciones.Length; i++)
                {
                    nroHabitaciones[i] = nroHabitaciones[i].Trim();
            }*/

            idEstadias.Clear();
            idReservaHabitaciones.Clear();
            nroHabitacionValidas.Clear();
            int temp = 0;

            List<string> nroHabitaciones = new List<string>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                nroHabitaciones.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
            }
            foreach (var nroHabitacion in nroHabitaciones.Distinct())
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //string nroHabitacion = dataGridView1.Rows[i].Cells[0].Value.ToString();

                var idEstadia = new SqlParameter("@idEstadia", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var idReservaHabitacion = new SqlParameter("@idReservaHabitacion", SqlDbType.Int) { Direction = ParameterDirection.Output };
                int result = 0;

                try
                {
                    result = DBHandler.SPWithValue("MATOTA.GetEstadiaForHabitacion",
                        new List<SqlParameter> {
                    new SqlParameter("@nroHabitacion", nroHabitacion) { Direction = ParameterDirection.Input },
                    new SqlParameter("@idHotel", Login.Login.LoggedUserSessionHotelID) { Direction = ParameterDirection.Input },
                    new SqlParameter("@fechaSistema", ConfigManager.FechaSistema.ToString("yyyy-MM-dd") ) { Direction = ParameterDirection.Input },
                    idEstadia,
                    idReservaHabitacion
                }
                    );

                    if (result == -1)
                    {
                        MessageBox.Show("La estadia (id: " + idEstadia.Value.ToString() + ") con fecha de ingreso mas reciente a la fecha del sistema sin fecha de salida definida para las habitaciones seleccionadas ya tiene una factura generada.\n\nEs decir, no hay estadia activa sin cerrar para las habitaciones seleccionadas.\n\nIntente modificar la fecha del sistema a una fecha mas tardia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                catch (Exception)
                {

                    MessageBox.Show("Imposible cerrar la habitación " + nroHabitacion + ". Ocurrió un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                if (string.IsNullOrEmpty(idEstadia.ToString()) || string.IsNullOrEmpty(idReservaHabitacion.ToString()))
                {
                    MessageBox.Show("Imposible cerrar la habitación " + nroHabitacion + ". La habitación no existe en el hotel o está mal escrito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
                else
                {
                    idEstadias.Add(idEstadia.Value.ToString());
                    idReservaHabitaciones.Add(idReservaHabitacion.Value.ToString());
                    nroHabitacionValidas.Add(nroHabitacion);
                    temp++;
                }
            }

            if (verificarEstadia(idEstadias) != 0)
            {
                MessageBox.Show("Las habitaciones ingresadas no son de una única estadía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("reg.nombre")
                .Table("MATOTA.Regimen reg")
                .AddJoin("JOIN MATOTA.Reserva r ON (reg.idRegimen = r.idRegimen)")
                .AddJoin("JOIN MATOTA.Estadia e ON (r.idReserva = e.idReserva)")
                .AddEquals("e.idEstadia", idEstadias[0]);

                try
                {
                    bool estadia = false;
                    var nombreRegimen = DBHandler.Query(query.Build()).First()["nombre"].ToString();
                    if (nombreRegimen == "All inclusive")
                    {
                        estadia = true;
                    }
                    else
                    {
                        estadia = false;
                    }
                    for (int i = 0; i < idEstadias.Count; i++)
                    {
                        new RegistrarConsumible.Registrar(idReservaHabitaciones[i], nroHabitacionValidas[i], estadia).ShowDialog(this);
                    }
                    new GenerarFactura(idEstadias[0], idReservaHabitaciones).ShowDialog(this);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al intentar obtener el régimen de la estadía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void FacturarEstadia_Load(object sender, EventArgs e)
        {
            if (Login.Login.LoggedUserSessionHotelID == -1)
            {
                var result = new AbmHotel.Listado().ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Abort)
                {// FALLO LA OBTENCION!
                    MessageBox.Show("Fallo en la obtención de un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel) // USUARIO CERRO LA VENTANA!
                {
                    MessageBox.Show("Se ha cerrado la ventana sin seleccionar un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }
            }
            try
            {
                var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
                textBoxNombreHotel.Text = DBHandler.Query(nombreHotel.Build()).First()["nombre"].ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al agregar el nombre del hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int verificarEstadia(List<string> estadias)
        {
            var idEstadia = estadias[0];
            foreach (var estadia in estadias)
            {
                if (!idEstadia.Equals(estadia))
                {
                    return -1;
                }
            }
            return 0;
        }

        private void elegir_Click(object sender, EventArgs e)
        {
            var selector = new listarHabitacionesFactura();

            if (selector.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string hab = selector.getHabitacionSeleccionada();

                this.dataGridView1.Rows.Add(hab, "Remover");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
    }
}
