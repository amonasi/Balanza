using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanza.Bean
{
    public class DetalleNotaPesoBean
    {
        public int ID_PESO;
        public int SECUENCIA;
        public String TIPO_SACO;
        public int CANTIDAD;
        public float PESO_BRUTO_SACO;
        public float PESO_NETO_SACO;
        public String PESO_ESTABLE;

        public DetalleNotaPesoBean() {
            ID_PESO = 0;
            SECUENCIA = 0;
            CANTIDAD = 0;
            TIPO_SACO =String.Empty;
            PESO_BRUTO_SACO=0;
            PESO_NETO_SACO=0;
            PESO_ESTABLE=String.Empty;
        }
    }
}
