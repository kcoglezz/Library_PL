using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class AdminLog
    {
        public static int RegistrarLog(InfoLog Log)
        {
            return Sistema.PL.Datos.AdminLog.RegistrarLog(Log);
        }
    }
}
