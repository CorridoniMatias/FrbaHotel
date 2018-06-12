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
                    textBoxNombre,
                    textBoxMail,
                    textBoxTel,
                    textBoxCalle,
                    textBoxNroCalle,
                    textBoxCiudad,
                    textBoxPais,
                    textBoxCantEstrellas
                };

            List<int> rgs = new List<int>();
            foreach(var item in checkedListBoxRegimenes.CheckedItems)
                rgs.Add( ((KeyValuePair<int, string>)item).Key );

            if (fields.Any(f => string.IsNullOrEmpty(f.Text.Trim())) || rgs.Count == 0)
            {
                MessageBox.Show("Debe llenar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Int32.Parse(textBoxCantEstrellas.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Cantidad de estrellas debe ser un numero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO MATOTA.Hotel (nombre,mail,telefono,calle,nroCalle,ciudad,pais,cantidadEstrellas,fechaCreacion)" +
                            "VALUES (";

            query += String.Join(",", fields.Select(f => "'"+f.Text+"'").ToArray());
            query += ",'" + dateTimePickerFechaCreacion.Value.ToString("yyyy-MM-dd");

            query += "');SELECT scope_identity()";


            int idhotel = DBHandler.QueryScalar(query);
            if (idhotel < 1)
            {
                MessageBox.Show("Error al agregar hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            query = "INSERT INTO MATOTA.RegimenHotel VALUES ";
            query += String.Join(",", rgs.Select(r => "(" + idhotel + ", " + r + ")").ToArray());
            int count = DBHandler.QueryRowCount(query);

            if (count != rgs.Count)
            {
                MessageBox.Show("Error al agregar hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Hotel agregado con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this.groupBox1);
            FormHandler.limpiar(this.groupBox2);
        }
    }
}
