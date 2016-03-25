using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;
namespace Sistema.PL.Datos
{
    public class AdminLog
    {
        public static int RegistrarLog(InfoLog Log)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_InsertaLog ";
                string strLastProcedure = "";
                strLastProcedure = "'" + Log.Descripcion.ToString() + "'," + Log.Error + ",'" + Log.Url + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));


                return intId;

            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
    }
}