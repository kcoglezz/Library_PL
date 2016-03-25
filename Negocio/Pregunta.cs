using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;
using Sistema.PL.Filtros;


namespace Sistema.PL.Negocio
{
    public class Pregunta
    {
        public static InfoPregunta TraerPreguntaActual()
        {
            return Sistema.PL.Datos.Pregunta.TraerPreguntaActual();
        }
        public static InfoResultadoEncuesta ResultadoPregunta(int IdPregunta)
        {
            return Sistema.PL.Datos.Pregunta.ResultadoPregunta(IdPregunta);
        }

        public static List<InfoPregunta> BuscarByFiltros(FiltroPregunta oFiltro)
        {
            return Sistema.PL.Datos.Pregunta.BuscarByFiltros(oFiltro);
        }
    }
}
