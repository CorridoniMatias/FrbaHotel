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
    public partial class Listado : Form
    {
        private PobladorHoteles poblador;
        private bool automaticallySelectForSessionHotel;
        public Hotel SelectedHotel { get; private set; }

        public Listado(bool automaticallySelectForSessionHotel = true)
        {
            InitializeComponent();
            this.automaticallySelectForSessionHotel = automaticallySelectForSessionHotel;
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            poblador = new PobladorHoteles(new List<TextBox>() { textBoxCantEstrellas, textBoxCiudad, textBoxNombre, textBoxPais, textBoxMail, textBoxTelefono }, dataGridView1, new List<string> { "Seleccionar" });
            if (automaticallySelectForSessionHotel)
            {
                poblador.Filtro
                 .AddJoin("INNER JOIN MATOTA.HotelesUsuario hu ON h.idHotel = hu.idHotel")
                 .AddEquals("hu.idUsuario", Login.Login.LoggedUsedID.ToString());
                this.Text += " donde se encuentra trabajando";
                poblador.Poblar(false);
            }
            else
                poblador.Poblar();

            WarnNoHotels();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (automaticallySelectForSessionHotel)
                {
                    try
                    {
                        Login.Login.LoggedUserSessionHotelID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    }
                    catch (Exception)
                    {
                        this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                        MessageBox.Show("Error al seleccionar hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                    this.SelectedHotel = new Hotel
                    {
                        idHotel = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        nombre = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()
                    };

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            poblador.Poblar();
            WarnNoHotels();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this.groupBox1);
        }

        private void WarnNoHotels()
        {
            if (!automaticallySelectForSessionHotel)
                return;

            this.labelNoHotels.Visible = dataGridView1.Rows.Count == 0;
        }
    }
}
