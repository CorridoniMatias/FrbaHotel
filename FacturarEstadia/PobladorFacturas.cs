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
    public partial class PobladorFacturas : Form
    {
        private DataGridView grid;
        public QueryBuilder condiciones { get; private set;}
        private string query;
        private string idEstadia;
        private List<string> idReservaHabitaciones;
        private double precioE {get;  set;}
        private List<int> idConsumibleEstadias { get; set; }
        private double precioBase;
        private string nombreRegimen;
        
        public PobladorFacturas(DataGridView grid, string idEstadia, List<string> idReservas)
        {
            this.grid = grid;
            condiciones = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("c.codigoConsumible, c.descripcion, ce.cantidad, ce.precioAlMomento, ce.idConsumibleEstadia")
                .Table("MATOTA.ConsumiblesEstadia ce").AddJoin("JOIN MATOTA.Consumible c ON (ce.codigoConsumible = c.codigoConsumible)");
            this.idEstadia = idEstadia;
            this.idReservaHabitaciones = idReservas;
            precioE = 0;
            idConsumibleEstadias = new List<int>();
            precioBase = 0;
            nombreRegimen = null;
        }

        public void Poblar()
        {
            query = generarCondiciones();
            
            try
            {
                var newset = DBHandler.Query(query).Select(row =>
                    {
                        var orig = new List<string>() { row["idConsumibleEstadia"].ToString(),
                                                        row["codigoConsumible"].ToString(), 
                                                        row["descripcion"].ToString(),  
                                                        row["precioAlMomento"].ToString(),
                                                        row["cantidad"].ToString(),
                                                        };
                        return orig;
                    }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No hay ningún consumible para la estadía " + idEstadia + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
                }
                
                llenarRegimen();
                recuentoEstadia();
            }
            catch (Exception e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar los consumibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private string generarCondiciones()
        {
            condiciones.ClearFilters();
            var temp = condiciones.Build() + " WHERE ";
            for (int i = 0; i < idReservaHabitaciones.Count; i++)
            {
                temp += "ce.idReservaHabitacion = " + idReservaHabitaciones[i];
                if (i + 1 != idReservaHabitaciones.Count)
                {
                    temp += " OR ";
                }
            }
            return temp;
        }

        private void llenarRegimen()
        {
            var stat = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("r.idRegimen, r.nombre, r.precioBase")
                .Table("MATOTA.Regimen r")
                .AddJoin("JOIN MATOTA.Reserva re ON (r.idRegimen = re.idRegimen)")
                .AddJoin("JOIN MATOTA.Estadia e ON (re.idReserva = e.idReserva)");
            string query = stat.Build() + "WHERE e.idEstadia" + " = " + this.idEstadia;

            try
            {
                var newset = DBHandler.Query(query).First();
                precioBase = Convert.ToDouble(newset["precioBase"]);

                nombreRegimen = newset["nombre"].ToString().Trim();
                //if(newset["nombre"].ToString().Trim().Equals("Allinclusive"))
                if(nombreRegimen == "All inclusive")
                {
                    double valorDescuento = 0;
                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        valorDescuento -= Convert.ToDouble(grid.Rows[i].Cells[4].Value) * Convert.ToDouble(grid.Rows[i].Cells[3].Value);
                    }

                    var temp = new List<string>()
                    {
                        "-",
                        newset["idRegimen"].ToString(),
                        "Descuento " + newset["nombre"].ToString(),
                        "-",
                        valorDescuento.ToString()
                    }.ToList();
                    grid.Rows.Add(temp.ToArray());
                }
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar el regimen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void recuentoEstadia()
        {
            var stat = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("r.cantidadNoches, r.fechaHasta")
                .Table("MATOTA.Estadia e")
                .AddJoin("JOIN MATOTA.Reserva r ON (e.idReserva = r.idReserva)")
                .AddEquals("e.idEstadia", this.idEstadia);

            int cantNoches;
            DateTime fechaHasta = ConfigManager.FechaSistema;
            try
            {
                var result = DBHandler.Query(stat.Build()).First();
                cantNoches = Convert.ToInt32(result["cantidadNoches"]);
                fechaHasta = Convert.ToDateTime(result["fechaHasta"]);

                var diferencia = DBHandler.SPWithValue("MATOTA.CantNoches",
                new List<SqlParameter> {
                    new SqlParameter("@fechaInicio", ConfigManager.FechaSistema), 
                    new SqlParameter("@fechaFin", fechaHasta)
                });

                if (diferencia < 0)
                {
                    diferencia = 0;
                }

                double precioEstadia = 0;

                if (nombreRegimen == "All inclusive")
                {
                    for (int i = 0; i < grid.Rows.Count - 1; i++)
                    {
                        precioEstadia += Convert.ToDouble(grid.Rows[i].Cells[4].Value) * Convert.ToDouble(grid.Rows[i].Cells[3].Value);
                    }
                    precioEstadia += Convert.ToDouble(grid.Rows[grid.Rows.Count - 1].Cells[4].Value);
                }
                else
                {
                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        precioEstadia += Convert.ToDouble(grid.Rows[i].Cells[4].Value) * Convert.ToDouble(grid.Rows[i].Cells[3].Value);
                    }
                }
                
                //precioEstadia = precioEstadia * (int)cantNoches;
                precioEstadia = precioEstadia + (cantNoches * Convert.ToDouble(this.precioBase));
                this.precioE = precioEstadia;

                var dif = cantNoches - diferencia;
                var rowEstadia = new List<string>()
                {
                    "-",
                    this.idEstadia,
                    "Estadía",
                    dif.ToString(),
                    precioBase.ToString()
                }.ToList();

                grid.Rows.Add(rowEstadia.ToArray());
                if (diferencia > 0)
                {
                    var faltantes = new List<string>()
                    {
                        "-",
                        "-",
                        "Estadía no utilizada",
                        diferencia.ToString(),
                        precioBase.ToString()
                    }.ToList();
                    grid.Rows.Add(faltantes.ToArray());
                }
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar los datos de la estadía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        public double getPrecioE()
        {
            return this.precioE;
        }
    }
}
