using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanza.Bean
{
    public class DetalleCalidadBean
    {
        public int ID_CALIDAD;
        public int ID_CAMPO;
        public String LABEL;
        public String VALOR;


        public DetalleCalidadBean()
        {
            ID_CALIDAD = 0;
            ID_CAMPO = 0;
            LABEL = String.Empty;
            VALOR = String.Empty;

        }
    }
}
