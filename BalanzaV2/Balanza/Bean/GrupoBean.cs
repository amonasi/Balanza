using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanza.Bean
{
    class GrupoBean
    {
        public String CODGRUPO;
        public String DESGRUPO;
        public String ESTADO;
        public String EDITABLE;
        public List<DetalleGrupoBean> DETALLE;

        public GrupoBean() {
            CODGRUPO=String.Empty;
            DESGRUPO = String.Empty;
            ESTADO = String.Empty;
            EDITABLE = String.Empty;
            DETALLE = new List<DetalleGrupoBean>();
        }
    }
}
