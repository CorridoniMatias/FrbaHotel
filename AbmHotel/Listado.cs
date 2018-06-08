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
        public Listado()
        {
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            this.Poblar();
        }

        private void Poblar()
        {
            var filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                Fields("idHotel, nombre, cantidadEstrellas,telefono,mail,ciudad,pais").Table("MATOTA.Hotel");

            new List<TextBox>() { textBoxCantEstrellas, textBoxCiudad, textBoxNombre, textBoxPais, textBoxMail, textBoxTelefono }
                .FindAll(c => !string.IsNullOrEmpty(c.Text.Trim()))
                .ForEach(c =>
                    filtro.AddEquals(c.Tag.ToString(), c.Text)
                );

            try
            {
                var newset = DBHandler.Query(filtro.Build()).Select(row =>
                    new List<string>() { row["idHotel"].ToString(), row["nombre"].ToString(), row["cantidadEstrellas"].ToString(), row["telefono"].ToString(), row["mail"].ToString(), row["ciudad"].ToString(), row["pais"].ToString(), "Seleccionar" }
                ).ToList();


                newset.ForEach(row =>
                        dataGridView1.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar hoteles.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
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

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            Poblar();
        }
    }
}
