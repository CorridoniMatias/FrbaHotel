using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public class PobladorHoteles : Form
    {
        private List<TextBox> inputs;
        private DataGridView grid;
        public QueryBuilder Filtro { get; private set;}
        private List<string> extraColumns;

        public PobladorHoteles(List<TextBox> inputs, DataGridView grid, List<string> extraColumns)
        {
            this.inputs = inputs;
            this.grid = grid;
            Filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("h.idHotel, h.nombre, h.cantidadEstrellas,h.telefono,h.mail,h.ciudad,h.pais")
                .Table("MATOTA.Hotel h");

            this.extraColumns = extraColumns;
        }

        public void Poblar()
        {
            inputs
                .FindAll(c => !string.IsNullOrEmpty(c.Text.Trim()))
                .ForEach(c =>
                    Filtro.AddEquals(c.Tag.ToString(), c.Text)
                );

            try
            {
                var newset = DBHandler.Query(Filtro.Build()).Select(row =>
                    {
                        var orig = new List<string>() { row["idHotel"].ToString(), row["nombre"].ToString(), row["cantidadEstrellas"].ToString(), row["telefono"].ToString(), row["mail"].ToString(), row["ciudad"].ToString(), row["pais"].ToString() };
                        orig.AddRange(extraColumns);
                        return orig;
                    }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No se encontró ningún hotel. Intente cambiar el criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar hoteles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
