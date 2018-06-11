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
    public partial class ListadoRegimenHotel : Form
    {
        private string idHotel;
        private ComboBox regimen;
        public ListadoRegimenHotel(string idHotel, ComboBox regimen)
        {
            this.idHotel = idHotel;
            this.regimen = regimen;
            InitializeComponent();
        }

        private void ListadoRegimenHotel_Load(object sender, EventArgs e)
        {
            this.setRegimenes();
        }
        private void setRegimenes()
        {
            var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("r.idRegimen,r.nombre").Table("MATOTA.Regimen r").
                AddJoin("JOIN MATOTA.RegimenHotel rh ON (rh.idRegimen = r.idRegimen AND rh.idHotel =" + idHotel + ")").Build();
            dataGridView1.DataSource = DBHandler.QueryForComboBox(query);
            if (!dataGridView1.Columns.Contains("Seleccionar"))
            {
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.Name = "Seleccionar";
                boton.HeaderText = "Seleccionar";
                boton.Text = "Seleccionar";
                boton.UseColumnTextForButtonValue = true;
                dataGridView1.Columns.Add(boton);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (e.ColumnIndex == dataGridView1.Columns["Modificar"].Index)
                {
                    regimen.SelectedValue = row.Cells["Nombre"].Value.ToString();
                }
            }
        }

    }
}