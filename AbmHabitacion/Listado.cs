using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHabitacion
{
    public partial class Listado : Form
    {
        private string idHotel;
        private GenerarModificacionReserva.GenerarReserva reserva;
        public Listado(string idHotel,GenerarModificacionReserva.GenerarReserva reserva)
        {
            this.idHotel = idHotel;
            this.reserva = reserva;
            InitializeComponent();
        }

        private void Listado_Load(object sender, EventArgs e)
        {
            FormHandler.listarTipoHabitacion(comboBoxTipoHab);
            FormHandler.listarTipoUbicacion(comboBoxUbicacion);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            this.setGridValuesHabitacion();
            if (!dataGridView1.Columns.Contains("Agregar"))
            {
                FormHandler.crearBotonesParaHabitacionesReserva(dataGridView1);
            }
        }
        private void setGridValuesHabitacion()
        {
            var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("h.nombre Hotel,ha.nroHabitacion Habitación,th.descripcion tipoHabitación,u.descripcion Ubicación").
                Table("MATOTA.Hotel h").AddJoin("JOIN MATOTA.Habitacion ha ON (h.idHotel = ha.idHotel)").AddJoin("JOIN MATOTA.TipoHabitacion th on (ha.idTipoHabitacion = th.idTipoHabitacion)").
                AddJoin("JOIN MATOTA.UbicacionHabitacion u on (ha.idUbicacion = u.idUbicacion)").AddEquals("h.idHotel", idHotel);
            if (comboBoxTipoHab.SelectedIndex != -1)
                query.AddEquals("th.idTipoHabitacion", comboBoxTipoHab.SelectedValue.ToString());
            if (comboBoxUbicacion.SelectedIndex != -1)
                query.AddEquals("u.idUbicacion", comboBoxUbicacion.SelectedValue.ToString());
            
            dataGridView1.DataSource = DBHandler.QueryForComboBox(query.Build());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var nroHab = row.Cells["Habitación"].Value.ToString();
                if (e.ColumnIndex == dataGridView1.Columns["Agregar"].Index)
                {
                    reserva.agregarHabitacion(nroHab);
                }
                else if (e.ColumnIndex == dataGridView1.Columns["Quitar"].Index)
                {
                    reserva.quitarHabitacion(nroHab);
                }
        }
    }
}
}
