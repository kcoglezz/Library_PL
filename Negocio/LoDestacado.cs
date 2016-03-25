using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;


namespace Sistema.PL.Negocio
{
    public class LoDestacado
    {
        public static List<InfoLoDestacado> ListarLoDestacado(int intIndex)
        {
            return Sistema.PL.Datos.LoDestacado.ObtenerLoDestacado(intIndex);
        }

        public static List<InfoArticuloListado> BuscarArticulosDestacados(int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.LoDestacado.BuscarArticulosDestacados(intInicio, IntCantidadRow);
        }
    }
}
