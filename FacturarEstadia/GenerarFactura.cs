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

namespace FrbaHotel.FacturarEstadia
{
    public partial class GenerarFactura : Form
    {
        private PobladorFacturas poblador;
        private string idEstadia;
        private List<string> idReservaHabitaciones;

        public GenerarFactura(string idEstadia, List<string> idReservaHabitaciones)
        {
            this.idEstadia = idEstadia;
            this.idReservaHabitaciones = idReservaHabitaciones;
            InitializeComponent();
        }

        private void GenerarFactura_Load(object sender, EventArgs e)
        {
            FormHandler.listarFormaDePago(comboBoxFormaDePago);
            comboBoxFormaDePago.SelectedIndex = -1;
            poblador = new PobladorFacturas(dataGridView1, idEstadia, idReservaHabitaciones);
            poblador.Poblar();
            textBoxTotal.Text = poblador.getPrecioE().ToString();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if (comboBoxFormaDePago.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione el medio de pago.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                try
                {
                    var ret = DBHandler.SPWithValue("MATOTA.altaFactura",
                        new List<SqlParameter>{
                        new SqlParameter("@idEstadia",idEstadia),
                        new SqlParameter("@fecha",ConfigManager.FechaSistema.ToString("yyyy-MM-dd")),
                        new SqlParameter("@idFormaDePago",comboBoxFormaDePago.SelectedValue),
                        new SqlParameter("@total",poblador.getPrecioE()),
                    });
                    if (ret == -1)
                    {
                        MessageBox.Show("Ya existe una factura para la estadía " + idEstadia + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Close();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Factura número " + ret + " creada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.cerrarEstadia();
                    }

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.Equals("-"))
                        {
                            dataGridView1.Rows[i].Cells[0].Value = -1;
                        }
                        if (dataGridView1.Rows[i].Cells[3].Value.Equals("-"))
                        {
                            dataGridView1.Rows[i].Cells[3].Value = 0;
                        }
                        if (dataGridView1.Rows[i].Cells[4].Value.Equals("-"))
                        {
                            dataGridView1.Rows[i].Cells[4].Value = 0;
                        }

                        var ret2 = DBHandler.SPWithValue("MATOTA.altaItemFactura",
                        new List<SqlParameter>{
                        new SqlParameter("@idFactura",ret),
                        new SqlParameter("@idConsumibleEstadia", dataGridView1.Rows[i].Cells[0].Value),
                        new SqlParameter("@descripcion",dataGridView1.Rows[i].Cells[2].Value),
                        new SqlParameter("@cantidad",dataGridView1.Rows[i].Cells[3].Value),
                        new SqlParameter("@monto",dataGridView1.Rows[i].Cells[4].Value),
                    });
                    }

                }
                catch (Exception exc)
                {
                    MessageBox.Show("Error al intentar crear la factura para la estadía " + idEstadia + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }

        private void cerrarEstadia()
        {
            var stat = new QueryBuilder(QueryBuilder.QueryBuilderType.UPDATE)
            .Table("MATOTA.Estadia")
            .Fields("fechaSalida = '" + ConfigManager.FechaSistema.ToString("yyyy-MM-dd") + "'")
            .AddEquals("idEstadia", this.idEstadia);

            int rows = 0;
            try
            {
                rows = DBHandler.QueryRowCount(stat.Build());
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar la fecha de salida de la Estadia!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (rows == 0)
                MessageBox.Show("Error al actualizar la fecha de salida de la Estadia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
