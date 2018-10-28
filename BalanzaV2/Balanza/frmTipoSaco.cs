using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Balanza.Configs;
using Balanza.Bean;

namespace Balanza
{
    public partial class frmTipoSaco : Form
    {
        Logger log;
        DAL datos;
        List<TipoSacoBean> lista = new List<TipoSacoBean>();
        DataTable tabla;

        public frmTipoSaco()
        {
            InitializeComponent();
            log = new Logger();
            datos = new DAL();
        }

        private void frmTipoSaco_Load(object sender, EventArgs e)
        {
            cargarData();
        }

        private void cargarData()
        {
            try
            {
                dgvTipoSaco.AllowUserToAddRows = false;
                dgvTipoSaco.DataSource = null;
                dgvTipoSaco.AutoGenerateColumns = false;

                tabla = datos.obtenerListaTipoSacos(false);

                dgvTipoSaco.Columns["TIPO_SACO"].DataPropertyName = "TIPO_SACO";
                dgvTipoSaco.Columns["PESO"].DataPropertyName = "PESO";
                dgvTipoSaco.Columns["ES_NEGATIVO"].DataPropertyName = "ES_NEGATIVO";
                dgvTipoSaco.Columns["ESTADO"].DataPropertyName = "ESTADO";
                dgvTipoSaco.DataSource = tabla;
                    
            }
            catch (Exception e)
            {
                log.LogMessage("cargarData: " + e.Message);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTipoSaco.SelectedRows)
            {
                DataTable dataTable = (DataTable)dgvTipoSaco.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                dataTable.Rows.RemoveAt(row.Index);
                dataTable.AcceptChanges();
                dgvTipoSaco.DataSource = dataTable;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!filasVacias()) {

                DataTable dataTable = (DataTable)dgvTipoSaco.DataSource;
                DataRow drToAdd = dataTable.NewRow();
                dataTable.Rows.Add(drToAdd);
                dataTable.AcceptChanges();
                dgvTipoSaco.DataSource = dataTable;
            }
            else
            {
                MessageBox.Show("No puede haber tipo de sacos vacios",datos.appConfig("TitShowMessage"));
            }
        }

        private bool filasVacias()
        {
            dgvTipoSaco.EndEdit();
            foreach (DataGridViewRow fila in dgvTipoSaco.Rows)
            {
                if (fila.Cells["TIPO_SACO"].Value.ToString() == null)
                {
                    return true;
                }
                else {
                    if (fila.Cells["TIPO_SACO"].Value.ToString().Trim().Equals(String.Empty))
                    {
                        return true;
                    }
                }

                if (fila.Cells["PESO"].Value.ToString() == null)
                {
                    return true;
                }
                else
                {
                    if (fila.Cells["PESO"].Value.ToString().Trim().Equals(String.Empty))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool guardar()
        {
            bool resultado = false;
            List<String> lista = new List<String>();
            dgvTipoSaco.EndEdit();
            String estado,es_negativo;

            try
            {
                if (dgvTipoSaco.Rows.Count > 0)
                {
                    lista.Add("DELETE FROM TIPO_SACO;");
                }
                foreach (DataGridViewRow r in dgvTipoSaco.Rows)
                {
                    if (r.Cells["ESTADO"].Value == null)
                    {
                        estado = "I";
                    }
                    else
                    {
                        if (r.Cells["ESTADO"].Value.ToString().Equals("True"))
                        {
                            estado = "A";
                        }
                        else
                        {
                            estado = "I";
                        }
                    }

                    if (r.Cells["ES_NEGATIVO"].Value == null)
                    {
                        es_negativo = "N";
                    }
                    else
                    {
                        if (r.Cells["ES_NEGATIVO"].Value.ToString().Equals("True"))
                        {
                            es_negativo = "S";
                        }
                        else
                        {
                            es_negativo = "N";
                        }
                    }

                    lista.Add("INSERT INTO TIPO_SACO(TIPO_SACO,PESO,ES_NEGATIVO,ESTADO) VALUES('" + r.Cells["TIPO_SACO"].Value.ToString() + "'," + r.Cells["PESO"].Value.ToString() + ",'" + es_negativo + "','"+estado+"');");
                }
                resultado = datos.insertarTipoSaco(lista);
            }
            catch(Exception e)
            {
                log.LogMessage("Fallo en la grabación de tipo de sacos.");
                resultado = false;
            }
            return resultado;
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool resultado = false;
            if (dgvTipoSaco.Rows.Count > 0)
            {
                if (!filasVacias())
                {
                    resultado = guardar();
                    if (!resultado)
                    {
                        MessageBox.Show("Error al grabar los tipos de sacos, revisar el log.", datos.appConfig("TitShowMessage"));
                    }
                    else {
                        MessageBox.Show("Actualización satisfactoria", datos.appConfig("TitShowMessage"));
                        cargarData();
                    }
                }
                else
                {
                    MessageBox.Show("No puede haber tipo de sacos vacios", datos.appConfig("TitShowMessage"));
                }
            }
            else {
                MessageBox.Show("No existen datos a guardar", datos.appConfig("TitShowMessage"));
            }
        }

    }
}
