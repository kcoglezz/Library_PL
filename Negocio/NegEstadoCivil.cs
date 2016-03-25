using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class NegEstadoCivil
    {
        public static List<InfoEstadoCivil> ListarEstadoCivil()
        {
            return Sistema.PL.Datos.EstadoCivil.ListarEstadoCivil();
        }
    }
}
