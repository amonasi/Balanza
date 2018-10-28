using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Balanza.Bean;
using Balanza.Configs;

namespace Balanza
{
    public partial class frmManParametros : Form
    {
        DAL datos;
        Logger log;
        Security seg;

        public frmManParametros()
        {
            InitializeComponent();
        }

        private void frmManParametros_Load(object sender, EventArgs e)
        {
            log = new Logger();
            datos = new DAL();
            seg = new Security();
            cargarDatos();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que desea actualizar los parámetros?", "Balanza", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (guardarDatos())
                {
                    MessageBox.Show("Parámetros guardados exitosamente.");
                }
                else {
                    MessageBox.Show("Error guardando los parámetros, revise el log.");
                }

                cargarDatos();
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cargarDatos() {
            try
            {
                List<ParametroBean> parametros = new List<ParametroBean>();
                parametros = datos.obtenerListaParametros();
                String dec = String.Empty;

                foreach (ParametroBean p in parametros) {
                    if (p.CODIGO.Equals("SEC_TICKET")) {
                        tbSecuencia.Text=p.VALOR;
                    }
                    if (p.CODIGO.Equals("LAR_TICKET"))
                    {
                        tbTamCar.Text = p.VALOR;
                    }
                    if (p.CODIGO.Equals("ID_LOC"))
                    {
                        tbLocalidad.Text = p.VALOR;
                    }
                    if (p.CODIGO.Equals("CLA_ADM"))
                    {
                        seg.SimpleDecrypt(p.VALOR, ref dec);
                        tbPassAdmin.Text = dec;
                    }
                    if (p.CODIGO.Equals("CLA_USU"))
                    {
                        seg.SimpleDecrypt(p.VALOR, ref dec);
                        tbPassUsuario.Text = dec;
                    }
                }

            }
            catch (Exception e) {
                log.LogMessage("Parametros - cargarDatos: " + e.Message);
            }
            

        }

        private void tbTamCar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void tbSecuencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private bool guardarDatos()
        {
            bool resultado = false;
            try
            {
                List<ParametroBean> parametros = new List<ParametroBean>();
                ParametroBean p;

                p = new ParametroBean();
                p.CODIGO = "SEC_TICKET";
                p.VALOR = tbSecuencia.Text;
                parametros.Add(p);

                p = new ParametroBean();
                p.CODIGO = "LAR_TICKET";
                p.VALOR = tbTamCar.Text;
                parametros.Add(p);

                p = new ParametroBean();
                p.CODIGO = "ID_LOC";
                p.VALOR = tbLocalidad.Text;
                parametros.Add(p);

                p = new ParametroBean();
                p.CODIGO = "CLA_ADM";
                seg.SimpleEncrypt(tbPassAdmin.Text, ref p.VALOR);
                parametros.Add(p);

                p = new ParametroBean();
                p.CODIGO = "CLA_USU";
                seg.SimpleEncrypt(tbPassUsuario.Text, ref p.VALOR);
                parametros.Add(p);

                resultado = datos.actualizarParametros(parametros);

                if (!resultado)
                {
                    throw new Exception("Actualización de parámetros fallido");
                }

                resultado = true;

            }
            catch(Exception e)
            {
                log.LogMessage("Parametros - guardarDatos: " + e.Message);
            }

            return resultado;
        }

        private void tbTamCar_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbSecuencia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
