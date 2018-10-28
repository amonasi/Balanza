using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanza.Bean
{
    class DetalleGrupoBean
    {
        public String CODGRUPO;
        public String VALOR;
        public String VALOR_DEFECTO;
        public String ESTADO;

        public DetalleGrupoBean() {
            CODGRUPO = String.Empty;
            VALOR = String.Empty;
            VALOR_DEFECTO = String.Empty;
            ESTADO = String.Empty;
        }
    }
}
