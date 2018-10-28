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
    public partial class frmManGrupos : Form
    {
        Logger log;
        DAL datos;
        List<GrupoBean> lista = new List<GrupoBean>();
        DataTable tabla;

        public frmManGrupos()
        {
            InitializeComponent();
            log = new Logger();
            datos = new DAL();

        }


        private void cmbGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarDetalle(cmbGrupo.Items[cmbGrupo.SelectedIndex].ToString());
        }

        private void cargarData() {
            try {
                lista = datos.obtenerListaGrupos(true);
                cmbGrupo.Items.Clear();
                foreach(GrupoBean g in lista)
                {
                    cmbGrupo.Items.Add(g.DESGRUPO);
                }
            }
            catch(Exception e)
            {
                log.LogMessage("cargarData: " + e.Message);
            }
        }

        private void cargarDetalle(String item)
        {
            try
            {
                dgvDetalleGrupo.AllowUserToAddRows = false;
                dgvDetalleGrupo.DataSource = null;
                dgvDetalleGrupo.AutoGenerateColumns = false;

                foreach (GrupoBean g in lista)
                {
                    if (g.DESGRUPO.Equals(item)) {
                        if (g.EDITABLE.Equals("S"))
                        {
                            cbSelGrupo.Checked = true;
                        }
                        else {
                            cbSelGrupo.Checked = false;
                        }

                        if (g.ESTADO.Equals("A"))
                        {
                            cbActivo.Checked = true;
                        }
                        else
                        {
                            cbActivo.Checked = false;
                        }

                        tabla = datos.obtenerDetalleGrupo(g.CODGRUPO);

                        dgvDetalleGrupo.Columns["CODGRUPO"].DataPropertyName = "CODGRUPO";
                        dgvDetalleGrupo.Columns["VALOR"].DataPropertyName = "VALOR";
                        dgvDetalleGrupo.Columns["VALOR_DEFECTO"].DataPropertyName = "VALOR_DEFECTO";
                        dgvDetalleGrupo.Columns["ESTADO"].DataPropertyName = "ESTADO";
                        dgvDetalleGrupo.DataSource = tabla;
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("cargarDetalle: " + e.Message);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado())
            {
                if (!filasSinData())
                {
                    
                    if (cuentaDefault()>1)
                    {
                        MessageBox.Show("Solo debe haber un valor por defecto");
                    }
                    else
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
                else
                {
                    MessageBox.Show("No puede haber filas sin el campo valor lleno.");
                }
            }
        }

        private void frmManGrupos_Load(object sender, EventArgs e)
        {
            cmbGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cargarData();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (grupoSeleccionado()) {
                if (!filasSinData())
                {
                    DataTable dataTable = (DataTable)dgvDetalleGrupo.DataSource;
                    DataRow drToAdd = dataTable.NewRow();
                    dataTable.Rows.Add(drToAdd);
                    dataTable.AcceptChanges();
                    dgvDetalleGrupo.DataSource = dataTable;
                }
                else
                {
                    MessageBox.Show("No puede haber filas sin el campo valor lleno.");
                }
            }
            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDetalleGrupo.SelectedRows)
            {
                DataTable dataTable = (DataTable)dgvDetalleGrupo.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                dataTable.Rows.RemoveAt(row.Index);
                dataTable.AcceptChanges();
                dgvDetalleGrupo.DataSource = dataTable;
            }
        }

        public bool filasSinData()
        {
            int i = 0;
            foreach (DataGridViewRow row in dgvDetalleGrupo.Rows)
            {
                if (row.Cells["VALOR"].Value==null)
                {
                    return true;
                }
                else
                {
                    if (row.Cells["VALOR"].Value.ToString().Equals(String.Empty))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool grupoSeleccionado() {
            if (cmbGrupo.SelectedItem == null)
            {
                return false;
            }
            else {
                if (cmbGrupo.SelectedItem.ToString().Equals(String.Empty))
                {
                    return false;
                }
            }
            
            return true;
        }

        public bool grabarGrupo()
        {
            bool resultado = false;
            try
            {
                dgvDetalleGrupo.EndEdit();
                dgvDetalleGrupo.Refresh();
                GrupoBean gr = new GrupoBean();
                DetalleGrupoBean det;

                gr.CODGRUPO = obtenerGrupo(cmbGrupo.SelectedItem.ToString());
                gr.DESGRUPO = cmbGrupo.SelectedItem.ToString();
                if (cbSelGrupo.Checked == true)
                {
                    gr.EDITABLE = "S";
                }
                else
                {
                    gr.EDITABLE = "N";
                }
                if (cbActivo.Checked == true)
                {
                    gr.ESTADO = "A";
                }
                else
                {
                    gr.ESTADO = "I";
                }

                foreach (DataGridViewRow row in dgvDetalleGrupo.Rows)
                {
                    det = new DetalleGrupoBean();
                    det.CODGRUPO = gr.CODGRUPO;
                    det.VALOR = row.Cells["VALOR"].Value.ToString();

                    if (row.Cells["VALOR_DEFECTO"].Value.ToString() == "True")
                    {
                        det.VALOR_DEFECTO = "S";
                    }
                    else
                    {
                        det.VALOR_DEFECTO = "N";
                    }

                    if (row.Cells["ESTADO"].Value.ToString() == "True")
                    {
                        det.ESTADO = "A";
                    }
                    else
                    {
                        det.ESTADO = "I";
                    }
                    gr.DETALLE.Add(det);
                }

                resultado = datos.actualizarGrupo(gr);
            }
            catch (Exception e) {
                resultado = false;
                log.LogMessage("Error grabarGrupo:"+ e.Message);
            }
            return resultado;
        }

        public String obtenerGrupo(String desGrupo) {
            String codigo = String.Empty;
            foreach(GrupoBean g in lista)
            {
                if (g.DESGRUPO.Equals(desGrupo))
                {
                    return g.CODGRUPO;
                }
            }
            return codigo;
        }

        public void limpiar()
        {
            dgvDetalleGrupo.DataSource = null;
            cmbGrupo.SelectedItem = String.Empty;
            cbActivo.Checked = false;
            cbSelGrupo.Checked = false;
            cargarData();
        }

        private int cuentaDefault()
        {
            int i = 0;
            dgvDetalleGrupo.EndEdit();
            foreach (DataGridViewRow fila in dgvDetalleGrupo.Rows)
            {
                if (fila.Cells["VALOR_DEFECTO"].Value.ToString() == "True")
                {
                    i++;
                }
            }

            return i;
        }

        private void dgvDetalleGrupo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
