using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class NegIdioma
    {
        public static List<InfoIdioma> ListarIdioma()
        {
            return Sistema.PL.Datos.Idioma.ListarIdioma();
        }
    }
}
