using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class Pais
    {
        public static List<InfoPais> ListarPaises()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "proc_GetCountriesWithRegUsers ";
            List<InfoPais> Listado = new List<InfoPais>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoPais Pais = new InfoPais();
                    Pais.Id = Convert.ToInt32(reader["id"]);
                    Pais.Nombre = Convert.ToString(reader["name"]);
                    Listado.Add(Pais);
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
