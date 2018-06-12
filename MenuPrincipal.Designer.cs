﻿namespace FrbaHotel
{
    partial class MenuPrincipal
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
            this.tabControlFunciones = new System.Windows.Forms.TabControl();
            this.tabPageRoles = new System.Windows.Forms.TabPage();
            this.tabPageHoteles = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonLaunchHotelManager = new System.Windows.Forms.Button();
            this.tabPageUsuarios = new System.Windows.Forms.TabPage();
            this.tabPageHuespedes = new System.Windows.Forms.TabPage();
            this.tabPageReservas = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonModificar = new System.Windows.Forms.Button();
            this.buttonGenerar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPageEstadias = new System.Windows.Forms.TabPage();
            this.buttonCheckin = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPageEstadistica = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarHotelActualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControlFunciones.SuspendLayout();
            this.tabPageHoteles.SuspendLayout();
            this.tabPageReservas.SuspendLayout();
            this.tabPageEstadias.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlFunciones
            // 
            this.tabControlFunciones.Controls.Add(this.tabPageRoles);
            this.tabControlFunciones.Controls.Add(this.tabPageHoteles);
            this.tabControlFunciones.Controls.Add(this.tabPageUsuarios);
            this.tabControlFunciones.Controls.Add(this.tabPageHuespedes);
            this.tabControlFunciones.Controls.Add(this.tabPageReservas);
            this.tabControlFunciones.Controls.Add(this.tabPageEstadias);
            this.tabControlFunciones.Controls.Add(this.tabPageEstadistica);
            this.tabControlFunciones.Location = new System.Drawing.Point(0, 24);
            this.tabControlFunciones.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControlFunciones.Name = "tabControlFunciones";
            this.tabControlFunciones.SelectedIndex = 0;
            this.tabControlFunciones.Size = new System.Drawing.Size(586, 180);
            this.tabControlFunciones.TabIndex = 0;
            // 
            // tabPageRoles
            // 
            this.tabPageRoles.Location = new System.Drawing.Point(4, 22);
            this.tabPageRoles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageRoles.Name = "tabPageRoles";
            this.tabPageRoles.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageRoles.Size = new System.Drawing.Size(578, 154);
            this.tabPageRoles.TabIndex = 0;
            this.tabPageRoles.Text = "Roles";
            this.tabPageRoles.UseVisualStyleBackColor = true;
            // 
            // tabPageHoteles
            // 
            this.tabPageHoteles.Controls.Add(this.label3);
            this.tabPageHoteles.Controls.Add(this.buttonEdit);
            this.tabPageHoteles.Controls.Add(this.label2);
            this.tabPageHoteles.Controls.Add(this.label1);
            this.tabPageHoteles.Controls.Add(this.buttonLaunchHotelManager);
            this.tabPageHoteles.Location = new System.Drawing.Point(4, 22);
            this.tabPageHoteles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageHoteles.Name = "tabPageHoteles";
            this.tabPageHoteles.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageHoteles.Size = new System.Drawing.Size(578, 154);
            this.tabPageHoteles.TabIndex = 1;
            this.tabPageHoteles.Text = "Hoteles";
            this.tabPageHoteles.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 122);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(277, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Para modificar / eliminar hoteles de la cadena haga click:";
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(299, 118);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(76, 22);
            this.buttonEdit.TabIndex = 3;
            this.buttonEdit.Text = "Administrar";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(249, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Para añadir un nuevo hotel a la cadena haga click:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Añadir, modificar o eliminar hoteles de la cadena";
            // 
            // buttonLaunchHotelManager
            // 
            this.buttonLaunchHotelManager.Location = new System.Drawing.Point(268, 74);
            this.buttonLaunchHotelManager.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLaunchHotelManager.Name = "buttonLaunchHotelManager";
            this.buttonLaunchHotelManager.Size = new System.Drawing.Size(76, 22);
            this.buttonLaunchHotelManager.TabIndex = 0;
            this.buttonLaunchHotelManager.Text = "Administrar";
            this.buttonLaunchHotelManager.UseVisualStyleBackColor = true;
            this.buttonLaunchHotelManager.Click += new System.EventHandler(this.buttonLaunchHotelManager_Click);
            // 
            // tabPageUsuarios
            // 
            this.tabPageUsuarios.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsuarios.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageUsuarios.Name = "tabPageUsuarios";
            this.tabPageUsuarios.Size = new System.Drawing.Size(578, 154);
            this.tabPageUsuarios.TabIndex = 2;
            this.tabPageUsuarios.Text = "Usuarios";
            this.tabPageUsuarios.UseVisualStyleBackColor = true;
            // 
            // tabPageHuespedes
            // 
            this.tabPageHuespedes.Location = new System.Drawing.Point(4, 22);
            this.tabPageHuespedes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageHuespedes.Name = "tabPageHuespedes";
            this.tabPageHuespedes.Size = new System.Drawing.Size(578, 154);
            this.tabPageHuespedes.TabIndex = 3;
            this.tabPageHuespedes.Text = "Huespedes";
            this.tabPageHuespedes.UseVisualStyleBackColor = true;
            // 
            // tabPageReservas
            // 
            this.tabPageReservas.Controls.Add(this.label7);
            this.tabPageReservas.Controls.Add(this.buttonModificar);
            this.tabPageReservas.Controls.Add(this.buttonGenerar);
            this.tabPageReservas.Controls.Add(this.label5);
            this.tabPageReservas.Controls.Add(this.label4);
            this.tabPageReservas.Location = new System.Drawing.Point(4, 22);
            this.tabPageReservas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageReservas.Name = "tabPageReservas";
            this.tabPageReservas.Size = new System.Drawing.Size(578, 154);
            this.tabPageReservas.TabIndex = 4;
            this.tabPageReservas.Text = "Reservas";
            this.tabPageReservas.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(266, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Para modificar o cancelar una reserva haga click aquí:";
            // 
            // buttonModificar
            // 
            this.buttonModificar.Location = new System.Drawing.Point(291, 113);
            this.buttonModificar.Name = "buttonModificar";
            this.buttonModificar.Size = new System.Drawing.Size(75, 23);
            this.buttonModificar.TabIndex = 4;
            this.buttonModificar.Text = "Administrar";
            this.buttonModificar.UseVisualStyleBackColor = true;
            this.buttonModificar.Click += new System.EventHandler(this.buttonModificar_Click);
            // 
            // buttonGenerar
            // 
            this.buttonGenerar.Location = new System.Drawing.Point(291, 66);
            this.buttonGenerar.Name = "buttonGenerar";
            this.buttonGenerar.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerar.TabIndex = 3;
            this.buttonGenerar.Text = "Administrar";
            this.buttonGenerar.UseVisualStyleBackColor = true;
            this.buttonGenerar.Click += new System.EventHandler(this.buttonGenerar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Para generar una reserva haga click aquí: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(89, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(415, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Generar, modificar o cancelar una reserva";
            // 
            // tabPageEstadias
            // 
            this.tabPageEstadias.Controls.Add(this.buttonCheckin);
            this.tabPageEstadias.Controls.Add(this.label9);
            this.tabPageEstadias.Controls.Add(this.label8);
            this.tabPageEstadias.Location = new System.Drawing.Point(4, 22);
            this.tabPageEstadias.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageEstadias.Name = "tabPageEstadias";
            this.tabPageEstadias.Size = new System.Drawing.Size(578, 154);
            this.tabPageEstadias.TabIndex = 5;
            this.tabPageEstadias.Text = "Estadias";
            this.tabPageEstadias.UseVisualStyleBackColor = true;
            // 
            // buttonCheckin
            // 
            this.buttonCheckin.Location = new System.Drawing.Point(188, 56);
            this.buttonCheckin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonCheckin.Name = "buttonCheckin";
            this.buttonCheckin.Size = new System.Drawing.Size(76, 22);
            this.buttonCheckin.TabIndex = 4;
            this.buttonCheckin.Text = "Check-In";
            this.buttonCheckin.UseVisualStyleBackColor = true;
            this.buttonCheckin.Click += new System.EventHandler(this.buttonCheckIn_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 60);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(173, 13);
            this.label9.TabIndex = 3;
            this.label9.Text = "Para hacer un check-in haga click:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(175, 15);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(228, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Check-Ins y Check-Outs";
            // 
            // tabPageEstadistica
            // 
            this.tabPageEstadistica.Location = new System.Drawing.Point(4, 22);
            this.tabPageEstadistica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabPageEstadistica.Name = "tabPageEstadistica";
            this.tabPageEstadistica.Size = new System.Drawing.Size(578, 154);
            this.tabPageEstadistica.TabIndex = 6;
            this.tabPageEstadistica.Text = "Estadistica";
            this.tabPageEstadistica.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(586, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 22);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarContraseñaToolStripMenuItem,
            this.cambiarHotelActualToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(59, 22);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // cambiarHotelActualToolStripMenuItem
            // 
            this.cambiarHotelActualToolStripMenuItem.Name = "cambiarHotelActualToolStripMenuItem";
            this.cambiarHotelActualToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.cambiarHotelActualToolStripMenuItem.Text = "Cambiar Hotel Actual";
            this.cambiarHotelActualToolStripMenuItem.Click += new System.EventHandler(this.cambiarHotelActualToolStripMenuItem_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 203);
            this.Controls.Add(this.tabControlFunciones);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FRBA Hotel";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.tabControlFunciones.ResumeLayout(false);
            this.tabPageHoteles.ResumeLayout(false);
            this.tabPageHoteles.PerformLayout();
            this.tabPageReservas.ResumeLayout(false);
            this.tabPageReservas.PerformLayout();
            this.tabPageEstadias.ResumeLayout(false);
            this.tabPageEstadias.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlFunciones;
        private System.Windows.Forms.TabPage tabPageRoles;
        private System.Windows.Forms.TabPage tabPageHoteles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarContraseñaToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPageUsuarios;
        private System.Windows.Forms.TabPage tabPageHuespedes;
        private System.Windows.Forms.TabPage tabPageReservas;
        private System.Windows.Forms.TabPage tabPageEstadias;
        private System.Windows.Forms.TabPage tabPageEstadistica;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonLaunchHotelManager;
        private System.Windows.Forms.ToolStripMenuItem cambiarHotelActualToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonEdit;

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonModificar;
        private System.Windows.Forms.Button buttonGenerar;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonCheckin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}