namespace FrbaHotel.AbmUsuario
{
    partial class Listado
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
            this.dataGridViewUsuarios = new System.Windows.Forms.DataGridView();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.buttonBuscarHotel = new System.Windows.Forms.Button();
            this.textBoxHotel = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.checkBoxHabilitado = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNumDoc = new System.Windows.Forms.TextBox();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hotelUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NroCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaNacimiento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Modificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Eliminar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).BeginInit();
            this.groupBoxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewUsuarios
            // 
            this.dataGridViewUsuarios.AllowUserToAddRows = false;
            this.dataGridViewUsuarios.AllowUserToDeleteRows = false;
            this.dataGridViewUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUsuario,
            this.Username,
            this.Rol,
            this.idHotel,
            this.hotelUser,
            this.Nombre,
            this.Apellido,
            this.TipoDocumento,
            this.NumeroDocumento,
            this.Mail,
            this.Telefono,
            this.Calle,
            this.NroCalle,
            this.Localidad,
            this.Pais,
            this.FechaNacimiento,
            this.Habilitado,
            this.Modificar,
            this.Eliminar});
            this.dataGridViewUsuarios.Location = new System.Drawing.Point(11, 196);
            this.dataGridViewUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewUsuarios.Name = "dataGridViewUsuarios";
            this.dataGridViewUsuarios.ReadOnly = true;
            this.dataGridViewUsuarios.RowTemplate.Height = 28;
            this.dataGridViewUsuarios.Size = new System.Drawing.Size(1242, 304);
            this.dataGridViewUsuarios.TabIndex = 31;
            this.dataGridViewUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuarios_CellContentClick);
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(857, 127);
            this.buttonBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(56, 32);
            this.buttonBuscar.TabIndex = 30;
            this.buttonBuscar.Text = "Buscar";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.Location = new System.Drawing.Point(18, 127);
            this.buttonLimpiar.Margin = new System.Windows.Forms.Padding(2);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(55, 32);
            this.buttonLimpiar.TabIndex = 29;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.buttonBuscarHotel);
            this.groupBoxFiltros.Controls.Add(this.textBoxHotel);
            this.groupBoxFiltros.Controls.Add(this.label17);
            this.groupBoxFiltros.Controls.Add(this.checkBoxHabilitado);
            this.groupBoxFiltros.Controls.Add(this.label8);
            this.groupBoxFiltros.Controls.Add(this.comboBoxRol);
            this.groupBoxFiltros.Controls.Add(this.label6);
            this.groupBoxFiltros.Controls.Add(this.textBoxUsername);
            this.groupBoxFiltros.Controls.Add(this.label7);
            this.groupBoxFiltros.Controls.Add(this.comboBoxTipoDoc);
            this.groupBoxFiltros.Controls.Add(this.label5);
            this.groupBoxFiltros.Controls.Add(this.textBoxApellido);
            this.groupBoxFiltros.Controls.Add(this.label4);
            this.groupBoxFiltros.Controls.Add(this.textBoxNumDoc);
            this.groupBoxFiltros.Controls.Add(this.textBoxMail);
            this.groupBoxFiltros.Controls.Add(this.label2);
            this.groupBoxFiltros.Controls.Add(this.label3);
            this.groupBoxFiltros.Controls.Add(this.textBoxNombre);
            this.groupBoxFiltros.Controls.Add(this.label1);
            this.groupBoxFiltros.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxFiltros.Location = new System.Drawing.Point(11, 11);
            this.groupBoxFiltros.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxFiltros.Size = new System.Drawing.Size(1242, 103);
            this.groupBoxFiltros.TabIndex = 28;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de búsqueda";
            // 
            // buttonBuscarHotel
            // 
            this.buttonBuscarHotel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonBuscarHotel.Location = new System.Drawing.Point(858, 64);
            this.buttonBuscarHotel.Name = "buttonBuscarHotel";
            this.buttonBuscarHotel.Size = new System.Drawing.Size(75, 23);
            this.buttonBuscarHotel.TabIndex = 26;
            this.buttonBuscarHotel.Text = "Buscar";
            this.buttonBuscarHotel.UseVisualStyleBackColor = true;
            this.buttonBuscarHotel.Click += new System.EventHandler(this.buttonBuscarHotel_Click);
            // 
            // textBoxHotel
            // 
            this.textBoxHotel.Enabled = false;
            this.textBoxHotel.Location = new System.Drawing.Point(651, 66);
            this.textBoxHotel.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxHotel.MaxLength = 20;
            this.textBoxHotel.Name = "textBoxHotel";
            this.textBoxHotel.ReadOnly = true;
            this.textBoxHotel.Size = new System.Drawing.Size(193, 20);
            this.textBoxHotel.TabIndex = 25;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(597, 69);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "Hotel";
            // 
            // checkBoxHabilitado
            // 
            this.checkBoxHabilitado.AutoSize = true;
            this.checkBoxHabilitado.Checked = true;
            this.checkBoxHabilitado.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.checkBoxHabilitado.Location = new System.Drawing.Point(85, 72);
            this.checkBoxHabilitado.Name = "checkBoxHabilitado";
            this.checkBoxHabilitado.Size = new System.Drawing.Size(15, 14);
            this.checkBoxHabilitado.TabIndex = 22;
            this.checkBoxHabilitado.ThreeState = true;
            this.checkBoxHabilitado.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(13, 72);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Habilitado";
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(85, 45);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(146, 21);
            this.comboBoxRol.TabIndex = 14;
            this.comboBoxRol.Tag = "idRol";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(12, 45);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Rol";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(85, 17);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUsername.MaxLength = 255;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(149, 20);
            this.textBoxUsername.TabIndex = 12;
            this.textBoxUsername.Tag = "username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(12, 20);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Username";
            // 
            // comboBoxTipoDoc
            // 
            this.comboBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDoc.FormattingEnabled = true;
            this.comboBoxTipoDoc.Location = new System.Drawing.Point(714, 11);
            this.comboBoxTipoDoc.Name = "comboBoxTipoDoc";
            this.comboBoxTipoDoc.Size = new System.Drawing.Size(146, 21);
            this.comboBoxTipoDoc.TabIndex = 10;
            this.comboBoxTipoDoc.Tag = "idTipoDocumento";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(333, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Apellido";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(406, 38);
            this.textBoxApellido.MaxLength = 255;
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(149, 20);
            this.textBoxApellido.TabIndex = 8;
            this.textBoxApellido.Tag = "apellido";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(593, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tipo de Documento";
            // 
            // textBoxNumDoc
            // 
            this.textBoxNumDoc.Location = new System.Drawing.Point(714, 38);
            this.textBoxNumDoc.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumDoc.MaxLength = 18;
            this.textBoxNumDoc.Name = "textBoxNumDoc";
            this.textBoxNumDoc.Size = new System.Drawing.Size(146, 20);
            this.textBoxNumDoc.TabIndex = 3;
            this.textBoxNumDoc.Tag = "numeroDocumento";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(406, 65);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMail.MaxLength = 255;
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(149, 20);
            this.textBoxMail.TabIndex = 5;
            this.textBoxMail.Tag = "mail";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(593, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Número de Documento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(333, 65);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mail";
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(406, 12);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNombre.MaxLength = 255;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(149, 20);
            this.textBoxNombre.TabIndex = 1;
            this.textBoxNombre.Tag = "nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(333, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // idUsuario
            // 
            this.idUsuario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.idUsuario.HeaderText = "idUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            this.idUsuario.Width = 5;
            // 
            // Username
            // 
            this.Username.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Username.HeaderText = "Username";
            this.Username.Name = "Username";
            this.Username.ReadOnly = true;
            this.Username.Width = 75;
            // 
            // Rol
            // 
            this.Rol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Rol.HeaderText = "Rol";
            this.Rol.Name = "Rol";
            this.Rol.ReadOnly = true;
            this.Rol.Width = 48;
            // 
            // idHotel
            // 
            this.idHotel.HeaderText = "idHotel";
            this.idHotel.Name = "idHotel";
            this.idHotel.ReadOnly = true;
            this.idHotel.Width = 65;
            // 
            // hotelUser
            // 
            this.hotelUser.HeaderText = "Hotel";
            this.hotelUser.Name = "hotelUser";
            this.hotelUser.ReadOnly = true;
            this.hotelUser.Width = 57;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 69;
            // 
            // Apellido
            // 
            this.Apellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Apellido.FillWeight = 200F;
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            this.Apellido.ReadOnly = true;
            this.Apellido.Width = 69;
            // 
            // TipoDocumento
            // 
            this.TipoDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.TipoDocumento.HeaderText = "Tipo de Documento";
            this.TipoDocumento.Name = "TipoDocumento";
            this.TipoDocumento.ReadOnly = true;
            this.TipoDocumento.Width = 75;
            // 
            // NumeroDocumento
            // 
            this.NumeroDocumento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumeroDocumento.HeaderText = "Número de Documento";
            this.NumeroDocumento.Name = "NumeroDocumento";
            this.NumeroDocumento.ReadOnly = true;
            this.NumeroDocumento.Width = 90;
            // 
            // Mail
            // 
            this.Mail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Mail.FillWeight = 200F;
            this.Mail.HeaderText = "Mail";
            this.Mail.Name = "Mail";
            this.Mail.ReadOnly = true;
            this.Mail.Width = 51;
            // 
            // Telefono
            // 
            this.Telefono.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Telefono.HeaderText = "Teléfono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 74;
            // 
            // Calle
            // 
            this.Calle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Calle.HeaderText = "Calle";
            this.Calle.Name = "Calle";
            this.Calle.ReadOnly = true;
            this.Calle.Width = 55;
            // 
            // NroCalle
            // 
            this.NroCalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NroCalle.HeaderText = "Nro. de Calle";
            this.NroCalle.Name = "NroCalle";
            this.NroCalle.ReadOnly = true;
            this.NroCalle.Width = 86;
            // 
            // Localidad
            // 
            this.Localidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Localidad.HeaderText = "Localidad";
            this.Localidad.Name = "Localidad";
            this.Localidad.ReadOnly = true;
            this.Localidad.Width = 78;
            // 
            // Pais
            // 
            this.Pais.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Pais.HeaderText = "País";
            this.Pais.Name = "Pais";
            this.Pais.ReadOnly = true;
            this.Pais.Width = 54;
            // 
            // FechaNacimiento
            // 
            this.FechaNacimiento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.FechaNacimiento.HeaderText = "Fecha de Nacimiento";
            this.FechaNacimiento.Name = "FechaNacimiento";
            this.FechaNacimiento.ReadOnly = true;
            this.FechaNacimiento.Width = 110;
            // 
            // Habilitado
            // 
            this.Habilitado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Habilitado.HeaderText = "Habilitado";
            this.Habilitado.Name = "Habilitado";
            this.Habilitado.ReadOnly = true;
            this.Habilitado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Habilitado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Habilitado.Width = 60;
            // 
            // Modificar
            // 
            this.Modificar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Modificar.HeaderText = "Modificar";
            this.Modificar.Name = "Modificar";
            this.Modificar.ReadOnly = true;
            this.Modificar.Text = "Modificar";
            this.Modificar.Width = 56;
            // 
            // Eliminar
            // 
            this.Eliminar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Eliminar.HeaderText = "Eliminar";
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.ReadOnly = true;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.Width = 49;
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 511);
            this.Controls.Add(this.dataGridViewUsuarios);
            this.Controls.Add(this.buttonBuscar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.groupBoxFiltros);
            this.Name = "Listado";
            this.Text = "Listado";
            this.Load += new System.EventHandler(this.Listado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuarios)).EndInit();
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewUsuarios;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.Button buttonLimpiar;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.ComboBox comboBoxTipoDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNumDoc;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxHabilitado;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonBuscarHotel;
        private System.Windows.Forms.TextBox textBoxHotel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Username;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rol;
        private System.Windows.Forms.DataGridViewTextBoxColumn idHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn hotelUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNacimiento;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Habilitado;
        private System.Windows.Forms.DataGridViewButtonColumn Modificar;
        private System.Windows.Forms.DataGridViewButtonColumn Eliminar;
    }
}