using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Balanza.Configs;
using System.Configuration;
using System.IO;
using System.IO.Ports;
using Balanza.Bean;
using Balanza.Configs;
using System.Windows.Forms;


namespace Balanza
{
    public partial class frmBalanza : Form
    {
        private string pesoBalanza = String.Empty;
        Logger log;
        DAL datos;
        SerialPortManager _spManager;
        ConfigBalanza bal;
        bool resulBalanza = false;
        List<GrupoBean> listaGrupo;
        Timer fechaTimer;
        List<TipoSacoBean> listaTipoSaco;
        NotaPesoBean objTemporal;

        public frmBalanza()
        {
            InitializeComponent();
            datos = new DAL();
            log = new Logger();
            bal = new ConfigBalanza();
            this.FormClosing += FormBalanza_FormClosing;
            cargarPuertos();
            
        }

        private void FormBalanza_Load(object sender, EventArgs e)
        {
            try
            {
                iniciar();
            }
            catch (Exception ex) {
                MessageBox.Show("FormBalanza_Load: " + ex.Message, "Error");
                log.LogMessage("FormBalanza_Load: " + ex.Message);
            }
        }

        void _spManager_NewSerialDataRecieved(object sender, SerialDataEventArgs e)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    // Using this.Invoke causes deadlock when closing serial port, and BeginInvoke is good practice anyway.
                    this.BeginInvoke(new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved), new object[] { sender, e });
                    return;
                }

                resulBalanza = bal.procesarTrama(e.tramaPuerto);

                if (bal.esEstable())
                {
                    tbEstable.Text = "SI";
                }
                else
                {
                    tbEstable.Text = "NO";
                }

                tbPesoBruto.Text = bal.getPesoBruto().ToString();
                tbPesoNeto.Text = bal.getPesoNeto().ToString();
                tbTrama.Text = bal.getTrama();
                tbCaracteres.Text = bal.getTrama().Length.ToString();
                tbDecimal.Text = bal.getDecimal().ToString();

                if (!ConfigurationManager.AppSettings["lecturaContinua"].ToString().Equals("1"))
                {
                    _spManager.StopListening();
                    btnDetener.Enabled = false;
                    btnLeer.Enabled = true;
                }
            }
            catch(System.OutOfMemoryException oe)
            {
                log.LogMessage("Balanza Memoria _spManager_NewSerialDataRecieved: " + oe.Message);
            }
            catch(Exception ex)
            {
                log.LogMessage("Balanza _spManager_NewSerialDataRecieved: " + ex.Message);
            }
        }

        private void FormBalanza_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Seguro desea salir?", "Balanza", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    if (_spManager!=null)
                    {
                        _spManager.Dispose();
                    }
                    pararTimer();
                    e.Cancel = false;
                }
                finally {

                }
            }
            else {
                e.Cancel = true;
            }
        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbPuerto.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione el puerto a leer", ConfigurationManager.AppSettings["TitShowMessage"].ToString());
                }
                else
                {
                    if (cmbPuerto.SelectedItem.ToString().Length>0)
                    {
                        UseWaitCursor = true;
                        setearPuerto();
                        _spManager.StartListening();
                        UseWaitCursor = false;

                        if (ConfigurationManager.AppSettings["lecturaContinua"].ToString().Equals("1"))
                        {
                            btnDetener.Enabled = true;
                            btnLeer.Enabled = false;
                            cmbPuerto.Enabled = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Seleccione el puerto a leer", ConfigurationManager.AppSettings["TitShowMessage"].ToString());
                    }
                }
                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnLeerPuerto_Click: " + ex.Message, "Error");
                log.LogMessage("btnLeerPuerto_Click: " + ex.Message);

                UseWaitCursor = false;
            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            try
            {
                UseWaitCursor = true;
                _spManager.StopListening();
                UseWaitCursor = false;
                btnDetener.Enabled = false;
                btnLeer.Enabled = true;
                cmbPuerto.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("btnDetener_Click: " + ex.Message, "Error");
                log.LogMessage("btnDetener_Click: " + ex.Message);
                UseWaitCursor = false;
            }
            
        }

        private void cargarPuertos()
        {
            try
            {
                string[] ports = SerialPort.GetPortNames();

                cmbPuerto.Items.Clear();
                foreach (string pto in ports)
                {
                    cmbPuerto.Items.Add(pto);
                }

                if (ports.Length > 1)
                {
                    cmbPuerto.Enabled = true;
                }
                else if (ports.Length == 1)
                {
                    cmbPuerto.SelectedItem = ports[0];
                    cmbPuerto.Enabled = false;
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error cargarPuertos: "+e.Message);
            }
        }

        #region formularios

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void seguridadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!datos.validaAutenticacion(DAL.SEG_ADM))
            {
                MessageBox.Show("Confirmarción se seguridad no autenticada, no se puede continuar.", "Seguridad", MessageBoxButtons.OK);
                return;
            }
            cargarFormSeguridad();
        }

        private void parámetrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!datos.validaAutenticacion(DAL.SEG_ADM))
            {
                MessageBox.Show("Confirmarción se seguridad no autenticada, no se puede continuar.", "Parámetros", MessageBoxButtons.OK);
                return;
            }
            cargarFormManParametros();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!datos.validaAutenticacion(DAL.SEG_ADM))
            {
                MessageBox.Show("Confirmarción se seguridad no autenticada, no se puede continuar.", "Grupos", MessageBoxButtons.OK);
                return;
            }
            cargarFormManGrupos();
        }

        private void tipoSacosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!datos.validaAutenticacion(DAL.SEG_ADM))
            {
                MessageBox.Show("Confirmarción se seguridad no autenticada, no se puede continuar.", "Seguridad", MessageBoxButtons.OK);
                return;
            }
            cargarFormManTipoSacos();
        }

        private void cargarFormSeguridad()
        {
            try
            {
                Form instance = null;

                // Looking for MyForm among all opened forms 
                foreach (Form form in Application.OpenForms)
                    if (form is frmSecurity)
                    {
                        instance = form;

                        break;
                    }

                if (Object.ReferenceEquals(null, instance))
                {
                    // No opened form, lets create it and show up:
                    instance = new frmSecurity();
                    instance.StartPosition = FormStartPosition.CenterScreen;
                    instance.Show();
                }
                else
                {

                    // Lets bring it to front, focus, restore it sizes (if minimized)
                    if (instance.WindowState == FormWindowState.Minimized)
                        instance.WindowState = FormWindowState.Normal;

                    instance.BringToFront();

                    if (instance.CanFocus)
                    {
                        instance.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                log.LogMessage("Error creando ventana de seguridad: " + ex.Message);
            }
        }

        private void cargarFormManGrupos()
        {
            try
            {
                Form instance = null;
                foreach (Form form in Application.OpenForms)
                    if (form is frmManGrupos)
                    {
                        instance = form;

                        break;
                    }

                if (Object.ReferenceEquals(null, instance))
                {
                    instance = new frmManGrupos();
                    instance.StartPosition = FormStartPosition.CenterScreen;
                    instance.Show();
                }
                else
                {
                    if (instance.WindowState == FormWindowState.Minimized)
                        instance.WindowState = FormWindowState.Normal;

                    instance.BringToFront();

                    if (instance.CanFocus)
                    {
                        instance.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                log.LogMessage("Error creando ventana de grupos: " + ex.Message);
            }
        }

        private void cargarFormManTipoSacos()
        {
            try
            {
                Form instance = null;
                foreach (Form form in Application.OpenForms)
                    if (form is frmTipoSaco)
                    {
                        instance = form;

                        break;
                    }

                if (Object.ReferenceEquals(null, instance))
                {
                    instance = new frmTipoSaco();
                    instance.StartPosition = FormStartPosition.CenterScreen;
                    instance.Show();
                }
                else
                {
                    if (instance.WindowState == FormWindowState.Minimized)
                        instance.WindowState = FormWindowState.Normal;

                    instance.BringToFront();

                    if (instance.CanFocus)
                    {
                        instance.Focus();
                    }
                }

            }
            catch (Exception ex)
            {
                log.LogMessage("Error creando ventana de grupos: " + ex.Message);
            }
        }

        private void cargarFormManParametros()
        {
            try
            {
                Form instance = null;

                foreach (Form form in Application.OpenForms)
                    if (form is frmManParametros)
                    {
                        instance = form;
                        break;
                    }

                if (Object.ReferenceEquals(null, instance))
                {
                    instance = new frmManParametros();
                    instance.StartPosition = FormStartPosition.CenterScreen;
                    instance.Show();
                }
                else
                {
                    if (instance.WindowState == FormWindowState.Minimized)
                        instance.WindowState = FormWindowState.Normal;

                    instance.BringToFront();

                    if (instance.CanFocus)
                    {
                        instance.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                log.LogMessage("Error creando ventana de parámetros: " + ex.Message);
            }
        }

        private void cargarFormConfigBalanza()
        {
            try
            {
                Form instance = null;

                foreach (Form form in Application.OpenForms)
                    if (form is frmConfigBalanza)
                    {
                        instance = form;
                        break;
                    }

                if (Object.ReferenceEquals(null, instance))
                {
                    instance = new frmConfigBalanza();
                    instance.StartPosition = FormStartPosition.CenterScreen;
                    instance.Show();
                }
                else
                {
                    if (instance.WindowState == FormWindowState.Minimized)
                        instance.WindowState = FormWindowState.Normal;

                    instance.BringToFront();

                    if (instance.CanFocus)
                    {
                        instance.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                log.LogMessage("Error creando ventana de conf. de balanza: " + ex.Message);
            }
        }

        private void cargarFormConfigCalidad()
        {
            try
            {
                Form instance = null;

                foreach (Form form in Application.OpenForms)
                    if (form is frmConfigCalidad)
                    {
                        instance = form;
                        break;
                    }

                if (Object.ReferenceEquals(null, instance))
                {
                    instance = new frmConfigCalidad();
                    instance.StartPosition = FormStartPosition.CenterScreen;
                    instance.Show();
                }
                else
                {
                    if (instance.WindowState == FormWindowState.Minimized)
                        instance.WindowState = FormWindowState.Normal;

                    instance.BringToFront();

                    if (instance.CanFocus)
                    {
                        instance.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                log.LogMessage("Error creando ventana de conf. de calidad: " + ex.Message);
            }
        }

        private void confCalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!datos.validaAutenticacion(DAL.SEG_ADM))
            {
                MessageBox.Show("Confirmarción se seguridad no autenticada, no se puede continuar.", "Conf. Balanza", MessageBoxButtons.OK);
                return;
            }
            cargarFormConfigCalidad();
        }

        private void confBalanzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!datos.validaAutenticacion(DAL.SEG_USU))
            {
                MessageBox.Show("Confirmarción se seguridad no autenticada, no se puede continuar.", "Conf. Balanza", MessageBoxButtons.OK);
                return;
            }
            cargarFormConfigBalanza();
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarFormHistorial();
        }

        private void cargarFormHistorial()
        {
            try
            {
                Form instance = null;

                foreach (Form form in Application.OpenForms)
                    if (form is frmHistoriaNotaPeso)
                    {
                        instance = form;
                        break;
                    }

                if (Object.ReferenceEquals(null, instance))
                {
                    instance = new frmHistoriaNotaPeso();
                    instance.StartPosition = FormStartPosition.CenterScreen;
                    instance.Show();
                }
                else
                {
                    if (instance.WindowState == FormWindowState.Minimized)
                        instance.WindowState = FormWindowState.Normal;

                    instance.BringToFront();

                    if (instance.CanFocus)
                    {
                        instance.Focus();
                    }

                }

            }
            catch (Exception ex)
            {
                log.LogMessage("Error creando ventana de conf. de balanza: " + ex.Message);
            }

            
        }


        #endregion

        private void btnNuevaCaptura_Click(object sender, EventArgs e)
        {
            iniciar();
        }

        private void btnGrabarNota_Click(object sender, EventArgs e)
        {
            grabar();
        }

        private void setearPuerto() {
            String puerto = String.Empty;
            puerto = cmbPuerto.SelectedItem.ToString();
            _spManager = new SerialPortManager(puerto, int.Parse(ConfigurationManager.AppSettings["BaudRate"].ToString()), Parity.None, int.Parse(ConfigurationManager.AppSettings["DataBits"].ToString()), StopBits.One);
            _spManager.NewSerialDataRecieved += new EventHandler<SerialDataEventArgs>(_spManager_NewSerialDataRecieved);
        }

        private void cargarCombos()
        {
            try
            {
                listaGrupo = datos.obtenerListaGrupos(false);
                if (cmbEmpresa.Items != null) {
                    cmbEmpresa.Items.Clear();
                }
                if (cmbTipoGrano.Items != null)
                {
                    cmbTipoGrano.Items.Clear();
                }
                if (cmbCiudad.Items != null)
                {
                    cmbCiudad.Items.Clear();
                }
                if (cmbBalanza.Items != null)
                {
                    cmbBalanza.Items.Clear();
                }
                String temp;
                foreach(GrupoBean g in listaGrupo)
                {
                    temp = String.Empty;
                    if (g.CODGRUPO.Equals("1"))
                    {
                        foreach (DetalleGrupoBean dg in g.DETALLE) {
                            cmbEmpresa.Items.Add(dg.VALOR);
                            if (dg.VALOR_DEFECTO.Equals("S"))
                            {
                                temp=dg.VALOR;
                            }
                        }
                        cmbEmpresa.DropDownStyle = ComboBoxStyle.DropDownList;

                        if (g.EDITABLE.Equals("S"))
                        {
                            cmbEmpresa.Enabled = true;
                        }
                        else
                        {
                            cmbEmpresa.Enabled = false;
                            if (g.DETALLE.Count == 1)
                            {
                                cmbEmpresa.SelectedIndex = cmbEmpresa.FindStringExact(g.DETALLE[0].VALOR);
                            } else if (g.DETALLE.Count>1)
                            {
                                if (temp != String.Empty)
                                {
                                    cmbEmpresa.SelectedIndex = cmbEmpresa.FindStringExact(temp);
                                }
                            }
                        }
                        
                    }
                    else if (g.CODGRUPO.Equals("3"))
                    {
                        foreach (DetalleGrupoBean dg in g.DETALLE)
                        {
                            cmbTipoGrano.Items.Add(dg.VALOR);
                            if (dg.VALOR_DEFECTO.Equals("S"))
                            {
                                temp = dg.VALOR;
                            }
                        }
                        cmbTipoGrano.DropDownStyle = ComboBoxStyle.DropDownList;
                        if (g.EDITABLE.Equals("S"))
                        {
                            cmbTipoGrano.Enabled = true;
                        }
                        else
                        {
                            cmbTipoGrano.Enabled = false;
                            if (g.DETALLE.Count == 1)
                            {
                                cmbTipoGrano.SelectedIndex = cmbTipoGrano.FindStringExact(g.DETALLE[0].VALOR);
                            }
                            else if (g.DETALLE.Count > 1)
                            {
                                if (temp != String.Empty)
                                {
                                    cmbTipoGrano.SelectedIndex = cmbTipoGrano.FindStringExact(temp);
                                }
                            }
                        }

                    }
                    else if (g.CODGRUPO.Equals("4"))
                    {
                        foreach (DetalleGrupoBean dg in g.DETALLE)
                        {

                            if (dg.VALOR_DEFECTO.Equals("S"))
                            {
                                temp = dg.VALOR;
                            }
                        }
                        
                    }
                    else if (g.CODGRUPO.Equals("5"))
                    {
                        foreach (DetalleGrupoBean dg in g.DETALLE)
                        {
                            cmbCiudad.Items.Add(dg.VALOR);
                            if (dg.VALOR_DEFECTO.Equals("S"))
                            {
                                temp = dg.VALOR;
                            }
                        }
                        cmbCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
                        if (g.EDITABLE.Equals("S"))
                        {
                            cmbCiudad.Enabled = true;
                        }
                        else
                        {
                            cmbCiudad.Enabled = false;
                            if (g.DETALLE.Count == 1)
                            {
                                cmbCiudad.SelectedIndex = cmbCiudad.FindStringExact(g.DETALLE[0].VALOR);
                            }
                            else if (g.DETALLE.Count > 1)
                            {
                                if (temp != String.Empty)
                                {
                                    cmbCiudad.SelectedIndex = cmbCiudad.FindStringExact(temp);
                                }
                            }
                        }
                    }
                }

                cmbBalanza.Items.Add(bal.nombreBalanza());
                cmbBalanza.SelectedIndex = cmbBalanza.FindStringExact(bal.nombreBalanza());
                cmbBalanza.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbBalanza.Enabled = false;
            }
            catch(Exception e)
            {
                log.LogMessage("Error cargarCombos: "+e.Message);
            }
        }

        private void cargarTipoSaco() {
            listaTipoSaco = new List<TipoSacoBean>();
            TipoSacoBean ts;
            DataTable tabla= datos.obtenerListaTipoSacos(true);
            foreach(DataRow r in tabla.Rows)
            {
                ts = new TipoSacoBean();
                ts.TIPO_SACO = r["TIPO_SACO"].ToString();
                ts.PESO = float.Parse(r["PESO"].ToString());
                ts.ES_NEGATIVO = r["ES_NEGATIVO"].ToString();
                ts.ESTADO = r["ESTADO"].ToString();
                listaTipoSaco.Add(ts);
            }
        }

        private void iniciar()
        {
            tbDocOperador.MaxLength = int.Parse(datos.appConfig("caracterMaxDoc"));
            tbDocProductor.MaxLength = int.Parse(datos.appConfig("caracterMaxDoc"));

            dgvDetalleNota.AllowUserToAddRows = false;
            dgvDetalleNota.DataSource = new DataTable();
            cmbPuerto.DropDownStyle = ComboBoxStyle.DropDownList;
            dgvDetalleNota.AllowUserToAddRows = false;

            if (!ConfigurationManager.AppSettings["lecturaContinua"].ToString().Equals("1"))
            {
                btnDetener.Visible = false;
            }

            cargarCombos();
            cargarTipoSaco();
            limpiarTB();

            //Generando ticket
            String ticket=String.Empty;
            if (datos.generarTicket(ref ticket))
            {
                tbNumTicket.Text = ticket;
            }
            else {
                MessageBox.Show("Error generando ticket.",datos.appConfig("TitShowMessage"));
            }

            if (!inicializarTimer())
            {
                MessageBox.Show("Error definiendo la fecha.", datos.appConfig("TitShowMessage"));
            }
        }

        private void limpiarTB()
        {
            tbNumTotSac.Text = String.Empty;
            tbDocOperador.Text = String.Empty;
            tbDocProductor.Text = String.Empty;
            tbTotalNotPesBru.Text = String.Empty;
            tbTotalNotPesNet.Text = String.Empty;
        }

        private void tbDocOperador_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tbDocProductor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #region timer
        private bool inicializarTimer() {
            bool resultado = false;
            try
            {
                if (fechaTimer == null)
                {
                    fechaTimer = new Timer();
                    fechaTimer.Interval = 1000;
                    fechaTimer.Tick += new EventHandler(_timer_Elapsed);
                    fechaTimer.Enabled = true; //
                    fechaTimer.Start();
                }
                resultado = true;
            }
            catch (Exception e)
            {
                log.LogMessage("Error iniciando el timer: " + e.Message);
            }
            return resultado;
        }

        private void _timer_Elapsed(object sender, EventArgs e)
        {
            tbFechaRegistro.Text=String.Format("{0:d/M/yyyy HH:mm:ss}", DateTime.Now);
        }

        private void pararTimer()
        {
            try
            {
                if (fechaTimer != null)
                {
                    fechaTimer.Stop();
                }
            }
            catch (Exception e) {
                log.LogMessage("Error parando el timer: "+e.Message);
            }
        }
        #endregion

        #region tabla
        private void dgvDetalleNota_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnPeso_KeyPress);
            if (dgvDetalleNota.CurrentCell.ColumnIndex == 1)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnPeso_KeyPress);
                }
            }
        }

        private void ColumnPeso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void dgvDetalleNota_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (listaTipoSaco != null) { 
                DataGridViewComboBoxCell box = dgvDetalleNota.Rows[e.RowIndex].Cells[2] as DataGridViewComboBoxCell;
                foreach (TipoSacoBean ts in listaTipoSaco)
                {
                    box.Items.Add(ts.TIPO_SACO);
                }
            }
        }

        private void dgvDetalleNota_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleNota.CurrentCell != null)
            {
                if (dgvDetalleNota.CurrentCell.ColumnIndex == 2)
                {
                    calcularPesoNeto(e.RowIndex);
                }
            }
        }

        private void dgvDetalleNota_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleNota.CurrentCell != null)
            {
                if (dgvDetalleNota.CurrentCell.ColumnIndex == 2)
                {
                    calcularPesoNeto(e.RowIndex);
                }
            }
        }

        private void dgvDetalleNota_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDetalleNota.CurrentCell != null)
            {
                if (dgvDetalleNota.CurrentCell.ColumnIndex == 6)
                {
                    dgvDetalleNota.Rows[e.RowIndex].Cells[3].Value = tbPesoBruto.Text.Equals(String.Empty) ? "0" : tbPesoBruto.Text;
                    calcularPesoNeto(e.RowIndex);
                }
            }
        }

        private void dgvDetalleNota_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calcularPesoNeto(e.RowIndex);
            crearJsonPeso();
        }

        private void dgvDetalleNota_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            crearJsonPeso();
        }


        private void calcularPesoNeto(int fila)
        {
            try
            {
                Double pesoBolsa = 0;
                Double pesoBruto = 0; ;
                Double cantidad = 0;
                bool pesoNegativo = false;
                //CALCULANDO EL PESO DE LA BOLSA
                if (dgvDetalleNota.Rows[fila].Cells["TIPO_SACO"].Value == null)
                {
                    pesoBolsa = 0;
                }
                else
                {
                    foreach (TipoSacoBean ts in listaTipoSaco)
                    {
                        if (ts.TIPO_SACO.Equals(dgvDetalleNota.Rows[fila].Cells["TIPO_SACO"].Value.ToString()))
                        {
                            pesoBolsa = Math.Round(ts.PESO, int.Parse(datos.appConfig("cantidadDecimal")));

                            if (ts.ES_NEGATIVO.Equals("True"))
                            {
                                pesoNegativo = true;
                            }
                            else
                            {
                                pesoNegativo = false;
                            }
                        }
                    }
                }
                //CALCULANDO EL PESO BRUTO
                if (dgvDetalleNota.Rows[fila].Cells["PESO_BRUTO_SACO"].Value == null)
                {
                    pesoBruto = 0;
                }
                else
                {
                    pesoBruto = Math.Round(Double.Parse(dgvDetalleNota.Rows[fila].Cells["PESO_BRUTO_SACO"].Value.ToString()), int.Parse(datos.appConfig("cantidadDecimal")));
                }
                //CALCULANDO LA CANTIDAD
                if (dgvDetalleNota.Rows[fila].Cells["CANTIDAD"].Value == null)
                {
                    cantidad = 0;
                }
                else
                {
                    cantidad = Math.Round(Double.Parse(dgvDetalleNota.Rows[fila].Cells["CANTIDAD"].Value.ToString()), int.Parse(datos.appConfig("cantidadDecimal")));
                }

                Double resultado = 0;

                if (pesoNegativo) {
                    resultado = pesoBruto;
                }
                else
                {
                    resultado = pesoBruto - (cantidad * pesoBolsa);
                }

                dgvDetalleNota.Rows[fila].Cells["PESO_NETO_SACO"].Value = Math.Round(resultado, int.Parse(datos.appConfig("cantidadDecimal")));

                //CALCULO DE TOTALES
                Double totalizadoBruto = 0;
                Double totalizadoNeto = 0;
                Double totalizadoSacos = 0;

                foreach (DataGridViewRow row in dgvDetalleNota.Rows)
                {
                    if (row.Cells["PESO_BRUTO_SACO"].Value != null && row.Cells["PESO_NETO_SACO"].Value != null && row.Cells["CANTIDAD"].Value != null)
                    {
                        if (sacoPesoNegativo(row.Cells["TIPO_SACO"].Value)) {
                            totalizadoBruto = totalizadoBruto - Double.Parse(row.Cells["PESO_BRUTO_SACO"].Value.ToString());
                            totalizadoNeto = totalizadoNeto - Double.Parse(row.Cells["PESO_NETO_SACO"].Value.ToString());
                            totalizadoSacos = totalizadoSacos - Double.Parse(row.Cells["CANTIDAD"].Value.ToString());
                        }
                        else
                        {
                            totalizadoBruto = totalizadoBruto + Double.Parse(row.Cells["PESO_BRUTO_SACO"].Value.ToString());
                            totalizadoNeto = totalizadoNeto + Double.Parse(row.Cells["PESO_NETO_SACO"].Value.ToString());
                            totalizadoSacos = totalizadoSacos + Double.Parse(row.Cells["CANTIDAD"].Value.ToString());
                        }               
                    }
                    else {
                        log.LogMessage("Revisar fila con datos de peso bruto, peso neto o cantidad vacios: Indice:" + row.Index);
                    }
                }

                tbNumTotSac.Text = totalizadoSacos.ToString();
                tbTotalNotPesNet.Text = totalizadoNeto.ToString();
                tbTotalNotPesBru.Text = totalizadoBruto.ToString();

            }
            catch (Exception ex)
            {
                log.LogMessage("Error calculando el peso neto: " + ex.Message);
            }
        }
        #endregion

        #region validaciones

        private bool filasVacias()
        {
            dgvDetalleNota.EndEdit();
            foreach (DataGridViewRow fila in dgvDetalleNota.Rows)
            {
                if (fila.Cells["CANTIDAD"].Value == null)
                {
                    return true;
                }
                else
                {
                    if (fila.Cells["CANTIDAD"].Value.ToString().Trim().Equals(String.Empty))
                    {
                        return true;
                    }
                }

                if (fila.Cells["TIPO_SACO"].Value == null)
                {
                    return true;
                }
                else
                {
                    if (fila.Cells["TIPO_SACO"].Value.ToString().Trim().Equals(String.Empty))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool cantidadDecimales()
        {
            dgvDetalleNota.EndEdit();
            foreach (DataGridViewRow fila in dgvDetalleNota.Rows)
            {
                if (fila.Cells["CANTIDAD"].Value == null)
                {

                }
                else
                {
                    if (fila.Cells["CANTIDAD"].Value.ToString().IndexOf(".")>0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool camposBalanzaVacios(out String mensaje)
        {
            mensaje = String.Empty;
            bool resultado = false;
            try
            {
                if (cmbPuerto.SelectedIndex == -1)
                {
                    mensaje = "Balanza no conectada.";
                    resultado = true;
                }
                if (tbPesoBruto.Text == null)
                {
                    mensaje = "Balanza no conectada.";
                    resultado = true;
                }

                if (tbEstable.Text == null)
                {
                    mensaje = "Balanza no conectada.";
                    resultado = true;
                }
            }
            catch (Exception e)
            {
                log.LogMessage("camposVacios: " + e.Message);
            }
            return resultado;
        }

        private bool camposVacios(out String mensaje)
        {
            mensaje = String.Empty;
            bool resultado = false;
            try
            {
                if (cmbEmpresa.SelectedIndex==-1)
                {
                    mensaje = "Debe seleccionar una empresa.";
                    resultado = true;
                }
                if (cmbCiudad.SelectedIndex == -1)
                {
                    mensaje = "Debe seleccionar una ciudad.";
                    resultado = true;
                }
                if (cmbTipoGrano.SelectedIndex == -1)
                {
                    mensaje = "Debe seleccionar un tipo de grano";
                    resultado = true;
                }
                if (cmbBalanza.SelectedIndex == -1)
                {
                    mensaje = "Debe seleccionar una balanza";
                    resultado = true;
                }
                if (tbDocOperador.Text == null)
                {
                    mensaje = "Debe ingresar el documento del operador.";
                    resultado = true;
                }
                else
                {
                    if (tbDocOperador.Text.Trim().Equals(String.Empty))
                    {
                        mensaje = "Debe ingresar el documento del operador.";
                        resultado = true;
                    }
                }

                if (tbDocProductor.Text == null)
                {
                    mensaje = "Debe ingresar el documento del productor.";
                    resultado = true;
                }
                else
                {
                    if (tbDocProductor.Text.Trim().Equals(String.Empty))
                    {
                        mensaje = "Debe ingresar el documento del productor.";
                        resultado = true;
                    }
                }
                if (dgvDetalleNota.Rows.Count == 0)
                {
                    mensaje = "No ha registrado pesos por tipo de saco.";
                    resultado = true;
                }
            }
            catch(Exception e)
            {
                log.LogMessage("camposVacios: "+e.Message);
            }
            return resultado;
        }

        private bool camposCalculadosVacios(out String mensaje) {
            mensaje = String.Empty;
            bool resultado = true;
            try
            {
                if (tbNumTotSac.Text == null)
                {
                    mensaje = "No se ha calculado el total de sacos totales.";
                    resultado = true;
                }
                else
                {
                    if (tbNumTotSac.Text.Trim().Equals(String.Empty))
                    {
                        mensaje = "No se ha calculado el total de sacos totales."; ;
                        resultado = true;
                    }
                }
                if (tbTotalNotPesBru.Text == null)
                {
                    mensaje = "No se ha calculado el total de peso bruto.";
                    resultado = true;
                }
                else
                {
                    if (tbTotalNotPesBru.Text.Trim().Equals(String.Empty))
                    {
                        mensaje = "No se ha calculado el total de peso bruto."; ;
                        resultado = true;
                    }
                }
                if (tbTotalNotPesNet.Text == null)
                {
                    mensaje = "No se ha calculado el total de peso neto.";
                    resultado = true;
                }
                else
                {
                    if (tbTotalNotPesNet.Text.Trim().Equals(String.Empty))
                    {
                        mensaje = "No se ha calculado el total de peso neto."; ;
                        resultado = true;
                    }
                }
                if (tbNumTicket.Text == null)
                {
                    mensaje = "No se ha calculado el numero de ticket.";
                    resultado = true;
                }
                else
                {
                    if (tbNumTicket.Text.Trim().Equals(String.Empty))
                    {
                        mensaje = "No se ha calculado el numero de ticket."; ;
                        resultado = true;
                    }
                }
                resultado = false;
            }
            catch (Exception e)
            {
                log.LogMessage("camposCalculadosVacios: " + e.Message);
            }
            return resultado;
        }
        #endregion

        #region botones
        private void btnCapturaPeso_Click(object sender, EventArgs e)
        {
            if (!filasVacias())
            {
                String mensaje = String.Empty;
                if (camposBalanzaVacios(out mensaje))
                {
                    MessageBox.Show(mensaje, datos.appConfig("TitShowMessage"));
                    return;
                }
                if (datos.appConfig("valTipoSaco").Equals("1")) { 
                    if (existenRepetidosTipoSaco())
                    {
                        MessageBox.Show("No puede existir dos mismos tipos de sacos.", datos.appConfig("TitShowMessage"));
                        return;
                    }
                }

                dgvDetalleNota.EndEdit();
                dgvDetalleNota.Refresh();
                DataTable dataTable = (DataTable)dgvDetalleNota.DataSource;
                DataRow drToAdd = dataTable.NewRow();
                dataTable.Rows.Add(drToAdd);
                dgvDetalleNota.DataSource = dataTable;

                dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["PESO_BRUTO_SACO"].Value = tbPesoBruto.Text.Equals(String.Empty) ? "0" : tbPesoBruto.Text;
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["ESTABLE"];
                if (bal.esEstable() == true)
                {
                    chk.Value = true;
                    chk.Selected = true;
                }
                else
                {
                    chk.Value = false;
                    chk.Selected = false;
                }
                
                recalculoSecuencia();
                calcularPesoNeto(dgvDetalleNota.Rows.Count - 1);
                crearJsonPeso();

            }
            else
            {
                MessageBox.Show("No puede haber filas sin cantidad ni tipo de sacos ingresados.", datos.appConfig("TitShowMessage"));
            }
        }

        private void btnEliminarPeso_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDetalleNota.SelectedRows)
            {
                DataTable dataTable = (DataTable)dgvDetalleNota.DataSource;
                DataRow drToAdd = dataTable.NewRow();

                dataTable.Rows.RemoveAt(row.Index);
                dgvDetalleNota.DataSource = dataTable;

                recalculoSecuencia();
            }

            crearJsonPeso();
        }

        private void recalculoSecuencia() {
            //Se recalcula la secuencia
            int i = 1;
            foreach (DataGridViewRow r in dgvDetalleNota.Rows)
            {
                r.Cells[0].Value = i;
                i++;
            }
        }

        public bool existenRepetidosTipoSaco()
        {
            List<String> lista=new List<String>();
            foreach (DataGridViewRow row in dgvDetalleNota.Rows)
            {
                lista.Add(row.Cells[2].Value.ToString());
            }
            if (lista.Count() == lista.Distinct().Count()){
                return false;
            }
            return true;
        }
        #endregion

        #region grabar
        public void grabar()
        {
            bool resultado = false;
            String mensaje = String.Empty;
            try
            {
                if (camposBalanzaVacios(out mensaje))
                {
                    MessageBox.Show(mensaje,datos.appConfig("TitShowMessage"));
                }
                else
                {
                    if (camposVacios(out mensaje))
                    {
                        MessageBox.Show(mensaje, datos.appConfig("TitShowMessage"));
                    }
                    else
                    {
                        if (camposCalculadosVacios(out mensaje))
                        {
                            MessageBox.Show(mensaje, datos.appConfig("TitShowMessage"));
                        }
                        else
                        {
                            if (cantidadDecimales()) {
                                MessageBox.Show("Una cantidad de sacos esta con valores decimales", datos.appConfig("TitShowMessage"));
                            }
                            else {
                                int ID = 0;
                                NotaPesoBean nota = new NotaPesoBean();
                                resultado = grabarOperacion(out ID, ref nota);
                                if (resultado)
                                {
                                    //Impresion
                                    DialogResult result = MessageBox.Show("Desea registrar la calidad de la nota de peso?", datos.appConfig("TitShowMessage"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (result == DialogResult.Yes)
                                    {
                                        frmCalidad formCalidad = new frmCalidad(nota);
                                        formCalidad.ShowDialog();
                                    }
                                    else
                                    {
                                        if (datos.appConfig("imprimirSinCalidad").Equals("0"))
                                        {
                                            MessageBox.Show("No se realizo registro de calidad, no se podra imprimir.", datos.appConfig("TitShowMessage"));
                                        }
                                    }

                                    if (datos.appConfig("imprimirSinCalidad").Equals("1")) {

                                        //Impresion
                                        result = MessageBox.Show("Desea imprimir la nota de peso?", datos.appConfig("TitShowMessage"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (result == DialogResult.Yes)
                                        {
                                            String ruta = String.Empty;
                                            PrintDialog pd = new PrintDialog();
                                            pd.PrinterSettings = new PrinterSettings();
                                            if (DialogResult.OK == pd.ShowDialog(this))
                                            {
                                                if (nota.impresionNotaPeso(ref ruta))
                                                {
                                                    impresion(ruta, pd.PrinterSettings.PrinterName);
                                                    if (datos.appConfig("eliminarTmp").Equals("1"))
                                                    {
                                                        File.Delete(ruta);
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Error al generar archivo de impresión.", datos.appConfig("TitShowMessage"));
                                                    log.LogMessage("Error al generar archivo de impresión.");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Impresión cancelada.", datos.appConfig("TitShowMessage"));

                                            }
                                        }

                                    }

                                    MessageBox.Show("Nota " + ID + " registrada con exito", datos.appConfig("TitShowMessage"));
                                    iniciar();
                                    borrarJson();
                                }
                                else
                                {
                                    MessageBox.Show("Error grabando la nota de peso, revisar el log.", datos.appConfig("TitShowMessage"));
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception e)
            {
                log.LogMessage("grabar: " + e.Message);
                MessageBox.Show("Error al grabar la nota de peso: "+e.Message,datos.appConfig("TitShowMessage"));
            }
        }

        private bool grabarOperacion(out int ID, ref NotaPesoBean nota)
        {
            bool resultado = false;
            ID = 0;
            try
            {
                String mes, dia,hora,minuto,segundo;
                if (DateTime.Now.Month.ToString().Length == 1)
                {
                    mes = "0"+DateTime.Now.Month.ToString();
                }
                else {
                    mes = DateTime.Now.Month.ToString();
                }
                if (DateTime.Now.Day.ToString().Length == 1)
                {
                    dia = "0" + DateTime.Now.Day.ToString();
                }
                else
                {
                    dia = DateTime.Now.Day.ToString();
                }
                if (DateTime.Now.Hour.ToString().Length == 1)
                {
                    hora = "0" + DateTime.Now.Hour.ToString();
                }
                else
                {
                    hora = DateTime.Now.Hour.ToString();
                }
                if (DateTime.Now.Minute.ToString().Length == 1)
                {
                    minuto = "0" + DateTime.Now.Minute.ToString();
                }
                else
                {
                    minuto = DateTime.Now.Minute.ToString();
                }
                if (DateTime.Now.Second.ToString().Length == 1)
                {
                    segundo = "0" + DateTime.Now.Second.ToString();
                }
                else
                {
                    segundo = DateTime.Now.Second.ToString();
                }
                DetalleNotaPesoBean det;
                //NotaPesoBean nota=new NotaPesoBean();
                nota.EMPRESA = cmbEmpresa.SelectedItem.ToString();
                nota.TIPO_GRANO= cmbTipoGrano.SelectedItem.ToString();
                nota.FEC_REG_OPE = DateTime.Now.Year.ToString() + "-" + mes+"-"+dia  +  " " + hora + ":" + minuto + ":" + segundo;
                nota.CIUDAD = cmbCiudad.SelectedItem.ToString();
                nota.CANT_SACOS = int.Parse(tbNumTotSac.Text);
                nota.NUM_TICKET = tbNumTicket.Text;
                nota.DOC_OPERADOR = tbDocOperador.Text;
                nota.DOC_PRODUCTOR = tbDocProductor.Text;
                nota.TOTAL_PESO_BRUTO = float.Parse(tbTotalNotPesBru.Text);
                nota.TOTAL_PESO_NETO = float.Parse(tbTotalNotPesNet.Text);
                nota.REPORTADO_CENTRAL = "N";
                nota.ID_BALANZA = cmbBalanza.SelectedItem.ToString();

                resultado = datos.insertarNotaPeso(ref nota);
                ID = nota.ID_PESO;

                if (resultado)
                {
                    foreach (DataGridViewRow r in dgvDetalleNota.Rows)
                    {
                        det = new DetalleNotaPesoBean();
                        det.ID_PESO = nota.ID_PESO;
                        det.SECUENCIA = int.Parse(r.Cells["SECUENCIA"].Value.ToString());
                        det.CANTIDAD = int.Parse(r.Cells["CANTIDAD"].Value.ToString());
                        det.TIPO_SACO = r.Cells["TIPO_SACO"].Value.ToString();
                        det.PESO_BRUTO_SACO = float.Parse(r.Cells["PESO_BRUTO_SACO"].Value.ToString());
                        det.PESO_NETO_SACO = float.Parse(r.Cells["PESO_NETO_SACO"].Value.ToString());
                        if (r.Cells["ESTABLE"].Value == null)
                        {
                            det.PESO_ESTABLE = "N";
                        }
                        else
                        {
                            det.PESO_ESTABLE = r.Cells["ESTABLE"].Value.ToString().Equals("True") ? "S" : "N";
                        }
                        
                        nota.DETALLE.Add(det);
                    }

                    resultado = datos.insertarDetalleNotaPeso(nota);

                    if (!resultado)
                    {
                        datos.eliminarNotaPeso(ID);
                        throw new Exception("Error insertando el detalle de la nota.");
                    }

                    CalidadBean calidad = datos.obtenerCalidadNotaPeso(ID);
                    nota.CALIDAD = calidad;

                    resultado = datos.nextTicket();

                    resultado = true;
                    if (!resultado)
                    {
                        datos.eliminarNotaPeso(ID);
                        throw new Exception("Error actualizando el numero de ticket.");
                    }
                }
                else
                {
                    throw new Exception("Error insertando la cabecera de la nota");
                }

            }
            catch (Exception e)
            {
                log.LogMessage("grabarOperacion: " + e.Message);
                resultado = false;
            }
            return resultado;
        }
        #endregion

        private void tbDocOperador_Leave(object sender, EventArgs e)
        {
            if (tbDocOperador.Text.Length > 0 && tbDocOperador.Text.Length<int.Parse(datos.appConfig("caracterMinDoc")))
            {
                MessageBox.Show("Cantidad de caracteres insuficientes.", datos.appConfig("TitShowMessage"));
                tbDocOperador.Text = String.Empty;
            }

            if (tbDocProductor.Text.Length > int.Parse(datos.appConfig("caracterMaxDoc")))
            {
                MessageBox.Show("Cantidad de caracteres excedidos.", datos.appConfig("TitShowMessage"));
                tbDocProductor.Text = String.Empty;
            }
        }

        private void tbDocProductor_Leave(object sender, EventArgs e)
        {
            if (tbDocProductor.Text.Length > 0 && tbDocProductor.Text.Length < int.Parse(datos.appConfig("caracterMinDoc")))
            {
                MessageBox.Show("Cantidad de caracteres insuficientes.", datos.appConfig("TitShowMessage"));
                tbDocProductor.Text = String.Empty;
            }

            if (tbDocProductor.Text.Length > int.Parse(datos.appConfig("caracterMaxDoc")))
            {
                MessageBox.Show("Cantidad de caracteres excedidos.", datos.appConfig("TitShowMessage"));
                tbDocProductor.Text = String.Empty;
            }
        }

        #region temporalJson
        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            try
            {
                objTemporal = recuperarJsonPeso();

                if (objTemporal != null)
                {
                    //Setear valores de vuelta al formulario
                    cmbEmpresa.SelectedItem = objTemporal.EMPRESA;
                    cmbTipoGrano.SelectedItem = objTemporal.TIPO_GRANO;
                    cmbCiudad.SelectedItem = objTemporal.CIUDAD;
                    tbNumTotSac.Text= objTemporal.CANT_SACOS.ToString();
                    tbNumTicket.Text= objTemporal.NUM_TICKET;
                    tbDocOperador.Text= objTemporal.DOC_OPERADOR;
                    tbDocProductor.Text=objTemporal.DOC_PRODUCTOR;
                    tbTotalNotPesBru.Text= objTemporal.TOTAL_PESO_BRUTO.ToString();
                    tbTotalNotPesNet.Text= objTemporal.TOTAL_PESO_NETO.ToString();
                    cmbBalanza.SelectedItem = objTemporal.ID_BALANZA;

                    if (dgvDetalleNota.Rows.Count > 0)
                    {
                        dgvDetalleNota.Rows.Clear();
                    }

                    dgvDetalleNota.EndEdit();
                    dgvDetalleNota.Refresh();
                    DataTable dataTable = (DataTable)dgvDetalleNota.DataSource;
                    
                    foreach (DetalleNotaPesoBean detTemporal in objTemporal.DETALLE)
                    {
                        DataRow drToAdd = dataTable.NewRow();
                        dataTable.Rows.Add(drToAdd);
                        dgvDetalleNota.DataSource = dataTable;

                        dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["SECUENCIA"].Value = detTemporal.SECUENCIA.ToString();
                        dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["CANTIDAD"].Value = detTemporal.CANTIDAD.ToString();
                        dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["TIPO_SACO"].Value = detTemporal.TIPO_SACO;
                        dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["PESO_BRUTO_SACO"].Value = detTemporal.PESO_BRUTO_SACO;
                        dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["PESO_NETO_SACO"].Value = detTemporal.PESO_NETO_SACO;

                        if (detTemporal.PESO_ESTABLE != null)
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["ESTABLE"];
                            if (detTemporal.PESO_ESTABLE.Equals("S") || detTemporal.PESO_ESTABLE.Equals("SI"))
                            {
                                chk.Value = true;
                                chk.Selected = true;
                            }
                            else
                            {
                                chk.Value = false;
                                chk.Selected = false;
                            }
                        }
                        else
                        {
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvDetalleNota.Rows[dgvDetalleNota.Rows.Count - 1].Cells["ESTABLE"];
                            chk.Value = false;
                            chk.Selected = false;
                        }

                    }

                }
                else
                {
                    MessageBox.Show("No hay un peso temporal que recuperar.", datos.appConfig("TitShowMessage"));
                }

            }catch(Exception ex)
            {
                log.LogMessage("Error btnRecuperar_Click: "+ex.Message);
            }
        }

        private bool crearJsonPeso() {
            bool resultado = false;
            try
            {
                if (dgvDetalleNota.Rows.Count > 0)
                {
                    objTemporal = new NotaPesoBean();

                    DetalleNotaPesoBean detTemporal;
                    if (cmbEmpresa.SelectedItem != null)
                    {
                        objTemporal.EMPRESA = cmbEmpresa.SelectedItem.ToString();
                    }
                    
                    if (cmbTipoGrano.SelectedItem != null)
                    {
                        objTemporal.TIPO_GRANO = cmbTipoGrano.SelectedItem.ToString();
                    }
                    
                    if (cmbCiudad.SelectedItem != null)
                    {
                        objTemporal.CIUDAD = cmbCiudad.SelectedItem.ToString();
                    }
                    
                    if (tbNumTotSac.Text != null)
                    {
                        objTemporal.CANT_SACOS = int.Parse(tbNumTotSac.Text);
                    }
                    
                    if (tbNumTicket.Text != null)
                    {
                        objTemporal.NUM_TICKET = tbNumTicket.Text;
                    }
                    
                    if (tbDocOperador.Text != null)
                    {
                        objTemporal.DOC_OPERADOR = tbDocOperador.Text;
                    }
                    
                    if (tbDocProductor.Text != null)
                    {
                        objTemporal.DOC_PRODUCTOR = tbDocProductor.Text;
                    }
                    
                    if (tbTotalNotPesBru.Text != null)
                    {
                        objTemporal.TOTAL_PESO_BRUTO = float.Parse(tbTotalNotPesBru.Text);
                    }
                    
                    if (tbTotalNotPesNet.Text != null)
                    {
                        objTemporal.TOTAL_PESO_NETO = float.Parse(tbTotalNotPesNet.Text);
                    }
                    
                    if (cmbBalanza.SelectedItem != null)
                    {
                        objTemporal.ID_BALANZA = cmbBalanza.SelectedItem.ToString();
                    }
                    objTemporal.REPORTADO_CENTRAL = "N";
                    

                    foreach (DataGridViewRow r in dgvDetalleNota.Rows)
                    {
                        detTemporal = new DetalleNotaPesoBean();
                        detTemporal.ID_PESO = 0;
                        if (r.Cells["SECUENCIA"].Value!=null) {
                            detTemporal.SECUENCIA = int.Parse(r.Cells["SECUENCIA"].Value.ToString());
                        }
                        
                        if (r.Cells["CANTIDAD"].Value != null)
                        {
                            detTemporal.CANTIDAD = int.Parse(r.Cells["CANTIDAD"].Value.ToString());
                        }
                        
                        if (r.Cells["TIPO_SACO"].Value != null)
                        {
                            detTemporal.TIPO_SACO = r.Cells["TIPO_SACO"].Value.ToString();
                        }
                        
                        if (r.Cells["PESO_BRUTO_SACO"].Value != null)
                        {
                            detTemporal.PESO_BRUTO_SACO = float.Parse(r.Cells["PESO_BRUTO_SACO"].Value.ToString());
                        }
                        if (r.Cells["PESO_NETO_SACO"].Value != null)
                        {
                            detTemporal.PESO_NETO_SACO = float.Parse(r.Cells["PESO_NETO_SACO"].Value.ToString());
                        }
                        
                        if (r.Cells["ESTABLE"].Value == null)
                        {
                            detTemporal.PESO_ESTABLE = "N";
                        }
                        else
                        {
                            detTemporal.PESO_ESTABLE = r.Cells["ESTABLE"].Value.ToString().Equals("True") ? "S" : "N";
                        }

                        objTemporal.DETALLE.Add(detTemporal);
                    }

                    String rutaJson = datos.appConfig("rutaJsonTemporal");

                    String jSonObjeto=Newtonsoft.Json.JsonConvert.SerializeObject(objTemporal);

                    borrarJson();

                    File.WriteAllText(Environment.CurrentDirectory + "\\" + rutaJson,jSonObjeto);

                    resultado = true;
                }
                else
                {
                    log.LogMessage("No se puede crear objeto temporal sin filas de peso");
                }

            }
            catch(Exception e)
            {
                log.LogMessage("Error crearJsonPeso: "+e.Message);
            }
            return resultado;
        }

        private void borrarJson()
        {
            if (File.Exists(Environment.CurrentDirectory + datos.appConfig("rutaJsonTemporal")))
            {
                File.Delete(Environment.CurrentDirectory + datos.appConfig("rutaJsonTemporal"));
            }
        }

        private NotaPesoBean recuperarJsonPeso()
        {
            objTemporal = null;
            try
            {
                if (File.Exists(Environment.CurrentDirectory + "\\" + datos.appConfig("rutaJsonTemporal")))
                {
                    objTemporal = Newtonsoft.Json.JsonConvert.DeserializeObject<NotaPesoBean>(File.ReadAllText(Environment.CurrentDirectory + "\\" + datos.appConfig("rutaJsonTemporal")));
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error recuperarJsonPeso" +e.Message);
            }
            return objTemporal;
            

        }
        #endregion

        
        private bool sacoPesoNegativo(object tipoSaco) {
            try {
                if (tipoSaco != null)
                {
                    foreach (TipoSacoBean ts in listaTipoSaco)
                    {
                        if (ts.TIPO_SACO.Equals(tipoSaco.ToString()) && ts.ES_NEGATIVO.Equals("True"))
                        {
                            return true;
                        }
                    }
                }     
            }
            catch(Exception e)
            {
                log.LogMessage("Error sacoPesoNegativo: " + e.Message);
            }
            return false;
        }

        #region impresion
        private Font printFont;
        private StreamReader streamToPrint;
        static string filePath;
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            //float leftMargin = ev.MarginBounds.Left;
            float leftMargin = float.Parse(datos.appConfig("margenPagina"));
            //float topMargin = ev.MarginBounds.Top;
            float topMargin = float.Parse(datos.appConfig("margenPagina"));
            String line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

            // Iterate over the file, printing each line.
            while (count < linesPerPage && ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
            {
                ev.HasMorePages = true;
            }
            else
            {
                ev.HasMorePages = false;
            }

        }

        private void impresion(String ruta, String printer)
        {
            try
            {
                //Print string
                streamToPrint = new StreamReader(ruta);
                try
                {
                    printFont = new Font(datos.appConfig("tipoFont"), int.Parse(datos.appConfig("tamanioFont")));
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                    pd.PrinterSettings.PrinterName = printer;
                    pd.Print();
                }
                finally
                {
                    if (streamToPrint != null)
                    {
                        streamToPrint.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                log.LogMessage("impresion: " + ex.Message);
            }

        }

        #endregion

        
    }
}
