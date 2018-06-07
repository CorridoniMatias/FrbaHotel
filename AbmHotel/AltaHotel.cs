using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class AltaHotel : Form
    {
        public AltaHotel()
        {
            InitializeComponent();
        }

        private void AltaHotel_Load(object sender, EventArgs e)
        {
            var regimenes = DBHandler.Query("SELECT idRegimen, nombre FROM MATOTA.Regimen")
                            .Select(reg => new KeyValuePair<int, string>(Int32.Parse(reg["idRegimen"].ToString()), reg["nombre"].ToString()) )
                            .ToDictionary(pair => pair.Key, pair => pair.Value);

            ((ListBox)checkedListBoxRegimenes).DataSource = new BindingSource(regimenes, null);
            ((ListBox)checkedListBoxRegimenes).DisplayMember = "Value";
            ((ListBox)checkedListBoxRegimenes).ValueMember = "Key";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<TextBox> fields = new List<TextBox>()
                {
                    textBoxCalle,
                    textBoxCantEstrellas,
                    textBoxCiudad,
                    textBoxMail,
                    textBoxNombre,
                    textBoxTel,
                    textBoxNroCalle,
                    textBoxPais
                };

            List<int> rgs = new List<int>();
            foreach(var item in checkedListBoxRegimenes.CheckedItems)
                rgs.Add( ((KeyValuePair<int, string>)item).Key );

            if (fields.Any(f => string.IsNullOrEmpty(f.Text.Trim())) || rgs.Count == 0)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


        }
    }
}
