using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class UsuarioEMail
    {
        public static List<InfoEmail> TraerMaildeUsuarios(int intInicio, int intFin)
        {
            List<InfoEmail> Listado = new List<InfoEmail>();
            Listado = Sistema.PL.Datos.UsuarioEMail.TraerMaildeUsuarios(intInicio, intFin );

            return Listado;
        }

        
       
            public static int RegistrarUsuarioVer(string valor1, string valor2)
        {
            return Sistema.PL.Datos.UsuarioEMail.RegistrarUsuarioVer(valor1, valor2);
        }
    }
}
