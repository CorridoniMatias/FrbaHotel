﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.GenerarModificacionReserva
{
    public partial class GenerarReserva : Form
    {
        private string idHotel = string.Empty;
        public List<string> habitaciones { get; private set; }
        private double precioNoche;
        private Reserva reserva;
        private string idCliente;
        public GenerarReserva()
        {
            habitaciones = new List<string>();
            
            InitializeComponent();
            if (Login.Login.LoggedUsedID == -1)
            {
                textBoxHotel.Hide();
                FormHandler.setHotelesHabilitados(comboBoxHotel);
            }
            else
            {
                comboBoxHotel.Hide();
                try
                {
                    var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                    Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
                    textBoxHotel.Text = DBHandler.Query(nombreHotel.Build()).First().Values.First().ToString();
                    idHotel = Login.Login.LoggedUserSessionHotelID.ToString();
                    this.setRegimenes();
                }
                catch (Exception)
                {
                    MessageBox.Show("Seleccione un hotel en el que quiera realizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    var result = new AbmHotel.Listado().ShowDialog();
                    idHotel = Login.Login.LoggedUserSessionHotelID.ToString();
                    this.setRegimenes();
                    if (result == System.Windows.Forms.DialogResult.Cancel) 
                    {
                        MessageBox.Show("Se ha cerrado la ventana sin seleccionar un Hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Load += cerrarFormEnConstructor;
                    }
                    else
                    {
                        var nombreHotel = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).
                        Fields("nombre").Table("MATOTA.Hotel").AddEquals("idHotel", Login.Login.LoggedUserSessionHotelID.ToString());
                        textBoxHotel.Text = DBHandler.Query(nombreHotel.Build()).First().Values.First().ToString();
                    }
                }
            }
        }


        private void setRegimenes()
        {
            try
            {
                var query = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("r.idRegimen,r.nombre").Table("MATOTA.Regimen r").
                    AddJoin("JOIN MATOTA.RegimenHotel rh ON (rh.idRegimen = r.idRegimen AND rh.idHotel =" + idHotel + ")").AddEquals("habilitado","1").Build();
                comboBoxRegimen.DataSource = DBHandler.QueryForComboBox(query);
                comboBoxRegimen.DisplayMember = "nombre";
                comboBoxRegimen.ValueMember = "idRegimen";
                comboBoxRegimen.SelectedIndex = -1;
            }
            catch (Exception) 
            {
                var i = 1;
            }
        }

        private void GenerarReserva_Load(object sender, EventArgs e)
        {
            dateTimePickerFechaDesde.Value = ConfigManager.FechaSistema;
            dateTimePickerFechaHasta.Value = ConfigManager.FechaSistema;
        }

        private void comboBoxHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxHotel.SelectedIndex != -1)
            {
                idHotel = comboBoxHotel.SelectedValue.ToString();
                this.habitaciones.Clear();
                this.setRegimenes();
            }
            FormHandler.limpiar(groupBox2);
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this);
            FormHandler.limpiar(groupBox2);
            FormHandler.limpiar(groupBox1);
        }
        private void buttonConsultar_Click(object sender, EventArgs e)
        {
            {
                if (comboBoxRegimen.SelectedIndex == -1)
                    new ListadoRegimenHotel(idHotel, comboBoxRegimen).ShowDialog();
                if (habitaciones.Count == 0)
                {
                    MessageBox.Show("No ingresó ninguna habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    FormHandler.limpiar(groupBox2);
                    return;
                }
                if (comboBoxRegimen.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (numericUpDownCantPersonas.Value == 0)
                {
                    MessageBox.Show("Seleccione la cantidad de huespedes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                reserva = new Reserva(idHotel, habitaciones, comboBoxRegimen.SelectedValue.ToString(), (int) numericUpDownCantPersonas.Value);
                var cantNoches = reserva.cantNoches(dateTimePickerFechaDesde, dateTimePickerFechaHasta);
                if (numericUpDownCantPersonas.Value > reserva.cantPersonasQueEntran())
                {
                    MessageBox.Show("La cantidad de personas ingresada no entran en las habitaciones seleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dateTimePickerFechaDesde.Value < ConfigManager.FechaSistema)
                {
                        MessageBox.Show("La fecha de inicio de la reserva no puede ser anterior a la fecha actual.\n\nLa fecha de hoy es: "+ConfigManager.FechaSistema.ToString("yyyy-MM-dd"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                }
                if (cantNoches <= 0)
                {
                    MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    precioNoche = reserva.precioPorNoche();
                    textBoxPrecioPorNoche.Text = "U$S " + precioNoche.ToString();
                    textBoxCantNoches.Text = cantNoches.ToString();
                    textBoxPrecioTotal.Text = "U$S " + (cantNoches * precioNoche).ToString();
                }
            }
        }
        private void buttonGenerar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantNoches.Text))
            {
                MessageBox.Show("Consulte los datos de su reserva antes de generarla", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            else{
            var cantNoches = reserva.cantNoches(dateTimePickerFechaDesde, dateTimePickerFechaHasta);
            if (cantNoches <= 0)
            {
                MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDownCantPersonas.Value == 0)
            {
                MessageBox.Show("Seleccione la cantidad de huespedes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (idCliente == null)
            {
                MessageBox.Show("Ingrese el cliente para ponerlo a nombre de la reserva actual", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (DBHandler.SPWithBool("MATOTA.HotelHabilitadoParaFechasReserva", new List<SqlParameter> { new SqlParameter("@idHotel",idHotel),
                                                                                                       new SqlParameter("@fechaInicioReserva",dateTimePickerFechaDesde.Value),
                                                                                                       new SqlParameter("@fechaFinReserva",dateTimePickerFechaHasta.Value)}))
            {
                MessageBox.Show("El hotel seleccionado se encuentra inhabilitado durante las fechas de su reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    var idReserva = DBHandler.SPWithValue("MATOTA.AltaReserva",
                        new List<SqlParameter>{ new SqlParameter("@idHotel",idHotel),
                                        new SqlParameter("@fechaReserva",ConfigManager.FechaSistema),
                                        new SqlParameter("@fechaDesde",dateTimePickerFechaDesde.Value),
                                        new SqlParameter("@fechaHasta",dateTimePickerFechaHasta.Value),
                                        new SqlParameter("@cantidadNoches",cantNoches),
                                        new SqlParameter("@idRegimen",comboBoxRegimen.SelectedValue),
                                        new SqlParameter("@idCliente",idCliente),
                                        new SqlParameter("@precioBase",precioNoche * cantNoches),
                                        new SqlParameter("@cantidadPersonas",numericUpDownCantPersonas.Value.ToString()),});
                    habitaciones.ForEach(hab => DBHandler.SPWithValue("MATOTA.agregarHabitacionesReservadas",
                        new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                    MessageBox.Show("Reserva realizada con éxito, el código de su reserva es: " + idReserva, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al realizar la reserva.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            }
        }
        private void buttonSeleccionarHab_Click(object sender, EventArgs e)
        {
            if ( (Login.Login.LoggedUsedID == -1 && comboBoxHotel.SelectedIndex == -1) )
            {
                MessageBox.Show("Seleccione un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(idHotel))
            {
                MessageBox.Show("Seleccione un hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                FormHandler.limpiar(groupBox2);
                try
                {
                    DBHandler.SPWithValue("MATOTA.ActualizarReservasVencidas", new List<SqlParameter> { new SqlParameter("@fechaSistema", ConfigManager.FechaSistema) });
                    DBHandler.SPWithValue("MATOTA.habilitarHabitacionesDeReservasVencidas");
                    var form = new AbmHabitacion.Listado(idHotel, habitaciones, dateTimePickerFechaDesde.Value, dateTimePickerFechaHasta.Value);
                    form.setHabitacionesRemovidas(new List<string>());
                    form.dataGridReserva = dataGridView1;
                    form.ShowDialog();
                }
                catch (Exception)
                {
                    MessageBox.Show("Ocurrió un error al actualizar y listar las habitaciones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
        private void setIdCliente()
        {
            var seleccion = new AbmCliente.ListadoSeleccion();
            seleccion.dataGridViewCliente = dataGridViewCliente;
            seleccion.MostrarSoloHabilitados();
            seleccion.ShowDialog();
            if (seleccion.existeCliente)
                if (seleccion.SelectedClient != null)
                {
                    idCliente = seleccion.SelectedClient.idCliente;
                }
                else
                {
                    MessageBox.Show("Si no se encuentra registrado, vuelva a elegir la opcion seleccionar cliente y toque el botón 'agregar cliente' para poder registrarse", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            else
            {
                var alta = new AbmCliente.Alta();
                alta.dataGridViewCliente = dataGridViewCliente;
                alta.ShowDialog();
                if(alta.InsertedClient != null)
                    idCliente = alta.InsertedClient.idCliente;
            }

        }

        private void dateTimePickerFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox2);
            dataGridView1.Rows.Clear();
            habitaciones.Clear();

        }

        private void textBoxCantPersonas_TextChanged(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox2);
        }

        private void dateTimePickerFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox2);
            dataGridView1.Rows.Clear();
            habitaciones.Clear();
        }

        private void comboBoxRegimen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox2);
            dataGridView1.Rows.Clear();
        }

        private void buttonSeleccionCliente_Click(object sender, EventArgs e)
        {
            this.setIdCliente();
        }

        private void cerrarFormEnConstructor(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}