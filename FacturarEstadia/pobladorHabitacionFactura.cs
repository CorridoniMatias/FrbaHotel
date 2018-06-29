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
    public partial class pobladorHabitacionFactura : Form
    {

        private List<TextBox> textBoxInputs;
        private List<ComboBox> comboBoxInputs;
        private DataGridView grid;
        public QueryBuilder Filtro { get; private set; }
        private List<string> extraColumns;

        public pobladorHabitacionFactura(List<TextBox> textBoxInputs, List<ComboBox> comboBoxInputs, DataGridView grid, List<string> extraColumns)
        {
            this.textBoxInputs = textBoxInputs;
            this.comboBoxInputs = comboBoxInputs;
            this.grid = grid;
            this.Filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("hab.nroHabitacion, hab.piso, hab.idUbicacion, uh.descripcion descripcionUbicacion, hab.idTipoHabitacion, th.descripcion descripcionTipoHabitacion")
                .Table("MATOTA.Habitacion hab").AddJoin("JOIN MATOTA.Hotel h ON (hab.idHotel = h.idHotel)")
                .AddJoin("JOIN MATOTA.UbicacionHabitacion uh ON (hab.idUbicacion = uh.idUbicacion)")
                .AddJoin("JOIN MATOTA.TipoHabitacion th ON (hab.idTipoHabitacion = th.idTipoHabitacion)")
                ;
            this.extraColumns = extraColumns;
        }

        public void Poblar()
        {
            Filtro.ClearFilters();

            Filtro.AddEquals("hab.idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
            Filtro.AddEquals("hab.habilitado", "1");

            textBoxInputs
                .FindAll(hab => !string.IsNullOrEmpty(hab.Text.Trim()))
                .ForEach(hab =>
                    Filtro.AddEquals("hab." + hab.Tag.ToString(), hab.Text)
                );

            comboBoxInputs
                .FindAll(hab => hab.SelectedIndex != -1)
                .ForEach(hab => Filtro.AddLike("hab." + hab.Tag.ToString(), hab.SelectedValue.ToString())
                );

            try
            {
                var newset = DBHandler.Query(Filtro.Build()).Select(row =>
                {
                    var orig = new List<string>() { 
                                                        row["nroHabitacion"].ToString(),
                                                        row["piso"].ToString(), 
                                                        row["idUbicacion"].ToString(),
                                                        row["descripcionUbicacion"].ToString(),
                                                        row["idTipoHabitacion"].ToString(),
                                                        row["descripcionTipoHabitacion"].ToString()
                    };
                    orig.AddRange(extraColumns);
                    return orig;
                }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No se ninguna habitación. Intente cambiar el criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar habitaciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
