namespace FrbaHotel.AbmRol
{
    partial class Listado
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
            this.groupBoxFiltros = new System.Windows.Forms.GroupBox();
            this.buttonLimpiar = new System.Windows.Forms.Button();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.checkBoxEstado = new System.Windows.Forms.CheckBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBoxFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 283);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(427, 210);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBoxFiltros
            // 
            this.groupBoxFiltros.Controls.Add(this.textBox1);
            this.groupBoxFiltros.Controls.Add(this.labelNombre);
            this.groupBoxFiltros.Controls.Add(this.checkBoxEstado);
            this.groupBoxFiltros.Controls.Add(this.buttonGuardar);
            this.groupBoxFiltros.Controls.Add(this.buttonLimpiar);
            this.groupBoxFiltros.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBoxFiltros.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFiltros.Name = "groupBoxFiltros";
            this.groupBoxFiltros.Size = new System.Drawing.Size(427, 227);
            this.groupBoxFiltros.TabIndex = 1;
            this.groupBoxFiltros.TabStop = false;
            this.groupBoxFiltros.Text = "Filtros de busqueda";
            // 
            // buttonLimpiar
            // 
            this.buttonLimpiar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonLimpiar.Location = new System.Drawing.Point(24, 174);
            this.buttonLimpiar.Name = "buttonLimpiar";
            this.buttonLimpiar.Size = new System.Drawing.Size(75, 23);
            this.buttonLimpiar.TabIndex = 0;
            this.buttonLimpiar.Text = "Limpiar";
            this.buttonLimpiar.UseVisualStyleBackColor = true;
            this.buttonLimpiar.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonGuardar.Location = new System.Drawing.Point(299, 174);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 1;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            // 
            // checkBoxEstado
            // 
            this.checkBoxEstado.AutoSize = true;
            this.checkBoxEstado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.checkBoxEstado.Location = new System.Drawing.Point(294, 45);
            this.checkBoxEstado.Name = "checkBoxEstado";
            this.checkBoxEstado.Size = new System.Drawing.Size(92, 17);
            this.checkBoxEstado.TabIndex = 2;
            this.checkBoxEstado.Text = "Estado Activo";
            this.checkBoxEstado.UseVisualStyleBackColor = true;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelNombre.Location = new System.Drawing.Point(21, 42);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(44, 13);
            this.labelNombre.TabIndex = 3;
            this.labelNombre.Text = "Nombre";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(105, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // Listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 505);
            this.Controls.Add(this.groupBoxFiltros);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Listado";
            this.Text = "Listado";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBoxFiltros.ResumeLayout(false);
            this.groupBoxFiltros.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBoxFiltros;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.CheckBox checkBoxEstado;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.Button buttonLimpiar;
    }
}