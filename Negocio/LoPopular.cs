using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class LoPopular
    {
        public static List<InfoLoPopular> ListarLoPopular(int intIndex)
        {
            return Sistema.PL.Datos.LoPopular.ObtenerLoPopular(intIndex);
        }
        public static List<InfoArticuloListado> BuscarArticulosLoPopular(int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.LoPopular.BuscarArticulosLoPopular(intInicio, IntCantidadRow);
        }
    }
}
