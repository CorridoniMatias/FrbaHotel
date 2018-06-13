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

namespace FrbaHotel.ListadoEstadistico
{
    public partial class ListadoEstadisticoHotel : Form
    {

        int nroTrimestre;
        int year;
        int tipoListado;

        public ListadoEstadisticoHotel(int nroTrimestre, int year, int tipoListado)
        {
            this.nroTrimestre = nroTrimestre;
            this.year = year;
            this.tipoListado = tipoListado;
            InitializeComponent();
        }

        private void ListadoHotel_Load(object sender, EventArgs e)
        {
            List<List<string>> resultados;
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@nroTrimestre", nroTrimestre), new SqlParameter("@year", year) };
            string storedprocedure = "";

            try
            {
                switch (tipoListado)
                {
                    case 0:
                        DBHandler.SPWithValue("MATOTA.ActualizarReservasVencidas", new List<SqlParameter> { new SqlParameter("@fechaSistema", ConfigManager.FechaSistema) });
                        dataGridViewHoteles.Columns[5].Tag = "Reservas Canceladas";
                        dataGridViewHoteles.Columns[5].HeaderText = "Reservas canceladas";
                        storedprocedure = "MATOTA.HotelesReservasCanceladas";
                        break;

                    case 1:
                        dataGridViewHoteles.Columns[5].Tag = "Consumibles Facturados";
                        dataGridViewHoteles.Columns[5].HeaderText = "Consumibles facturados";
                        storedprocedure = "MATOTA.HotelesMayorCantConsumibles";
                        break;
                    case 2:
                        dataGridViewHoteles.Columns[5].Tag = "Dias Inactivo";
                        dataGridViewHoteles.Columns[5].HeaderText = "Días fuera de servicio";
                        storedprocedure = "MATOTA.HotelesMayorDiasInactivo";
                        break;

                }

                resultados = DBHandler.SPWithResultSet(storedprocedure, parametros)
                    .Select(row =>
                        new List<object>()
                        {
                            row["nombre"],
                            row["calle"],
                            row["nroCalle"],
                            row["ciudad"],
                            row["pais"],
                            row[dataGridViewHoteles.Columns[5].Tag.ToString()] 
                        }
                        .Select(c => c.ToString().Trim())
                        .ToList()
                        )
                    .ToList();

                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay información sobre ese período.");
                    this.Close();
                }

                resultados.ForEach(row => dataGridViewHoteles.Rows.Add(row.ToArray()));
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al hacer el listado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
