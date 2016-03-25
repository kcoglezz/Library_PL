using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{

    public class Etiqueta
    {
        public static List<InfoEtiqueta> ListarEtiquetasConMasRating()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "proc_GetEtiquetas ";
            List<InfoEtiqueta> ListadoEtiqueta = new List<InfoEtiqueta>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoEtiqueta resultado = new InfoEtiqueta();
                    resultado.Etiqueta = Convert.ToString(reader["KEYWORDS"]);
                    resultado.PageId = Convert.ToInt32(reader["page_id"]);
                    if (object.ReferenceEquals(reader["rating"], DBNull.Value))
                    {
                        resultado.Rating = 0;
                    }
                    else
                    {
                        resultado.Rating = Convert.ToInt32(reader["rating"]);
                    }
                    resultado.AuthorId = Convert.ToInt32(reader["user_id"]);
                    resultado.IdSeccion = Convert.ToInt32(reader["section_id"]);
                    resultado.Titulo = Convert.ToString(reader["page_title"]);
                    resultado.Contenido = Convert.ToString(reader["blurb"]);
                    resultado.MasUsoTag = Convert.ToString(reader["Mas_Uso_Tag"]);
                    ListadoEtiqueta.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListadoEtiqueta;
        }
        public static List<InfoEtiqueta> BuscarPaginasPorEtiquetas(string strEtiqueta, int IntInicio, int intCantidadRow)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Obtiene_PaginasPorTags " + IntInicio.ToString() + "," + intCantidadRow.ToString() + ",'" + strEtiqueta.ToString() + "'";
            List<InfoEtiqueta> Listado = new List<InfoEtiqueta>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoEtiqueta resultado = new InfoEtiqueta();
                    resultado.Etiqueta = Convert.ToString(reader["tag"]);
                    resultado.PageId = Convert.ToInt32(reader["page_id"]);
                    if (object.ReferenceEquals(reader["rating"], DBNull.Value))
                    {
                        resultado.Rating = 0;
                    }
                    else
                    {
                        resultado.Rating = Convert.ToInt32(reader["rating"]);
                    }
                    resultado.Titulo = Convert.ToString(reader["page_title"]);
                    resultado.Contenido = Convert.ToString(reader["blurb"]);
                    resultado.NombreAutor = Convert.ToString(reader["author"]);
                    resultado.posted = Convert.ToDateTime(reader["posted"]);
                    resultado.AuthorId = Convert.ToInt32(reader["author_id"]);

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

        public static int ObtenerCantidadRegistroPorEtiqueta(string strEtiqueta)
        {
            string strProcedure = "proc_GetPagesByTagsCount '" + strEtiqueta.ToString() + "'";
            int intCount = 0;
            try
            {
                intCount = FuncionesDB.CountArticles(strProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intCount;
        }

    }

}