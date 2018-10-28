using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;
using Balanza.Configs;

namespace Balanza.Bean
{
    public class NotaPesoBean
    {
        public int ID_PESO;
        public String EMPRESA;
        public String TIPO_GRANO;
        public String FEC_REG_OPE;
        public String CIUDAD;
        public int CANT_SACOS;
        public String NUM_TICKET;
        public String TIPDOC_OPERADOR;
        public String TIPDOC_PRODUCTOR;
        public String DOC_OPERADOR;
        public String DOC_PRODUCTOR;
        public float TOTAL_PESO_BRUTO;
        public float TOTAL_PESO_NETO;
        public String REPORTADO_CENTRAL;
        public String ID_BALANZA;
        public List<DetalleNotaPesoBean> DETALLE;
        public CalidadBean CALIDAD;

        private String nomArchivo;
        Logger log;

        public NotaPesoBean()
        {
            ID_PESO=0;
            EMPRESA = String.Empty;
            TIPO_GRANO =String.Empty;
            FEC_REG_OPE = String.Empty;
            CIUDAD = String.Empty;
            CANT_SACOS=0;
            NUM_TICKET = String.Empty;
            TIPDOC_OPERADOR = String.Empty;
            TIPDOC_PRODUCTOR = String.Empty;
            DOC_OPERADOR = String.Empty;
            DOC_PRODUCTOR = String.Empty;
            TOTAL_PESO_BRUTO=0;
            TOTAL_PESO_NETO=0;
            REPORTADO_CENTRAL = String.Empty;
            ID_BALANZA = String.Empty;
            DETALLE = new List<DetalleNotaPesoBean>();
            CALIDAD = new CalidadBean();
        }

        public bool impresionNotaPeso(ref String ruta)
        {
            log = new Logger();
            bool resultado = false;
            

            try
            {
                nomArchivo = "NOTA_PESO" + NUM_TICKET + "_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Second + ".txt";
                ruta = Environment.CurrentDirectory + "\\" + ConfigurationManager.AppSettings["folderTMP"].ToString() + "\\" + nomArchivo;
                if (Directory.Exists(Environment.CurrentDirectory + ConfigurationManager.AppSettings["folderTMP"].ToString()))
                {
                    escribirArchivo(ruta);
                }
                else
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + ConfigurationManager.AppSettings["folderTMP"].ToString());
                    escribirArchivo(ruta);
                }
                
                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                log.LogMessage("impresionNotaPeso: "+ex.Message +" ruta: "+ruta);
            }
            finally
            {

            }
            return resultado;
        }

        private void escribirArchivo(String ruta)
        {

            String empresa = "Emp:";
            String id = "ID:";
            String cabecera = "NOTA DE PESO";
            String fecha = "Fec:";
            String hora = "Hor:";
            String tipoGrano = "T.gr.:";
            String ciudad = "Loc.:";
            String numTicket = "Tckt:";
            String docOpe = "Ope.:";
            String docPro = "Prod.:";
            String cantSacos = "T.Sacos:";
            String pesoBruto = "T.P.B.:";
            String pesoNeto = "T.P.N.:";
            String balanza = "Bal.:";
            String TAG_Calidad = "CALIDAD";
            String CALIDAD_PENDIENTE= "CALIDAD_PENDIENTE";

            String detalle = "CNT T.SC  P.B. P.N. ";
   
            if (File.Exists(ruta) == false)
            {
                File.Create(ruta).Close();
            }

            StreamWriter str = new StreamWriter(ruta, true);
            str.AutoFlush = true;
            str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            //str.WriteLine(String.Concat(Enumerable.Repeat(" ", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            str.WriteLine(String.Concat(Enumerable.Repeat("", caracteresCentrado(cabecera)).ToArray()) + cabecera);
            //str.WriteLine(String.Concat(Enumerable.Repeat(" ", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            str.WriteLine(String.Concat(Enumerable.Repeat(" ", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            str.WriteLine(EMPRESA.Length > 20 ? EMPRESA.Substring(0, 20) : EMPRESA);
            str.WriteLine(id + ID_PESO);
            str.WriteLine(numTicket + NUM_TICKET);
            str.WriteLine(fecha + FEC_REG_OPE.Substring(0,10));
            str.WriteLine(hora + FEC_REG_OPE.Substring(11,8));
            
            str.WriteLine(ciudad + ((ciudad.Length+CIUDAD.Length) > 20 ? CIUDAD.Substring(0, 15) : CIUDAD));
            //str.WriteLine(balanza + ID_BALANZA);
            str.WriteLine(docOpe + DOC_OPERADOR);
            str.WriteLine(docPro + DOC_PRODUCTOR);
            str.WriteLine(String.Concat(Enumerable.Repeat(" ", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            str.WriteLine(tipoGrano + TIPO_GRANO);
            str.WriteLine(cantSacos + CANT_SACOS);
            str.WriteLine(pesoBruto + TOTAL_PESO_BRUTO);
            str.WriteLine(pesoNeto + TOTAL_PESO_NETO);
            str.WriteLine(String.Concat(Enumerable.Repeat(" ", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));

            DAL datos = new DAL();
            String tipoImpresion = datos.appConfig("tipoImpresion");
            String det0, det1, det2, det3;

            if (tipoImpresion.Equals("1")) { 
                str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
                str.WriteLine(detalle);
                str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            }

            foreach (DetalleNotaPesoBean nb in DETALLE)
            {

                if (tipoImpresion.Equals("1")) { 

                    if (nb.CANTIDAD.ToString().Length >= 3)
                    {
                        det0 = nb.CANTIDAD.ToString().Substring(0, 3);
                    }
                    else
                    {
                        det0 = String.Concat(Enumerable.Repeat(" ", 3 - nb.CANTIDAD.ToString().Length).ToArray()) + nb.CANTIDAD.ToString();
                    }

                    if (nb.TIPO_SACO.Length >= 4) {
                        det1=nb.TIPO_SACO.Substring(0, 4);
                     }
                    else {
                        det1= String.Concat(Enumerable.Repeat(" ", 4 - nb.TIPO_SACO.Length).ToArray()) + nb.TIPO_SACO;
                    }

                    if (nb.PESO_BRUTO_SACO.ToString().Length >= 5)
                    {
                        det2 = nb.PESO_BRUTO_SACO.ToString().Substring(0, 5);
                    }
                    else
                    {
                        det2 = String.Concat(Enumerable.Repeat(" ", 5 - nb.PESO_BRUTO_SACO.ToString().Length).ToArray()) + nb.PESO_BRUTO_SACO.ToString();
                    }

                    if (nb.PESO_NETO_SACO.ToString().Length >= 5)
                    {
                        det3= nb.PESO_NETO_SACO.ToString().Substring(0, 5);
                    }
                    else
                    {
                        det3 = String.Concat(Enumerable.Repeat(" ", 5 - nb.PESO_NETO_SACO.ToString().Length).ToArray()) + nb.PESO_NETO_SACO.ToString();
                    }

                    str.WriteLine(det0 + " " + det1 + " " + det2 + " " + det3);
                }
                else
                {
                    str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
                    str.WriteLine("Detalle: "+nb.SECUENCIA);
                    str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
                    str.WriteLine("Cant: " + nb.CANTIDAD);
                    if (nb.TIPO_SACO.Length >= 10)
                    {
                        det1 = nb.TIPO_SACO.Substring(0, 10);
                    }
                    else
                    {
                        det1 = nb.TIPO_SACO;
                    }
                    str.WriteLine("T.Saco: " + det1);
                    str.WriteLine("P.Bruto: " + nb.PESO_BRUTO_SACO);
                    str.WriteLine("P.Neto: " + nb.PESO_NETO_SACO);
                }
            }

            //Impresion de calidad
            if (CALIDAD.ID_CALIDAD != 0)
            {
                str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
                str.WriteLine(TAG_Calidad);
                str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
                foreach (DetalleCalidadBean detCalidad in CALIDAD.DETALLE)
                {
                    String etiqueta = String.Empty;
                    bool impresion = false;
                    etiqueta = datos.devolverEtiquetaCalidad(TIPO_GRANO, detCalidad.ID_CAMPO, out impresion);

                    if (impresion)
                    {

                        if (etiqueta.Length >= int.Parse(datos.appConfig("tamEtiquetaCalidad")))
                        {
                            det0 = etiqueta.Substring(0, int.Parse(datos.appConfig("tamEtiquetaCalidad")));
                        }
                        else
                        {
                            det0 = etiqueta;
                        }

                        if (detCalidad.VALOR.Length >= (int.Parse(datos.appConfig("CaracteresImpresion"))- etiqueta.Length))
                        {
                            det1 = etiqueta.Substring(0, (int.Parse(datos.appConfig("CaracteresImpresion")) - etiqueta.Length));
                        }
                        else
                        {
                            det1 = detCalidad.VALOR;
                        }

                        str.WriteLine(det0 + det1);
                    }
                }
                str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            }
            else {
                str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
                str.WriteLine(CALIDAD_PENDIENTE);
                str.WriteLine(String.Concat(Enumerable.Repeat("=", int.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString())).ToArray()));
            }

            str.Close();
        }

        private int caracteresCentrado(String frase)
        {
            int resultado= int.Parse(Math.Round((float.Parse(ConfigurationManager.AppSettings["CaracteresImpresion"].ToString()) - frase.Length) / 2).ToString());
            return resultado;
        }
    }
}
