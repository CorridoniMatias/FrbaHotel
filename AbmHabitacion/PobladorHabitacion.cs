using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class PobladorHabitacion : Form
    {
        private List<TextBox> textBoxInputs;
        private List<ComboBox> comboBoxInputs;
        private DataGridView grid;
        public QueryBuilder Filtro { get; private set; }
        private List<string> extraColumns;

        public PobladorHabitacion(List<TextBox> textBoxInputs, List<ComboBox> comboBoxInputs, DataGridView grid, List<string> extraColumns)
        {
            this.textBoxInputs = textBoxInputs;
            this.comboBoxInputs = comboBoxInputs;
            this.grid = grid;
            this.Filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("hab.idHotel, h.nombre, hab.nroHabitacion, hab.piso, hab.idUbicacion, hab.idTipoHabitacion, hab.descripcion, hab.comodidades, hab.habilitado")
                .Table("MATOTA.Habitacion hab").AddJoin("JOIN MATOTA.Hotel h ON (hab.idHotel = h.idHotel)");
            this.extraColumns = extraColumns;
        }

        public void Poblar()
        {
            Filtro.ClearFilters();
            textBoxInputs
                .FindAll(hab => !string.IsNullOrEmpty(hab.Text.Trim()) && (!hab.Tag.Equals("descripcion") && !hab.Tag.Equals("comodidades")))
                .ForEach(hab =>
                    Filtro.AddEquals("hab." + hab.Tag.ToString(), hab.Text)
                );

            textBoxInputs
                .FindAll(hab => !string.IsNullOrEmpty(hab.Text) && (hab.Tag.Equals("descripcion") || hab.Tag.Equals("comodidades")))
                .ForEach(hab => Filtro.AddLike("hab." + hab.Tag.ToString(), hab.Text)
                );

            comboBoxInputs
                .FindAll(hab => hab.SelectedIndex != -1)
                .ForEach(hab => Filtro.AddLike("hab." + hab.Tag.ToString(), hab.SelectedValue.ToString())
                );

            try
            {
                var newset = DBHandler.Query(Filtro.Build()).Select(row =>
                {
                    var orig = new List<string>() { row["idHotel"].ToString(), 
                                                        row["nombre"].ToString(), 
                                                        row["nroHabitacion"].ToString(), 
                                                        row["piso"].ToString(), 
                                                        row["idUbicacion"].ToString(),
                                                        row["idTipoHabitacion"].ToString(),
                                                        row["descripcion"].ToString(),
                                                        row["comodidades"].ToString(),
                                                        row["habilitado"].ToString()};
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
