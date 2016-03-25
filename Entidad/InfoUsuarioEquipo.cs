using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoUsuarioEquipo
    {
        public int IdUsuario = 0;
        public int IdEquipo = 0;
        public string Nombre = string.Empty;
        public Boolean Es_Administrador = false;
        public string Es_Adm = string.Empty;
       
       
        //============================
        // Constructores
        //============================
        public InfoUsuarioEquipo()
        {

        }
    }
}
