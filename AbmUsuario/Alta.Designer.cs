namespace FrbaHotel.AbmUsuario
{
    partial class Alta
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
            this.groupBoxUser = new System.Windows.Forms.GroupBox();
            this.comboBoxRol = new System.Windows.Forms.ComboBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDireccion = new System.Windows.Forms.GroupBox();
            this.textBoxPiso = new System.Windows.Forms.TextBox();
            this.textBoxPais = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxLocalidad = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxDepto = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxNroCalle = new System.Windows.Forms.TextBox();
            this.textBoxCalle = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBoxDatos = new System.Windows.Forms.GroupBox();
            this.dateTimePickerFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxTipoDoc = new System.Windows.Forms.ComboBox();
            this.textBoxTelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNumDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxApellido = new System.Windows.Forms.TextBox();
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.groupBoxUser.SuspendLayout();
            this.groupBoxDireccion.SuspendLayout();
            this.groupBoxDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxUser
            // 
            this.groupBoxUser.Controls.Add(this.comboBoxRol);
            this.groupBoxUser.Controls.Add(this.textBoxPassword);
            this.groupBoxUser.Controls.Add(this.textBoxUsername);
            this.groupBoxUser.Controls.Add(this.label7);
            this.groupBoxUser.Controls.Add(this.label2);
            this.groupBoxUser.Controls.Add(this.label1);
            this.groupBoxUser.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxUser.Location = new System.Drawing.Point(13, 13);
            this.groupBoxUser.Name = "groupBoxUser";
            this.groupBoxUser.Size = new System.Drawing.Size(358, 126);
            this.groupBoxUser.TabIndex = 0;
            this.groupBoxUser.TabStop = false;
            this.groupBoxUser.Text = "Datos del Usuario";
            // 
            // comboBoxRol
            // 
            this.comboBoxRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRol.FormattingEnabled = true;
            this.comboBoxRol.Location = new System.Drawing.Point(150, 90);
            this.comboBoxRol.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxRol.Name = "comboBoxRol";
            this.comboBoxRol.Size = new System.Drawing.Size(193, 21);
            this.comboBoxRol.TabIndex = 18;
            this.comboBoxRol.SelectedIndexChanged += new System.EventHandler(this.comboBoxRol_SelectedIndexChanged);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(150, 60);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPassword.MaxLength = 20;
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.PasswordChar = '*';
            this.textBoxPassword.Size = new System.Drawing.Size(193, 20);
            this.textBoxPassword.TabIndex = 18;
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxUsername.Location = new System.Drawing.Point(150, 30);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxUsername.MaxLength = 10;
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(193, 20);
            this.textBoxUsername.TabIndex = 18;
            this.textBoxUsername.TextChanged += new System.EventHandler(this.textBoxUsername_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(7, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Rol asignado";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(7, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // groupBoxDireccion
            // 
            this.groupBoxDireccion.Controls.Add(this.textBoxPiso);
            this.groupBoxDireccion.Controls.Add(this.textBoxPais);
            this.groupBoxDireccion.Controls.Add(this.label11);
            this.groupBoxDireccion.Controls.Add(this.textBoxLocalidad);
            this.groupBoxDireccion.Controls.Add(this.label12);
            this.groupBoxDireccion.Controls.Add(this.textBoxDepto);
            this.groupBoxDireccion.Controls.Add(this.label13);
            this.groupBoxDireccion.Controls.Add(this.textBoxNroCalle);
            this.groupBoxDireccion.Controls.Add(this.textBoxCalle);
            this.groupBoxDireccion.Controls.Add(this.label14);
            this.groupBoxDireccion.Controls.Add(this.label15);
            this.groupBoxDireccion.Controls.Add(this.label16);
            this.groupBoxDireccion.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxDireccion.Location = new System.Drawing.Point(13, 394);
            this.groupBoxDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxDireccion.Name = "groupBoxDireccion";
            this.groupBoxDireccion.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxDireccion.Size = new System.Drawing.Size(358, 215);
            this.groupBoxDireccion.TabIndex = 19;
            this.groupBoxDireccion.TabStop = false;
            this.groupBoxDireccion.Text = "Dirección";
            // 
            // textBoxPiso
            // 
            this.textBoxPiso.Location = new System.Drawing.Point(150, 90);
            this.textBoxPiso.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPiso.MaxLength = 18;
            this.textBoxPiso.Name = "textBoxPiso";
            this.textBoxPiso.Size = new System.Drawing.Size(193, 20);
            this.textBoxPiso.TabIndex = 13;
            // 
            // textBoxPais
            // 
            this.textBoxPais.Location = new System.Drawing.Point(150, 180);
            this.textBoxPais.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxPais.MaxLength = 60;
            this.textBoxPais.Name = "textBoxPais";
            this.textBoxPais.Size = new System.Drawing.Size(193, 20);
            this.textBoxPais.TabIndex = 12;
            this.textBoxPais.TextChanged += new System.EventHandler(this.textBoxPais_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(7, 180);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "País";
            // 
            // textBoxLocalidad
            // 
            this.textBoxLocalidad.Location = new System.Drawing.Point(150, 150);
            this.textBoxLocalidad.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxLocalidad.MaxLength = 255;
            this.textBoxLocalidad.Name = "textBoxLocalidad";
            this.textBoxLocalidad.Size = new System.Drawing.Size(193, 20);
            this.textBoxLocalidad.TabIndex = 10;
            this.textBoxLocalidad.TextChanged += new System.EventHandler(this.textBoxLocalidad_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(7, 150);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 13);
            this.label12.TabIndex = 9;
            this.label12.Text = "Localidad";
            // 
            // textBoxDepto
            // 
            this.textBoxDepto.Location = new System.Drawing.Point(150, 120);
            this.textBoxDepto.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxDepto.MaxLength = 3;
            this.textBoxDepto.Name = "textBoxDepto";
            this.textBoxDepto.Size = new System.Drawing.Size(193, 20);
            this.textBoxDepto.TabIndex = 8;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(7, 120);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Departamento";
            // 
            // textBoxNroCalle
            // 
            this.textBoxNroCalle.Location = new System.Drawing.Point(150, 60);
            this.textBoxNroCalle.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNroCalle.MaxLength = 18;
            this.textBoxNroCalle.Name = "textBoxNroCalle";
            this.textBoxNroCalle.Size = new System.Drawing.Size(193, 20);
            this.textBoxNroCalle.TabIndex = 4;
            this.textBoxNroCalle.TextChanged += new System.EventHandler(this.textBoxNroCalle_TextChanged);
            // 
            // textBoxCalle
            // 
            this.textBoxCalle.Location = new System.Drawing.Point(150, 30);
            this.textBoxCalle.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxCalle.MaxLength = 255;
            this.textBoxCalle.Name = "textBoxCalle";
            this.textBoxCalle.Size = new System.Drawing.Size(193, 20);
            this.textBoxCalle.TabIndex = 3;
            this.textBoxCalle.TextChanged += new System.EventHandler(this.textBoxCalle_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(7, 90);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(27, 13);
            this.label14.TabIndex = 2;
            this.label14.Text = "Piso";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(7, 60);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Nro. Calle";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(7, 30);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(30, 13);
            this.label16.TabIndex = 0;
            this.label16.Text = "Calle";
            // 
            // groupBoxDatos
            // 
            this.groupBoxDatos.Controls.Add(this.dateTimePickerFechaNacimiento);
            this.groupBoxDatos.Controls.Add(this.label8);
            this.groupBoxDatos.Controls.Add(this.comboBoxTipoDoc);
            this.groupBoxDatos.Controls.Add(this.textBoxTelefono);
            this.groupBoxDatos.Controls.Add(this.label6);
            this.groupBoxDatos.Controls.Add(this.textBoxMail);
            this.groupBoxDatos.Controls.Add(this.label5);
            this.groupBoxDatos.Controls.Add(this.textBoxNumDoc);
            this.groupBoxDatos.Controls.Add(this.label4);
            this.groupBoxDatos.Controls.Add(this.textBoxApellido);
            this.groupBoxDatos.Controls.Add(this.textBoxNombre);
            this.groupBoxDatos.Controls.Add(this.label3);
            this.groupBoxDatos.Controls.Add(this.label9);
            this.groupBoxDatos.Controls.Add(this.label10);
            this.groupBoxDatos.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxDatos.Location = new System.Drawing.Point(13, 144);
            this.groupBoxDatos.Margin = new System.Windows.Forms.Padding(2);
            this.groupBoxDatos.Name = "groupBoxDatos";
            this.groupBoxDatos.Padding = new System.Windows.Forms.Padding(2);
            this.groupBoxDatos.Size = new System.Drawing.Size(358, 246);
            this.groupBoxDatos.TabIndex = 20;
            this.groupBoxDatos.TabStop = false;
            this.groupBoxDatos.Text = "Datos Identificatorios";
            // 
            // dateTimePickerFechaNacimiento
            // 
            this.dateTimePickerFechaNacimiento.Location = new System.Drawing.Point(150, 210);
            this.dateTimePickerFechaNacimiento.Margin = new System.Windows.Forms.Padding(2);
            this.dateTimePickerFechaNacimiento.Name = "dateTimePickerFechaNacimiento";
            this.dateTimePickerFechaNacimiento.Size = new System.Drawing.Size(193, 20);
            this.dateTimePickerFechaNacimiento.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(7, 210);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Fecha de Nacimiento";
            // 
            // comboBoxTipoDoc
            // 
            this.comboBoxTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDoc.FormattingEnabled = true;
            this.comboBoxTipoDoc.Location = new System.Drawing.Point(150, 90);
            this.comboBoxTipoDoc.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxTipoDoc.Name = "comboBoxTipoDoc";
            this.comboBoxTipoDoc.Size = new System.Drawing.Size(193, 21);
            this.comboBoxTipoDoc.TabIndex = 13;
            this.comboBoxTipoDoc.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDoc_SelectedIndexChanged);
            // 
            // textBoxTelefono
            // 
            this.textBoxTelefono.Location = new System.Drawing.Point(150, 180);
            this.textBoxTelefono.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTelefono.MaxLength = 80;
            this.textBoxTelefono.Name = "textBoxTelefono";
            this.textBoxTelefono.Size = new System.Drawing.Size(193, 20);
            this.textBoxTelefono.TabIndex = 12;
            this.textBoxTelefono.TextChanged += new System.EventHandler(this.textBoxTelefono_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(7, 180);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Teléfono";
            // 
            // textBoxMail
            // 
            this.textBoxMail.Location = new System.Drawing.Point(150, 150);
            this.textBoxMail.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxMail.MaxLength = 255;
            this.textBoxMail.Name = "textBoxMail";
            this.textBoxMail.Size = new System.Drawing.Size(193, 20);
            this.textBoxMail.TabIndex = 10;
            this.textBoxMail.TextChanged += new System.EventHandler(this.textBoxMail_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(7, 150);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mail";
            // 
            // textBoxNumDoc
            // 
            this.textBoxNumDoc.Location = new System.Drawing.Point(150, 120);
            this.textBoxNumDoc.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNumDoc.MaxLength = 20;
            this.textBoxNumDoc.Name = "textBoxNumDoc";
            this.textBoxNumDoc.Size = new System.Drawing.Size(193, 20);
            this.textBoxNumDoc.TabIndex = 8;
            this.textBoxNumDoc.TextChanged += new System.EventHandler(this.textBoxNumDoc_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(7, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Número de Documento";
            // 
            // textBoxApellido
            // 
            this.textBoxApellido.Location = new System.Drawing.Point(150, 60);
            this.textBoxApellido.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxApellido.MaxLength = 82;
            this.textBoxApellido.Name = "textBoxApellido";
            this.textBoxApellido.Size = new System.Drawing.Size(193, 20);
            this.textBoxApellido.TabIndex = 4;
            this.textBoxApellido.TextChanged += new System.EventHandler(this.textBoxApellido_TextChanged);
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(150, 30);
            this.textBoxNombre.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxNombre.MaxLength = 82;
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(193, 20);
            this.textBoxNombre.TabIndex = 3;
            this.textBoxNombre.TextChanged += new System.EventHandler(this.textBoxNombre_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(7, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tipo de Documento";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(7, 60);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Apellido";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(7, 30);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Nombre";
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonGuardar.Location = new System.Drawing.Point(296, 616);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 22;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.buttonLimpiar.Location = new System.Drawing.Point(14, 616);
            this.buttonLimpiar.Margin = new System.Windows.Forms.Padding(5);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 21;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 649);
            this.Controls.Add(this.buttonGuardar);
            this.Controls.Add(this.buttonLimpiar);
            this.Controls.Add(this.groupBoxDatos);
            this.Controls.Add(this.groupBoxDireccion);
            this.Controls.Add(this.groupBoxUser);
            this.Name = "Alta";
            this.Text = "Alta";
            this.Load += new System.EventHandler(this.Alta_Load);
            this.groupBoxUser.ResumeLayout(false);
            this.groupBoxUser.PerformLayout();
            this.groupBoxDireccion.ResumeLayout(false);
            this.groupBoxDireccion.PerformLayout();
            this.groupBoxDatos.ResumeLayout(false);
            this.groupBoxDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxDireccion;
        private System.Windows.Forms.TextBox textBoxPiso;
        private System.Windows.Forms.TextBox textBoxPais;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxLocalidad;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxDepto;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxNroCalle;
        private System.Windows.Forms.TextBox textBoxCalle;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBoxDatos;
        private System.Windows.Forms.DateTimePicker dateTimePickerFechaNacimiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxTipoDoc;
        private System.Windows.Forms.TextBox textBoxTelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNumDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxApellido;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxRol;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonLimpiar;
    }
}