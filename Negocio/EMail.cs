using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;


namespace Sistema.PL.Negocio
{
    public class EMail
    {
        public static void Enviar(InfoEnvioMail DatosMail)
        {

            Sistema.PL.Datos.FuncionesDB.EnviarCorreo(DatosMail);
                      
        }
    }
}
