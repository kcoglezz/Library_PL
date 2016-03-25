using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class NegRecurso
    {
        public static List<InfoRecurso> ListarRecursos()
        {
            return Sistema.PL.Datos.Recurso.ListarRecursos();
        }
    }
}
