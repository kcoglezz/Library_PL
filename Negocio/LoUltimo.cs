using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;


namespace Sistema.PL.Negocio
{
    public class LoUltimo
    {
        public static List<InfoLoUltimo> ListarLoUltimo(int intIndex)
        {
            return Sistema.PL.Datos.LoUltimo.ObtenerLoUltimo(intIndex);
        }

        public static List<InfoArticuloListado> BuscarArticulosLoUltimo(int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.LoUltimo.BuscarArticulosLoUltimo(intInicio, IntCantidadRow);
        }
    }
}
