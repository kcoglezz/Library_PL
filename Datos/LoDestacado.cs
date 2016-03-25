using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class LoDestacado
    {
        public static List<InfoLoDestacado> ObtenerLoDestacado(int intIndex)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "proc_GetLoDestacado " + intIndex.ToString();
            List<InfoLoDestacado> ListadoLoDestacado = new List<InfoLoDestacado>();
            try
            {
                int intCount = 0;
                intCount = FuncionesDB.CountArticles("proc_LoDestacadoCount");

                if (intCount > 0)
                {
                    reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                    while (reader.Read())
                    {
                        InfoLoDestacado resultado = new InfoLoDestacado();
                        resultado.IdFila = Convert.ToInt32(reader["rownum"]);
                        resultado.PageId = Convert.ToInt32(reader["page_id"]);
                        resultado.Fecha = Convert.ToDateTime(reader["posted"]);
                        resultado.Titulo = Convert.ToString(reader["page_title"]);
                        resultado.Contenido = Convert.ToString(reader["blurbs"]);
                        if (object.ReferenceEquals(reader["rating"], DBNull.Value))
                        {
                            resultado.rating = 0;
                        }
                        else
                        {
                            resultado.rating = Convert.ToInt32(reader["rating"]);
                        }
                        resultado.Autor = Convert.ToString(reader["author"]);
                        resultado.IdSeccion = Convert.ToInt32(reader["seccion_id"]);
                        resultado.Nombre_Seccion = Convert.ToString(reader["section_name"]);
                        resultado.AuthorId = Convert.ToInt32(reader["author_id"]);
                        resultado.Etiqueta = Convert.ToString(reader["Etiqueta"]);
                        ListadoLoDestacado.Add(resultado);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListadoLoDestacado;
        }

        public static List<InfoArticuloListado> BuscarArticulosDestacados(int IntInicio, int intCantidadRow)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Obtiene_LoDestacado_Ver_Mas " + IntInicio.ToString() + "," + intCantidadRow.ToString();
            List<InfoArticuloListado> Listado = new List<InfoArticuloListado>();

            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoArticuloListado resultado = new InfoArticuloListado();
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