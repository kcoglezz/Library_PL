using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class MenuPL
    {
        public static List<InfoMenu> BuscarMenuPrincipal()
        {
            return Sistema.PL.Datos.Menu.BuscarMenuPrincipal();
        }
    }
}
