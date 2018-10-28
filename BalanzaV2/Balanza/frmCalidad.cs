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
using Balanza.UC;
using System.Windows.Forms;


namespace Balanza
{
    public partial class frmCalidad : Form
    {
        private string pesoBalanza = String.Empty;
        Logger log;
        DAL datos;
        bool resulBalanza = false;
        List<GrupoBean> listaGrupo;
        Timer fechaTimer;
        List<TipoSacoBean> listaTipoSaco;
        private String VENTANA=String.Empty;
        private bool nuevoRegistro = false;
        NotaPesoBean notaPesoCalidad;

        public frmCalidad(NotaPesoBean nota)
        {
            InitializeComponent();
            datos = new DAL();
            log = new Logger();
            notaPesoCalidad = nota;
        }

        private void FormCalidad_Load(object sender, EventArgs e)
        {
            try
            {
                iniciar();
            }
            catch (Exception ex) {
                MessageBox.Show("FormCalidad_Load: " + ex.Message, "Error");
                log.LogMessage("FormCalidad_Load: " + ex.Message);
            }
        }

        #region MenuBotones

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grabarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String mensaje = String.Empty;
            if (camposVacios(out mensaje))
            {
                MessageBox.Show(mensaje,datos.appConfig("TitShowMessage"));
            }
            else
            {
                if (camposCalculadosVacios(out mensaje))
                {
                    MessageBox.Show(mensaje, datos.appConfig("TitShowMessage"));
                }
                else
                {
                    if(!validarObligatoriosCalidad(out mensaje))
                    {
                        MessageBox.Show(mensaje, datos.appConfig("TitShowMessage"));
                    }
                    else
                    {
                        int IDCalidad = 0;
                        if (grabarCalidad(out IDCalidad))
                        {
                            //Impresion
                            DialogResult result = MessageBox.Show("Desea imprimir la nota de peso?", datos.appConfig("TitShowMessage"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                String ruta = String.Empty;
                                PrintDialog pd = new PrintDialog();
                                pd.PrinterSettings = new PrinterSettings();
                                if (DialogResult.OK == pd.ShowDialog(this))
                                {
                                    if (notaPesoCalidad.impresionNotaPeso(ref ruta))
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


                            MessageBox.Show("Nota de calidad "+IDCalidad+" registrada exitosamente", datos.appConfig("TitShowMessage"));
                            deshabilitarControlesDinamicos(true);
                            grabarToolStripMenuItem.Enabled = false;
                        }
                        else {
                            MessageBox.Show("Error grabando nota de calidad, revisar el log.", datos.appConfig("TitShowMessage"));
                        }
                    }
                }
            }
        }
        
        #endregion

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
                ts.ESTADO = r["ESTADO"].ToString();
                listaTipoSaco.Add(ts);
            }
        }

        private void iniciar()
        {
            tbDocOperador.MaxLength = int.Parse(datos.appConfig("caracterMaxDoc"));
            tbDocProductor.MaxLength = int.Parse(datos.appConfig("caracterMaxDoc"));
            cargarCombos();
            cargarTipoSaco();
            limpiarTB();

            cargarDatosBalanza(notaPesoCalidad);

            crearControles(cargarControlDinamico(notaPesoCalidad.TIPO_GRANO));
            setearDatosControles(notaPesoCalidad.CALIDAD);

            if (notaPesoCalidad.CALIDAD.ID_CALIDAD == 0)
            {
                grabarToolStripMenuItem.Enabled = true;
                habilitarCamposNotaPeso(false);
                nuevoRegistro = true;
            }
            else
            {
                grabarToolStripMenuItem.Enabled = false;
                habilitarCamposNotaPeso(false);
                deshabilitarControlesDinamicos(true);
                nuevoRegistro = false;
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

        private void cargarDatosBalanza(NotaPesoBean nota)
        {
            try
            {
                if (nota != null) { 
                    if (nota.ID_PESO != null)
                    {
                        tbID.Text = nota.ID_PESO.ToString();
                    }
                    if (cmbEmpresa.Items.Count > 0 && nota.EMPRESA != null)
                    {
                        cmbEmpresa.SelectedItem = nota.EMPRESA;
                    }
                    if (nota.NUM_TICKET != null)
                    {
                        tbNumTicket.Text = nota.NUM_TICKET;
                    }
                    if (nota.FEC_REG_OPE != null)
                    {
                        tbFechaRegistro.Text = nota.FEC_REG_OPE;
                    }
                    if (cmbTipoGrano.Items.Count > 0 && nota.TIPO_GRANO != null)
                    {
                        cmbTipoGrano.SelectedItem = nota.TIPO_GRANO;
                    }
                    if (cmbCiudad.Items.Count > 0 && nota.CIUDAD != null)
                    {
                        cmbCiudad.SelectedItem = nota.CIUDAD;
                    }
                    if (nota.ID_BALANZA != null)
                    {
                        tbBalanza.Text= nota.ID_BALANZA;
                    }
                    tbPesosRegistrados.Text = nota.DETALLE.Count.ToString();
                    if (nota.DOC_OPERADOR != null)
                    {
                        tbDocOperador.Text = nota.DOC_OPERADOR;
                    }
                    if (nota.DOC_PRODUCTOR != null)
                    {
                        tbDocProductor.Text = nota.DOC_PRODUCTOR;
                    }
                    if (nota.TOTAL_PESO_BRUTO != null)
                    {
                        tbTotalNotPesBru.Text = nota.TOTAL_PESO_BRUTO.ToString();
                    }
                    if (nota.TOTAL_PESO_NETO != null)
                    {
                        tbTotalNotPesNet.Text = nota.TOTAL_PESO_NETO.ToString();
                    }
                    if (nota.CANT_SACOS != null)
                    {
                        tbNumTotSac.Text = nota.CANT_SACOS.ToString();
                    }
                }
            }
            catch(Exception e)
            {
                log.LogMessage("Error cargarDatosBalanza: " + e.Message);
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

        #region validaciones

        private bool camposVacios(out String mensaje)
        {
            mensaje = String.Empty;
            bool resultado = false;
            try
            {
                if (cmbEmpresa.SelectedIndex==-1)
                {
                    mensaje = "Debe existir una empresa.";
                    resultado = true;
                }
                if (cmbCiudad.SelectedIndex == -1)
                {
                    mensaje = "Debe existir una ciudad.";
                    resultado = true;
                }
                if (cmbTipoGrano.SelectedIndex == -1)
                {
                    mensaje = "Debe existir un tipo de grano";
                    resultado = true;
                }
                if (tbDocOperador.Text == null)
                {
                    mensaje = "Debe existir el documento del operador.";
                    resultado = true;
                }
                else
                {
                    if (tbDocOperador.Text.Trim().Equals(String.Empty))
                    {
                        mensaje = "Debe existir el documento del operador.";
                        resultado = true;
                    }
                }

                if (tbDocProductor.Text == null)
                {
                    mensaje = "Debe existir el documento del productor.";
                    resultado = true;
                }
                else
                {
                    if (tbDocProductor.Text.Trim().Equals(String.Empty))
                    {
                        mensaje = "Debe existir el documento del productor.";
                        resultado = true;
                    }
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

        private bool validarObligatoriosCalidad(out String mensaje)
        {
            bool resultado = true;
            mensaje = String.Empty;
            try
            {
                foreach (Control ctrl in tlPanel.Controls)
                {
                    if (ctrl is UCAlfanumerico)
                    {
                        UCAlfanumerico obj = ctrl as UCAlfanumerico;
                        if (obj.esObligatorio() == true && obj.obtenerValor().Equals(String.Empty))
                        {
                            resultado = false;
                            mensaje = "Campo " + obj.obtenerEtiqueta() + " esta vacio. Por favor ingresar data.";
                        }
                    }
                    if (ctrl is UCNumerico)
                    {
                        UCNumerico obj = ctrl as UCNumerico;
                        if (obj.esObligatorio() == true && obj.obtenerValor().Equals(String.Empty))
                        {
                            resultado = false;
                            mensaje = "Campo " + obj.obtenerEtiqueta() + " esta vacio. Por favor ingresar data.";
                        }
                    }
                    if (ctrl is UCComboBox)
                    {
                        UCComboBox obj = ctrl as UCComboBox;
                        if (obj.esObligatorio() == true && obj.obtenerValor().Equals(String.Empty))
                        {
                            resultado = false;
                            mensaje = "Campo " + obj.obtenerEtiqueta() + " esta vacio. Por favor ingresar data.";
                        }
                    }
                    if (ctrl is UCDate)
                    {
                        UCDate obj = ctrl as UCDate;
                        if (obj.esObligatorio() == true && obj.obtenerValor().Equals(String.Empty))
                        {
                            resultado = false;
                            mensaje = "Campo " + obj.obtenerEtiqueta() + " esta vacio. Por favor ingresar data.";
                        }
                    }
                    if (ctrl is UCDNI)
                    {
                        UCDNI obj = ctrl as UCDNI;
                        if (obj.esObligatorio() == true && obj.obtenerValor().Equals(String.Empty))
                        {
                            resultado = false;
                            mensaje = "Campo " + obj.obtenerEtiqueta() + " esta vacio. Por favor ingresar data.";
                        }
                    }
                    if (ctrl is UCPercentage)
                    {
                        UCPercentage obj = ctrl as UCPercentage;
                        if (obj.esObligatorio() == true && obj.obtenerValor().Equals(datos.appConfig("UCPercentageVacio")))
                        {
                            resultado = false;
                            mensaje = "Campo " + obj.obtenerEtiqueta() + " esta vacio. Por favor ingresar data.";
                        }
                    }

                    if (!resultado)
                    {
                        return false;
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error validarObligatoriosCalidad: " + e.Message);
            }
            return resultado;
        }
        #endregion

        #region ControlDinamico

        private List<ConfigCalidadBean> cargarControlDinamico(String tipoGrano) {
            List<ConfigCalidadBean> lista = new List<ConfigCalidadBean>();
            try
            {
                lista=datos.obtenerConfiguracionCalidad(tipoGrano);
            }
            catch(Exception e)
            {
                log.LogMessage("Error cargarControlDinamico: "+e.Message);
            }
            return lista;
        }

        private void crearControles(List<ConfigCalidadBean> lista)
        {
            try
            {
                UCAlfanumerico alfa;
                UCNumerico nume;
                UCCheckBox check;
                UCComboBox combo;
                UCDate fecha;
                UCDNI dni;
                UCPercentage porc;
                UCRadioButton radio;
                UCTickerHour ticker;
                List<String> listaGrupo;

                tlPanel.Controls.Clear();
                tlPanel.ColumnCount = int.Parse(datos.appConfig("ColumnasLayout"));

                foreach (ConfigCalidadBean bean in lista)
                {
                    if (bean.TIPO.Equals("INPUT_ALFANUMERICO"))
                    {
                        alfa = new UCAlfanumerico(bean.ID_CAMPO);
                        if (bean.OBLIGATORIO.Equals("S"))
                        {
                            alfa.setearObligatorio(true);
                        }
                        alfa.longitud(int.Parse(datos.appConfig("longitudCalidad")));
                        alfa.setearEtiqueta(bean.LABEL);
                        tlPanel.Controls.Add(alfa);
                    }
                    if (bean.TIPO.Equals("INPUT_NUMERICO"))
                    {
                        nume = new UCNumerico(bean.ID_CAMPO);
                        if (bean.OBLIGATORIO.Equals("S"))
                        {
                            nume.setearObligatorio(true);
                        }
                        nume.longitud(int.Parse(datos.appConfig("longitudNumeroCalidad")));
                        nume.setearEtiqueta(bean.LABEL);
                        tlPanel.Controls.Add(nume);
                    }
                    if (bean.TIPO.Equals("DROPDOWN_LIST"))
                    {
                        combo = new UCComboBox(bean.ID_CAMPO);
                        if (bean.OBLIGATORIO.Equals("S"))
                        {
                            combo.setearObligatorio(true);
                        }
                        combo.setearEtiqueta(bean.LABEL);
                        if (bean.COD_GRUPO>0)
                        {
                            listaGrupo = new List<String>();
                            GrupoBean grupo=datos.obtenerGrupo(bean.COD_GRUPO.ToString());
                            foreach(DetalleGrupoBean det in grupo.DETALLE)
                            {
                                listaGrupo.Add(det.VALOR);
                            }
                            combo.cargarCombo(listaGrupo);
                        }
                        tlPanel.Controls.Add(combo);
                    }
                    if (bean.TIPO.Equals("DATE"))
                    {
                        fecha = new UCDate(bean.ID_CAMPO);
                        if (bean.OBLIGATORIO.Equals("S"))
                        {
                            fecha.setearObligatorio(true);
                        }
                        fecha.setearEtiqueta(bean.LABEL);
                        tlPanel.Controls.Add(fecha);
                    }
                    if (bean.TIPO.Equals("CHECKBOX"))
                    {
                        check = new UCCheckBox(bean.ID_CAMPO);
                        check.setearEtiqueta(bean.LABEL);
                        tlPanel.Controls.Add(check);
                    }
                    if (bean.TIPO.Equals("RADIO_BUTTON"))
                    {
                        radio = new UCRadioButton(bean.ID_CAMPO);
                        radio.setearEtiqueta(bean.LABEL);
                        tlPanel.Controls.Add(radio);
                    }
                    if (bean.TIPO.Equals("TICKER_HOUR"))
                    {
                        ticker = new UCTickerHour(bean.ID_CAMPO);
                        ticker.setearEtiqueta(bean.LABEL);
                        tlPanel.Controls.Add(ticker);
                    }
                    if (bean.TIPO.Equals("PERCENTAGE"))
                    {
                        porc = new UCPercentage(bean.ID_CAMPO);
                        if (bean.OBLIGATORIO.Equals("S"))
                        {
                            porc.setearObligatorio(true);
                        }
                        porc.longitud(int.Parse(datos.appConfig("longitudPorcentajeCalidad")));
                        porc.setearEtiqueta(bean.LABEL);
                        porc.inputMask(datos.appConfig("formatoPorcentaje"));
                        tlPanel.Controls.Add(porc);
                    }
                    if (bean.TIPO.Equals("DNI"))
                    {
                        dni = new UCDNI(bean.ID_CAMPO);
                        if (bean.OBLIGATORIO.Equals("S"))
                        {
                            dni.setearObligatorio(true);
                        }
                        dni.setearEtiqueta(bean.LABEL);
                        dni.longitud(int.Parse(datos.appConfig("caracterMaxDoc")));
                        tlPanel.Controls.Add(dni);
                    }
                }
            }
            catch(Exception e)
            {
                log.LogMessage("Error crearControles: " + e.Message);
            }
        }

        private List<DetalleCalidadBean> recuperarDatosControles()
        {
            List<DetalleCalidadBean> listaDetalle = new List<DetalleCalidadBean>();
            DetalleCalidadBean detalle;
            try
            {
                foreach (Control ctrl in tlPanel.Controls)
                {
                    if (ctrl is UCAlfanumerico)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCAlfanumerico obj = ctrl as UCAlfanumerico;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.obtenerValor();
                        listaDetalle.Add(detalle);
                    }
                    if (ctrl is UCNumerico)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCNumerico obj = ctrl as UCNumerico;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.obtenerValor();
                        listaDetalle.Add(detalle);
                    }
                    if (ctrl is UCCheckBox)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCCheckBox obj = ctrl as UCCheckBox;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.estaSeleccionado() ? "SI" : "NO";
                        listaDetalle.Add(detalle);
                    }
                    if (ctrl is UCComboBox)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCComboBox obj = ctrl as UCComboBox;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.obtenerValor();
                        listaDetalle.Add(detalle);
                    }
                    if (ctrl is UCDate)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCDate obj = ctrl as UCDate;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.obtenerValor();
                        listaDetalle.Add(detalle);
                    }
                    if (ctrl is UCDNI)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCDNI obj = ctrl as UCDNI;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.obtenerValor();
                        listaDetalle.Add(detalle);
                    }
                    if (ctrl is UCPercentage)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCPercentage obj = ctrl as UCPercentage;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.obtenerValor();
                        listaDetalle.Add(detalle);
                    }
                    if (ctrl is UCRadioButton)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCRadioButton obj = ctrl as UCRadioButton;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.estaSeleccionado() ? "SI":"NO";
                        listaDetalle.Add(detalle);
                    }
                    if (ctrl is UCTickerHour)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCTickerHour obj = ctrl as UCTickerHour;
                        detalle.ID_CAMPO = obj.getID();
                        detalle.LABEL = obj.obtenerEtiqueta();
                        detalle.VALOR = obj.obtenerValor();
                        listaDetalle.Add(detalle);
                    }
                }
            }
            catch(Exception e)
            {
                log.LogMessage("Error recuperarDatosControles: " + e.Message);
            }
            return listaDetalle;
        }

        private bool grabarCalidad(out int IDCalidad) {
            bool resultado = false;
            IDCalidad = 0;
            try {
                CalidadBean calidad = new CalidadBean();
                calidad.FECHA_CALIDAD =datos.horaActual();
                calidad.ID_PESO = int.Parse(tbID.Text);
                calidad.ESTADO = "A";
                calidad.DETALLE = recuperarDatosControles();
                resultado = datos.grabarCalidad(calidad);
                //setearDatosControles el bean de calidad
                notaPesoCalidad.CALIDAD = calidad;
                IDCalidad = calidad.ID_CALIDAD;
                pararTimers();
            }
            catch (Exception e)
            {
                log.LogMessage("Error recuperarDatosControles: " + e.Message);
            }
            return resultado;
        }

        #endregion

        //Deshabilitar campos de nota de peso
        public void habilitarCamposNotaPeso(bool accion)
        {
            tbID.Enabled = accion;
            tbNumTicket.Enabled = accion;
            cmbEmpresa.Enabled = accion;
            tbFechaRegistro.Enabled = accion;
            cmbTipoGrano.Enabled = accion;
            cmbCiudad.Enabled = accion;
            tbBalanza.Enabled = accion;
            tbPesosRegistrados.Enabled = accion;
            tbDocOperador.Enabled = accion;
            tbDocProductor.Enabled = accion;
            tbTotalNotPesBru.Enabled = accion;
            tbTotalNotPesNet.Enabled = accion;
            tbNumTotSac.Enabled = accion;
        }

        private void deshabilitarControlesDinamicos(bool accion)
        {
            try
            {
                foreach (Control ctrl in tlPanel.Controls)
                {
                    if (ctrl is UCAlfanumerico)
                    {
                        UCAlfanumerico obj = ctrl as UCAlfanumerico;
                        obj.setearReadOnly(accion);
                    }
                    if (ctrl is UCNumerico)
                    {
                        UCNumerico obj = ctrl as UCNumerico;
                        obj.setearReadOnly(accion);
                    }
                    if (ctrl is UCCheckBox)
                    {
                        UCCheckBox obj = ctrl as UCCheckBox;
                        if (accion)
                        {
                            obj.editable(false);
                        }
                        else
                        {
                            obj.editable(true);
                        }
                    }
                    if (ctrl is UCComboBox)
                    {
                        UCComboBox obj = ctrl as UCComboBox;
                        if (accion) {
                            obj.editable(false);
                        }
                        else
                        {
                            obj.editable(true);
                        }
                    }
                    if (ctrl is UCDate)
                    {
                        UCDate obj = ctrl as UCDate;
                        if (accion)
                        {
                            obj.editable(false);
                        }
                        else
                        {
                            obj.editable(true);
                        }
                    }
                    if (ctrl is UCDNI)
                    {
                        UCDNI obj = ctrl as UCDNI;
                        obj.setearReadOnly(accion);
                    }
                    if (ctrl is UCPercentage)
                    {
                        UCPercentage obj = ctrl as UCPercentage;
                        obj.setearReadOnly(accion);
                    }
                    if (ctrl is UCRadioButton)
                    {
                        UCRadioButton obj = ctrl as UCRadioButton;
                        if (accion)
                        {
                            obj.editable(false);
                        }
                        else
                        {
                            obj.editable(true);
                        }
                    }

                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error habilitarControlesDinamicos: " + e.Message);
            }
        }

        //Setear valores cargados de una nota de calidad registrada
        private bool setearDatosControles(CalidadBean calidad)
        {
            bool resultado = false;
            try
            {
                if (calidad.ID_CALIDAD != 0)
                {
                    foreach (DetalleCalidadBean detalle in calidad.DETALLE)
                    {
                        foreach (Control ctrl in tlPanel.Controls)
                        {
                            if (ctrl is UCAlfanumerico)
                            {
                                UCAlfanumerico obj = ctrl as UCAlfanumerico;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    obj.setearValor(detalle.VALOR);
                                }
                            }
                            if (ctrl is UCNumerico)
                            {
                                UCNumerico obj = ctrl as UCNumerico;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    obj.setearValor(detalle.VALOR);
                                }
                            }
                            if (ctrl is UCCheckBox)
                            {
                                UCCheckBox obj = ctrl as UCCheckBox;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    if (detalle.VALOR.Equals("S") || detalle.VALOR.Equals("SI"))
                                    {
                                        obj.setearValor(true);
                                    }
                                    else
                                    {
                                        obj.setearValor(false);
                                    }
                                }
                                
                            }
                            if (ctrl is UCComboBox)
                            {
                                UCComboBox obj = ctrl as UCComboBox;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    obj.setearValor(detalle.VALOR);
                                }
                            }
                            if (ctrl is UCDate)
                            {
                                UCDate obj = ctrl as UCDate;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    obj.setearValor(detalle.VALOR);
                                }
                            }
                            if (ctrl is UCDNI)
                            {
                                UCDNI obj = ctrl as UCDNI;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    obj.setearValor(detalle.VALOR);
                                }
                            }
                            if (ctrl is UCPercentage)
                            {
                                UCPercentage obj = ctrl as UCPercentage;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    obj.setearValor(detalle.VALOR);
                                }
                            }
                            if (ctrl is UCRadioButton)
                            {
                                UCRadioButton obj = ctrl as UCRadioButton;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    if (detalle.VALOR.Equals("S") || detalle.VALOR.Equals("SI"))
                                    {
                                        obj.setearValor(true);
                                    }
                                    else
                                    {
                                        obj.setearValor(false);
                                    }
                                }
                            }
                            if (ctrl is UCTickerHour)
                            {
                                UCTickerHour obj = ctrl as UCTickerHour;
                                if (detalle.ID_CAMPO == obj.getID())
                                {
                                    obj.pararTimer();
                                    obj.setearValor(detalle.VALOR);
                                }
                            }
                        }
                    }
                }
                
                resultado = true;
            }
            catch (Exception e)
            {
                log.LogMessage("Error recuperarDatosControles: " + e.Message);
            }
            return resultado;
        }

        //Parada de timer para grabar calidad
        private void pararTimers()
        {
            List<DetalleCalidadBean> listaDetalle = new List<DetalleCalidadBean>();
            DetalleCalidadBean detalle;
            try
            {
                foreach (Control ctrl in tlPanel.Controls)
                {
                    if (ctrl is UCTickerHour)
                    {
                        detalle = new DetalleCalidadBean();
                        detalle.ID_CALIDAD = 0;
                        UCTickerHour obj = ctrl as UCTickerHour;
                        obj.pararTimer();
                    }
                }
            }
            catch (Exception e)
            {
                log.LogMessage("Error pararTimers: " + e.Message);
            }
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
