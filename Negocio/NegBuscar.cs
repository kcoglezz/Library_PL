using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;


namespace Sistema.PL.Negocio
{
    public class NegBuscar
    {
        public static List<InfoBuscar> BuscarenPaginas(string strPalabra, int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.Buscar.BuscarenPaginas(strPalabra, intInicio, IntCantidadRow);
        }
        public static List<InfoArticuloListado> BuscarArticulosLoUltimo(int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.LoUltimo.BuscarArticulosLoUltimo(intInicio, IntCantidadRow);
        }
    }
}
