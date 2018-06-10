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

namespace FrbaHotel.AbmRol
{
    public partial class Alta : Form
    {
        bool modificando;
        string idRol;

        public Alta(string idRol = null, string nombre = null, string estado = "false", bool modificando = false)
        {
            this.modificando = modificando;
            this.idRol = idRol;

            InitializeComponent();
            if (idRol != null)
            {
                textBoxNombre.Text = nombre;
                checkBoxEstado.Checked = Convert.ToBoolean(estado);
                var funcionalidades = DBHandler.Query("SELECT idPermiso, nombre FROM MATOTA.Permiso")
                    .Select(fun => new KeyValuePair<int, string>(Int32.Parse(fun["idPermiso"].ToString()), fun["nombre"].ToString()))
                    .ToDictionary(pair => pair.Key, pair => pair.Value);
                ((ListBox)checkedListBoxFuncionalidades).DataSource = new BindingSource(funcionalidades, null);
                ((ListBox)checkedListBoxFuncionalidades).DisplayMember = "Value";
                ((ListBox)checkedListBoxFuncionalidades).ValueMember = "Key";

                var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("p.idPermiso, p.nombre").Table("MATOTA.Permiso p");
                query.AddJoin("INNER JOIN MATOTA.PermisosRol pr ON p.idPermiso = pr.idPermiso");
                query.AddEquals("pr.idRol",idRol);

                var funcionalidadesSeleccionadas = DBHandler.Query(query.Build())
                    .Select(fun => new KeyValuePair<int, string>(Int32.Parse(fun["idPermiso"].ToString()), fun["nombre"].ToString()))
                    .ToDictionary(pair => pair.Key, pair => pair.Value);

                foreach (KeyValuePair<int, string> func in funcionalidadesSeleccionadas)
                {
                    checkedListBoxFuncionalidades.SetItemChecked(checkedListBoxFuncionalidades.Items.IndexOf(func), true);
                }


            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxRol);
        }

        private void Alta_Load(object sender, EventArgs e)
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {

            ActualizarFuncionalidades();

            TextBox field = textBoxNombre;

            List<int> funcionalidades = new List<int>();
            foreach (var item in checkedListBoxFuncionalidades.CheckedItems)
                funcionalidades.Add(((KeyValuePair<int, string>)item).Key);

            if (string.IsNullOrEmpty(field.Text.Trim()) || funcionalidades.Count == 0)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!modificando)
            {
                string query = "INSERT INTO MATOTA.Rol (NOMBRE,estado)" +
                                "VALUES (";

                query += "'" + field.Text + "'";

                query += "," + Convert.ToInt32(checkBoxEstado.Checked) + ")";

                query += ";SELECT scope_identity()";



                int idRol = DBHandler.QueryScalar(query);

                if (idRol < 1)
                {
                    MessageBox.Show("Error al agregar Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                query = "INSERT INTO MATOTA.PermisosRol VALUES ";
                query += String.Join(",", funcionalidades.Select(fun => "(" + idRol + ", " + fun + ")").ToArray());
                int count = DBHandler.QueryRowCount(query);

                if (count != funcionalidades.Count)
                {
                    MessageBox.Show("Error al agregar Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Rol agregado con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }

            else
            {
                string query = "UPDATE MATOTA.ROL SET nombre = '";

                query += textBoxNombre.Text.ToString() + "' ";

                query += "estado = " + Convert.ToInt32(checkBoxEstado.Checked);

                query += "WHERE idRol = " + idRol;


                int filasModificadas = DBHandler.QueryRowCount(query);

                if (filasModificadas != 1)
                {
                    MessageBox.Show("Error al guardar Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                query = "INSERT INTO MATOTA.PermisosRol VALUES ";

                query += String.Join(",", funcionalidades.Select(fun => "(" + idRol + ", " + fun + ")").ToArray());
                int count = DBHandler.QueryRowCount(query);

                if (count != funcionalidades.Count)
                {
                    MessageBox.Show("Error al agregar Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Rol agregado con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }


        }
        private void ActualizarFuncionalidades()
        {
            var altas = new List<Funcionalidades>();
            var bajas = new List<Funcionalidades>();
            var elegidas = checkedListBoxFuncionalidades.CheckedIndices;

            for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
            {
                if (((Funcionalidades)checkedListBoxFuncionalidades.Items[i]).seleccionado && !elegidas.Contains(i))
                    bajas.Add((Funcionalidades)checkedListBoxFuncionalidades.Items[i]);
                else if (!((Funcionalidades)checkedListBoxFuncionalidades.Items[i]).seleccionado && elegidas.Contains(i))
                    altas.Add(((Funcionalidades)checkedListBoxFuncionalidades.Items[i]));
            }

            if (altas.Count > 0)
            {
                var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.INSERT).Table("MATOTA.PermisosRol")
                                                                                    .Fields("idRol, idPermiso");

                altas.ForEach(alta => builder.AddValues(idRol, alta.idFuncionalidad));


                var rows = DBHandler.QueryRowCount(builder.Build());

                if (rows != altas.Count)
                    MessageBox.Show("Error al agregar las funcionalidades seleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            if (bajas.Count > 0)
            {
                var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.DELETE).Table("MATOTA.RegimenHotel");
                int borradas = 0;

                foreach (var func in bajas)
                {

                    int ret = DBHandler.SPWithValue(new List<SqlParameter> { 
                            new SqlParameter("@idRol", idRol) { Direction = ParameterDirection.Input },
                            new SqlParameter("@idPermiso", func.idFuncionalidad) { Direction = ParameterDirection.Input },
                        }
                    );

                    builder.AddAndFilter("idRol=" + idRol, "idPermiso=" + func.idFuncionalidad);
                    borradas++;
                }

                var count = DBHandler.QueryRowCount(builder.Build());

                if (count != borradas)
                    MessageBox.Show("Error al desvincular alguno de las funcionalidades deseleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public class Funcionalidades
        {
            public string idFuncionalidad { get; set; }
            public string nombre { get; set; }
            public bool seleccionado { get; set; }

            public Funcionalidades(string id, string nombre, bool sel)
            {
                this.idFuncionalidad = id;
                this.nombre = nombre;
                this.seleccionado = sel;
            }
        }
    }
}
