using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class NegSeccion
    {
        public static List<InfoSeccionPadre> BuscarSeccionRecursos(string strNombreOpcion)
        {
            return Sistema.PL.Datos.Seccion.BuscarSeccionRecursos(strNombreOpcion);
        }

        public static InfoSeccion ObtenerInformacionSeccion(int intIdSeccion)
        {
            return Sistema.PL.Datos.Seccion.ObtenerInformacionSeccion(intIdSeccion);
        }

        public static List<InfoPaginasdelaSeccion> BuscarPaginasPorSeccion(int intIdSeccion, int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.Seccion.BuscarPaginasPorSeccion(intIdSeccion,intInicio,IntCantidadRow);
        }



    }
}
