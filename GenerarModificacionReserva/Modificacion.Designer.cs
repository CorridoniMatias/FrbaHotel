namespace FrbaHotel.GenerarModificacionReserva
{
    partial class Modificacion
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
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPrecioNoche = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCantPersonas = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxRegimen = new System.Windows.Forms.ComboBox();
            this.dateTimePickerFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonSeleccionar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxPrecioTotal = new System.Windows.Forms.TextBox();
            this.buttonConsultar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCantNoches = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxPrecioPorNoche = new System.Windows.Forms.TextBox();
            this.Column4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(317, 464);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(75, 23);
            this.buttonModificar.TabIndex = 0;
            this.buttonModificar.Text = "Modificar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(22, 464);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(138, 23);
            this.buttonLimpiar.TabIndex = 1;
            this.buttonLimpiar.Text = "Cancelar modificación";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPrecioNoche);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxCantPersonas);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxRegimen);
            this.groupBox1.Controls.Add(this.dateTimePickerFechaHasta);
            this.groupBox1.Controls.Add(this.dateTimePickerFechaDesde);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox1.Location = new System.Drawing.Point(22, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(370, 209);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de su reserva";
            // 
            // textBoxPrecioNoche
            // 
            this.textBoxPrecioNoche.Location = new System.Drawing.Point(147, 172);
            this.textBoxPrecioNoche.MaxLength = 18;
            this.textBoxPrecioNoche.Name = "textBoxPrecioNoche";
            this.textBoxPrecioNoche.ReadOnly = true;
            this.textBoxPrecioNoche.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecioNoche.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(9, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Precio por Noche Anterior";
            // 
            // textBoxCantPersonas
            // 
            this.textBoxCantPersonas.Location = new System.Drawing.Point(112, 141);
            this.textBoxCantPersonas.Name = "textBoxCantPersonas";
            this.textBoxCantPersonas.Size = new System.Drawing.Size(100, 20);
            this.textBoxCantPersonas.TabIndex = 11;
            this.textBoxCantPersonas.TextChanged += new System.EventHandler(this.textBoxCantPersonas_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(9, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cant. personas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(9, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Regimen";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(9, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Fecha hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(9, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fecha desde";
            // 
            // comboBoxRegimen
            // 
            this.comboBoxRegimen.FormattingEnabled = true;
            this.comboBoxRegimen.Location = new System.Drawing.Point(112, 105);
            this.comboBoxRegimen.Name = "comboBoxRegimen";
            this.comboBoxRegimen.Size = new System.Drawing.Size(121, 21);
            this.comboBoxRegimen.TabIndex = 3;
            this.comboBoxRegimen.SelectedIndexChanged += new System.EventHandler(this.comboBoxRegimen_SelectedIndexChanged);
            // 
            // dateTimePickerFechaHasta
            // 
            this.dateTimePickerFechaHasta.Location = new System.Drawing.Point(112, 66);
            this.dateTimePickerFechaHasta.Name = "dateTimePickerFechaHasta";
            this.dateTimePickerFechaHasta.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechaHasta.TabIndex = 1;
            this.dateTimePickerFechaHasta.ValueChanged += new System.EventHandler(this.dateTimePickerFechaHasta_ValueChanged);
            // 
            // dateTimePickerFechaDesde
            // 
            this.dateTimePickerFechaDesde.Location = new System.Drawing.Point(112, 29);
            this.dateTimePickerFechaDesde.Name = "dateTimePickerFechaDesde";
            this.dateTimePickerFechaDesde.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFechaDesde.TabIndex = 0;
            this.dateTimePickerFechaDesde.ValueChanged += new System.EventHandler(this.dateTimePickerFechaDesde_ValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonSeleccionar);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(410, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(467, 209);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Habitaciones";
            // 
            // buttonSeleccionar
            // 
            this.buttonSeleccionar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonSeleccionar.Location = new System.Drawing.Point(112, 30);
            this.buttonSeleccionar.Name = "buttonSeleccionar";
            this.buttonSeleccionar.Size = new System.Drawing.Size(142, 23);
            this.buttonSeleccionar.TabIndex = 1;
            this.buttonSeleccionar.Text = "Seleccionar habitaciones";
            this.buttonSeleccionar.UseVisualStyleBackColor = true;
            this.buttonSeleccionar.Click += new System.EventHandler(this.buttonSeleccionar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView1.Location = new System.Drawing.Point(12, 74);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(444, 129);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Nro. habitacion";
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBoxPrecioTotal);
            this.groupBox3.Controls.Add(this.buttonConsultar);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBoxCantNoches);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBoxPrecioPorNoche);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
            this.groupBox3.Location = new System.Drawing.Point(26, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(366, 204);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos nuevos de su reserva";
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
            // textBoxCantNoches
            // 
            this.textBoxCantNoches.Location = new System.Drawing.Point(125, 115);
            this.textBoxCantNoches.Name = "textBoxCantNoches";
            this.textBoxCantNoches.ReadOnly = true;
            this.textBoxCantNoches.Size = new System.Drawing.Size(100, 20);
            this.textBoxCantNoches.TabIndex = 19;
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
            // textBoxPrecioPorNoche
            // 
            this.textBoxPrecioPorNoche.Location = new System.Drawing.Point(125, 75);
            this.textBoxPrecioPorNoche.Name = "textBoxPrecioPorNoche";
            this.textBoxPrecioPorNoche.ReadOnly = true;
            this.textBoxPrecioPorNoche.Size = new System.Drawing.Size(100, 20);
            this.textBoxPrecioPorNoche.TabIndex = 12;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Quitar";
            this.Column4.Name = "Column4";
            // 
            // Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 505);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.buttonModificar);
            this.Name = "Modificacion";
            this.Text = "Modificacion";
            this.Load += new System.EventHandler(this.Modificacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRegimen;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaHasta;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaDesde;
        private System.Windows.Forms.TextBox textBoxCantPersonas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSeleccionar;
        private System.Windows.Forms.TextBox textBoxPrecioNoche;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxPrecioTotal;
        private System.Windows.Forms.Button buttonConsultar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxCantNoches;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxPrecioPorNoche;
        private System.Windows.Forms.DataGridViewButtonColumn Column4;
    }
}