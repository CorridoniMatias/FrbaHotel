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
    public partial class Modificacion : Form
    {
        private string idReserva;
        private string idHotel;
        private int cantPersonasReserva;
        public List<string> habitaciones;
        public List<string> habitacionesRemovidas;
        private Reserva reserva{get; set;}
        private double precioNoche;
        private Boolean puedeModificar;
        public AbmHabitacion.HabitacionReservada habReservada { get; set; }
        public Modificacion(string idReserva,string fechaDesde, string fechaHasta, string idRegimen, string cantPersonas,string precioNoche, List<string> habitaciones,string regimen)
        {
            InitializeComponent();
            this.idReserva = idReserva;
            try
            {
                this.idHotel = DBHandler.Query("SELECT idHotel FROM MATOTA.RESERVA WHERE idReserva =" + idReserva).First().Values.First().ToString();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al obtener el hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dateTimePickerFechaDesde.Value = DateTime.Parse(fechaDesde);
            dateTimePickerFechaHasta.Value = DateTime.Parse(fechaHasta);
            this.setRegimenes();
            comboBoxRegimen.Text = regimen;

            try
            {
                numericUpDownCantPersonas.Value = Convert.ToInt32(cantPersonas);
            }
            catch (Exception)
            {
                numericUpDownCantPersonas.Value = 0;
            }

            textBoxPrecioNoche.Text = precioNoche;
            this.habitaciones = habitaciones;
            habitacionesRemovidas = new List<string>();
            reserva = new Reserva(idHotel, habitaciones, idRegimen, cantPersonasReserva);
            habitaciones.ForEach(hab => { crearHabitacionReservada(hab); dataGridView1.Rows.Add(habReservada.nroHabitacion, habReservada.tipoHabitacion, habReservada.ubicacion,"Quitar"); });
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
        }
        
        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
           var form = new AbmHabitacion.Listado(idHotel, habitaciones,dateTimePickerFechaDesde.Value,dateTimePickerFechaHasta.Value);
           form.setHabitacionesRemovidas(habitacionesRemovidas);
           form.dataGridReserva = dataGridView1;
           form.ShowDialog();
        }
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            var cantNoches = reserva.cantNoches(dateTimePickerFechaDesde,dateTimePickerFechaHasta);
            if (dateTimePickerFechaDesde.Value < ConfigManager.FechaSistema)
            {
                MessageBox.Show("La fecha de inicio de la reserva no puede ser anterior a la fecha actual.\n\nLa fecha de hoy es: " + ConfigManager.FechaSistema.ToString("yyyy-MM-dd"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cantNoches <= 0)
            {
                MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                puedeModificar = DBHandler.SPWithBool("MATOTA.FechaCorrectaParaModificarReserva", new List<SqlParameter>{new SqlParameter("@idReserva",idReserva),
                                                                                                      new SqlParameter("@fechaSistema",ConfigManager.FechaSistema)});
            }
            catch(Exception excep)
            {
                MessageBox.Show("Error al chequear si puede modificar la reserva","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (!puedeModificar)
            {
                MessageBox.Show("Ya pasó la fecha límite para modificar esta reserva", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(comboBoxRegimen.SelectedIndex == -1 )
            {
                MessageBox.Show("Debe completar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (numericUpDownCantPersonas.Value == 0)
            {
                MessageBox.Show("Seleccione la cantidad de huespedes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxCantNoches.Text))
            {
                MessageBox.Show("Consulte los datos de su reserva antes de generarla", "Stop", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            try
            {
                cantPersonasReserva = (int)numericUpDownCantPersonas.Value;
                var ret = DBHandler.SPWithValue("Matota.UpdateReserva",
                    new List<SqlParameter>{new SqlParameter("@idReserva",idReserva),
                                       new SqlParameter("@fechaDesde",dateTimePickerFechaDesde.Value),
                                       new SqlParameter("@fechaHasta",dateTimePickerFechaHasta.Value),
                                       new SqlParameter("@cantNoches",cantNoches),
                                       new SqlParameter("@idRegimen",comboBoxRegimen.SelectedValue),
                                       new SqlParameter("@precioBaseReserva",precioNoche*cantNoches),
                                       new SqlParameter("@cantidadPersonas",cantPersonasReserva.ToString()),});
                if (ret == 1)
                {
                    habitaciones.ForEach(hab => DBHandler.SPWithValue("MATOTA.agregarHabitacionesReservadas",
                        new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                    if (habitacionesRemovidas.Count != 0)
                        habitacionesRemovidas.ForEach(hab => DBHandler.SPWithValue("MATOTA.QuitarHabitacionesReserva",
                            new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                    MessageBox.Show("Modificación realizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Error en la modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }   

        private void crearHabitacionReservada(string nroHab)
        {
            try
            {
                var queryTipoHab = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("th.descripcion").Table("MATOTA.TipoHabitacion th").
                                   AddJoin("JOIN MATOTA.Habitacion h ON(th.idTipoHabitacion = h.idTipoHabitacion)").AddEquals("h.nroHabitacion", nroHab).AddEquals("h.idHotel",idHotel).Build();
                var queryUbicacion = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT).Fields("u.descripcion").Table("MATOTA.UbicacionHabitacion u").
                                     AddJoin("JOIN MATOTA.Habitacion h ON (h.idUbicacion = u.idUbicacion)").AddEquals("h.nroHabitacion", nroHab).AddEquals("h.idHotel",idHotel).Build();

                habReservada = new AbmHabitacion.HabitacionReservada()
                {
                    nroHabitacion = nroHab,
                    tipoHabitacion = DBHandler.Query(queryTipoHab).First().Values.First().ToString(),
                    ubicacion = DBHandler.Query(queryUbicacion).First().Values.First().ToString()
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las habitaciones ya reservadas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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

                cantPersonasReserva = (int)numericUpDownCantPersonas.Value;
                reserva = new Reserva(idHotel, habitaciones, comboBoxRegimen.SelectedValue.ToString(), cantPersonasReserva);
                var cantNoches = reserva.cantNoches(dateTimePickerFechaDesde, dateTimePickerFechaHasta);
                if (cantPersonasReserva > reserva.cantPersonasQueEntran())
                {
                    MessageBox.Show("La cantidad de personas ingresada no entran en las habitaciones seleccionadas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (cantNoches <= 0)
                {
                    MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void comboBoxRegimen_SelectedIndexChanged(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox3);
        }

        private void dateTimePickerFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox3);
        }

        private void dateTimePickerFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox3);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                var nroHab = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (habitaciones.Contains(nroHab))
                {
                    habitaciones.Remove(nroHab);
                    if (!habitacionesRemovidas.Contains(nroHab))
                        habitacionesRemovidas.Add(nroHab);
                    MessageBox.Show("Habitacion " + nroHab.ToString() + " quitada", "Habitación quitada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                }
                else
                {
                    MessageBox.Show("Usted nunca agregó esta habitación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
        }

        private void numericUpDownCantPersonas_ValueChanged(object sender, EventArgs e)
        {
            cantPersonasReserva = (int)numericUpDownCantPersonas.Value;
            FormHandler.limpiar(groupBox2);
            FormHandler.limpiar(groupBox3);
        }
    }
}