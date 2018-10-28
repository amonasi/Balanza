using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Balanza.Configs;

namespace Balanza.Bean
{
    class BalanzaBean
    {
        public String COD_BALANZA;
        public int TAM_TRAMA;
        public String CAR_INI_TRA;
        public String CAR_EST_BAL;
        public int POS_INI_CEB;
        public int POS_FIN_CEB;
        public int POS_INI_PESO_ST;
        public int POS_FIN_PESO_ST;
        public int POS_INI_PESO_CT;
        public int POS_FIN_PESO_CT;
        public String ESTADO;
        public String BAL_DEFAULT;
        public int POS_DEC;

        Logger log;

        public BalanzaBean()
        {
            COD_BALANZA=String.Empty;
            TAM_TRAMA=0;
            CAR_INI_TRA = String.Empty;
            CAR_EST_BAL = String.Empty;
            POS_INI_CEB = 0;
            POS_FIN_CEB = 0;
            POS_INI_PESO_ST = 0;
            POS_FIN_PESO_ST = 0;
            POS_INI_PESO_CT = 0;
            POS_FIN_PESO_CT = 0;
            ESTADO = String.Empty;
            BAL_DEFAULT = String.Empty;
            POS_DEC = 0;

            log = new Logger();
        }

        public void generarLog()
        {
            log.LogMessage("BalanzaBean COD_BALANZA: " + COD_BALANZA);
            log.LogMessage("BalanzaBean TAM_TRAMA: " + TAM_TRAMA);
            log.LogMessage("BalanzaBean CAR_INI_TRA: " + CAR_INI_TRA);
            log.LogMessage("BalanzaBean CAR_EST_BAL: " + CAR_EST_BAL);
            log.LogMessage("BalanzaBean POS_INI_CEB: " + POS_INI_CEB);
            log.LogMessage("BalanzaBean POS_FIN_CEB: " + POS_FIN_CEB);
            log.LogMessage("BalanzaBean POS_INI_PESO_ST: " + POS_INI_PESO_ST);
            log.LogMessage("BalanzaBean POS_FIN_PESO_ST: " + POS_FIN_PESO_ST);
            log.LogMessage("BalanzaBean POS_INI_PESO_CT: " + POS_INI_PESO_CT);
            log.LogMessage("BalanzaBean POS_FIN_PESO_CT: " + POS_FIN_PESO_CT);
            log.LogMessage("BalanzaBean ESTADO: " + ESTADO);
            log.LogMessage("BalanzaBean BAL_DEFAULT: " + BAL_DEFAULT);
            log.LogMessage("BalanzaBean POS_DEC: " + POS_DEC);
        }
    }
}
