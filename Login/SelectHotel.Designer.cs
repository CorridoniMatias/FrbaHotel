namespace FrbaHotel.Login
{
    partial class SelectHotel
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
            this.dataGridViewHotels = new System.Windows.Forms.DataGridView();
            this.ColumnIdHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNombreHotel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHotelCalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHotelCalleNro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHotelCiudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHotels)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewHotels
            // 
            this.dataGridViewHotels.AllowUserToAddRows = false;
            this.dataGridViewHotels.AllowUserToDeleteRows = false;
            this.dataGridViewHotels.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHotels.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIdHotel,
            this.ColumnNombreHotel,
            this.ColumnHotelCalle,
            this.ColumnHotelCalleNro,
            this.ColumnHotelCiudad});
            this.dataGridViewHotels.Location = new System.Drawing.Point(0, 157);
            this.dataGridViewHotels.Name = "dataGridViewHotels";
            this.dataGridViewHotels.ReadOnly = true;
            this.dataGridViewHotels.RowTemplate.Height = 30;
            this.dataGridViewHotels.Size = new System.Drawing.Size(906, 427);
            this.dataGridViewHotels.TabIndex = 0;
            // 
            // ColumnIdHotel
            // 
            this.ColumnIdHotel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIdHotel.HeaderText = "Column1";
            this.ColumnIdHotel.Name = "ColumnIdHotel";
            this.ColumnIdHotel.ReadOnly = true;
            this.ColumnIdHotel.Visible = false;
            // 
            // ColumnNombreHotel
            // 
            this.ColumnNombreHotel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnNombreHotel.HeaderText = "Nombre";
            this.ColumnNombreHotel.Name = "ColumnNombreHotel";
            this.ColumnNombreHotel.ReadOnly = true;
            // 
            // ColumnHotelCalle
            // 
            this.ColumnHotelCalle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnHotelCalle.HeaderText = "Calle";
            this.ColumnHotelCalle.Name = "ColumnHotelCalle";
            this.ColumnHotelCalle.ReadOnly = true;
            // 
            // ColumnHotelCalleNro
            // 
            this.ColumnHotelCalleNro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnHotelCalleNro.HeaderText = "Nro. Calle";
            this.ColumnHotelCalleNro.Name = "ColumnHotelCalleNro";
            this.ColumnHotelCalleNro.ReadOnly = true;
            // 
            // ColumnHotelCiudad
            // 
            this.ColumnHotelCiudad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnHotelCiudad.HeaderText = "Ciudad";
            this.ColumnHotelCiudad.Name = "ColumnHotelCiudad";
            this.ColumnHotelCiudad.ReadOnly = true;
            // 
            // SelectHotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 585);
            this.Controls.Add(this.dataGridViewHotels);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SelectHotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione su hotel";
            this.Load += new System.EventHandler(this.SelectHotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHotels)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewHotels;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIdHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNombreHotel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHotelCalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHotelCalleNro;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHotelCiudad;
    }
}