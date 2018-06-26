namespace FrbaHotel.GenerarModificacionReserva
{
    partial class GenerarReserva
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.textBoxCantPersonas = new System.Windows.Forms.TextBox();
            this.textBoxPrecioPorNoche = new System.Windows.Forms.TextBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonGenerar = new System.Windows.Forms.Button();
            this.textBoxHotel = new System.Windows.Forms.TextBox();
            this.comboBoxRegimen = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSeleccionarHab = new System.Windows.Forms.Button();
            this.textBoxCantNoches = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPrecioTotal = new System.Windows.Forms.TextBox();
            this.buttonConsultar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonSeleccionCliente = new System.Windows.Forms.Button();
            this.dataGridViewCliente = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha desde";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fecha hasta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Cantidad personas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Régimen";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(17, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Precio por noche";
            // 
            // dateTimePickerFechaDesde
            // 
            this.dateTimePickerFechaDesde.Location = new System.Drawing.Point(119, 74);
            this.dateTimePickerFechaDesde.Name = "dateTimePickerFechaDesde";
            this.dateTimePickerFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechaDesde.TabIndex = 7;
            this.dateTimePickerFechaDesde.ValueChanged += new System.EventHandler(this.dateTimePickerFechaDesde_ValueChanged);
            // 
            // dateTimePickerFechaHasta
            // 
            this.dateTimePickerFechaHasta.Location = new System.Drawing.Point(119, 116);
            this.dateTimePickerFechaHasta.Name = "dateTimePickerFechaHasta";
            this.dateTimePickerFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechaHasta.TabIndex = 8;
            this.dateTimePickerFechaHasta.ValueChanged += new System.EventHandler(this.dateTimePickerFechaHasta_ValueChanged);
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.FormattingEnabled = true;
            this.comboBoxHotel.Location = new System.Drawing.Point(119, 31);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHotel.TabIndex = 9;
            this.comboBoxHotel.SelectedIndexChanged += new System.EventHandler(this.comboBoxHotel_SelectedIndexChanged);
            // 
            // textBoxCantPersonas
            // 
            this.textBoxCantPersonas.Location = new System.Drawing.Point(140, 150);
            this.textBoxCantPersonas.MaxLength = 1000;
            this.textBoxCantPersonas.Name = "textBoxCantPersonas";
            this.textBoxCantPersonas.Size = new System.Drawing.Size(55, 20);
            this.textBoxCantPersonas.TabIndex = 10;
            this.textBoxCantPersonas.TextChanged += new System.EventHandler(this.textBoxCantPersonas_TextChanged);
            // 
            // textBoxPrecioPorNoche
            // 
            this.textBoxPrecioPorNoche.Location = new System.Drawing.Point(125, 75);
            this.textBoxPrecioPorNoche.Name = "textBoxPrecioPorNoche";
            this.textBoxPrecioPorNoche.ReadOnly = true;
            this.textBoxPrecioPorNoche.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecioPorNoche.TabIndex = 12;
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(359, 491);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 13;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonGenerar
            // 
            this.buttonGenerar.Location = new System.Drawing.Point(642, 491);
            this.buttonGenerar.Name = "buttonGenerar";
            this.buttonGenerar.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerar.TabIndex = 14;
            this.buttonGenerar.Text = "Generar";
            this.buttonGenerar.UseVisualStyleBackColor = true;
            this.buttonGenerar.Click += new System.EventHandler(this.buttonGenerar_Click);
            // 
            // textBoxHotel
            // 
            this.textBoxHotel.Location = new System.Drawing.Point(119, 31);
            this.textBoxHotel.Name = "textBoxHotel";
            this.textBoxHotel.ReadOnly = true;
            this.textBoxHotel.Size = new System.Drawing.Size(121, 20);
            this.textBoxHotel.TabIndex = 15;
            // 
            // comboBoxRegimen
            // 
            this.comboBoxRegimen.FormattingEnabled = true;
            this.comboBoxRegimen.Location = new System.Drawing.Point(119, 181);
            this.comboBoxRegimen.Name = "comboBoxRegimen";
            this.comboBoxRegimen.Size = new System.Drawing.Size(175, 21);
            this.comboBoxRegimen.TabIndex = 16;
            this.comboBoxRegimen.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegimen_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 241);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese aquí los datos";
            // 
            // buttonSeleccionarHab
            // 
            this.buttonSeleccionarHab.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSeleccionarHab.Location = new System.Drawing.Point(94, 22);
            this.buttonSeleccionarHab.Name = "buttonSeleccionarHab";
            this.buttonSeleccionarHab.Size = new System.Drawing.Size(175, 23);
            this.buttonSeleccionarHab.TabIndex = 0;
            this.buttonSeleccionarHab.Text = "Seleccionar habitaciones";
            this.buttonSeleccionarHab.UseVisualStyleBackColor = true;
            this.buttonSeleccionarHab.Click += new System.EventHandler(this.buttonSeleccionarHab_Click);
            // 
            // textBoxCantNoches
            // 
            this.textBoxCantNoches.Location = new System.Drawing.Point(125, 115);
            this.textBoxCantNoches.Name = "textBoxCantNoches";
            this.textBoxCantNoches.ReadOnly = true;
            this.textBoxCantNoches.Size = new System.Drawing.Size(100, 20);
            this.textBoxCantNoches.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxPrecioTotal);
            this.groupBox2.Controls.Add(this.buttonConsultar);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBoxCantNoches);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxPrecioPorNoche);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox2.Location = new System.Drawing.Point(351, 270);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(366, 204);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos de su reserva";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(17, 162);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Precio total";
            // 
            // textBoxPrecioTotal
            // 
            this.textBoxPrecioTotal.Location = new System.Drawing.Point(125, 159);
            this.textBoxPrecioTotal.Name = "textBoxPrecioTotal";
            this.textBoxPrecioTotal.ReadOnly = true;
            this.textBoxPrecioTotal.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecioTotal.TabIndex = 22;
            // 
            // buttonConsultar
            // 
            this.buttonConsultar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonConsultar.Location = new System.Drawing.Point(73, 30);
            this.buttonConsultar.Name = "buttonConsultar";
            this.buttonConsultar.Size = new System.Drawing.Size(139, 23);
            this.buttonConsultar.TabIndex = 21;
            this.buttonConsultar.Text = "Consultar";
            this.buttonConsultar.UseVisualStyleBackColor = true;
            this.buttonConsultar.Click += new System.EventHandler(this.buttonConsultar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(17, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Cantidad noches";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Controls.Add(this.buttonSeleccionarHab);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(351, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(367, 241);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Habitaciones";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dataGridView1.Location = new System.Drawing.Point(6, 64);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(346, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nro. Habitación";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tipo habitación";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Ubicación";
            this.Column3.Name = "Column3";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonSeleccionCliente);
            this.groupBox5.Controls.Add(this.dataGridViewCliente);
            this.groupBox5.Location = new System.Drawing.Point(15, 270);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(321, 244);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Cliente";
            // 
            // buttonSeleccionCliente
            // 
            this.buttonSeleccionCliente.Location = new System.Drawing.Point(104, 33);
            this.buttonSeleccionCliente.Name = "buttonSeleccionCliente";
            this.buttonSeleccionCliente.Size = new System.Drawing.Size(121, 23);
            this.buttonSeleccionCliente.TabIndex = 1;
            this.buttonSeleccionCliente.Text = "Seleccionar Cliente";
            this.buttonSeleccionCliente.UseVisualStyleBackColor = true;
            this.buttonSeleccionCliente.Click += new System.EventHandler(this.buttonSeleccionCliente_Click);
            // 
            // dataGridViewCliente
            // 
            this.dataGridViewCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Column6});
            this.dataGridViewCliente.Location = new System.Drawing.Point(7, 75);
            this.dataGridViewCliente.Name = "dataGridViewCliente";
            this.dataGridViewCliente.Size = new System.Drawing.Size(308, 150);
            this.dataGridViewCliente.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Tipo. Documento";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Nro. Documento";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Nombre";
            this.Column6.Name = "Column6";
            // 
            // GenerarReserva
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(729, 526);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.comboBoxRegimen);
            this.Controls.Add(this.buttonGenerar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.textBoxCantPersonas);
            this.Controls.Add(this.comboBoxHotel);
            this.Controls.Add(this.dateTimePickerFechaHasta);
            this.Controls.Add(this.dateTimePickerFechaDesde);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxHotel);
            this.Controls.Add(this.groupBox1);
            this.Name = "GenerarReserva";
            this.Text = "Generar reserva";
            this.Load += new System.EventHandler(this.GenerarReserva_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaDesde;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaHasta;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.TextBox textBoxCantPersonas;
        private System.Windows.Forms.TextBox textBoxPrecioPorNoche;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.Button buttonGenerar;
        private System.Windows.Forms.TextBox textBoxHotel;
        private System.Windows.Forms.ComboBox comboBoxRegimen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxCantNoches;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonSeleccionarHab;
        private System.Windows.Forms.Button buttonConsultar;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrecioTotal;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridViewCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Button buttonSeleccionCliente;
    }
}