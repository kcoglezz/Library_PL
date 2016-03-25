using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class Sexo
    {
        public static List<InfoSexo> ListarSexo()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_ListarSexo ";
            List<InfoSexo> Listado = new List<InfoSexo>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoSexo Sexo = new InfoSexo();
                    Sexo.Id = Convert.ToInt32(reader["id"]);
                    Sexo.Nombre = Convert.ToString(reader["name"]);
                    Listado.Add(Sexo);
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