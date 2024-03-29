﻿namespace FrbaHotel.RegistrarConsumible
{
    partial class Registrar
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idConsumible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModificar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.ColumnRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonContinue = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxNroHabitacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelDescuento = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idConsumible,
            this.Column1,
            this.Column2,
            this.ColumnCantidad,
            this.ColumnSubTotal,
            this.ColumnModificar,
            this.ColumnRemove});
            this.dataGridView1.Location = new System.Drawing.Point(10, 41);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(852, 381);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAltered);
            this.dataGridView1.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dataGridView1_RowsAltered);
            // 
            // idConsumible
            // 
            this.idConsumible.HeaderText = "idConsumible";
            this.idConsumible.Name = "idConsumible";
            this.idConsumible.ReadOnly = true;
            this.idConsumible.Visible = false;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "Descripcion";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Precio";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // ColumnCantidad
            // 
            this.ColumnCantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnCantidad.HeaderText = "Cantidad";
            this.ColumnCantidad.Name = "ColumnCantidad";
            this.ColumnCantidad.ReadOnly = true;
            // 
            // ColumnSubTotal
            // 
            this.ColumnSubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSubTotal.HeaderText = "Subtotal";
            this.ColumnSubTotal.Name = "ColumnSubTotal";
            this.ColumnSubTotal.ReadOnly = true;
            // 
            // ColumnModificar
            // 
            this.ColumnModificar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnModificar.HeaderText = "Modificar";
            this.ColumnModificar.Name = "ColumnModificar";
            this.ColumnModificar.ReadOnly = true;
            this.ColumnModificar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnModificar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnModificar.Width = 111;
            // 
            // ColumnRemove
            // 
            this.ColumnRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnRemove.HeaderText = "Remover";
            this.ColumnRemove.Name = "ColumnRemove";
            this.ColumnRemove.ReadOnly = true;
            this.ColumnRemove.Text = "Remover";
            this.ColumnRemove.Width = 93;
            // 
            // buttonRegister
            // 
            this.buttonRegister.Location = new System.Drawing.Point(663, 663);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(5);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(222, 39);
            this.buttonRegister.TabIndex = 10;
            this.buttonRegister.Text = "Registrar consumibles";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonContinue
            // 
            this.buttonContinue.Location = new System.Drawing.Point(13, 663);
            this.buttonContinue.Margin = new System.Windows.Forms.Padding(5);
            this.buttonContinue.Name = "buttonContinue";
            this.buttonContinue.Size = new System.Drawing.Size(252, 39);
            this.buttonContinue.TabIndex = 9;
            this.buttonContinue.Text = "Continuar sin consumibles";
            this.buttonContinue.UseVisualStyleBackColor = true;
            this.buttonContinue.Click += new System.EventHandler(this.buttonContinue_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxNroHabitacion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(872, 117);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Estadia";
            // 
            // textBoxNroHabitacion
            // 
            this.textBoxNroHabitacion.Enabled = false;
            this.textBoxNroHabitacion.Location = new System.Drawing.Point(227, 49);
            this.textBoxNroHabitacion.Margin = new System.Windows.Forms.Padding(5);
            this.textBoxNroHabitacion.MaxLength = 82;
            this.textBoxNroHabitacion.Name = "textBoxNroHabitacion";
            this.textBoxNroHabitacion.ReadOnly = true;
            this.textBoxNroHabitacion.Size = new System.Drawing.Size(312, 28);
            this.textBoxNroHabitacion.TabIndex = 4;
            this.textBoxNroHabitacion.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(17, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Número de Habitación";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelDescuento);
            this.groupBox2.Controls.Add(this.buttonAdd);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(13, 151);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(872, 504);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consumibles";
            // 
            // labelDescuento
            // 
            this.labelDescuento.AutoSize = true;
            this.labelDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.950921F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescuento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelDescuento.Location = new System.Drawing.Point(17, 443);
            this.labelDescuento.Name = "labelDescuento";
            this.labelDescuento.Size = new System.Drawing.Size(374, 24);
            this.labelDescuento.TabIndex = 12;
            this.labelDescuento.Text = "Bonificación por régimen All Inclusive: ";
            this.labelDescuento.Visible = false;
            // 
            // buttonAdd
            // 
            this.buttonAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonAdd.Location = new System.Drawing.Point(673, 443);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(187, 39);
            this.buttonAdd.TabIndex = 11;
            this.buttonAdd.Text = "Añadir consumible";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // Registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 723);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.buttonContinue);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Registrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Consumibles";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.Button buttonContinue;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxNroHabitacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn idConsumible;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubTotal;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnModificar;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnRemove;
        private System.Windows.Forms.Label labelDescuento;
    }
}