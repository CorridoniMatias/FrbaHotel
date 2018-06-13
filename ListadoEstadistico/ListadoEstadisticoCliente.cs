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
    public partial class ListadoEstadisticoCliente : Form
    {
        int nroTrimestre;
        int year;

        public ListadoEstadisticoCliente(int nroTrimestre, int year)
        {
            this.nroTrimestre = nroTrimestre;
            this.year = year;
            InitializeComponent();
        }

        private void ListadoEstadisticoCliente_Load(object sender, EventArgs e)
        {
            List<List<string>> resultados;
            List<SqlParameter> parametros = new List<SqlParameter> { new SqlParameter("@nroTrimestre", nroTrimestre), new SqlParameter("@year", year) };

            //try
            //{
                resultados = DBHandler.SPWithResultSet("MATOTA.ClientesConMasPuntos", parametros)
                    .Select(row =>
                        new List<object>()    
                        { 
                            row["nombre"],
                            row["apellido"],
                            row["Tipo Documento"],
                            row["numeroDocumento"],
                            row["Puntos"]
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

                resultados.ForEach(row => dataGridViewClientes.Rows.Add(row.ToArray()));
            //}
            //catch (Exception)
            //{
            //    this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            //    MessageBox.Show("Error al hacer el listado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.Close();
            //}
        }
    }
}
