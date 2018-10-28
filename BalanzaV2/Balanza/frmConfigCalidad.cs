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
    public partial class frmConfigCalidad : Form
    {
        public frmConfigCalidad()
        {
            InitializeComponent();
        }

        private DAL dal;
        private Logger log;
        private DataTable dtTipoObjeto,dtGrupo;
        GrupoBean grupo;

        private void frmConfigCalidad_Load(object sender, EventArgs e)
        {
            dal = new DAL();
            log = new Logger();
            cargarDatos();
 
        }

        private void cmbTipGra_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDetalle(cmbTipGra.Items[cmbTipGra.SelectedIndex].ToString());
        }

        private void cargarDetalle(String item)
        {
            try
            {
                dgvConfigCalidad.AllowUserToAddRows = false;
                dgvConfigCalidad.DataSource = null;
                dgvConfigCalidad.AutoGenerateColumns = false;

                DataTable tabla;
                tabla = dal.obtenerconfiguracionCalidadDT(item);

                dgvConfigCalidad.Columns["ID_CAMPO"].DataPropertyName = "ID_CAMPO";
                dgvConfigCalidad.Columns["LABEL"].DataPropertyName = "LABEL";
                dgvConfigCalidad.Columns["TIPO"].DataPropertyName = "TIPO";
                dgvConfigCalidad.Columns["COD_GRUPO"].DataPropertyName = "COD_GRUPO";
                dgvConfigCalidad.Columns["OBLIGATORIO"].DataPropertyName = "OBLIGATORIO";
                dgvConfigCalidad.Columns["ESTADO"].DataPropertyName = "ESTADO";
                dgvConfigCalidad.Columns["LABEL_ETIQUETA"].DataPropertyName = "LABEL_ETIQUETA";
                dgvConfigCalidad.Columns["IMPRESION"].DataPropertyName = "IMPRESION";
                dgvConfigCalidad.DataSource = tabla;

            }
            catch (Exception e)
            {
                log.LogMessage("cargarDetalle: " + e.Message);
            }
        }

        private void dgvConfigCalidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado())
            {
                if (!filasSinData())
                {
                    DataTable dataTable = (DataTable)dgvConfigCalidad.DataSource;
                    DataRow drToAdd = dataTable.NewRow();
                    dataTable.Rows.Add(drToAdd);
                    dgvConfigCalidad.DataSource = dataTable;
                    recalculoSecuencia();
                    dgvConfigCalidad.EndEdit();
                }
                else
                {
                    MessageBox.Show("No puede haber filas sin el campo etiqueta y tipo lleno.");
                }
            }
            
        }

        public bool grupoSeleccionado()
        {
            if (cmbTipGra.SelectedItem == null)
            {
                return false;
            }
            else
            {
                if (cmbTipGra.SelectedItem.ToString().Equals(String.Empty))
                {
                    return false;
                }
            }

            return true;
        }

        public bool filasSinData()
        {
            int i = 0;
            foreach (DataGridViewRow row in dgvConfigCalidad.Rows)
            {
                if (row.Cells["LABEL"].Value == null)
                {
                    return true;
                }
                else
                {
                    if (row.Cells["LABEL"].Value.ToString().Equals(String.Empty))
                    {
                        return true;
                    }
                }

                if (row.Cells["TIPO"].Value == null)
                {
                    return true;
                }
                else
                {
                    if (row.Cells["TIPO"].Value.ToString().Equals(String.Empty))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvConfigCalidad.SelectedRows)
            {
                DataTable dataTable = (DataTable)dgvConfigCalidad.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                dataTable.Rows.RemoveAt(row.Index);
                dgvConfigCalidad.DataSource = dataTable;
            }
        }

        private void recalculoSecuencia()
        {
            //Se recalcula la secuencia
            int i = 1;
            foreach (DataGridViewRow r in dgvConfigCalidad.Rows)
            {
                r.Cells[0].Value = i;
                i++;
            }
        }

        private void dgvConfigCalidad_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConfigCalidad.Rows[e.RowIndex].Cells["TIPO"].Value != null)
            {
                if (!dgvConfigCalidad.Rows[e.RowIndex].Cells["TIPO"].Value.Equals("DROPDOWN_LIST"))
                {
                    dgvConfigCalidad.Rows[e.RowIndex].Cells["COD_GRUPO"].ReadOnly = true;
                    ((DataGridViewComboBoxCell)dgvConfigCalidad.Rows[e.RowIndex].Cells["COD_GRUPO"]).Value = 0;
                }
                else
                {
                    dgvConfigCalidad.Rows[e.RowIndex].Cells["COD_GRUPO"].ReadOnly = false;
                }
            }
            dgvConfigCalidad.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvConfigCalidad_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado())
            {
                if (!filasSinData())
                {
                    if (grabarGrupo())
                    {
                        MessageBox.Show("Grupo actualizado satisfactoriamente.");
                        limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error actualizando el grupo, revise el log.");
                    }
                }
            }
        }

        private void dgvConfigCalidad_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dtTipoObjeto != null)
            {
                DataGridViewComboBoxCell box = dgvConfigCalidad.Rows[e.RowIndex].Cells["TIPO"] as DataGridViewComboBoxCell;
                box.DisplayMember = "DESC_OBJETO";
                box.ValueMember = "TIPO_OBJETO";
                box.DataSource = dtTipoObjeto;
            }

            if (dtGrupo != null)
            {
                DataGridViewComboBoxCell box = dgvConfigCalidad.Rows[e.RowIndex].Cells["COD_GRUPO"] as DataGridViewComboBoxCell;
                box.DisplayMember = "DESGRUPO";
                box.ValueMember = "CODGRUPO";
                box.DataSource = dtGrupo;
            }
        }

        public void limpiar()
        {
            dgvConfigCalidad.DataSource = null;
            cmbTipGra.SelectedItem = String.Empty;
            cargarDatos();
        }

        public bool grabarGrupo()
        {
            bool resultado = false;
            String tipoGrano=String.Empty;
            try
            {
                dgvConfigCalidad.EndEdit();
                dgvConfigCalidad.Refresh();
                ConfigCalidadBean cg;
                List<ConfigCalidadBean> lista = new List<ConfigCalidadBean>();

                if (cmbTipGra.SelectedItem != null)
                {
                    tipoGrano=cmbTipGra.SelectedItem.ToString();
                }

                foreach (DataGridViewRow row in dgvConfigCalidad.Rows)
                {
                    cg = new ConfigCalidadBean();

                    if (row.Cells["ID_CAMPO"].Value != null)
                    {
                        cg.ID_CAMPO = int.Parse(row.Cells["ID_CAMPO"].Value.ToString());
                    }

                    cg.TIPO_GRANO = tipoGrano;

                    if (row.Cells["LABEL"].Value != null)
                    {
                        cg.LABEL = row.Cells["LABEL"].Value.ToString();
                    }

                    if (row.Cells["TIPO"].Value!=null) {
                        cg.TIPO = row.Cells["TIPO"].Value.ToString();
                    }

                    if (row.Cells["COD_GRUPO"].Value != null)
                    {
                        cg.COD_GRUPO = int.Parse(row.Cells["COD_GRUPO"].Value.ToString());
                    }

                    if (row.Cells["OBLIGATORIO"].Value != null)
                    {
                        if (row.Cells["OBLIGATORIO"].Value.ToString() == "True")
                        {
                            cg.OBLIGATORIO = "S";
                        }
                        else
                        {
                            cg.OBLIGATORIO = "N";
                        }
                    }

                    if (row.Cells["ESTADO"].Value != null)
                    {
                        if (row.Cells["ESTADO"].Value.ToString() == "True")
                        {
                            cg.ESTADO = "A";
                        }
                        else
                        {
                            cg.ESTADO = "I";
                        }
                    }

                    if (row.Cells["IMPRESION"].Value != null)
                    {
                        if (row.Cells["IMPRESION"].Value.ToString() == "True")
                        {
                            cg.IMPRESION = "S";
                        }
                        else
                        {
                            cg.IMPRESION = "N";
                        }
                    }

                    if (row.Cells["LABEL_ETIQUETA"].Value != null)
                    {
                        cg.LABEL_ETIQUETA = row.Cells["LABEL_ETIQUETA"].Value.ToString();
                    }

                    lista.Add(cg);
                }

                resultado =dal.grabarConfigCalidad(lista, tipoGrano);

            }
            catch (Exception e)
            {
                resultado = false;
                log.LogMessage("Error grabarGrupo:" + e.Message);
            }
            return resultado;
        }

        public void cargarDatos() {
            try
            {
                dtTipoObjeto = dal.obtenerTipoObjeto();
                dtGrupo = dal.obtenerListaGrupos();

                dgvConfigCalidad.AllowUserToAddRows = false;
                dgvConfigCalidad.DataSource = null;
                dgvConfigCalidad.AutoGenerateColumns = false;

                grupo = dal.obtenerGrupo("3");

                if (grupo != null)
                {
                    cmbTipGra.Items.Clear();
                    foreach (DetalleGrupoBean dgb in grupo.DETALLE)
                    {
                        cmbTipGra.Items.Add(dgb.VALOR);
                    }
                }
            }
            catch (Exception e) {
                log.LogMessage("Error cargarDatos:" + e.Message);
            }
        }

    }
}
