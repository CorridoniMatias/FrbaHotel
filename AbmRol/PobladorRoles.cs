using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class PobladorRoles : Form
    {
        private TextBox input;
        private CheckBox estado;
        private DataGridView grid;
        public QueryBuilder Filtro { get; private set; }
        private List<string> extraColumns;

        public PobladorRoles(TextBox input, CheckBox estado, DataGridView grid, List<string> extraColumns)
        {
            InitializeComponent();
            this.input = input;
            this.estado = estado;
            this.grid = grid;
            Filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("idRol, NOMBRE, estado")
                .Table("MATOTA.Rol");

            this.extraColumns = extraColumns;
        }

        public void Poblar()
        {
            if (!string.IsNullOrEmpty(input.Text.Trim()))
            {
                Filtro.AddLike("NOMBRE", input.Text.Trim());
                
            }

            Filtro.AddEquals("estado", Convert.ToInt32(estado.Checked).ToString());

            try
            {
                var newset = DBHandler.Query(Filtro.Build()).Select(row =>
                    {
                        var orig = new List<string>() { row["idRol"].ToString(), 
                                                        row["NOMBRE"].ToString(), 
                                                        row["estado"].ToString()};
                        orig.AddRange(extraColumns);
                        return orig;
                    }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No se encontró ningún rol. Intente cambiar el criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar roles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
       
    }
}
