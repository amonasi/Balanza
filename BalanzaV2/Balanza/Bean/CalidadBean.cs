using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanza.Bean
{
    public class CalidadBean
    {
        public int ID_CALIDAD;
        public String FECHA_CALIDAD;
        public int ID_PESO;
        public String ESTADO;
        public List<DetalleCalidadBean> DETALLE;

        public CalidadBean()
        {
            ID_CALIDAD = 0;
            FECHA_CALIDAD = String.Empty;
            ID_PESO = 0;
            ESTADO = String.Empty;
            DETALLE = new List<DetalleCalidadBean>();
        }
    }
}
