using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class Etiqueta
    {
        public static List<InfoEtiqueta> BuscarEtiquetas()
        {
            return Sistema.PL.Datos.Etiqueta.ListarEtiquetasConMasRating();
        }
        public static List<InfoEtiqueta> BuscarPaginasPorEtiquetas(string strEtiqueta, int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.Etiqueta.BuscarPaginasPorEtiquetas(strEtiqueta, intInicio, IntCantidadRow);
        }

        public static int ObtenerCantidadRegistroPorEtiqueta(string strEtiqueta)
        {
            return Sistema.PL.Datos.Etiqueta.ObtenerCantidadRegistroPorEtiqueta(strEtiqueta);
        }
    }
}
