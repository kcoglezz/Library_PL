using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class Autor
    {
        public static InfoAutor TraerAutor(int Id_Autor)
        {
            return Sistema.PL.Datos.Autor.TraerAutor(Id_Autor);
        }

        public static List<InfoPublicacionesDelAutor> BuscarPublicacionesdelAutor(int intIdAutor, int intInicio, int IntCantidadRow)
        {
            return Sistema.PL.Datos.Autor.BuscarPublicacionesdelAutor(intIdAutor, intInicio, IntCantidadRow);
        }
    }
}

