using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class TipoTrabajo
    {
        public static List<InfoTipoTrabajo> ListarTipoTrabajo()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_ListarTipoTrabajo ";
            List<InfoTipoTrabajo> Listado = new List<InfoTipoTrabajo>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoTipoTrabajo Result = new InfoTipoTrabajo();
                    Result.Id = Convert.ToInt32(reader["id"]);
                    Result.Nombre = Convert.ToString(reader["name"]);
                    Listado.Add(Result);
                }
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