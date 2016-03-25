using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class NegTipoTrabajo
    {
        public static List<InfoTipoTrabajo> ListarTipoTrabajo()
        {
            return Sistema.PL.Datos.TipoTrabajo.ListarTipoTrabajo();
        }
    }
}
