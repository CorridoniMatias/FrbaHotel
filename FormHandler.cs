using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                            comboBox.SelectedIndex = -1;
                    }
                    if (control is CheckBox)
                    {
                        CheckBox checkBox = (CheckBox)control;
                        if (checkBox.ThreeState)
                            checkBox.CheckState = CheckState.Indeterminate;
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
                    if (control is CheckedListBox) 
                    {
                        CheckedListBox checkedListBox = (CheckedListBox)control;
                        foreach (int i in checkedListBox.CheckedIndices)
                        {
                            checkedListBox.SetItemCheckState(i,CheckState.Unchecked);
                        }
                    }
                }
            }
            public static void listarTipoDoc(ComboBox comboBox)
            {
                comboBox.DataSource = DBHandler.QueryForComboBox("SELECT * FROM MATOTA.TipoDocumento");
                comboBox.DisplayMember = "nombre";
                comboBox.ValueMember = "IdTipoDocumento";
            }
            public static void crearBotonesDataGridViewCliente(DataGridView dataGridView)
            {
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.Name = "Modificar";
                boton.HeaderText = "Modificar";
                boton.Text = "Modificar";
                boton.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn boton2 = new DataGridViewButtonColumn();
                boton2.Name = "Inhabilitar";
                boton2.HeaderText = "Inhabilitar";
                boton2.Text = "Inhabilitar";
                boton2.UseColumnTextForButtonValue = true;

                dataGridView.Columns.Add(boton);
                dataGridView.Columns.Add(boton2);
            }
            public static string queryFiltradorSegunDoc(QueryBuilder qBuilder, string tipoDoc, string numDoc)
            {
                var idTipoDoc = DBHandler.SPWithResultSet("MATOTA.getTipoDoc", new List<SqlParameter> { new SqlParameter("@tipoDoc", tipoDoc) }).First().Values.First();
                qBuilder.AddEquals("IdTipoDocumento", idTipoDoc.ToString()).AddEquals("numeroDocumento", numDoc);
                return idTipoDoc.ToString();
            }
            public static void listarTipoHabitacion(ComboBox comboBox)
            {
                comboBox.DataSource = DBHandler.QueryForComboBox("SELECT idTipoHabitacion,descripcion FROM MATOTA.TipoHabitacion");
                comboBox.DisplayMember = "descripcion";
                comboBox.ValueMember = "idTipoHabitacion";
                comboBox.SelectedIndex = -1;
            }
            public static void listarTipoUbicacion(ComboBox comboBox)
            {
                comboBox.DataSource = DBHandler.QueryForComboBox("SELECT * FROM MATOTA.UbicacionHabitacion");
                comboBox.DisplayMember = "descripcion";
                comboBox.ValueMember = "idUbicacion";
                comboBox.SelectedIndex = -1;
            }
            public static void listarHoteles(ComboBox comboBox)
            {
                comboBox.DataSource = DBHandler.QueryForComboBox("SELECT idHotel,nombre FROM MATOTA.Hotel");
                comboBox.DisplayMember = "nombre";
                comboBox.ValueMember = "idHotel";
            }
            public static void crearBotonesParaHabitacionesReserva(DataGridView dataGridView)
            {
                DataGridViewButtonColumn boton = new DataGridViewButtonColumn();
                boton.Name = "Agregar";
                boton.HeaderText = "Agregar";
                boton.Text = "Agregar";
                boton.UseColumnTextForButtonValue = true;

                DataGridViewButtonColumn boton2 = new DataGridViewButtonColumn();
                boton2.Name = "Quitar";
                boton2.HeaderText = "Quitar";
                boton2.Text = "Quitar";
                boton2.UseColumnTextForButtonValue = true;

                dataGridView.Columns.Add(boton);
                dataGridView.Columns.Add(boton2);
            }
    }
}
