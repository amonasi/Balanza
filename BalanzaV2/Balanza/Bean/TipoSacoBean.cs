using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanza.Bean
{
    class TipoSacoBean
    {
        public String TIPO_SACO;
        public float PESO;
        public String ES_NEGATIVO;
        public String ESTADO;

        public TipoSacoBean()
        {
            TIPO_SACO = String.Empty;
            PESO = 0;
            ES_NEGATIVO = String.Empty;
            ESTADO = String.Empty;
        }
    }
}
