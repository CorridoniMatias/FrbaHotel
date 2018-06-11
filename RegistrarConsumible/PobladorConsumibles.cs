using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class PobladorConsumibles : Form
    {

        private List<TextBox> inputs;
        private DataGridView grid;
        public QueryBuilder Filtro { get; private set; }
        private List<string> extraColumns;

        public PobladorConsumibles(List<TextBox> inputs, DataGridView grid, List<string> extraColumns)
        {
            InitializeComponent();
            this.inputs = inputs;
            this.grid = grid;
            Filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("c.codigoConsumible, c.descripcion, c.precio")
                .Table("MATOTA.Consumible c");

            this.extraColumns = extraColumns;
        }

        public void Poblar()
        {
            Filtro.ClearFilters();
            inputs
                .FindAll(c => !string.IsNullOrEmpty(c.Text.Trim()))
                .ForEach(c =>
                    Filtro.AddLike(c.Tag.ToString(), c.Text)
                );

            try
            {
                var newset = DBHandler.Query(Filtro.Build()).Select(row =>
                    {
                        var orig = new List<string>() { row["codigoConsumible"].ToString(), 
                                                        row["descripcion"].ToString(), 
                                                        row["precio"].ToString() };
                        orig.AddRange(extraColumns);
                        return orig;
                    }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No se encontraron consumibles. Intente cambiar el criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar consumibles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
