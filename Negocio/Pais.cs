using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class Pais
    {
        public static List<InfoPais> ListarPaises()
        {
            return Sistema.PL.Datos.Pais.ListarPaises();
        }
    }
}
