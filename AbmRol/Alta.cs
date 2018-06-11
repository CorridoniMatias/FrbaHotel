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
        bool hayError;
        string idRol;

        public Alta(string idRol = "null", string nombre = null, string estado = "false", bool modificando = false)
        {
            this.modificando = modificando;
            this.idRol = idRol;
            hayError = false;
            InitializeComponent();

            var funcionalidades = DBHandler.Query("SELECT p.idPermiso, nombre, pr.idRol FROM MATOTA.Permiso p LEFT JOIN MATOTA.PermisosRol pr ON p.idPermiso = pr.idPermiso AND pr.IdRol =" + idRol)
               .Select(fun => new Funcionalidad(fun["idPermiso"].ToString(), fun["nombre"].ToString(), (string.IsNullOrEmpty(fun["idRol"].ToString())) ? false : true));

            ((ListBox)checkedListBoxFuncionalidades).DataSource = new BindingSource(funcionalidades, null);
            ((ListBox)checkedListBoxFuncionalidades).DisplayMember = "nombre";
            ((ListBox)checkedListBoxFuncionalidades).ValueMember = "idFuncionalidad";

            for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
            {
                if (((Funcionalidad)checkedListBoxFuncionalidades.Items[i]).seleccionado)
                    checkedListBoxFuncionalidades.SetItemChecked(i, true);
            }

            textBoxNombre.Text = nombre;
            checkBoxEstado.Checked = Convert.ToBoolean(estado);

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

            TextBox field = textBoxNombre;

            List<int> funcionalidades = new List<int>();
            foreach (var item in checkedListBoxFuncionalidades.CheckedItems)
                funcionalidades.Add(Int32.Parse(((Funcionalidad)item).idFuncionalidad));

            if (string.IsNullOrEmpty(field.Text.Trim()) || funcionalidades.Count == 0)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hayError = true;
            }

            string queryValidar = "SELECT COUNT(*) FROM MATOTA.Rol WHERE NOMBRE = '" + textBoxNombre.Text + "'";

            if (idRol != "null")
            {
                queryValidar += "AND idRol <>" + idRol;
            }

            int cant = DBHandler.QueryScalar(queryValidar);

            if (cant > 0)
            {
                MessageBox.Show("Ya existe un rol con ese nombre.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                hayError = true;
            }

            if (hayError)
            {
                hayError = false;
                return;
            }

            if (!modificando)
            {
                string query = "INSERT INTO MATOTA.Rol (NOMBRE,estado)" +
                                "VALUES (";

                query += "'" + field.Text + "'";

                query += "," + Convert.ToInt32(checkBoxEstado.Checked) + ")";

                query += ";SELECT scope_identity()";



                int idRolInsertado = DBHandler.QueryScalar(query);

                if (idRolInsertado < 1)
                {
                    MessageBox.Show("Error al agregar Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                query = "INSERT INTO MATOTA.PermisosRol VALUES ";
                query += String.Join(",", funcionalidades.Select(fun => "(" + idRolInsertado + ", " + fun + ")").ToArray());

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
                ActualizarFuncionalidades();

                string query = "UPDATE MATOTA.ROL SET nombre = '";

                query += textBoxNombre.Text.ToString() + "',";

                query += "estado = " + Convert.ToInt32(checkBoxEstado.Checked);

                query += "WHERE idRol = " + idRol;


                int filasModificadas = DBHandler.QueryRowCount(query);

                if (filasModificadas != 1)
                {
                    MessageBox.Show("Error al guardar Rol", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                else
                {
                    MessageBox.Show("Rol modificado con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

            }


        }
        private void ActualizarFuncionalidades()
        {
            var altas = new List<Funcionalidad>();
            var bajas = new List<Funcionalidad>();
            var elegidas = checkedListBoxFuncionalidades.CheckedIndices;

            for (int i = 0; i < checkedListBoxFuncionalidades.Items.Count; i++)
            {
                if (((Funcionalidad)checkedListBoxFuncionalidades.Items[i]).seleccionado && !elegidas.Contains(i))
                    bajas.Add((Funcionalidad)checkedListBoxFuncionalidades.Items[i]);
                else if (!((Funcionalidad)checkedListBoxFuncionalidades.Items[i]).seleccionado && elegidas.Contains(i))
                    altas.Add(((Funcionalidad)checkedListBoxFuncionalidades.Items[i]));
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
                var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.DELETE).Table("MATOTA.PermisosRol");
                int borradas = 0;

                foreach (var func in bajas)
                {
                    builder.AddAndFilter("idRol=" + idRol, "idPermiso=" + func.idFuncionalidad);
                    borradas++;
                }

                var count = DBHandler.QueryRowCount(builder.Build());

                if (count != borradas)
                    MessageBox.Show("Error al desvincular alguna de las funcionalidades deseleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public class Funcionalidad
        {
            public string idFuncionalidad { get; set; }
            public string nombre { get; set; }
            public bool seleccionado { get; set; }

            public Funcionalidad(string id, string nombre, bool sel)
            {
                this.idFuncionalidad = id;
                this.nombre = nombre;
                this.seleccionado = sel;
            }
        }
    }
}
