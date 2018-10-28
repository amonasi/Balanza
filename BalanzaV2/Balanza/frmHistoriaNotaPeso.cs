using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Balanza.Bean;
using Balanza.Configs;
using System.IO;

namespace Balanza
{
    public partial class frmHistoriaNotaPeso : Form
    {
        Logger log;
        DAL datos;
        List<NotaPesoBean> lista = new List<NotaPesoBean>();

        public frmHistoriaNotaPeso()
        {
            InitializeComponent();
            log = new Logger();
            datos = new DAL();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int filasSeleccionadas()
        {
            int i = 0;
            foreach (DataGridViewRow row in dgvHistoriaNotaPeso.SelectedRows)
            {
                i++;
            }
            return i;
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        public void imprimir()
        {
            if (filasSeleccionadas() > 1)
            {
                MessageBox.Show("Seleccione una fila para la reimpresión.", datos.appConfig("TitShowMessage"));
            }
            else if (filasSeleccionadas() == 0)
            {
                MessageBox.Show("Tiene que seleccionar una fila para la reimpresión.", datos.appConfig("TitShowMessage"));
            }
            else
            {
                String ruta=String.Empty;
                NotaPesoBean n;
                PrintDialog pd = new PrintDialog();
                pd.PrinterSettings = new PrinterSettings();
                if (DialogResult.OK == pd.ShowDialog(this))
                {
                    DataGridViewSelectedRowCollection rows;
                    rows = dgvHistoriaNotaPeso.SelectedRows;
                    foreach (DataGridViewRow r in rows)
                    {
                        n = lista.Find(x => x.ID_PESO==int.Parse(r.Cells["ID_PESO"].Value.ToString()));
                        if (n != null)
                        {
                            n.CALIDAD = datos.obtenerCalidadNotaPeso(n.ID_PESO);


                            if (datos.appConfig("imprimirSinCalidad").Equals("0"))
                            {
                                if (n.CALIDAD.ID_CALIDAD != 0)
                                {
                                    if (n.impresionNotaPeso(ref ruta))
                                    {
                                        // Print the file to the printer.
                                        //RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ruta);
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
                                    MessageBox.Show("No se puede imprimir un registro sin calidad registrada.", datos.appConfig("TitShowMessage"));

                                }
                            }
                            else {
                                if (n.impresionNotaPeso(ref ruta))
                                {
                                    // Print the file to the printer.
                                    //RawPrinterHelper.SendFileToPrinter(pd.PrinterSettings.PrinterName, ruta);
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

                        }
                        else
                        {
                            MessageBox.Show("Nota de peso con ID:"+ r.Cells["ID_PESO"].Value.ToString()+" no encontrado.", datos.appConfig("TitShowMessage"));
                            log.LogMessage("Nota de peso con ID:" + r.Cells["ID_PESO"].Value.ToString() + " no encontrado");
                        }
                    }
                }

            }
        }

        private void frmHistoriaNotaPeso_Load(object sender, EventArgs e)
        {
            //dgvHistoriaNotaPeso.AutoGenerateColumns = false;
            dgvHistoriaNotaPeso.AllowUserToAddRows = false;
            setearFechas();
        }

        public void cargarData(bool total) {
            try {
                DataTable tabla = new DataTable();
                DataRow r;
                //Crear Columnas
                tabla.Columns.Add("ID_PESO");
                tabla.Columns.Add("EMPRESA");
                tabla.Columns.Add("TIPO_GRANO");
                tabla.Columns.Add("FEC_REG_OPE");
                tabla.Columns.Add("CIUDAD");
                tabla.Columns.Add("CANT_SACOS");
                tabla.Columns.Add("NUM_TICKET");
                tabla.Columns.Add("DOC_OPERADOR");
                tabla.Columns.Add("DOC_PRODUCTOR");
                tabla.Columns.Add("TOTAL_PESO_BRUTO");
                tabla.Columns.Add("TOTAL_PESO_NETO");
                tabla.Columns.Add("DETALLE");
                tabla.Columns.Add("TIENE_CALIDAD");

                if (total)
                {
                    lista = datos.obtenerNotasCompletas();
                }
                else {
                    if (dtInicio.Enabled) { 
                        String mes = dtInicio.Value.Month.ToString().Length == 1 ? "0" + dtInicio.Value.Month.ToString() : dtInicio.Value.Month.ToString();
                        String dia = dtInicio.Value.Day.ToString().Length == 1 ? "0" + dtInicio.Value.Day.ToString() : dtInicio.Value.Day.ToString();
                        String fecIni = dtInicio.Value.Year.ToString() + "-" + mes + "-" + dia +" 00:00:00";

                        mes = dtFin.Value.Month.ToString().Length == 1 ? "0" + dtFin.Value.Month.ToString() : dtFin.Value.Month.ToString();
                        dia = dtFin.Value.Day.ToString().Length == 1 ? "0" + dtFin.Value.Day.ToString() : dtFin.Value.Day.ToString();
                        String fecFin = dtFin.Value.Year.ToString() + "-" + mes + "-" + dia + " 23:59:59";
                        lista = datos.obtenerNotasFecha(fecIni,fecFin);
                    }
                    else
                    {
                        lista = datos.obtenerNotasID(tbID.Text);
                    }
                }
                

                foreach (NotaPesoBean n in lista) {
                    r = tabla.NewRow();
                    r["ID_PESO"] = n.ID_PESO;
                    r["EMPRESA"] = n.EMPRESA;
                    r["TIPO_GRANO"] = n.TIPO_GRANO;
                    r["FEC_REG_OPE"] = n.FEC_REG_OPE;
                    r["CIUDAD"] = n.CIUDAD;
                    r["CANT_SACOS"] = n.CANT_SACOS;
                    r["NUM_TICKET"] = n.NUM_TICKET;
                    r["DOC_OPERADOR"] = n.DOC_OPERADOR;
                    r["DOC_PRODUCTOR"] = n.DOC_PRODUCTOR;
                    r["TOTAL_PESO_BRUTO"] = n.TOTAL_PESO_BRUTO;
                    r["TOTAL_PESO_NETO"] = n.TOTAL_PESO_NETO;
                    r["DETALLE"] = n.DETALLE.Count;
                    r["TIENE_CALIDAD"] = n.CALIDAD.ID_CALIDAD!=0 ? "SI":"NO";
                    tabla.Rows.Add(r);
                }
                dgvHistoriaNotaPeso.DataSource = tabla;
                dgvHistoriaNotaPeso.AutoResizeColumns();

                renombrarColumnas();

            }catch(Exception e)
            {
                log.LogMessage("Error cargarData: "+ e.Message);
            }
        }

        private void renombrarColumnas()
        {
            foreach(DataGridViewColumn col in dgvHistoriaNotaPeso.Columns)
            {
                if (col.Name.Equals("ID_PESO"))
                {
                    col.HeaderText = "ID";
                    col.ReadOnly = true;
                    col.Width = 30;
                }
                if (col.Name.Equals("EMPRESA"))
                {
                    col.HeaderText = "Empresa";
                    col.ReadOnly = true;
                    col.Width = 100;
                }
                if (col.Name.Equals("TIPO_GRANO"))
                {
                    col.HeaderText = "Tipo Grano";
                    col.ReadOnly = true;
                    col.Width = 80;
                }
                if (col.Name.Equals("FEC_REG_OPE"))
                {
                    col.HeaderText = "Fec. Ope.";
                    col.ReadOnly = true;
                    col.Width = 100;
                }
                if (col.Name.Equals("CIUDAD"))
                {
                    col.HeaderText = "Localidad";
                    col.ReadOnly = true;
                    col.Width = 100;
                }
                if (col.Name.Equals("CANT_SACOS"))
                {
                    col.HeaderText = "Sacos";
                    col.ReadOnly = true;
                    col.Width = 60;
                }
                if (col.Name.Equals("NUM_TICKET"))
                {
                    col.HeaderText = "Ticket";
                    col.ReadOnly = true;
                    col.Width = 100;
                }
                if (col.Name.Equals("DOC_OPERADOR"))
                {
                    col.HeaderText = "Doc. Ope.";
                    col.ReadOnly = true;
                    col.Width = 70;
                }
                if (col.Name.Equals("DOC_PRODUCTOR"))
                {
                    col.HeaderText = "Doc. Prod.";
                    col.ReadOnly = true;
                    col.Width = 70;
                }
                if (col.Name.Equals("TOTAL_PESO_BRUTO"))
                {
                    col.HeaderText = "Tot. P.Bruto";
                    col.ReadOnly = true;
                    col.Width = 80;
                }
                if (col.Name.Equals("TOTAL_PESO_NETO"))
                {
                    col.HeaderText = "Tot. P.Neto";
                    col.ReadOnly = true;
                    col.Width = 80;
                }
                if (col.Name.Equals("DETALLE"))
                {
                    col.HeaderText = "Detalle";
                    col.ReadOnly = true;
                    col.Width = 50;
                }
                if (col.Name.Equals("TIENE_CALIDAD"))
                {
                    col.HeaderText = "T.Calidad?";
                    col.ReadOnly = true;
                    col.Width = 70;
                }
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!datos.validaAutenticacion(DAL.SEG_ADM))
            {
                MessageBox.Show("Confirmarción se seguridad no autenticada, no se puede continuar.", "Grupos", MessageBoxButtons.OK);
                return;
            }
            else
            {
                if (filasSeleccionadas() == 0)
                {
                    MessageBox.Show("Tiene que seleccionar una fila para la eliminar.", datos.appConfig("TitShowMessage"));
                }
                else
                {
                    foreach (DataGridViewRow r in dgvHistoriaNotaPeso.SelectedRows)
                    {
                        datos.eliminarNotaPeso(int.Parse(r.Cells["ID_PESO"].Value.ToString()));
                    }
                    cargarData(false);
                }

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

        private void impresion(String ruta,String printer)
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
                    if (streamToPrint!=null) {
                        streamToPrint.Close();
                    }
                    
                }
            }
            catch (Exception ex)
            {
                log.LogMessage("impresion: "+ex.Message);
            }

        }
        #endregion

        private void buscarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cargarData(true);
        }

        private void setearFechas() {
            try
            {
                dtInicio.Value = DateTime.Now.AddDays(-7);
                dtFin.Value = DateTime.Now;

                dtInicio.Format = DateTimePickerFormat.Custom;
                dtInicio.CustomFormat = "dd-MM-yyyy";
                dtFin.Format = DateTimePickerFormat.Custom;
                dtFin.CustomFormat = "dd-MM-yyyy";
            }
            catch(Exception e) {
                log.LogMessage("Error seteando fechas: "+e.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            cargarData(false);
            Cursor.Current = Cursors.Default;
        }

        private void dgvHistoriaNotaPeso_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvHistoriaNotaPeso_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            String IDNotaPeso=dgvHistoriaNotaPeso[0, e.RowIndex].Value.ToString();
            NotaPesoBean nota=datos.obtenerNotaPeso(int.Parse(IDNotaPeso));
            if (nota != null)
            {
                nota.CALIDAD = datos.obtenerCalidadNotaPeso(nota.ID_PESO);
                if (nota.ID_PESO > 0)
                {
                    frmCalidad formCalidad = new frmCalidad(nota);
                    formCalidad.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Objeto: " + IDNotaPeso +" invalido", datos.appConfig("TitShowMessage"));
                }
            }
            else
            {
                MessageBox.Show("No se pudo recuperar el objeto nota de peso: "+IDNotaPeso,datos.appConfig("TitShowMessage"));
            }
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {
            if (tbID.Text.Length >= 1){
                dtInicio.Enabled = false;
                dtFin.Enabled = false;
            }
            else
            {
                dtInicio.Enabled = true;
                dtFin.Enabled = true;
            }
        }

        private void tbID_KeyPress(object sender, KeyPressEventArgs e)
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
    }
    
}
