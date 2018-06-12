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

namespace FrbaHotel.AbmHotel
{
    public partial class Suspender : Form
    {

        private string idHotel, nombreHotel;

        public Suspender(string idHotel, string nombreHotel)
        {
            InitializeComponent();
            this.idHotel = idHotel;
            this.nombreHotel = nombreHotel;

            this.groupBoxInactividad.Text += " " + this.nombreHotel;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMotivo.Text.Trim()))
            {
                MessageBox.Show("Debe especificar el motivo de inactividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePickerDesde.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("No se puede suspender el hotel en una fecha pasada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dateTimePickerHasta.Value.Date < DateTime.Now.Date || dateTimePickerHasta.Value.Date < dateTimePickerDesde.Value.Date)
            {
                MessageBox.Show("No se puede finalizar la inactividad antes de que comience.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var cantReservasP = new SqlParameter("@reservas", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var cantEstadiasP = new SqlParameter("@estadias", SqlDbType.Int) { Direction = ParameterDirection.Output };
            var cantInactividadesP = new SqlParameter("@inactividades", SqlDbType.Int) { Direction = ParameterDirection.Output };
            int ret = DBHandler.SPWithValue("MATOTA.ReservasEstadiasEnPeriodo",
                new List<SqlParameter> { 
                            new SqlParameter("@fechaDesde", dateTimePickerDesde.Value.ToString("yyyy-MM-dd") ) { Direction = ParameterDirection.Input },
                            new SqlParameter("@fechaHasta", dateTimePickerHasta.Value.ToString("yyyy-MM-dd") ) { Direction = ParameterDirection.Input },
                            new SqlParameter("@idHotel", idHotel) { Direction = ParameterDirection.Input },
                            cantEstadiasP,
                            cantReservasP,
                            cantInactividadesP
                        }
            );

            if (Convert.ToInt32(cantReservasP.Value) > 0)
            {
                MessageBox.Show("Imposible suspender el hotel en el periodo seleccionado pues hay reservas activas para ese periodo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(cantEstadiasP.Value) > 0)
            {
                MessageBox.Show("Imposible suspender el hotel en el periodo seleccionado pues hay huespedes ese periodo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (Convert.ToInt32(cantInactividadesP.Value) > 0)
            {
                MessageBox.Show("Imposible suspender el hotel en el periodo seleccionado pues ya hay una suspension programada para dicho periodo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var query = new QueryBuilder(QueryBuilder.QueryBuilderType.INSERT)
                                .Table("MATOTA.InactividadHotel")
                                .Fields("motivo,fechaInicio,fechaFin,idHotel")
                                .AddValues(textBoxMotivo.Text.Trim(), dateTimePickerDesde.Value.ToString("yyyy-MM-dd"), dateTimePickerHasta.Value.ToString("yyyy-MM-dd"), idHotel)
                                .Build();

            var rows = DBHandler.QueryRowCount(query);

            if (rows < 1)
            {
                MessageBox.Show("Imposible suspender el hotel en el periodo seleccionado, ocurrio un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Inactividad del Hotel registrada con exito.", "Enhorabuena", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this.groupBoxInactividad);
        }


    }
}
