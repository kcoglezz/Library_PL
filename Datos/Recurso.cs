using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class Recurso
    {
        public static List<InfoRecurso> ListarRecursos()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Listado_Recursos_Colaboracion ";
            List<InfoRecurso> Listado = new List<InfoRecurso>();

            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoRecurso result = new InfoRecurso();
                    result.Id = Convert.ToInt32(reader["id"]);
                    result.Nombre = Convert.ToString(reader["name"]);
                    Listado.Add(result);
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