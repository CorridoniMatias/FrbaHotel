﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmCliente
{
    public partial class ListadoSeleccion : Form
    {

        public Cliente SelectedClient { get; private set; }
        public bool existeCliente { get; private set; }
        public DataGridView dataGridViewCliente { get; set; }
        public ListadoSeleccion()
        {
            InitializeComponent();

            FormHandler.listarTipoDoc(comboBoxTipoDoc);
            comboBoxTipoDoc.SelectedIndex = -1;
            existeCliente = true;
            poblador = new PobladorCliente(new List<TextBox>() { textBoxNombre, textBoxMail, textBoxApellido, textBoxNumDoc }, comboBoxTipoDoc, dataGridView1, new List<string> { "Seleccionar" });
        }

        private PobladorCliente poblador;
        private bool soloHabilido = false;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (!Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value))
                {
                    MessageBox.Show("El cliente seleccionado no se encuentra habilitado, para habilitarlo comuníquese con un recepcionista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    this.SelectedClient = new Cliente()
                    {
                        idCliente = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(),
                        nombre = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(),
                        apellido = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(),
                    };
                    if (dataGridViewCliente != null)
                    {
                        dataGridViewCliente.Rows.Clear();
                        dataGridViewCliente.Rows.Add(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), SelectedClient.nombre);
                    }
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if ((comboBoxTipoDoc.SelectedIndex != -1 && string.IsNullOrEmpty(textBoxNumDoc.Text)) || (comboBoxTipoDoc.SelectedIndex == -1 && !string.IsNullOrEmpty(textBoxNumDoc.Text)))
            {
                MessageBox.Show("Si quiere buscar por documento debera completar los campos tipo documento y nro documento", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                poblador.Poblar(soloHabilido);
            }
        }

        private void ListadoSeleccion_Load(object sender, EventArgs e)
        {
            
        }

        public void MostrarSoloHabilitados()
        {
            this.soloHabilido = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
        }

        private void buttonAgregarCliente_Click(object sender, EventArgs e)
        {
            existeCliente = false;
            this.Close();
        }
    }
}
