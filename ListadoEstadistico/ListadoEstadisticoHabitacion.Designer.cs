namespace FrbaHotel.ListadoEstadistico
{
    partial class ListadoEstadisticoHabitacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridViewHabitaciones = new System.Windows.Forms.DataGridView();
            this.Hotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiasOcupada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VecesOcupada = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHabitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHabitaciones
            // 
            this.dataGridViewHabitaciones.AllowUserToAddRows = false;
            this.dataGridViewHabitaciones.AllowUserToDeleteRows = false;
            this.dataGridViewHabitaciones.AllowUserToOrderColumns = true;
            this.dataGridViewHabitaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewHabitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHabitaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hotel,
            this.Habitacion,
            this.DiasOcupada,
            this.VecesOcupada});
            this.dataGridViewHabitaciones.Location = new System.Drawing.Point(13, 13);
            this.dataGridViewHabitaciones.Name = "dataGridViewHabitaciones";
            this.dataGridViewHabitaciones.ReadOnly = true;
            this.dataGridViewHabitaciones.Size = new System.Drawing.Size(613, 225);
            this.dataGridViewHabitaciones.TabIndex = 0;
            // 
            // Hotel
            // 
            this.Hotel.HeaderText = "Hotel";
            this.Hotel.Name = "Hotel";
            this.Hotel.ReadOnly = true;
            this.Hotel.Width = 57;
            // 
            // Habitacion
            // 
            this.Habitacion.HeaderText = "Habitacion";
            this.Habitacion.Name = "Habitacion";
            this.Habitacion.ReadOnly = true;
            this.Habitacion.Width = 83;
            // 
            // DiasOcupada
            // 
            this.DiasOcupada.HeaderText = "Días Ocupada";
            this.DiasOcupada.Name = "DiasOcupada";
            this.DiasOcupada.ReadOnly = true;
            this.DiasOcupada.Width = 94;
            // 
            // VecesOcupada
            // 
            this.VecesOcupada.HeaderText = "Veces Ocupada";
            this.VecesOcupada.Name = "VecesOcupada";
            this.VecesOcupada.ReadOnly = true;
            // 
            // ListadoEstadisticoHabitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 250);
            this.Controls.Add(this.dataGridViewHabitaciones);
            this.Name = "ListadoEstadisticoHabitacion";
            this.Text = "ListadoEstadisticoHabitacion";
            this.Load += new System.EventHandler(this.ListadoEstadisticoHabitacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHabitaciones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHabitaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Habitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiasOcupada;
        private System.Windows.Forms.DataGridViewTextBoxColumn VecesOcupada;
    }
}