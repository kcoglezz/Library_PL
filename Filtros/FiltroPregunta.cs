using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Filtros
{
    public class FiltroPregunta
    {
        private System.Int32 _Anio;
        private System.Int32 _idPregunta;
        private System.Int32 _Numero;

        public System.Int32 Anio
        {
            get { return _Anio; }
            set { _Anio = value; }
        }

        public System.Int32 idPregunta
        {
            get { return _idPregunta; }
            set { _idPregunta = value; }
        }

        public System.Int32 Numero
        {
            get { return _Numero; }
            set { _Numero = value; }
        }

    }

}
