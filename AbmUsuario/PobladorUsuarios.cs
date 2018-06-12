using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmUsuario
{
    public partial class PobladorUsuarios : Form
    {
        private List<TextBox> inputsTextBox;
        private List<ComboBox> inputsComboBox;
        private CheckBox habilitado;
        private DataGridView grid;
        public QueryBuilder Filtro { get; private set; }
        private List<string> extraColumns;

        public PobladorUsuarios(List<TextBox> inputsTextBox, List<ComboBox> inputsComboBox, CheckBox habilitado, DataGridView grid, List<string> extraColumns)
        {
            this.inputsTextBox = inputsTextBox;
            this.inputsComboBox = inputsComboBox;
            this.habilitado = habilitado;
            this.grid = grid;
            this.extraColumns = extraColumns;

            Filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
             .Fields("u.idUsuario, u.username, r.NOMBRE nombreRol, u.nombre nombre, u.apellido, td.nombre nombreTipoDocumento, u.numeroDocumento, u.mail, u.telefono, u.calle, u.nroCalle, u.localidad, u.pais, u.fechaNacimiento, u.habilitado")
             .Table("MATOTA.Usuario u").AddJoin("LEFT JOIN MATOTA.RolesUsuario ru ON u.idUsuario = ru.idUsuario").AddJoin("LEFT JOIN MATOTA.Rol r ON ru.idRol = r.idRol").AddJoin("INNER JOIN MATOTA.TipoDocumento td ON u.idTipoDocumento = td.idTipoDocumento");

        }

        public void Poblar()
        {
            Filtro.ClearFilters();

            inputsTextBox
                .FindAll(c => !string.IsNullOrEmpty(c.Text.Trim()) && !c.Tag.Equals("numeroDocumento"))
                .ForEach(c =>
                    Filtro.AddLike(c.Tag.ToString(), c.Text)
                );
            inputsTextBox
                .FindAll(c => !string.IsNullOrEmpty(c.Text.Trim()) && c.Tag.Equals("numeroDocumento"))
                .ForEach(c => Filtro.AddEquals("u." + c.Tag.ToString(), c.Text)
                );

            inputsComboBox
                .FindAll(c => c.SelectedIndex > 0 && !c.Tag.Equals("rol"))
                .ForEach(c => Filtro.AddEquals("u." + c.Tag.ToString(), c.SelectedValue.ToString()));
            inputsComboBox
                .FindAll(c => c.SelectedIndex > 0 && c.Tag.Equals("rol"))
                .ForEach(c => Filtro.AddEquals("ru." + c.Tag.ToString(), c.SelectedValue.ToString()));

            if (habilitado.CheckState != CheckState.Indeterminate)
                Filtro.AddEquals("habilitado", Convert.ToInt32(habilitado.Checked).ToString());
            try
            {
                var newset = DBHandler.Query(Filtro.Build()).Select(row =>
                    {
                        var orig = new List<string>() { row["idUsuario"].ToString(), 
                                                        row["username"].ToString(), 
                                                        row["nombreRol"].ToString(), 
                                                        row["nombre"].ToString(),
                                                        row["apellido"].ToString(), 
                                                        row["nombreTipoDocumento"].ToString(), 
                                                        row["numeroDocumento"].ToString(),
                                                        row["mail"].ToString(),
                                                        row["telefono"].ToString(), 
                                                        row["calle"].ToString(),
                                                        row["nroCalle"].ToString(),
                                                        row["localidad"].ToString(), 
                                                        row["pais"].ToString(), 
                                                        row["fechaNacimiento"].ToString(),
                                                        row["habilitado"].ToString()};
                        orig.AddRange(extraColumns);
                        return orig;
                    }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No se encontró ningún usuario. Intente cambiar el criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        
    }
}
