using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class PobladorReservas : Form
    {
        private TextBox idReserva;
        private ComboBox hotel;
        private ComboBox regimen;
        private DataGridView grid;
        public QueryBuilder Filtro { get; private set; }
        private List<string> extraColumns;

        public PobladorReservas(TextBox idReserva, ComboBox hotel, ComboBox regimen,DataGridView grid, List<string> extraColumns)
        {
            this.idReserva = idReserva;
            this.hotel = hotel;
            this.regimen = regimen;
            this.grid = grid;
            Filtro = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                .Fields("r.idReserva,h.nombre nombreHotel,reg.nombre nombreRegimen,reg.idRegimen,r.fechaDesde,r.fechaHasta,r.cantidadPersonas,r.precioBaseReserva,e.descripcion")
                .Table("MATOTA.Reserva r").AddJoin("JOIN MATOTA.Hotel h ON (r.idHotel = h.idHotel)").
                AddJoin("JOIN MATOTA.Regimen reg ON (r.idRegimen = reg.idRegimen)").AddJoin("JOIN MATOTA.EstadoReserva e ON (e.idEstadoReserva = r.idEstadoReserva)");
            this.extraColumns = extraColumns;
        }

        public void Poblar()
        {
            Filtro.ClearFilters();
            if (!string.IsNullOrEmpty(idReserva.Text.Trim()))
                Filtro.AddEquals("r.idReserva", idReserva.Text.Trim());
            if (hotel.SelectedIndex != -1)
                Filtro.AddEquals("r.idHotel", hotel.SelectedValue.ToString());
            if (Login.Login.LoggedUserRoleID != 3)
                Filtro.AddEquals("r.idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
            if (regimen.SelectedIndex != -1)
                Filtro.AddEquals("r.idRegimen", regimen.SelectedValue.ToString());
            try
            {
                var newset = DBHandler.Query(Filtro.Build()).Select(row =>
                {
                    var orig = new List<string>() { row["idReserva"].ToString(), 
                                                        row["nombreHotel"].ToString(), 
                                                        row["idRegimen"].ToString(), 
                                                        row["nombreRegimen"].ToString(), 
                                                        row["fechaDesde"].ToString(), 
                                                        row["fechaHasta"].ToString(),
                                                        row["cantidadPersonas"].ToString(),
                                                        row["precioBaseReserva"].ToString(),
                                                        row["descripcion"].ToString()};
                    orig.AddRange(extraColumns);
                    return orig;
                }
                ).ToList();

                if (newset.Count() == 0)
                {
                    MessageBox.Show("No se encontró ninguna reserva. Intente cambiar el criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                newset.ForEach(row =>
                        grid.Rows.Add(row.ToArray())
                    );
            }
            catch (Exception e)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                MessageBox.Show("Error al buscar reservas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
