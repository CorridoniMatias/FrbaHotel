namespace FrbaHotel.ListadoEstadistico
{
    partial class Form1
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
            this.dateTimePickerAño = new System.Windows.Forms.DateTimePicker();
            this.comboBoxTrimestre = new System.Windows.Forms.ComboBox();
            this.comboBoxTipo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBoxListado = new System.Windows.Forms.GroupBox();
            this.groupBoxListado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePickerAño
            // 
            this.dateTimePickerAño.CustomFormat = "yyyy";
            this.dateTimePickerAño.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerAño.Location = new System.Drawing.Point(120, 24);
            this.dateTimePickerAño.Name = "dateTimePickerAño";
            this.dateTimePickerAño.ShowUpDown = true;
            this.dateTimePickerAño.Size = new System.Drawing.Size(305, 20);
            this.dateTimePickerAño.TabIndex = 0;
            this.dateTimePickerAño.Tag = "año";
            // 
            // comboBoxTrimestre
            // 
            this.comboBoxTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTrimestre.FormattingEnabled = true;
            this.comboBoxTrimestre.Items.AddRange(new object[] {
            "1° Trimestre :  Enero - Marzo",
            "2° Trimestre :  Abril - Junio",
            "3° Trimestre :  Julio - Septiembre",
            "4° Trimestre :  Octubre - Diciembre"});
            this.comboBoxTrimestre.Location = new System.Drawing.Point(120, 60);
            this.comboBoxTrimestre.Name = "comboBoxTrimestre";
            this.comboBoxTrimestre.Size = new System.Drawing.Size(305, 21);
            this.comboBoxTrimestre.TabIndex = 1;
            this.comboBoxTrimestre.Tag = "trimestre";
            // 
            // comboBoxTipo
            // 
            this.comboBoxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipo.FormattingEnabled = true;
            this.comboBoxTipo.Items.AddRange(new object[] {
            "Hoteles con mayor cantidad de reservas canceladas",
            "Hoteles con mayor cantidad de consumibles facturados",
            "Hoteles con mayor cantidad de días fuera de servicio",
            "Habitaciones con mayor cantidad de días y veces ocupadas",
            "Clientes con mayor cantidad de puntos"});
            this.comboBoxTipo.Location = new System.Drawing.Point(120, 90);
            this.comboBoxTipo.Name = "comboBoxTipo";
            this.comboBoxTipo.Size = new System.Drawing.Size(305, 21);
            this.comboBoxTipo.TabIndex = 2;
            this.comboBoxTipo.Tag = "tipo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trimestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tipo de Listado";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(362, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Buscar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBoxListado
            // 
            this.groupBoxListado.Controls.Add(this.label1);
            this.groupBoxListado.Controls.Add(this.dateTimePickerAño);
            this.groupBoxListado.Controls.Add(this.label2);
            this.groupBoxListado.Controls.Add(this.label3);
            this.groupBoxListado.Controls.Add(this.comboBoxTrimestre);
            this.groupBoxListado.Controls.Add(this.comboBoxTipo);
            this.groupBoxListado.Location = new System.Drawing.Point(12, 12);
            this.groupBoxListado.Name = "groupBoxListado";
            this.groupBoxListado.Size = new System.Drawing.Size(431, 131);
            this.groupBoxListado.TabIndex = 8;
            this.groupBoxListado.TabStop = false;
            this.groupBoxListado.Text = "Filtros de Listado";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 182);
            this.Controls.Add(this.groupBoxListado);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Listado estadístico";
            this.groupBoxListado.ResumeLayout(false);
            this.groupBoxListado.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerAño;
        private System.Windows.Forms.ComboBox comboBoxTrimestre;
        private System.Windows.Forms.ComboBox comboBoxTipo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBoxListado;
    }
}