namespace FrbaHotel
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageRoles = new System.Windows.Forms.TabPage();
            this.tabPageHoteles = new System.Windows.Forms.TabPage();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarContraseñaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageUsuarios = new System.Windows.Forms.TabPage();
            this.tabPageHuespedes = new System.Windows.Forms.TabPage();
            this.tabPageReservas = new System.Windows.Forms.TabPage();
            this.tabPageEstadias = new System.Windows.Forms.TabPage();
            this.tabPageEstadistica = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageRoles);
            this.tabControl1.Controls.Add(this.tabPageHoteles);
            this.tabControl1.Controls.Add(this.tabPageUsuarios);
            this.tabControl1.Controls.Add(this.tabPageHuespedes);
            this.tabControl1.Controls.Add(this.tabPageReservas);
            this.tabControl1.Controls.Add(this.tabPageEstadias);
            this.tabControl1.Controls.Add(this.tabPageEstadistica);
            this.tabControl1.Location = new System.Drawing.Point(0, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1330, 643);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageRoles
            // 
            this.tabPageRoles.Location = new System.Drawing.Point(4, 31);
            this.tabPageRoles.Name = "tabPageRoles";
            this.tabPageRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRoles.Size = new System.Drawing.Size(1322, 608);
            this.tabPageRoles.TabIndex = 0;
            this.tabPageRoles.Text = "Roles";
            this.tabPageRoles.UseVisualStyleBackColor = true;
            // 
            // tabPageHoteles
            // 
            this.tabPageHoteles.Location = new System.Drawing.Point(4, 31);
            this.tabPageHoteles.Name = "tabPageHoteles";
            this.tabPageHoteles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHoteles.Size = new System.Drawing.Size(1322, 608);
            this.tabPageHoteles.TabIndex = 1;
            this.tabPageHoteles.Text = "Hoteles";
            this.tabPageHoteles.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.usuarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1330, 38);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(95, 34);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarContraseñaToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(95, 34);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // cambiarContraseñaToolStripMenuItem
            // 
            this.cambiarContraseñaToolStripMenuItem.Name = "cambiarContraseñaToolStripMenuItem";
            this.cambiarContraseñaToolStripMenuItem.Size = new System.Drawing.Size(274, 34);
            this.cambiarContraseñaToolStripMenuItem.Text = "Cambiar Contraseña";
            this.cambiarContraseñaToolStripMenuItem.Click += new System.EventHandler(this.cambiarContraseñaToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(152, 34);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // tabPageUsuarios
            // 
            this.tabPageUsuarios.Location = new System.Drawing.Point(4, 31);
            this.tabPageUsuarios.Name = "tabPageUsuarios";
            this.tabPageUsuarios.Size = new System.Drawing.Size(1322, 608);
            this.tabPageUsuarios.TabIndex = 2;
            this.tabPageUsuarios.Text = "Usuarios";
            this.tabPageUsuarios.UseVisualStyleBackColor = true;
            // 
            // tabPageHuespedes
            // 
            this.tabPageHuespedes.Location = new System.Drawing.Point(4, 31);
            this.tabPageHuespedes.Name = "tabPageHuespedes";
            this.tabPageHuespedes.Size = new System.Drawing.Size(1322, 608);
            this.tabPageHuespedes.TabIndex = 3;
            this.tabPageHuespedes.Text = "Huespedes";
            this.tabPageHuespedes.UseVisualStyleBackColor = true;
            // 
            // tabPageReservas
            // 
            this.tabPageReservas.Location = new System.Drawing.Point(4, 31);
            this.tabPageReservas.Name = "tabPageReservas";
            this.tabPageReservas.Size = new System.Drawing.Size(1322, 608);
            this.tabPageReservas.TabIndex = 4;
            this.tabPageReservas.Text = "Reservas";
            this.tabPageReservas.UseVisualStyleBackColor = true;
            // 
            // tabPageEstadias
            // 
            this.tabPageEstadias.Location = new System.Drawing.Point(4, 31);
            this.tabPageEstadias.Name = "tabPageEstadias";
            this.tabPageEstadias.Size = new System.Drawing.Size(1322, 608);
            this.tabPageEstadias.TabIndex = 5;
            this.tabPageEstadias.Text = "Estadias";
            this.tabPageEstadias.UseVisualStyleBackColor = true;
            // 
            // tabPageEstadistica
            // 
            this.tabPageEstadistica.Location = new System.Drawing.Point(4, 31);
            this.tabPageEstadistica.Name = "tabPageEstadistica";
            this.tabPageEstadistica.Size = new System.Drawing.Size(1322, 608);
            this.tabPageEstadistica.TabIndex = 6;
            this.tabPageEstadistica.Text = "Estadistica";
            this.tabPageEstadistica.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 683);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FRBA Hotel";
            this.tabControl1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
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
    }
}