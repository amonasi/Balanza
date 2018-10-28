using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanza.Bean
{
    class ConfigCalidadBean
    {
        public String TIPO_GRANO;
        public int ID_CAMPO;
        public String LABEL;
        public String TIPO;
        public int COD_GRUPO;
        public String OBLIGATORIO;
        public String ESTADO;
        public String LABEL_ETIQUETA;
        public String IMPRESION;

        public ConfigCalidadBean()
        {
            TIPO_GRANO = String.Empty;
            ID_CAMPO = 0;
            LABEL = String.Empty;
            TIPO = String.Empty;
            COD_GRUPO = 0;
            OBLIGATORIO = String.Empty;
            ESTADO = String.Empty;
            LABEL_ETIQUETA = String.Empty;
            IMPRESION = String.Empty;
        }
    }
}
