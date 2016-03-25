using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;
using Library_PL.Filtros;

namespace Sistema.PL.Negocio
{
    public class Pagina
    {
        public static InfoPagina TraerPagina(int id_Pagina)
        {
            return Sistema.PL.Datos.Pagina.TraerPagina(id_Pagina);
        }
        public static int RegistrarColaboracion(InfoColaboracion Colaborar)
        {
            return Sistema.PL.Datos.Pagina.RegistrarColaboracion(Colaborar);
        }
        public static int RegistrarRecursoDescarga(InfoPaginaDescarga oDescargar)
        {
            return Sistema.PL.Datos.Pagina.RegistrarRecursoDescarga(oDescargar);
        }
        public static int CantidadDeDescargadeRecurso(int id_Pagina)
        {
            return Sistema.PL.Datos.Pagina.CantidadDeDescargadeRecurso(id_Pagina);
        }

        public static List<InfoDescarga> ListaTodasLasDescagadas(int Pagina)
        {
            return Sistema.PL.Datos.Pagina.ListaTodasLasDescagadas(Pagina);
        }
        public static List<InfoDescarga> ListaDescargasXFecha()
        {
            return Sistema.PL.Datos.Pagina.ListaDescargasXFecha();
        }

        public static List<InfoDescarga> BuscarDescarga_x_Mes_Anio(InfoFiltroPagina oPagina)
        {
            return Sistema.PL.Datos.Pagina.BuscarDescarga_x_Mes_Anio(oPagina);
        }
    }
}
