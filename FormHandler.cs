﻿using System;
using System.Collections.Generic;
using System.Data;
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
                        if (textBox.Enabled)
                        {
                            textBox.Text = null;
                        }
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
                        else
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
                        dateTimePicker.Value = ConfigManager.FechaSistema;

                        if(control.Name.Equals("dateTimePickerFilter"))
                            dateTimePicker.Checked = false;
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
                try
                {
                    comboBox.DataSource = DBHandler.QueryForComboBox("SELECT * FROM MATOTA.TipoDocumento");
                    comboBox.DisplayMember = "nombre";
                    comboBox.ValueMember = "IdTipoDocumento";
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al listar los documentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            public static string getIdTipoDoc(string tipoDoc)
            {
                var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("td.idTipoDocumento").Table("MATOTA.TipoDocumento td").AddEquals("td.nombre", tipoDoc).Build();
                return DBHandler.Query(query).First().Values.First().ToString();
            }
            public static void listarTipoHabitacion(ComboBox comboBox)
            {
                try
                {
                    comboBox.DataSource = DBHandler.QueryForComboBox("SELECT idTipoHabitacion,descripcion FROM MATOTA.TipoHabitacion");
                    comboBox.DisplayMember = "descripcion";
                    comboBox.ValueMember = "idTipoHabitacion";
                    comboBox.SelectedIndex = -1;
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al listar los tipo de habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public static void listarTipoUbicacion(ComboBox comboBox)
            {
                try
                {
                    comboBox.DataSource = DBHandler.QueryForComboBox("SELECT * FROM MATOTA.UbicacionHabitacion");
                    comboBox.DisplayMember = "descripcion";
                    comboBox.ValueMember = "idUbicacion";
                    comboBox.SelectedIndex = -1;
                }
                catch (Exception)
                {

                    MessageBox.Show("Error al listar las ubicaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public static void listarHoteles(ComboBox comboBox)
            {
                comboBox.DataSource = DBHandler.QueryForComboBox("SELECT idHotel,nombre FROM MATOTA.Hotel");
                comboBox.DisplayMember = "nombre";
                comboBox.ValueMember = "idHotel";
            }
            public static string getIdHotel(string nombre)
            {
                try
                {
                    var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("idHotel").Table("MATOTA.Hotel").AddLike("nombre", nombre).Build();
                    return DBHandler.Query(query).First().Values.First().ToString();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error obtener el IdHotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "1";
                }
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

            public static void listarRoles(ComboBox comboBox)
            {
                try
                {
                    comboBox.DataSource = DBHandler.QueryForComboBox("SELECT * FROM MATOTA.Rol WHERE NOMBRE <> 'Guest'");
                    comboBox.DisplayMember = "NOMBRE";
                    comboBox.ValueMember = "idRol";
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al listar los roles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public static void listarRegimenes(ComboBox comboBox)
            {
                try
                {
                    comboBox.DataSource = DBHandler.QueryForComboBox("SELECT idRegimen,nombre FROM MATOTA.Regimen");
                    comboBox.DisplayMember = "nombre";
                    comboBox.ValueMember = "idRegimen";
                    comboBox.SelectedIndex = -1;
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al listar los regimenes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public static void listarHabitacionesReserva(DataGridView dataGridView, List<string> habitaciones)
            {
                try
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("nroHabitacion", typeof(int));
                    habitaciones.ForEach(hab => dt.Rows.Add(hab));
                    dataGridView.Rows.Clear();
                    var habitacionesParam = new SqlParameter("@habitaciones", SqlDbType.Structured).Value = dt;
                    dataGridView.DataSource = DBHandler.QueryForComboBox("MATOTA.GetHabitacionesReserva", new List<SqlParameter> { new SqlParameter("@habitaciones", habitacionesParam) });
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al listar las habitaciones", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        //MÉTODOS PARA EL PRECIO DE LA RESERVA
            public static float precioPorNoche(List<string> habitaciones, string idHotel, ComboBox comboBoxRegimen,int cantPersonasReserva)
            {
                var precio = habitaciones.Sum(habitacion => DBHandler.SPWithValue("MATOTA.PrecioHabitacion",
                    new List<SqlParameter> { new SqlParameter("@idHotel", idHotel), new SqlParameter("@nroHabitacion", habitacion), 
                    new SqlParameter("@cantPersonas", cantidadPersonasHabitacion(habitacion,idHotel,cantPersonasReserva)), new SqlParameter("@idRegimen",comboBoxRegimen.SelectedValue)}));
                return precio;
            }
            public static int cantidadPersonasHabitacion(string habitacion,string idHotel,int cantPersonasReserva)
            {
                var cantMaxPersonasHabitacion = getPersonasMaxHabitacion(habitacion,idHotel);
                int aux;
                if (cantPersonasReserva - cantMaxPersonasHabitacion > 0)
                {
                    cantPersonasReserva -= cantMaxPersonasHabitacion;
                    return cantMaxPersonasHabitacion;
                }
                else
                {
                    aux = cantPersonasReserva;
                    cantPersonasReserva = Math.Max(0, cantPersonasReserva - cantMaxPersonasHabitacion);
                    return aux;
                }
            }
            public static int cantNoches(DateTimePicker dateTimePickerFechaDesde, DateTimePicker dateTimePickerFechaHasta)
            {
                return DBHandler.SPWithValue("MATOTA.CantNoches",
                    new List<SqlParameter> { new SqlParameter("@fechaInicio", dateTimePickerFechaDesde.Value), new SqlParameter("@fechaFin", dateTimePickerFechaHasta.Value) });
            }
            public static int getPersonasMaxHabitacion(string nroHab, string idHotel)
            {
                return DBHandler.SPWithValue("MATOTA.personasHabitacion", new List<SqlParameter> { new SqlParameter("@idHotel", idHotel), new SqlParameter("@nroHabitacion", nroHab) });

            }

     }   
}
