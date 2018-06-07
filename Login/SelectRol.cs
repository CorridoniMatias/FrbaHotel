using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class SelectRol : Form
    {
        private Dictionary<int, string> roles = new Dictionary<int, string>();

        public int SelectedRole { get; private set; }

        public SelectRol(List<Dictionary<string, object>> roles)
        {
            InitializeComponent();

            this.DialogResult = DialogResult.None;

            this.roles = roles.Select(rol => new KeyValuePair<int, string>(Int32.Parse(rol["idRol"].ToString()), rol["nombre"].ToString()) )
                         .ToDictionary(pair => pair.Key, pair => pair.Value);

            comboBoxRol.DataSource = new BindingSource(this.roles, null);
            comboBoxRol.DisplayMember = "Value";
            comboBoxRol.ValueMember = "Key";
            comboBoxRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            SelectedRole = ((KeyValuePair<int, string>)comboBoxRol.SelectedItem).Key;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
