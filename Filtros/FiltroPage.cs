using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Filtros
{
    public class FiltroPage
    {
        
        private System.Int32 _idPage;
        private System.String _Resena;


        public System.Int32 idPage
        {
            get { return _idPage; }
            set { _idPage = value; }
        }

        public System.String Resena
        {
            get { return _Resena; }
            set { _Resena = value; }
        }

    }
}
