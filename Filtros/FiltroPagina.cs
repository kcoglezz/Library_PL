using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Filtros
{
    public class FiltroPagina
    {
        private System.Int32 _IdPagina;
        private System.Int32 _IdUser;
        private System.Int32 _Votacion;
        private System.Int32 _Megusta;
        private System.Int32 _NoMegusta;
        
        public System.Int32 IdPagina
        {
            get { return _IdPagina; }
            set { _IdPagina = value; }
        }

        public System.Int32 IdUser
        {
            get { return _IdUser; }
            set { _IdUser = value; }
        }

        public System.Int32 Votacion
        {
            get { return _Votacion; }
            set { _Votacion = value; }
        }

        public System.Int32 Megusta
        {
            get { return _Megusta; }
            set { _Megusta = value; }
        }
        public System.Int32 NoMegusta
        {
            get { return _NoMegusta; }
            set { _NoMegusta = value; }
        }
    }


}
