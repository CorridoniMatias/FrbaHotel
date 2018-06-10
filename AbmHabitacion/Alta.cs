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

namespace FrbaHotel.AbmHabitacion
{
    public partial class Alta : Form
    {
        public Alta()
        {
            InitializeComponent();
        }

        private void Alta_Load(object sender, EventArgs e)
        {
            //FormHandler.listarHoteles(comboBoxHotel);
            FormHandler.listarTipoHabitacion(comboBoxTipoHabitacion);
            FormHandler.listarTipoUbicacion(comboBoxUbicacion);
            //comboBoxHotel.SelectedIndex = -1;
            comboBoxTipoHabitacion.SelectedIndex = -1;
            comboBoxUbicacion.SelectedIndex = -1;
            if (Login.Login.LoggedUserSessionHotelID == -1)
            {
                var result = new AbmHotel.Listado().ShowDialog();
                if (result == System.Windows.Forms.DialogResult.Abort)
                {// FALLO LA OBTENCION!
                    MessageBox.Show("Fallo en la obtención de un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (result == System.Windows.Forms.DialogResult.Cancel) // USUARIO CERRO LA VENTANA!
                {
                    MessageBox.Show("Se ha cerrado la ventana sin seleccionar un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
                textBoxHotel.Text = DBHandler.Query(nombreHotel.Build()).ToString();
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            //textBoxHotel no se ve aqui ya que es solo para que vean el nombre del hotel, sin embargo
            //el id del hotel no se modifica y se encuentra en el Login.Login.LoggedUserSessionHotelID,
            //que es el que realmente se tiene que guardar
            List<TextBox> textBoxes = new List<TextBox> {textBoxComodidades,textBoxDescripcion,textBoxNumHabitacion,textBoxPiso,textBoxNumHabitacion};
            List<ComboBox> comboBoxes = new List<ComboBox> {comboBoxTipoHabitacion,comboBoxUbicacion};
            
            if (textBoxes.Any(tb => string.IsNullOrEmpty(tb.Text)) || comboBoxes.Any(cb => cb.SelectedIndex == -1))
            {
                MessageBox.Show("Debe completar todos los campos para dar de alta la habitación","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            var ret = DBHandler.SPWithValue("MATOTA.altaHabitacion",
                    new List<SqlParameter>{
                        new SqlParameter("@nroHabitacion",textBoxNumHabitacion.Text.Trim()),
                        new SqlParameter("@piso",textBoxPiso.Text.Trim()),
                        new SqlParameter("@idUbicacion",comboBoxUbicacion.SelectedValue),
                        new SqlParameter("@idTipoHabitacion",comboBoxTipoHabitacion.SelectedValue),
                        new SqlParameter("@idHotel",Login.Login.LoggedUserSessionHotelID),
                        new SqlParameter("@descripcion",textBoxDescripcion.Text),
                        new SqlParameter("@comodidades",textBoxComodidades.Text),
                    });
            if (ret == 0)
            {
                MessageBox.Show("El número de habitacion ingresado ya existe en el hotel " + textBoxHotel.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxNumHabitacion.Text = string.Empty;
            }
            else if (ret == 1)
                MessageBox.Show("Habitación ingresada exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
