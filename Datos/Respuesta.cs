using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class Respuesta
    {
        public static bool InsertarRespuesta(InfoRespuesta oRespuesta)
        {
            bool intResult = false;
            int intId = 0;

            try
            {
                string strProcedure = "proc_InsertAnswers ";
                string strLastProcedure = "";
                strLastProcedure = oRespuesta.Id_Pregunta + "," + oRespuesta.Respuesta_1 + "," + oRespuesta.Respuesta_2 + "," + oRespuesta.Respuesta_3 + "," + oRespuesta.Respuesta_4 + "," + oRespuesta.Respuesta_5 + "," + oRespuesta.Respuesta_6 + "," + oRespuesta.Respuesta_7 + "," + oRespuesta.Respuesta_8 + "," + oRespuesta.Respuesta_9 + "," + oRespuesta.Respuesta_10 + ",'" + oRespuesta.IpAddress + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));

                if (intId > 0)
                {
                    intResult = true;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intResult;
        }

        public static int EstaRespondidaLaPregunta(int IdPregunta, string IpAddress)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_IPaddress_Responde_Pregunta ";
                string strLastProcedure = "";
                strLastProcedure = "'" + IdPregunta + "','" + IpAddress + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

    }
}