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
    public partial class Alta : Form
    {
        public Alta(DataGridViewRow row = null)
        {
            InitializeComponent();
            if (row != null)
            {
                textBoxNombre.Text = row.Cells["nombre"].Value.ToString();
                checkBoxEstado.Checked = (bool)row.Cells["estado"].Value;

            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxRol);
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            var funcionalidades = DBHandler.Query("SELECT idPermiso, nombre FROM MATOTA.Permiso")
                            .Select(fun => new KeyValuePair<int, string>(Int32.Parse(fun["idPermiso"].ToString()), fun["nombre"].ToString()))
                            .ToDictionary(pair => pair.Key, pair => pair.Value);

            ((ListBox)checkedListBoxFuncionalidades).DataSource = new BindingSource(funcionalidades, null);
            ((ListBox)checkedListBoxFuncionalidades).DisplayMember = "Value";
            ((ListBox)checkedListBoxFuncionalidades).ValueMember = "Key";
   
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            TextBox field = textBoxNombre;

            List<int> funcionalidades = new List<int>();
            foreach(var item in checkedListBoxFuncionalidades.CheckedItems)
                funcionalidades.Add( ((KeyValuePair<int, string>)item).Key );

            if (string.IsNullOrEmpty(field.Text.Trim()) || funcionalidades.Count == 0)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO MATOTA.Rol (NOMBRE,estado)" +
                            "VALUES (";

            query += "'" + field.Text + "'";

            query += ","+ Convert.ToInt32(checkBoxEstado.Checked) +")";
            
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
    }
}
