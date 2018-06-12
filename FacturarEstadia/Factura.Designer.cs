namespace FrbaHotel.FacturarEstadia
{
    partial class Factura
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelUbicacion = new System.Windows.Forms.Label();
            this.textBoxIdFactura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIdEstadia = new System.Windows.Forms.TextBox();
            this.textBoxNombrePago = new System.Windows.Forms.TextBox();
            this.textBoxTotal = new System.Windows.Forms.TextBox();
            this.textBoxFecha = new System.Windows.Forms.TextBox();
            this.idItemFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(321, 48);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Id Estadía";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 48);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Factura";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idItemFactura,
            this.ColumnDescripcion,
            this.ColumnCantidad,
            this.ColumnMonto});
            this.dataGridView1.Location = new System.Drawing.Point(13, 178);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(980, 352);
            this.dataGridView1.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFecha);
            this.groupBox1.Controls.Add(this.textBoxTotal);
            this.groupBox1.Controls.Add(this.textBoxNombrePago);
            this.groupBox1.Controls.Add(this.textBoxIdEstadia);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBoxIdFactura);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelUbicacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(980, 154);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos de la Factura";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(644, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Forma de Pago";
            // 
            // labelUbicacion
            // 
            this.labelUbicacion.AutoSize = true;
            this.labelUbicacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelUbicacion.Location = new System.Drawing.Point(15, 104);
            this.labelUbicacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelUbicacion.Name = "labelUbicacion";
            this.labelUbicacion.Size = new System.Drawing.Size(54, 20);
            this.labelUbicacion.TabIndex = 1;
            this.labelUbicacion.Text = "Fecha";
            // 
            // textBoxIdFactura
            // 
            this.textBoxIdFactura.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxIdFactura.Enabled = false;
            this.textBoxIdFactura.Location = new System.Drawing.Point(101, 45);
            this.textBoxIdFactura.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxIdFactura.MaxLength = 18;
            this.textBoxIdFactura.Name = "textBoxIdFactura";
            this.textBoxIdFactura.Size = new System.Drawing.Size(177, 26);
            this.textBoxIdFactura.TabIndex = 20;
            this.textBoxIdFactura.Tag = "idFactura";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(718, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Total";
            // 
            // textBoxIdEstadia
            // 
            this.textBoxIdEstadia.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxIdEstadia.Enabled = false;
            this.textBoxIdEstadia.Location = new System.Drawing.Point(410, 45);
            this.textBoxIdEstadia.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxIdEstadia.MaxLength = 32;
            this.textBoxIdEstadia.Name = "textBoxIdEstadia";
            this.textBoxIdEstadia.Size = new System.Drawing.Size(188, 26);
            this.textBoxIdEstadia.TabIndex = 24;
            this.textBoxIdEstadia.Tag = "idEstadia";
            // 
            // textBoxNombrePago
            // 
            this.textBoxNombrePago.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxNombrePago.Enabled = false;
            this.textBoxNombrePago.Location = new System.Drawing.Point(770, 45);
            this.textBoxNombrePago.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNombrePago.MaxLength = 20;
            this.textBoxNombrePago.Name = "textBoxNombrePago";
            this.textBoxNombrePago.Size = new System.Drawing.Size(192, 26);
            this.textBoxNombrePago.TabIndex = 25;
            this.textBoxNombrePago.Tag = "nombrePago";
            // 
            // textBoxTotal
            // 
            this.textBoxTotal.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTotal.Enabled = false;
            this.textBoxTotal.Location = new System.Drawing.Point(770, 101);
            this.textBoxTotal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxTotal.MaxLength = 20;
            this.textBoxTotal.Name = "textBoxTotal";
            this.textBoxTotal.Size = new System.Drawing.Size(192, 26);
            this.textBoxTotal.TabIndex = 26;
            this.textBoxTotal.Tag = "total";
            // 
            // textBoxFecha
            // 
            this.textBoxFecha.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFecha.Enabled = false;
            this.textBoxFecha.Location = new System.Drawing.Point(77, 101);
            this.textBoxFecha.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxFecha.MaxLength = 60;
            this.textBoxFecha.Name = "textBoxFecha";
            this.textBoxFecha.Size = new System.Drawing.Size(293, 26);
            this.textBoxFecha.TabIndex = 27;
            this.textBoxFecha.Tag = "fecha";
            // 
            // idItemFactura
            // 
            this.idItemFactura.HeaderText = "idItemFactura";
            this.idItemFactura.Name = "idItemFactura";
            this.idItemFactura.ReadOnly = true;
            this.idItemFactura.Visible = false;
            // 
            // ColumnDescripcion
            // 
            this.ColumnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnDescripcion.HeaderText = "Descripción";
            this.ColumnDescripcion.Name = "ColumnDescripcion";
            this.ColumnDescripcion.ReadOnly = true;
            // 
            // ColumnCantidad
            // 
            this.ColumnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCantidad.HeaderText = "Cantidad";
            this.ColumnCantidad.Name = "ColumnCantidad";
            this.ColumnCantidad.ReadOnly = true;
            // 
            // ColumnMonto
            // 
            this.ColumnMonto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnMonto.HeaderText = "Monto";
            this.ColumnMonto.Name = "ColumnMonto";
            this.ColumnMonto.ReadOnly = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(904, 549);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(71, 35);
            this.buttonOk.TabIndex = 16;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // Factura
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 598);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Factura";
            this.Text = "Factura";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idItemFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDescripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFecha;
        private System.Windows.Forms.TextBox textBoxTotal;
        private System.Windows.Forms.TextBox textBoxNombrePago;
        private System.Windows.Forms.TextBox textBoxIdEstadia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIdFactura;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelUbicacion;
        private System.Windows.Forms.Button buttonOk;
    }
}