namespace FrbaHotel.FacturarEstadia
{
    partial class listarHabitacionesFactura
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
            this.comboBoxHabitacion = new System.Windows.Forms.ComboBox();
            this.comboBoxUbicacion = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNroHabitacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnNroHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNombreUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIdTipoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNombreHotel = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxHabitacion
            // 
            this.comboBoxHabitacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHabitacion.FormattingEnabled = true;
            this.comboBoxHabitacion.Location = new System.Drawing.Point(343, 66);
            this.comboBoxHabitacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxHabitacion.Name = "comboBoxHabitacion";
            this.comboBoxHabitacion.Size = new System.Drawing.Size(157, 21);
            this.comboBoxHabitacion.TabIndex = 19;
            this.comboBoxHabitacion.Tag = "idTipoHabitacion";
            // 
            // comboBoxUbicacion
            // 
            this.comboBoxUbicacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxUbicacion.FormattingEnabled = true;
            this.comboBoxUbicacion.Location = new System.Drawing.Point(67, 66);
            this.comboBoxUbicacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxUbicacion.Name = "comboBoxUbicacion";
            this.comboBoxUbicacion.Size = new System.Drawing.Size(143, 21);
            this.comboBoxUbicacion.TabIndex = 18;
            this.comboBoxUbicacion.Tag = "idUbicacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(244, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 10;
            this.label6.Tag = "";
            this.label6.Text = "Tipo de Habitación";
            // 
            // textBoxNroHabitacion
            // 
            this.textBoxNroHabitacion.Location = new System.Drawing.Point(328, 31);
            this.textBoxNroHabitacion.MaxLength = 18;
            this.textBoxNroHabitacion.Name = "textBoxNroHabitacion";
            this.textBoxNroHabitacion.Size = new System.Drawing.Size(171, 20);
            this.textBoxNroHabitacion.TabIndex = 9;
            this.textBoxNroHabitacion.Tag = "nroHabitacion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(244, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nro. Habitación";
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Location = new System.Drawing.Point(565, 31);
            this.textBoxPiso.MaxLength = 18;
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(172, 20);
            this.textBoxPiso.TabIndex = 6;
            this.textBoxPiso.Tag = "piso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(534, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Piso";
            // 
            // labelUbicacion
            // 
            this.labelUbicacion.AutoSize = true;
            this.labelUbicacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUbicacion.Location = new System.Drawing.Point(10, 68);
            this.labelUbicacion.Name = "labelUbicacion";
            this.labelUbicacion.Size = new System.Drawing.Size(55, 13);
            this.labelUbicacion.TabIndex = 1;
            this.labelUbicacion.Text = "Ubicación";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(10, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNroHabitacion,
            this.ColumnPiso,
            this.ColumnUbicacion,
            this.ColumnNombreUbicacion,
            this.ColumnTipoHabitacion,
            this.ColumnIdTipoHabitacion,
            this.ColumnSeleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(9, 170);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(768, 262);
            this.dataGridView1.TabIndex = 17;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // ColumnNroHabitacion
            // 
            this.ColumnNroHabitacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNroHabitacion.HeaderText = "Nro. Habitación";
            this.ColumnNroHabitacion.Name = "ColumnNroHabitacion";
            this.ColumnNroHabitacion.ReadOnly = true;
            // 
            // ColumnPiso
            // 
            this.ColumnPiso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPiso.HeaderText = "Piso";
            this.ColumnPiso.Name = "ColumnPiso";
            this.ColumnPiso.ReadOnly = true;
            // 
            // ColumnUbicacion
            // 
            this.ColumnUbicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUbicacion.HeaderText = "Ubicación";
            this.ColumnUbicacion.Name = "ColumnUbicacion";
            this.ColumnUbicacion.ReadOnly = true;
            this.ColumnUbicacion.Visible = false;
            // 
            // ColumnNombreUbicacion
            // 
            this.ColumnNombreUbicacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNombreUbicacion.HeaderText = "Ubicación";
            this.ColumnNombreUbicacion.Name = "ColumnNombreUbicacion";
            this.ColumnNombreUbicacion.ReadOnly = true;
            // 
            // ColumnTipoHabitacion
            // 
            this.ColumnTipoHabitacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTipoHabitacion.HeaderText = "Tipo Habitación";
            this.ColumnTipoHabitacion.Name = "ColumnTipoHabitacion";
            this.ColumnTipoHabitacion.ReadOnly = true;
            this.ColumnTipoHabitacion.Visible = false;
            // 
            // ColumnIdTipoHabitacion
            // 
            this.ColumnIdTipoHabitacion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIdTipoHabitacion.HeaderText = "Tipo Habitación";
            this.ColumnIdTipoHabitacion.Name = "ColumnIdTipoHabitacion";
            this.ColumnIdTipoHabitacion.ReadOnly = true;
            // 
            // ColumnSeleccionar
            // 
            this.ColumnSeleccionar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSeleccionar.HeaderText = "Seleccionar";
            this.ColumnSeleccionar.Name = "ColumnSeleccionar";
            this.ColumnSeleccionar.ReadOnly = true;
            this.ColumnSeleccionar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSeleccionar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnSeleccionar.Text = "Seleccionar";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(686, 118);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 16;
            this.buttonSearch.Text = "Buscar";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click_1);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(21, 118);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 15;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNombreHotel);
            this.groupBox1.Controls.Add(this.comboBoxHabitacion);
            this.groupBox1.Controls.Add(this.comboBoxUbicacion);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxNroHabitacion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxPiso);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelUbicacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 99);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // textBoxNombreHotel
            // 
            this.textBoxNombreHotel.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNombreHotel.Enabled = false;
            this.textBoxNombreHotel.Location = new System.Drawing.Point(47, 31);
            this.textBoxNombreHotel.MaxLength = 18;
            this.textBoxNombreHotel.Name = "textBoxNombreHotel";
            this.textBoxNombreHotel.Size = new System.Drawing.Size(171, 20);
            this.textBoxNombreHotel.TabIndex = 20;
            this.textBoxNombreHotel.Tag = "nombreHotel";
            // 
            // listarHabitacionesFactura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 438);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "listarHabitacionesFactura";
            this.Text = "listarHabitacionesFactura";
            this.Load += new System.EventHandler(this.listarHabitacionesFactura_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxHabitacion;
        private System.Windows.Forms.ComboBox comboBoxUbicacion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNroHabitacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUbicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNroHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombreUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipoHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdTipoHabitacion;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSeleccionar;
        private System.Windows.Forms.TextBox textBoxNombreHotel;
    }
}