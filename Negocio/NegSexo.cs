using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class NegSexo
    {
        public static List<InfoSexo> ListarSexo()
        {
            return Sistema.PL.Datos.Sexo.ListarSexo();
        }
    }
}
