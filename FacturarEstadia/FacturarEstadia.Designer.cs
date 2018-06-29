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
            this.buttonCargar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnHabitación = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRemove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.elegir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // buttonCargar
            // 
            this.buttonCargar.Location = new System.Drawing.Point(463, 450);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(84, 32);
            this.buttonCargar.TabIndex = 29;
            this.buttonCargar.Text = "Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnHabitación,
            this.ColumnRemove});
            this.dataGridView1.Location = new System.Drawing.Point(13, 90);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(552, 346);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ColumnHabitación
            // 
            this.ColumnHabitación.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnHabitación.HeaderText = "Nro. Habitación";
            this.ColumnHabitación.Name = "ColumnHabitación";
            this.ColumnHabitación.ReadOnly = true;
            // 
            // ColumnRemove
            // 
            this.ColumnRemove.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ColumnRemove.HeaderText = "Remover";
            this.ColumnRemove.Name = "ColumnRemove";
            this.ColumnRemove.ReadOnly = true;
            this.ColumnRemove.Text = "Remover";
            this.ColumnRemove.Width = 79;
            // 
            // elegir
            // 
            this.elegir.Location = new System.Drawing.Point(37, 450);
            this.elegir.Name = "elegir";
            this.elegir.Size = new System.Drawing.Size(165, 32);
            this.elegir.TabIndex = 31;
            this.elegir.Text = "Elegir Habitación";
            this.elegir.UseVisualStyleBackColor = true;
            this.elegir.Click += new System.EventHandler(this.elegir_Click);
            // 
            // FacturarEstadia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 494);
            this.Controls.Add(this.elegir);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonCargar);
            this.Controls.Add(this.textBoxNombreHotel);
            this.Controls.Add(this.label1);
            this.Name = "FacturarEstadia";
            this.Text = "FacturarEstadia";
            this.Load += new System.EventHandler(this.FacturarEstadia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombreHotel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHabitación;
        private System.Windows.Forms.DataGridViewButtonColumn ColumnRemove;
        private System.Windows.Forms.Button elegir;

    }
}