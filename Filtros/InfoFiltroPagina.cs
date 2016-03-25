using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library_PL.Filtros
{
    public class InfoFiltroPagina
    {
        private System.Int32 _IdPagina;
        private System.Int32 _Mes;
        private System.Int32 _Anio;
      
        public System.Int32 IdPagina
        {
            get { return _IdPagina; }
            set { _IdPagina = value; }
        }

        public System.Int32 Mes
        {
            get { return _Mes; }
            set { _Mes = value; }
        }

        public System.Int32 Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

    }
}
