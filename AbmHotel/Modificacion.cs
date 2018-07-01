using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class Modificacion : Form
    {
        private string idHotel;

        public Modificacion(string idHotel, string nombre, string mail, string tel, string cantEstrellas, string fechaCreacion, string calle, string nrocalle, string ciudad, string pais)
        {
            InitializeComponent();
            this.idHotel = idHotel;
            this.textBoxCalle.Text = calle;
            this.textBoxCantEstrellas.Text = cantEstrellas;
            this.textBoxCiudad.Text = ciudad;
            this.textBoxMail.Text = mail;
            this.textBoxNombre.Text = nombre;
            this.textBoxNroCalle.Text = nrocalle;
            this.textBoxPais.Text = pais;
            this.textBoxTelefono.Text = tel;
            if (!string.IsNullOrEmpty(fechaCreacion))
                this.dateTimePickerCreado.Value = DateTime.Parse(fechaCreacion);
            else
                this.dateTimePickerCreado.Value = ConfigManager.FechaSistema;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxMail.Text.Trim()))
                if (!FormHandler.verificarMail(textBoxMail))
                {
                    MessageBox.Show("El mail tiene un formato invalido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            ActualizarRegimenes();

            var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.UPDATE).Table("MATOTA.Hotel");


            var fields = String.Join(",",
                            new List<TextBox> { textBoxCalle, textBoxCantEstrellas, textBoxCiudad, textBoxMail, textBoxNombre, textBoxNroCalle, textBoxTelefono }
                                .FindAll(f => !string.IsNullOrEmpty(f.Text.Trim()))
                                .Select(f => f.Tag + "='" + f.Text.Trim() + "'")
                                .Union(new List<string> { dateTimePickerCreado.Tag + "='" +dateTimePickerCreado.Value.ToString("yyyy-MM-dd") + "'" }));

            builder.Fields(fields)
                    .AddEquals("idHotel", idHotel);

            int rows = 0;
            try
            {
                rows = DBHandler.QueryRowCount(builder.Build());
            }
            catch (Exception)
            {
                MessageBox.Show("Error al actualizar datos base hotel!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (rows == 0)
                MessageBox.Show("Error al actualizar datos base hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MessageBox.Show("Datos basicos del Hotel actualizados con éxito.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void ActualizarRegimenes()
        {
            var altas = new List<RegimenesHoteles>();
            var bajas = new List<RegimenesHoteles>();
            var elegidas = checkedListBoxRegimenes.CheckedIndices;

            for (int i = 0; i < checkedListBoxRegimenes.Items.Count; i++)
            {
                if (((RegimenesHoteles)checkedListBoxRegimenes.Items[i]).seleccionado && !elegidas.Contains(i))
                    bajas.Add((RegimenesHoteles)checkedListBoxRegimenes.Items[i]);
                else if (!((RegimenesHoteles)checkedListBoxRegimenes.Items[i]).seleccionado && elegidas.Contains(i))
                    altas.Add(((RegimenesHoteles)checkedListBoxRegimenes.Items[i]));
            }

            if (altas.Count > 0)
            {
                var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.UPDATE).Table("MATOTA.RegimenHotel").SetORConnector().Fields("habilitado=1");

                altas.ForEach(alta => builder.AddAndFilter("idHotel=" + idHotel, "idRegimen=" + alta.idRegimen));

                int rows = 0;

                try
                {
                    rows = DBHandler.QueryRowCount(builder.Build());
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al agregar los regímenes seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (rows != altas.Count)
                    MessageBox.Show("Error al agregar los regímenes seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

            if (bajas.Count > 0)
            {
                var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.UPDATE).Table("MATOTA.RegimenHotel").SetORConnector().Fields("habilitado=0");
                int borradas = 0;

                foreach(var regimen in bajas)
                {
                    var cantReservasP = new SqlParameter("@reservas", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    var cantEstadiasP = new SqlParameter("@estadias", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    int ret = 0;
                    try
                    {
                        ret = DBHandler.SPWithValue("MATOTA.CheckRegimenHotelConstraint",
                            new List<SqlParameter> { 
                            new SqlParameter("@fechaActual", ConfigManager.FechaSistema.ToString("yyyy-MM-dd") ) { Direction = ParameterDirection.Input },
                            new SqlParameter("@idHotel", idHotel) { Direction = ParameterDirection.Input },
                            new SqlParameter("@idRegimen", regimen.idRegimen) { Direction = ParameterDirection.Input },
                            cantEstadiasP,
                            cantReservasP
                        }
                        );
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Imposible quitar el regimen " + regimen.nombre + ". Ocurrió un error inesperado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    if (Convert.ToInt32(cantReservasP.Value) > 0)
                    {
                        MessageBox.Show("Imposible quitar el regimen " + regimen.nombre + " pues tiene reservas pendientes de ejecucion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        continue;
                    }

                    if (Convert.ToInt32(cantEstadiasP.Value) > 0)
                    {
                        MessageBox.Show("Imposible quitar el regimen " + regimen.nombre + " pues hay huespedes hospedandose actualmente en dicho regimen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }

                    builder.AddAndFilter("idHotel=" + idHotel, "idRegimen=" + regimen.idRegimen);
                    borradas++;
                }
                if (borradas != 0)
                {
                    int count = 0;
                    try
                    {
                        count = DBHandler.QueryRowCount(builder.Build());
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show("Ocurrió un error inesperado al intentar remover los regímenes seleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (count != borradas)
                        MessageBox.Show("Error al desvincular alguno de los regimenes deseleccionados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Modificacion_Load(object sender, EventArgs e)
        {
            try
            {
                var regimenes = DBHandler.Query("SELECT r.idRegimen, nombre, rh.habilitado FROM MATOTA.Regimen r LEFT JOIN MATOTA.RegimenHotel rh ON rh.idRegimen = r.idRegimen AND rh.idHotel=" + idHotel)
                                .Select(reg =>

                                    new RegimenesHoteles(reg["idRegimen"].ToString(), reg["nombre"].ToString(), ((reg["habilitado"].ToString().Equals("False")) ? false : true))


                                 ).ToList();

                ((ListBox)checkedListBoxRegimenes).DataSource = new BindingSource(regimenes, null);
                ((ListBox)checkedListBoxRegimenes).DisplayMember = "nombre";
                ((ListBox)checkedListBoxRegimenes).ValueMember = "idRegimen";


                for (int i = 0; i < checkedListBoxRegimenes.Items.Count; i++)
                {
                    if (((RegimenesHoteles)checkedListBoxRegimenes.Items[i]).seleccionado)
                        checkedListBoxRegimenes.SetItemChecked(i, true);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al intentar cargar los datos del hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }
        }

        public class RegimenesHoteles
        {
            public string idRegimen { get; set; }
            public string nombre { get; set; }
            public bool seleccionado { get; set; }

            public RegimenesHoteles(string id, string nombre, bool sel)
            {
                this.idRegimen = id;
                this.nombre = nombre;
                this.seleccionado = sel;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void textBoxTelefono_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTelefono.Text))
                return;

            try
            {
                Convert.ToInt32(textBoxTelefono.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El numero de telefono debe ser un numero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxTelefono.Text = textBoxTelefono.Text.Substring(0, textBoxTelefono.Text.Length - 1);
            }
        }

        private void textBoxCantEstrellas_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCantEstrellas.Text))
                return;

            try
            {
                Convert.ToInt32(textBoxCantEstrellas.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("La cantidad de estrellas debe ser un numero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxCantEstrellas.Text = textBoxCantEstrellas.Text.Substring(0, textBoxCantEstrellas.Text.Length - 1);
            }
        }

        private void textBoxNroCalle_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxNroCalle.Text))
                return;

            try
            {
                Convert.ToInt32(textBoxNroCalle.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("El numero de calle debe ser un numero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxNroCalle.Text = textBoxNroCalle.Text.Substring(0, textBoxNroCalle.Text.Length - 1);
            }
        }
    }
}
