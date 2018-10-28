using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Balanza.Bean;

namespace Balanza.Configs
{
    class ConfigBalanza
    {
        DAL data;
        BalanzaBean currentBalanza;
        Logger log;

        private String tramaCompleta;
        private float pesoNeto;
        private float pesoBruto;
        private bool isEstable;
        private String mensajeError;
        private bool saltoInicioTrama = false;

        public ConfigBalanza()
        {
            log = new Logger();
            data = new DAL();
            currentBalanza = new BalanzaBean();
            balanzaActual();
            if (data.appConfig("saltarIniTraBal").Equals("1"))
            {
                saltoInicioTrama = true;
            }
        }

        private void balanzaActual()
        {
            currentBalanza=data.obtenerBalanza();
        }

        public float getPesoBruto() {
            return pesoBruto;
        }

        public String getTrama()
        {
            return tramaCompleta;
        }

        public float getPesoNeto()
        {
            return pesoNeto;
        }

        public bool esEstable()
        {
            return isEstable;
        }

        public String nombreBalanza()
        {
            if (currentBalanza.COD_BALANZA != null)
            {
                return currentBalanza.COD_BALANZA;
            }
            else {
                return "SIN BALANZA CONFIGURADA";
            }
            
        }

        public int getDecimal()
        {
            if (currentBalanza.POS_DEC != null)
            {
                return currentBalanza.POS_DEC;
            }
            else
            {
                return 0;
            }

        }
        public String getMensajeError()
        {
            return mensajeError;
        }

        public bool procesarTrama(String trama) {
            bool resultado = false;
            mensajeError = String.Empty;
            try
            {
                //Validando el objeto
                if (currentBalanza != null)
                {
                    
                    if (data.appConfig("preProcesarTrama").Equals("1"))
                    {
                        trama = preProcesoTrama(trama, currentBalanza.CAR_INI_TRA, currentBalanza.TAM_TRAMA);
                    }

                    tramaCompleta = trama;
                    logging(trama);
                    //Tamaño basico de la trama
                    if (currentBalanza.TAM_TRAMA == trama.Length)
                    {
                        //Caracteres iniciales de la trama
                        if (trama.StartsWith(currentBalanza.CAR_INI_TRA) || saltoInicioTrama)
                        {
                            //Verificacion de estabilidad de balanza
                            if (trama.Substring(currentBalanza.POS_INI_CEB,currentBalanza.POS_FIN_CEB-currentBalanza.POS_INI_CEB).Equals(currentBalanza.CAR_EST_BAL))
                            {
                                isEstable = true;
                            }
                            else
                            {
                                isEstable = false;
                                mensajeError = "Peso no es estable.";
                                log.LogMessage("Peso no es estable.");
                            }

                            //Obtener Peso Bruto
                            if (float.TryParse(trama.Substring(currentBalanza.POS_INI_PESO_CT, currentBalanza.POS_FIN_PESO_CT - currentBalanza.POS_INI_PESO_CT), out pesoBruto))
                            {
                                if (currentBalanza.POS_DEC >= 1 && pesoBruto.ToString().Length >= currentBalanza.POS_DEC) {
                                    String pesoBE = pesoBruto.ToString().Substring(0, pesoBruto.ToString().Length - currentBalanza.POS_DEC);
                                    String pesoBD = pesoBruto.ToString().Substring(pesoBruto.ToString().Length - currentBalanza.POS_DEC, currentBalanza.POS_DEC);
                                    float.TryParse(pesoBE+data.appConfig("valorSimDecimal") +pesoBD, out pesoBruto);
                                }
                                resultado = true;
                            }
                            else
                            {
                                mensajeError = "Error al obtener el peso bruto.";
                                log.LogMessage("Error al obtener el peso bruto.");
                                return false;
                            }

                            //Obtener peso neto
                            if (float.TryParse(trama.Substring(currentBalanza.POS_INI_PESO_ST, currentBalanza.POS_FIN_PESO_ST - currentBalanza.POS_INI_PESO_ST), out pesoNeto))
                            {
                                String pesoNE = pesoNeto.ToString().Substring(0, pesoNeto.ToString().Length - currentBalanza.POS_DEC);
                                String pesoND = pesoNeto.ToString().Substring(pesoNeto.ToString().Length - currentBalanza.POS_DEC, currentBalanza.POS_DEC);
                                float.TryParse(pesoNE + data.appConfig("valorSimDecimal") + pesoND, out pesoNeto);
                                resultado = true;
                            }
                            else
                            {
                                mensajeError = "Error al obtener el peso neto.";
                                log.LogMessage("Error al obtener el peso neto.");
                                return false;
                            }
                        }
                        else
                        {
                            mensajeError = "Caracteres iniciales son diferentes a los de la configuracion.";
                            log.LogMessage("Caracteres iniciales son diferentes a los de la configuracion.");
                            return false;
                        }
                    }
                    else {
                        mensajeError = "El tamaño de la trama es diferente al de la configuracion.";
                        log.LogMessage("El tamaño de la trama es diferente al de la configuracion.");
                        return false;
                    }
                }
            }
            catch (System.OutOfMemoryException oe)
            {
                limpiarValores();
                log.LogMessage("Error de memoria: " + oe.Message);
            }
            catch (Exception e)
            {
                limpiarValores();
                log.LogMessage("Error procesarTrama: " + e.Message);
            }
            finally
            {
                if (!resultado)
                {
                    limpiarValores();
                }
            }
            return resultado;
        }

        private void limpiarValores()
        {
            pesoBruto = 0;
            pesoNeto = 0;
            isEstable = false;
        }

        private void logging(String trama)
        {
            if (data.appConfig("enabledLogTrama").Equals("1"))
            {
                log.LogMessage("trama: " + trama);
                log.LogMessage("tamanio: " + trama.Length);
                log.LogMessage("Salto inicio trama: " + saltoInicioTrama.ToString());
            }
            
        }

        private String preProcesoTrama(String trama,String carInicial,int tamTrama)
        {
            String preproceso=trama;
            try
            {
                if (trama.Length > tamTrama)
                {
                    if (trama.IndexOf(carInicial) > -1)
                    {
                        preproceso = trama.Substring(trama.IndexOf(carInicial));

                        if (preproceso.Length > tamTrama)
                        {
                            preproceso=preproceso.Substring(0, tamTrama);
                        }

                        if (preproceso.Length < tamTrama)
                        {
                            preproceso=preproceso.PadRight(tamTrama - preproceso.Length,' ');
                        }
                    }
                }
            }
            catch(Exception e)
            {
                log.LogMessage("preProcesoTrama: " + e.Message);
            }

            return preproceso;

        }
    }
}
