using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class LoDelAutor
    {
        public static List<InfoLoDelAutor> ListarLoDelAutor(int intIdAutor, int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.Autor.ObtenerLoDelAutor(intIdAutor, intInicio, IntCantidadRow);
        }
    }
}
