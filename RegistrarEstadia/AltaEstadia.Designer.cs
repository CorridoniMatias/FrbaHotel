namespace FrbaHotel.RegistrarEstadia
{
    partial class AltaEstadia
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxHuespuedes = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxHuespedes = new System.Windows.Forms.ListBox();
            this.textBoxReserva = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonCheckin = new System.Windows.Forms.Button();
            this.labelCuposFull = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelCuposFull);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBoxHuespuedes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.listBoxHuespedes);
            this.groupBox1.Controls.Add(this.textBoxReserva);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(544, 630);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos para check-in";
            // 
            // button2
            // 
            this.button2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button2.Location = new System.Drawing.Point(381, 563);
            this.button2.Margin = new System.Windows.Forms.Padding(5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 39);
            this.button2.TabIndex = 11;
            this.button2.Text = "Nuevo Cliente";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(202, 563);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Buscar Cliente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxHuespuedes
            // 
            this.textBoxHuespuedes.Enabled = false;
            this.textBoxHuespuedes.Location = new System.Drawing.Point(236, 133);
            this.textBoxHuespuedes.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxHuespuedes.MaxLength = 82;
            this.textBoxHuespuedes.Name = "textBoxHuespuedes";
            this.textBoxHuespuedes.ReadOnly = true;
            this.textBoxHuespuedes.Size = new System.Drawing.Size(285, 28);
            this.textBoxHuespuedes.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(12, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(214, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cantidad de Huespedes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(10, 189);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Huespedes";
            // 
            // listBoxHuespedes
            // 
            this.listBoxHuespedes.FormattingEnabled = true;
            this.listBoxHuespedes.ItemHeight = 22;
            this.listBoxHuespedes.Location = new System.Drawing.Point(202, 189);
            this.listBoxHuespedes.Name = "listBoxHuespedes";
            this.listBoxHuespedes.Size = new System.Drawing.Size(319, 356);
            this.listBoxHuespedes.TabIndex = 7;
            // 
            // textBoxReserva
            // 
            this.textBoxReserva.Enabled = false;
            this.textBoxReserva.Location = new System.Drawing.Point(202, 81);
            this.textBoxReserva.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxReserva.MaxLength = 82;
            this.textBoxReserva.Name = "textBoxReserva";
            this.textBoxReserva.ReadOnly = true;
            this.textBoxReserva.Size = new System.Drawing.Size(319, 28);
            this.textBoxReserva.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Reserva";
            // 
            // buttonCheckin
            // 
            this.buttonCheckin.Location = new System.Drawing.Point(433, 664);
            this.buttonCheckin.Margin = new System.Windows.Forms.Padding(5);
            this.buttonCheckin.Name = "buttonCheckin";
            this.buttonCheckin.Size = new System.Drawing.Size(125, 39);
            this.buttonCheckin.TabIndex = 7;
            this.buttonCheckin.Text = "Check-In";
            this.buttonCheckin.UseVisualStyleBackColor = true;
            this.buttonCheckin.Click += new System.EventHandler(this.buttonCheckin_Click);
            // 
            // labelCuposFull
            // 
            this.labelCuposFull.AutoSize = true;
            this.labelCuposFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.950921F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCuposFull.ForeColor = System.Drawing.SystemColors.Desktop;
            this.labelCuposFull.Location = new System.Drawing.Point(12, 571);
            this.labelCuposFull.Name = "labelCuposFull";
            this.labelCuposFull.Size = new System.Drawing.Size(178, 24);
            this.labelCuposFull.TabIndex = 12;
            this.labelCuposFull.Text = "Cupos completos!";
            this.labelCuposFull.Visible = false;
            // 
            // AltaEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 727);
            this.Controls.Add(this.buttonCheckin);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "AltaEstadia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check-In";
            this.Load += new System.EventHandler(this.AltaEstadia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxHuespuedes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxHuespedes;
        private System.Windows.Forms.TextBox textBoxReserva;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCheckin;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelCuposFull;
    }
}