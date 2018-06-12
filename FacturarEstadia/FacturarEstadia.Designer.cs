namespace FrbaHotel.FacturarEstadia
{
    partial class FacturarEstadia
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
            this.textBoxNombreHotel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxHabitaciones = new System.Windows.Forms.TextBox();
            this.buttonCargar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxNombreHotel
            // 
            this.textBoxNombreHotel.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNombreHotel.Enabled = false;
            this.textBoxNombreHotel.Location = new System.Drawing.Point(181, 17);
            this.textBoxNombreHotel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNombreHotel.MaxLength = 80;
            this.textBoxNombreHotel.Name = "textBoxNombreHotel";
            this.textBoxNombreHotel.Size = new System.Drawing.Size(255, 26);
            this.textBoxNombreHotel.TabIndex = 22;
            this.textBoxNombreHotel.Tag = "nombreHotel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(125, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Hotel";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(26, 87);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(521, 40);
            this.label2.TabIndex = 23;
            this.label2.Text = "Ingresar el número de habitación o habitaciones que fueron utilizadas en\r\nla esta" +
    "día (separar cada número de habitación con un \";\"):";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBoxHabitaciones
            // 
            this.textBoxHabitaciones.Location = new System.Drawing.Point(30, 148);
            this.textBoxHabitaciones.MaxLength = 255;
            this.textBoxHabitaciones.Name = "textBoxHabitaciones";
            this.textBoxHabitaciones.Size = new System.Drawing.Size(517, 26);
            this.textBoxHabitaciones.TabIndex = 24;
            // 
            // buttonCargar
            // 
            this.buttonCargar.Location = new System.Drawing.Point(245, 200);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(84, 32);
            this.buttonCargar.TabIndex = 29;
            this.buttonCargar.Text = "Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // FacturarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 244);
            this.Controls.Add(this.buttonCargar);
            this.Controls.Add(this.textBoxHabitaciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNombreHotel);
            this.Controls.Add(this.label1);
            this.Name = "FacturarEstadia";
            this.Text = "FacturarEstadia";
            this.Load += new System.EventHandler(this.FacturarEstadia_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombreHotel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxHabitaciones;
        private System.Windows.Forms.Button buttonCargar;

    }
}