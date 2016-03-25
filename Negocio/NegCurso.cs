using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class NegCurso
    {
        public static List<InfoCurso> TraerCursos()
        {
            return Sistema.PL.Datos.Curso.TraerCursos();
        }
    }
   
}
