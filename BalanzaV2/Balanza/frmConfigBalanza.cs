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
    public partial class frmConfigBalanza : Form
    {
        DAL datos;
        Logger log;
        Security seg;
        List<BalanzaBean> lista;

        public frmConfigBalanza()
        {
            InitializeComponent();
            
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dgvTablaBalanza.Rows.Count > 0)
            {
                int totDef = cuentaDefault();
                if (totDef == 0)
                {
                    MessageBox.Show("Tiene que haber una balanza por defecto.", datos.appConfig("TitShowMessage"));
                    return;
                }
                if (totDef >1)
                {
                    MessageBox.Show("Solo puede haber una balanza por defecto.", datos.appConfig("TitShowMessage"));
                    return;
                }

                List<BalanzaBean> balanzas= obtenerBalanzas();
                bool resultado=datos.actualizarBalanzas(balanzas);
                if (resultado)
                {
                    MessageBox.Show("Actualizacion satisfactoria",datos.appConfig("TitShowMessage"));
                }
                else
                {
                    MessageBox.Show("Error actualizando la conf. de las balanzas. Revise el log.", datos.appConfig("TitShowMessage"));
                }
                cargarDatosBalanza();
            }
            else
            {
                MessageBox.Show("La tabla esta vacia, no se puede actualizar.", datos.appConfig("TitShowMessage"));
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTablaBalanza_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmConfigBalanza_Load(object sender, EventArgs e)
        {
            log = new Logger();
            datos = new DAL();
            seg = new Security();
            cargarDatosBalanza();
            dgvTablaBalanza.AutoResizeRows();
        }

        private void ColumnaNumerica_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgvTablaBalanza_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnaNumerica_KeyPress);
            if (dgvTablaBalanza.CurrentCell.ColumnIndex ==1 || dgvTablaBalanza.CurrentCell.ColumnIndex == 4 || dgvTablaBalanza.CurrentCell.ColumnIndex == 5 || dgvTablaBalanza.CurrentCell.ColumnIndex == 6 || dgvTablaBalanza.CurrentCell.ColumnIndex == 7 || dgvTablaBalanza.CurrentCell.ColumnIndex == 8 || dgvTablaBalanza.CurrentCell.ColumnIndex == 9)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnaNumerica_KeyPress);
                }
            }
        }

        private int cuentaDefault()
        {
            int i = 0;
            dgvTablaBalanza.EndEdit();
            foreach(DataGridViewRow fila in dgvTablaBalanza.Rows)
            {
                if (fila.Cells["BAL_DEFAULT"].Value.ToString() == "True")
                {
                    i++;
                }
            }
                
            return i;
        }

        /*
        public void cargarDatosBalanza()
        {
            try
            {

                dgvTablaBalanza.AllowUserToAddRows = false;
                dgvTablaBalanza.Rows.Clear();
                int fila;
                lista = new List<BalanzaBean>();
                lista = datos.obtenerTodasBalanzas();

                foreach (BalanzaBean b in lista)
                {
                    fila = dgvTablaBalanza.Rows.Add();
                    dgvTablaBalanza.Rows[fila].Cells["COD_BALANZA"].Value = b.COD_BALANZA;
                    dgvTablaBalanza.Rows[fila].Cells["TAM_TRAMA"].Value = b.TAM_TRAMA.ToString();
                    dgvTablaBalanza.Rows[fila].Cells["CAR_INI_TRA"].Value = b.CAR_INI_TRA.ToString();
                    dgvTablaBalanza.Rows[fila].Cells["CAR_EST_BAL"].Value = b.CAR_EST_BAL;
                    dgvTablaBalanza.Rows[fila].Cells["POS_INI_CEB"].Value = b.POS_INI_CEB.ToString();
                    dgvTablaBalanza.Rows[fila].Cells["POS_FIN_CEB"].Value = b.POS_FIN_CEB.ToString();
                    dgvTablaBalanza.Rows[fila].Cells["POS_INI_PESO_ST"].Value = b.POS_INI_PESO_CT.ToString();
                    dgvTablaBalanza.Rows[fila].Cells["POS_FIN_PESO_ST"].Value = b.POS_FIN_PESO_CT.ToString();
                    dgvTablaBalanza.Rows[fila].Cells["POS_INI_PESO_CT"].Value = b.POS_INI_PESO_ST;
                    dgvTablaBalanza.Rows[fila].Cells["POS_FIN_PESO_ST"].Value = b.POS_FIN_PESO_ST;
                    if (b.ESTADO.Equals("A"))
                    {
                        dgvTablaBalanza.Rows[fila].Cells["ESTADO"].Value = true;
                    }
                    else
                    {
                        dgvTablaBalanza.Rows[fila].Cells["ESTADO"].Value = false;
                    }
                    if (b.BAL_DEFAULT.Equals("S"))
                    {
                        dgvTablaBalanza.Rows[fila].Cells["BAL_DEFAULT"].Value = true;
                    }
                    else
                    {
                        dgvTablaBalanza.Rows[fila].Cells["BAL_DEFAULT"].Value = false;
                    }
                }
                //dgvTablaBalanza.Rows.Remove(dgvTablaBalanza.Rows[dgvTablaBalanza.Rows.Count - 1]);
            }
            catch (Exception e)
            {

            }
            finally
            {
                log.LogMessage("Error cargarDatosBalanza:" + e.Message);
            }
        }
        */

        public void cargarDatosBalanza()
        {
            try
            {

                dgvTablaBalanza.AllowUserToAddRows = false;
                dgvTablaBalanza.Rows.Clear();
                dgvTablaBalanza.AutoGenerateColumns = false;

                if (datos.appConfig("edicionBalanza").Equals("0")) {
                    dgvTablaBalanza.Columns["COD_BALANZA"].ReadOnly = true;
                    dgvTablaBalanza.Columns["TAM_TRAMA"].ReadOnly = true;
                    dgvTablaBalanza.Columns["CAR_INI_TRA"].ReadOnly = true;
                    dgvTablaBalanza.Columns["CAR_EST_BAL"].ReadOnly = true;
                    dgvTablaBalanza.Columns["POS_INI_CEB"].ReadOnly = true;
                    dgvTablaBalanza.Columns["POS_FIN_CEB"].ReadOnly = true;
                    dgvTablaBalanza.Columns["POS_INI_PESO_ST"].ReadOnly = true;
                    dgvTablaBalanza.Columns["POS_FIN_PESO_ST"].ReadOnly = true;
                    dgvTablaBalanza.Columns["POS_INI_PESO_CT"].ReadOnly = true;
                    dgvTablaBalanza.Columns["POS_FIN_PESO_CT"].ReadOnly = true;
                    dgvTablaBalanza.Columns["POS_DEC"].ReadOnly = true;
                }

                dgvTablaBalanza.Columns["COD_BALANZA"].DataPropertyName = "COD_BALANZA";
                dgvTablaBalanza.Columns["TAM_TRAMA"].DataPropertyName = "TAM_TRAMA";
                dgvTablaBalanza.Columns["CAR_INI_TRA"].DataPropertyName = "CAR_INI_TRA";
                dgvTablaBalanza.Columns["CAR_EST_BAL"].DataPropertyName = "CAR_EST_BAL";
                dgvTablaBalanza.Columns["POS_INI_CEB"].DataPropertyName = "POS_INI_CEB";
                dgvTablaBalanza.Columns["POS_FIN_CEB"].DataPropertyName = "POS_FIN_CEB";
                dgvTablaBalanza.Columns["POS_INI_PESO_ST"].DataPropertyName = "POS_INI_PESO_ST";
                dgvTablaBalanza.Columns["POS_FIN_PESO_ST"].DataPropertyName = "POS_FIN_PESO_ST";
                dgvTablaBalanza.Columns["POS_INI_PESO_CT"].DataPropertyName = "POS_INI_PESO_CT";
                dgvTablaBalanza.Columns["POS_FIN_PESO_CT"].DataPropertyName = "POS_FIN_PESO_CT";
                
                dgvTablaBalanza.Columns["ESTADO"].DataPropertyName = "ESTADO";
                dgvTablaBalanza.Columns["BAL_DEFAULT"].DataPropertyName = "BAL_DEFAULT";

                dgvTablaBalanza.Columns["POS_DEC"].DataPropertyName = "POS_DEC";

                DataTable tabla = datos.obtenerBalanzas();
                dgvTablaBalanza.DataSource = tabla;
            }
            catch (Exception e)
            {
                log.LogMessage("Error cargarDatosBalanza:" + e.Message);
            }
            finally
            {

            }
        }
        

        private List<BalanzaBean> obtenerBalanzas()
        {
            dgvTablaBalanza.EndEdit();
            dgvTablaBalanza.Update();
            List<BalanzaBean> lista = new List<BalanzaBean>();
            BalanzaBean bal;
            try
            {
                foreach (DataGridViewRow r in dgvTablaBalanza.Rows)
                {
                    bal = new BalanzaBean();
                    bal.COD_BALANZA= r.Cells["COD_BALANZA"].Value.ToString();
                    bal.TAM_TRAMA= int.Parse(r.Cells["TAM_TRAMA"].Value.ToString());
                    bal.CAR_INI_TRA= r.Cells["CAR_INI_TRA"].Value.ToString();
                    bal.CAR_EST_BAL= r.Cells["CAR_EST_BAL"].Value.ToString();
                    bal.POS_INI_CEB = int.Parse(r.Cells["POS_INI_CEB"].Value.ToString());
                    bal.POS_FIN_CEB = int.Parse(r.Cells["POS_FIN_CEB"].Value.ToString());
                    bal.POS_INI_PESO_CT = int.Parse(r.Cells["POS_INI_PESO_ST"].Value.ToString());
                    bal.POS_FIN_PESO_CT = int.Parse(r.Cells["POS_FIN_PESO_ST"].Value.ToString());
                    bal.POS_INI_PESO_ST = int.Parse(r.Cells["POS_INI_PESO_CT"].Value.ToString());
                    bal.POS_FIN_PESO_ST = int.Parse(r.Cells["POS_FIN_PESO_CT"].Value.ToString());
                    if (r.Cells["ESTADO"].Value.ToString() == "True")
                    {
                        bal.ESTADO="A";
                    }
                    else
                    {
                        bal.ESTADO = "I";
                    }
                    if (r.Cells["BAL_DEFAULT"].Value.ToString()=="True")
                    {
                        bal.BAL_DEFAULT="S";
                    }
                    else
                    {
                        bal.BAL_DEFAULT = "N";
                    }
                    bal.POS_DEC = int.Parse(r.Cells["POS_DEC"].Value.ToString());
                    lista.Add(bal);
                }

            }
            catch(Exception e)
            {
                log.LogMessage("Error obtenerBalanzas:" + e.Message);
            }
            finally
            {

            }
            return lista;
        }
    }
}
