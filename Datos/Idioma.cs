using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class Idioma
    {
        public static List<InfoIdioma> ListarIdioma()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_ListarIdiomas ";
            int intIndiceX = 0;
            List<InfoIdioma> Listado = new List<InfoIdioma>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoIdioma Result = new InfoIdioma();
                    Result.Id = Convert.ToInt32(intIndiceX);
                    Result.Nombre = Convert.ToString(reader["name"]);
                    intIndiceX = intIndiceX + 1;
                    Listado.Add(Result);
                }
                InfoIdioma Result2 = new InfoIdioma();
                Result2.Id = Convert.ToInt32(intIndiceX);
                Result2.Nombre = "Otro";
                Listado.Add(Result2);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;
        }
    }

}