namespace FrbaHotel.AbmHabitacion
{
    partial class ListadoSeleccion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxHotel = new System.Windows.Forms.ComboBox();
            this.comboBoxHabitacion = new System.Windows.Forms.ComboBox();
            this.comboBoxUbicacion = new System.Windows.Forms.ComboBox();
            this.textBoxcomodidades = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxNroHabitacion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxDescripcion = new System.Windows.Forms.TextBox();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNombreHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNroHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNombreUbicacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTipoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIdTipoHabitacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComodidades = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHabilitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSeleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxHotel);
            this.groupBox1.Controls.Add(this.comboBoxHabitacion);
            this.groupBox1.Controls.Add(this.comboBoxUbicacion);
            this.groupBox1.Controls.Add(this.textBoxcomodidades);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.textBoxNroHabitacion);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxDescripcion);
            this.groupBox1.Controls.Add(this.textBoxPiso);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelUbicacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 138);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            // 
            // comboBoxHotel
            // 
            this.comboBoxHotel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHotel.FormattingEnabled = true;
            this.comboBoxHotel.Location = new System.Drawing.Point(46, 29);
            this.comboBoxHotel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxHotel.Name = "comboBoxHotel";
            this.comboBoxHotel.Size = new System.Drawing.Size(164, 21);
            this.comboBoxHotel.TabIndex = 20;
            this.comboBoxHotel.Tag = "idHotel";
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
            // textBoxcomodidades
            // 
            this.textBoxcomodidades.Location = new System.Drawing.Point(87, 104);
            this.textBoxcomodidades.MaxLength = 255;
            this.textBoxcomodidades.Name = "textBoxcomodidades";
            this.textBoxcomodidades.Size = new System.Drawing.Size(195, 20);
            this.textBoxcomodidades.TabIndex = 15;
            this.textBoxcomodidades.Tag = "comodidades";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(10, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Comodidades";
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
            // textBoxDescripcion
            // 
            this.textBoxDescripcion.Location = new System.Drawing.Point(470, 104);
            this.textBoxDescripcion.MaxLength = 255;
            this.textBoxDescripcion.Name = "textBoxDescripcion";
            this.textBoxDescripcion.Size = new System.Drawing.Size(206, 20);
            this.textBoxDescripcion.TabIndex = 7;
            this.textBoxDescripcion.Tag = "descripcion";
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(403, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripción";
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
            this.label1.Location = new System.Drawing.Point(10, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hotel";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(687, 161);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 10;
            this.buttonSearch.Text = "Buscar";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(21, 161);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 9;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idHotel,
            this.ColumnNombreHotel,
            this.ColumnNroHabitacion,
            this.ColumnPiso,
            this.ColumnUbicacion,
            this.ColumnNombreUbicacion,
            this.ColumnTipoHabitacion,
            this.ColumnIdTipoHabitacion,
            this.ColumnDescripcion,
            this.ColumnComodidades,
            this.ColumnHabilitado,
            this.ColumnSeleccionar});
            this.dataGridView1.Location = new System.Drawing.Point(9, 213);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(768, 262);
            this.dataGridView1.TabIndex = 13;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // idHotel
            // 
            this.idHotel.HeaderText = "idHotel";
            this.idHotel.Name = "idHotel";
            this.idHotel.ReadOnly = true;
            this.idHotel.Visible = false;
            // 
            // ColumnNombreHotel
            // 
            this.ColumnNombreHotel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNombreHotel.HeaderText = "Hotel";
            this.ColumnNombreHotel.Name = "ColumnNombreHotel";
            this.ColumnNombreHotel.ReadOnly = true;
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
            // ColumnDescripcion
            // 
            this.ColumnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDescripcion.HeaderText = "Descripción";
            this.ColumnDescripcion.Name = "ColumnDescripcion";
            this.ColumnDescripcion.ReadOnly = true;
            // 
            // ColumnComodidades
            // 
            this.ColumnComodidades.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComodidades.HeaderText = "Comodidades";
            this.ColumnComodidades.Name = "ColumnComodidades";
            this.ColumnComodidades.ReadOnly = true;
            // 
            // ColumnHabilitado
            // 
            this.ColumnHabilitado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnHabilitado.HeaderText = "Habilitado";
            this.ColumnHabilitado.Name = "ColumnHabilitado";
            this.ColumnHabilitado.ReadOnly = true;
            this.ColumnHabilitado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnHabilitado.Visible = false;
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
            // ListadoSeleccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 484);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ListadoSeleccion";
            this.Text = "ListadoModificacionBaja";
            this.Load += new System.EventHandler(this.ListadoSeleccion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxcomodidades;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxNroHabitacion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxDescripcion;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUbicacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxUbicacion;
        private System.Windows.Forms.ComboBox comboBoxHabitacion;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBoxHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombreHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNroHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombreUbicacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTipoHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdTipoHabitacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComodidades;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHabilitado;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnSeleccionar;
    }
}