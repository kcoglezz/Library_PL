using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class Respuesta
    {
        public static Boolean InsertarRespuesta(InfoRespuesta oRespuesta)
        {
            return Sistema.PL.Datos.Respuesta.InsertarRespuesta(oRespuesta);
        }
        public static Boolean EstaRespondidaLaPregunta(int IdPregunta, string strIPAddress)
        { 
            Boolean boResult=false;
            if (Sistema.PL.Datos.Respuesta.EstaRespondidaLaPregunta(IdPregunta,strIPAddress) > 0)
            {
                boResult = true;
            }
            return boResult;
        }
    }
}
