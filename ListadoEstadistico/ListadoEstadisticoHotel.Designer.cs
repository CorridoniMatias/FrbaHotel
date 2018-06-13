namespace FrbaHotel.ListadoEstadistico
{
    partial class ListadoEstadisticoHotel
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
            this.dataGridViewHoteles = new System.Windows.Forms.DataGridView();
            this.nombreHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pais = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoteles)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHoteles
            // 
            this.dataGridViewHoteles.AllowUserToAddRows = false;
            this.dataGridViewHoteles.AllowUserToDeleteRows = false;
            this.dataGridViewHoteles.AllowUserToOrderColumns = true;
            this.dataGridViewHoteles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHoteles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreHotel,
            this.calle,
            this.nroCalle,
            this.ciudad,
            this.pais,
            this.valor});
            this.dataGridViewHoteles.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewHoteles.Name = "dataGridViewHoteles";
            this.dataGridViewHoteles.ReadOnly = true;
            this.dataGridViewHoteles.Size = new System.Drawing.Size(699, 222);
            this.dataGridViewHoteles.TabIndex = 0;
            // 
            // nombreHotel
            // 
            this.nombreHotel.HeaderText = "Nombre";
            this.nombreHotel.Name = "nombreHotel";
            this.nombreHotel.ReadOnly = true;
            this.nombreHotel.Width = 69;
            // 
            // calle
            // 
            this.calle.HeaderText = "Calle";
            this.calle.Name = "calle";
            this.calle.ReadOnly = true;
            this.calle.Width = 55;
            // 
            // nroCalle
            // 
            this.nroCalle.HeaderText = "Nro. de Calle";
            this.nroCalle.Name = "nroCalle";
            this.nroCalle.ReadOnly = true;
            this.nroCalle.Width = 93;
            // 
            // ciudad
            // 
            this.ciudad.HeaderText = "Ciudad";
            this.ciudad.Name = "ciudad";
            this.ciudad.ReadOnly = true;
            this.ciudad.Width = 65;
            // 
            // pais
            // 
            this.pais.HeaderText = "País";
            this.pais.Name = "pais";
            this.pais.ReadOnly = true;
            this.pais.Width = 54;
            // 
            // valor
            // 
            this.valor.HeaderText = "Valor";
            this.valor.Name = "valor";
            this.valor.ReadOnly = true;
            this.valor.Width = 56;
            // 
            // ListadoHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 250);
            this.Controls.Add(this.dataGridViewHoteles);
            this.Name = "ListadoHotel";
            this.Text = "Listado de Hoteles";
            this.Load += new System.EventHandler(this.ListadoHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHoteles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHoteles;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn calle;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn pais;
        private System.Windows.Forms.DataGridViewTextBoxColumn valor;
    }
}