using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmRol
{
    public partial class Listado : Form
    {
        public Listado()
        {
            InitializeComponent();
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(groupBoxFiltros);
        }
    }
}
