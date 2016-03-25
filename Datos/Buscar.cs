using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class Buscar
    {
        public static List<InfoBuscar> BuscarenPaginas(string strPalabra, int IntInicio, int intCantidadRow)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Buscar '" + strPalabra.ToString() + "'," + IntInicio.ToString() + "," + intCantidadRow.ToString();
            List<InfoBuscar> Listado = new List<InfoBuscar>();
            try
            {
                
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoBuscar resultado = new InfoBuscar();
                    resultado.PageId = Convert.ToInt32(reader["page_id"]);
                    resultado.posted = Convert.ToDateTime(reader["posted"]);
                    resultado.Titulo = Convert.ToString(reader["page_title"]);
                    resultado.Contenido = Convert.ToString(reader["blurb"]);
                    if (object.ReferenceEquals(reader["rating"], DBNull.Value))
                    {
                        resultado.Rating = 0;
                    }
                    else
                    {
                        resultado.Rating = Convert.ToInt32(reader["rating"]);
                    }
                    resultado.NombreAutor = Convert.ToString(reader["author"]);
                    resultado.CantidadTotalRegistros = Convert.ToInt32(reader["cantidad_Total"]);
                    resultado.AuthorId = Convert.ToInt32(reader["author_id"]);
                    resultado.SeccionId = Convert.ToInt32(reader["seccion_id"]);
                    resultado.SeccionName = Convert.ToString(reader["section_name"]);
                    Listado.Add(resultado);
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