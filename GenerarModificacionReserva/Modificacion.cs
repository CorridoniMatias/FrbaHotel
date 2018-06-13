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
        private Reserva reserva;
        public Modificacion(string idReserva, string idHotel, string fechaDesde, string fechaHasta, string idRegimen, string cantPersonas,string precioNoche, List<string> habitaciones)
        {
            InitializeComponent();
            this.idReserva = idReserva;
            this.idHotel = idHotel;
            dateTimePickerFechaDesde.Value = DateTime.Parse(fechaDesde);
            dateTimePickerFechaHasta.Value = DateTime.Parse(fechaHasta);
            FormHandler.listarRegimenes(comboBoxRegimen);
            comboBoxRegimen.Text = idRegimen;
            textBoxCantPersonas.Text = cantPersonas;
            textBoxPrecioNoche.Text = precioNoche;
            this.habitaciones = habitaciones;
            habitacionesRemovidas = new List<string>();
            reserva = new Reserva(idHotel, habitaciones, idRegimen, cantPersonasReserva);
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBox1);
            FormHandler.limpiar(groupBox2);
        }

        private void buttonSeleccionar_Click(object sender, EventArgs e)
        {
           var form = new AbmHabitacion.Listado(idHotel, habitaciones);
           form.setHabitacionesRemovidas(habitacionesRemovidas);
           form.ShowDialog();
        }
        private void buttonModificar_Click(object sender, EventArgs e)
        {
            var cantNoches = reserva.cantNoches(dateTimePickerFechaDesde,dateTimePickerFechaHasta);
            if (cantNoches <= 0)
            {
                MessageBox.Show("Ingrese fechas válidas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                cantPersonasReserva = Convert.ToInt32(textBoxCantPersonas.Text);
                var ret = DBHandler.SPWithValue("Matota.UpdateReserva",
                    new List<SqlParameter>{new SqlParameter("@idReserva",idReserva),
                                       new SqlParameter("@fechaDesde",dateTimePickerFechaDesde.Value),
                                       new SqlParameter("@fechaHasta",dateTimePickerFechaHasta.Value),
                                       new SqlParameter("@cantNoches",cantNoches),
                                       new SqlParameter("@idRegimen",comboBoxRegimen.SelectedValue),
                                       new SqlParameter("@precioBaseReserva",reserva.precioPorNoche()*cantNoches),
                                       new SqlParameter("@cantidadPersonas",textBoxCantPersonas.Text),});
                if (ret == 1)
                {
                    habitaciones.ForEach(hab => DBHandler.SPWithValue("MATOTA.agregarHabitacionesReservadas",
                        new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                    if (habitacionesRemovidas.Count != 0)
                        habitacionesRemovidas.ForEach(hab => DBHandler.SPWithValue("MATOTA.QuitarHabitacionesReserva",
                            new List<SqlParameter> { new SqlParameter("@nroHabitacion", hab), new SqlParameter("@idReserva", idReserva), new SqlParameter("@idHotel", idHotel) }));
                    MessageBox.Show("Modificación realizada con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Error en la modificación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    }

        private void textBoxCantPersonas_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCantPersonas.Text))
                cantPersonasReserva = Convert.ToInt32(textBoxCantPersonas.Text);
            FormHandler.limpiar(groupBox2);
        }
    }
}