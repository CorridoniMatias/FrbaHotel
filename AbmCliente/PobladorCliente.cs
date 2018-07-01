using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class PobladorCliente : Form
    {

        private List<TextBox> inputs;
        private ComboBox tipoDoc;
        private DataGridView grid;
        public QueryBuilder Filtro { get; private set;}
        private List<string> extraColumns;

        public PobladorCliente(List<TextBox> inputs, ComboBox tipoDoc, DataGridView grid, List<string> extraColumns)
        {
            this.inputs = inputs;
            this.grid = grid;
            Filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                        .Fields("c.idCliente,c.nombre,c.apellido,td.nombre tipoDocumento,c.numeroDocumento,c.mail,c.habilitado").Table("MATOTA.Cliente c")
                        .AddJoin("JOIN MATOTA.TipoDocumento td ON (c.IdTipoDocumento = td.IdTipoDocumento)");

            this.extraColumns = extraColumns;
            this.tipoDoc = tipoDoc;
        }

        public void Poblar(bool soloHabilitados = false)
        {
            Filtro.ClearFilters();
            inputs
                .FindAll(c => !string.IsNullOrEmpty(c.Text.Trim()) && !c.Tag.Equals("numeroDocumento"))
                .ForEach(c =>
                    Filtro.AddLike("c." + c.Tag.ToString(), c.Text)
                );

            inputs
                .FindAll(c => !string.IsNullOrEmpty(c.Text.Trim()) && c.Tag.Equals("numeroDocumento"))
                .ForEach(c =>
                       {
                           Filtro.AddEquals("c." + c.Tag.ToString(), c.Text);
                           Filtro.AddEquals("c." + tipoDoc.Tag.ToString(), tipoDoc.SelectedValue.ToString());
                       }
                );

            if(soloHabilitados)
                Filtro.AddEquals("c.habilitado", "1");

            
            try
            {
                var newset = DBHandler.Query(Filtro.Build()).Select(row =>
                    {
                        var orig = new List<string>() { row["idCliente"].ToString(), 
                                                        row["nombre"].ToString(), 
                                                        row["apellido"].ToString(), 
                                                        row["tipoDocumento"].ToString(), 
                                                        row["numeroDocumento"].ToString(),
                                                        row["mail"].ToString(),
                                                        row["habilitado"].ToString(),
                                                         };
                        orig.AddRange(extraColumns);
                        return orig;
                    }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No se encontró ningún Cliente. Intente cambiar el criterio de búsqueda o agregué al nuevo cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar clientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
