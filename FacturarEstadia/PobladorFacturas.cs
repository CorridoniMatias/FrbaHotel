using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        
        public PobladorFacturas(DataGridView grid, string idEstadia, List<string> idReservas)
        {
            this.grid = grid;
            condiciones = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("c.codigoConsumible, c.descripcion, ce.cantidad, ce.precioAlMomento")
                .Table("MATOTA.ConsumiblesEstadia ce").AddJoin("JOIN MATOTA.Consumible c ON (ce.codigoConsumible = c.codigoConsumible)");
            this.idEstadia = idEstadia;
            this.idReservaHabitaciones = idReservas;
        }

        public void Poblar()
        {
            query = generarCondiciones();
            
            try
            {
                var newset = DBHandler.Query(query).Select(row =>
                    {
                        var orig = new List<string>() { row["codigoConsumible"].ToString(), 
                                                        row["descripcion"].ToString(), 
                                                        row["cantidad"].ToString(), 
                                                        row["precioAlMomento"].ToString()
                                                        };
                        return orig;
                    }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No hay ningún consumible para la estadía " + idEstadia + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
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
    }
}
