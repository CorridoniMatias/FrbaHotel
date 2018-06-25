using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.RegistrarConsumible
{
    public partial class Registrar : Form
    {

        private string idReservaHabitacion;
        private bool allInclusive = false;

        public Registrar(string idReservaHabitacion, string nroHabitacion)
        {
            InitializeComponent();
            this.textBoxNroHabitacion.Text = nroHabitacion;
            this.idReservaHabitacion = idReservaHabitacion;
        }

        public Registrar(string idReservaHabitacion, string nroHabitacion, bool allInclusive) : this(idReservaHabitacion, nroHabitacion)
        {
            this.allInclusive = allInclusive;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {

                if (senderGrid.Columns[e.ColumnIndex].Name.Equals("ColumnModificar"))
                {
                    Consumible cons = new Consumible
                    {
                        codigoConsumible = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        descripcion = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        precio = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()
                    };

                    var cantidadSelector = new SelectCantidad(cons, Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()));

                    if (cantidadSelector.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        senderGrid.Rows[e.RowIndex].Cells[3].Value = cantidadSelector.CantidadElegida;
                        senderGrid.Rows[e.RowIndex].Cells[4].Value = CalcSubTotal(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), cantidadSelector.CantidadElegida).ToString();
                        dataGridView1_RowsAltered(null, null);
                    } 
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name.Equals("ColumnRemove"))
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private decimal CalcSubTotal(string precio, int cantidad)
        {
            return Convert.ToDecimal(precio) * cantidad;
        }

       

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var selector = new SeleccionadorConsumible();

            if (selector.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                Consumible consumible = selector.ConsumibleSeleccionado;


                var cantidadSelector = new SelectCantidad(consumible);

                if (cantidadSelector.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    this.dataGridView1.Rows.Add(consumible.codigoConsumible, consumible.descripcion, consumible.precio, cantidadSelector.CantidadElegida, CalcSubTotal(consumible.precio, cantidadSelector.CantidadElegida) , "Modificar", "Remover");
                }
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No se han agregado consumibles, si desea continuar de este modo por favor utilice el boton en el sector inferior izquierdo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.Enabled = false;
            buttonAdd.Enabled = false;
            buttonContinue.Enabled = false;
            buttonRegister.Enabled = false;

            var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.INSERT)
                                .Table("MATOTA.ConsumiblesEstadia")
                                .Fields("codigoConsumible,precioAlMomento,cantidad,idReservaHabitacion");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                builder.AddValues(
                        dataGridView1.Rows[i].Cells[0].Value.ToString(),
                        dataGridView1.Rows[i].Cells[2].Value.ToString(),
                        dataGridView1.Rows[i].Cells[3].Value.ToString(),
                        idReservaHabitacion
                    );
            }

            try
            {

                var count = DBHandler.QueryRowCount(builder.Build());

                if (count != dataGridView1.Rows.Count)
                    throw new Exception("count != rowcount");
                else
                {
                    MessageBox.Show("Consumibles registrados con éxito!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al guardar los consumibles, por favor intente de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Enabled = true;
                buttonAdd.Enabled = true;
                buttonContinue.Enabled = true;
                buttonRegister.Enabled = true;
                return;
            }

        }

        private void buttonContinue_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void dataGridView1_RowsAltered(object sender, EventArgs e)
        {
            if (!allInclusive)
                return;

            if (dataGridView1.Rows.Count == 0)
            {
                labelDescuento.Visible = false;
                return;
            }

            labelDescuento.Visible = true;

            labelDescuento.Text = "Bonificación por régimen All Inclusive: -$" + CalcTotal();
        }

        private decimal CalcTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDecimal(row.Cells[4].Value);
            }

            return total;
        }

    }
}
