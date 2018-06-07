using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel
{
    class FormHandler
    {
            public static void limpiar(Control form)
            {
                foreach (Control control in form.Controls)
                {
                    if (control is TextBox)
                    {
                        TextBox textBox = (TextBox)control;
                        textBox.Text = null;
                    }
                    if (control is ComboBox)
                    {
                        ComboBox comboBox = (ComboBox)control;
                        if (comboBox.Items.Count > 0)
                            comboBox.SelectedIndex = 0;
                    }
                    if (control is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)control;
                        checkBox.Checked = false;
                    }
                    if (control is ListBox)
                    {
                        ListBox listBox = (ListBox)control;
                        listBox.ClearSelected();
                    }
                    if (control is DateTimePicker)
                    {
                        DateTimePicker dateTimePicker = (DateTimePicker)control;
                        dateTimePicker.Value = DateTime.Now;
                    }
                }
            }
            public static void listarTipoDoc(ComboBox comboBox)
            {
                comboBox.DataSource = DBHandler.QueryForComboBox("SELECT * FROM MATOTA.TipoDocumento");
                comboBox.DisplayMember = "nombre";
                comboBox.ValueMember = "IdTipoDocumento";
            }
            public static void crearBotonesDataGridView(DataGridView dataGridView)
            {
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.Name = "Modificar";
                boton.HeaderText = "Modificar";
                boton.Text = "Modificar";
                boton.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn boton2 = new DataGridViewButtonColumn();
                boton2.Name = "Eliminar";
                boton2.HeaderText = "Eliminar";
                boton2.Text = "Eliminar";
                boton2.UseColumnTextForButtonValue = true;

                dataGridView.Columns.Add(boton);
                dataGridView.Columns.Add(boton2);
            }
    }
}
