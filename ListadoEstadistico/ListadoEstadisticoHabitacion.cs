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
    public partial class ListadoEstadisticoHabitacion : Form
    {
        int nroTrimestre;
        int year;

        public ListadoEstadisticoHabitacion(int nroTrimestre, int year)
        {
            this.nroTrimestre = nroTrimestre;
            this.year = year;
            InitializeComponent();
        }

        private void ListadoEstadisticoHabitacion_Load(object sender, EventArgs e)
        {
            List<List<string>> resultados;
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@nroTrimestre", nroTrimestre), new SqlParameter("@year", year) };
            
            try
            {
                resultados = DBHandler.SPWithResultSet("MATOTA.HabitacionesMasOcupadas", parametros).Select(row =>

                    new List<String>() 
                    { 
                        String.IsNullOrEmpty(row["nombre"].ToString().Trim())?

                                     String.Join(", ", new List<object>()
                                     {
                                         row["calle"],
                                         row["nroCalle"],
                                         row["ciudad"],
                                         row["pais"]
                                     }
                                    .Select(c=>c.ToString().Trim())
                                    .ToList<String>()
                                    .FindAll(c => !String.IsNullOrEmpty(c))
                                    .ToArray())

                       :row["nombre"].ToString(),

                        row["nroHabitacion"].ToString(),
                        row["Dias Ocupada"].ToString(),
                        row["Veces Ocupada"].ToString()
                    }
                ).ToList().Select(r => r.Select(c => c.Trim()).ToList()).ToList();



                if (resultados.Count == 0)
                {
                    MessageBox.Show("No hay información sobre ese período.");
                    this.Close();
                }

                resultados.ForEach(row => dataGridViewHabitaciones.Rows.Add(row.ToArray()));
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
