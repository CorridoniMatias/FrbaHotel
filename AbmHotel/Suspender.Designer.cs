namespace FrbaHotel.AbmHotel
{
    partial class Suspender
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
            this.groupBoxInactividad = new System.Windows.Forms.GroupBox();
            this.dateTimePickerHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerDesde = new System.Windows.Forms.DateTimePicker();
            this.textBoxMotivo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxInactividad.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInactividad
            // 
            this.groupBoxInactividad.Controls.Add(this.dateTimePickerHasta);
            this.groupBoxInactividad.Controls.Add(this.label2);
            this.groupBoxInactividad.Controls.Add(this.dateTimePickerDesde);
            this.groupBoxInactividad.Controls.Add(this.textBoxMotivo);
            this.groupBoxInactividad.Controls.Add(this.label5);
            this.groupBoxInactividad.Controls.Add(this.label1);
            this.groupBoxInactividad.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxInactividad.Location = new System.Drawing.Point(14, 14);
            this.groupBoxInactividad.Margin = new System.Windows.Forms.Padding(5);
            this.groupBoxInactividad.Name = "groupBoxInactividad";
            this.groupBoxInactividad.Padding = new System.Windows.Forms.Padding(5);
            this.groupBoxInactividad.Size = new System.Drawing.Size(598, 340);
            this.groupBoxInactividad.TabIndex = 1;
            this.groupBoxInactividad.TabStop = false;
            this.groupBoxInactividad.Text = "Suspender Hotel";
            // 
            // dateTimePickerHasta
            // 
            this.dateTimePickerHasta.Location = new System.Drawing.Point(200, 290);
            this.dateTimePickerHasta.Margin = new System.Windows.Forms.Padding(5);
            this.dateTimePickerHasta.Name = "dateTimePickerHasta";
            this.dateTimePickerHasta.Size = new System.Drawing.Size(388, 28);
            this.dateTimePickerHasta.TabIndex = 14;
            this.dateTimePickerHasta.Tag = "fechaFin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(12, 295);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "Fin inactividad";
            // 
            // dateTimePickerDesde
            // 
            this.dateTimePickerDesde.Location = new System.Drawing.Point(200, 210);
            this.dateTimePickerDesde.Margin = new System.Windows.Forms.Padding(5);
            this.dateTimePickerDesde.Name = "dateTimePickerDesde";
            this.dateTimePickerDesde.Size = new System.Drawing.Size(388, 28);
            this.dateTimePickerDesde.TabIndex = 12;
            this.dateTimePickerDesde.Tag = "fechaInicio";
            // 
            // textBoxMotivo
            // 
            this.textBoxMotivo.Location = new System.Drawing.Point(200, 40);
            this.textBoxMotivo.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxMotivo.MaxLength = 82;
            this.textBoxMotivo.Multiline = true;
            this.textBoxMotivo.Name = "textBoxMotivo";
            this.textBoxMotivo.Size = new System.Drawing.Size(388, 160);
            this.textBoxMotivo.TabIndex = 6;
            this.textBoxMotivo.Tag = "motivo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(12, 215);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = "Inicio inactividad";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Motivo";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(487, 387);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(5);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(125, 39);
            this.buttonSave.TabIndex = 15;
            this.buttonSave.Text = "Guardar";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 387);
            this.button1.Margin = new System.Windows.Forms.Padding(5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 39);
            this.button1.TabIndex = 16;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Suspender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 454);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxInactividad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Suspender";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Suspender Hotel";
            this.groupBoxInactividad.ResumeLayout(false);
            this.groupBoxInactividad.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInactividad;
        private System.Windows.Forms.DateTimePicker dateTimePickerHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerDesde;
        private System.Windows.Forms.TextBox textBoxMotivo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button button1;
    }
}