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
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Poblar();
        }

        private void Poblar()
        {
            var filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("h.idHotel, h.nombre, h.cantidadEstrellas,h.telefono,h.mail,h.ciudad,h.pais")
                .Table("MATOTA.Hotel h")
                .AddJoin("INNER JOIN MATOTA.HotelesUsuario hu ON h.idHotel = hu.idHotel")
                .AddEquals("hu.idUsuario", Login.Login.LoggedUsedID.ToString());

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

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No se encontró ningún hotel donde esté vinculado. Intente cambiar el criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                newset.ForEach(row =>
                        dataGridView1.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception e)
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
