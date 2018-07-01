using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrbaHotel.AbmHotel
{
    public partial class AltaHotel : Form
    {
        public AltaHotel()
        {
            InitializeComponent();
        }

        private void AltaHotel_Load(object sender, EventArgs e)
        {
            dateTimePickerFechaCreacion.Value = ConfigManager.FechaSistema;

            var regimenes = DBHandler.Query("SELECT idRegimen, nombre FROM MATOTA.Regimen")
                            .Select(reg => new KeyValuePair<int, string>(Int32.Parse(reg["idRegimen"].ToString()), reg["nombre"].ToString()) )
                            .ToDictionary(pair => pair.Key, pair => pair.Value);

            ((ListBox)checkedListBoxRegimenes).DataSource = new BindingSource(regimenes, null);
            ((ListBox)checkedListBoxRegimenes).DisplayMember = "Value";
            ((ListBox)checkedListBoxRegimenes).ValueMember = "Key";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(textBoxMail.Text.Trim()))
                if (!FormHandler.verificarMail(textBoxMail))
                {
                    MessageBox.Show("El mail tiene un formato invalido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            List<TextBox> fields = new List<TextBox>()
                {
                    textBoxNombre,
                    textBoxMail,
                    textBoxTel,
                    textBoxCalle,
                    textBoxNroCalle,
                    textBoxCiudad,
                    textBoxPais,
                    textBoxCantEstrellas
                };


            if (fields.Any(f => string.IsNullOrEmpty(f.Text.Trim())) || checkedListBoxRegimenes.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe llenar todos los campos y seleccionar al menos un regimen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Int32.Parse(textBoxCantEstrellas.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Cantidad de estrellas debe ser un numero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var builder = new QueryBuilder(QueryBuilder.QueryBuilderType.SELECT)
                                .Table("MATOTA.Hotel")
                                .Fields("idHotel")
                                .AddEquals("calle", textBoxCalle.Text.Trim())
                                .AddEquals("nroCalle", textBoxNroCalle.Text.Trim())
                                .AddEquals("ciudad", textBoxCiudad.Text.Trim())
                                .AddEquals("pais", textBoxPais.Text.Trim());

            try
            {
                var res = DBHandler.Query(builder.Build());

                if (res.Count > 0)
                {
                    MessageBox.Show("Ya existe un hotel en la misma ubicacion que especificó.\nPor favor, revise los datos ingresados.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al comprobar si ya existe el hotel que desea registrar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "INSERT INTO MATOTA.Hotel (nombre,mail,telefono,calle,nroCalle,ciudad,pais,cantidadEstrellas,fechaCreacion)" +
                            "VALUES (";

            query += String.Join(",", fields.Select(f => "'"+f.Text+"'").ToArray());
            query += ",'" + dateTimePickerFechaCreacion.Value.ToString("yyyy-MM-dd");

            query += "');SELECT scope_identity()";

            int idhotel = -1;
            try
            {
                idhotel = DBHandler.QueryScalar(query);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrió un error al agregar el hotel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (idhotel < 1)
            {
                MessageBox.Show("Error al agregar hotel", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var adds = new List<string>();
            query = "INSERT INTO MATOTA.RegimenHotel VALUES ";

            for (int i = 0; i < checkedListBoxRegimenes.Items.Count; i++)
            {
                var item = (KeyValuePair<int, string>)checkedListBoxRegimenes.Items[i];
                int enabled = ((checkedListBoxRegimenes.CheckedIndices.Contains(i)) ? 1 : 0);

                adds.Add("(" + idhotel + ", " + item.Key + ", " + enabled + ")");
            }

            query += String.Join(",", adds);

            int count = -1;

            try
            {
                count = DBHandler.QueryRowCount(query);
            }
            catch (Exception ex)
            {
                try
                {
                    var queryDelete = new QueryBuilder(QueryBuilder.QueryBuilderType.DELETE).Table("MATOTA.Hotel").AddEquals("idHotel", idhotel.ToString());
                    DBHandler.QueryScalar(queryDelete.Build());
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Ocurrió un error al agregar los regímenes seleccionados, el hotel no fue registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                MessageBox.Show("Ocurrió un error al agregar los regímenes seleccionados, el hotel no fue registrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                MessageBox.Show("Hotel agregado con exito.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            try
            {
                builder = new QueryBuilder(QueryBuilder.QueryBuilderType.INSERT)
                                    .Table("MATOTA.HotelesUsuario")
                                    .Fields("idUsuario, idHotel")
                                    .AddValues(Login.Login.LoggedUsedID.ToString(), idhotel.ToString());

                DBHandler.QueryScalar(builder.Build());
            }
            catch (Exception)
            {
                MessageBox.Show("Error al vincularlo con el hotel recientemente creado. Para poder administrar dicho hotel por favor adjudiqueselo manualmente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormHandler.limpiar(this.groupBox1);
            FormHandler.limpiar(this.groupBox2);
        }

        private void textBoxTel_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxTel.Text))
                return;

            try
            {
                Convert.ToInt32(textBoxTel.Text);
            }catch(Exception)
            {
                MessageBox.Show("El numero de telefono debe ser un numero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textBoxTel.Text = textBoxTel.Text.Substring(0, textBoxTel.Text.Length - 1);
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
    }
}
