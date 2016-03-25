using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class EstadoCivil
    {
        public static List<InfoEstadoCivil> ListarEstadoCivil()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_ListarEstadoCivil ";
            List<InfoEstadoCivil> Listado = new List<InfoEstadoCivil>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoEstadoCivil EstadoCivil = new InfoEstadoCivil();
                    EstadoCivil.Id = Convert.ToInt32(reader["id"]);
                    EstadoCivil.Nombre = Convert.ToString(reader["name"]);
                    Listado.Add(EstadoCivil);
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