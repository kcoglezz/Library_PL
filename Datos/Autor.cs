using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{


    public class Autor
    {

        //Public Shared ORA As InfoConexionORA = New InfoConexionORA

        public static InfoAutor TraerAutor(int IdAutor)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "sp_GetAuthorByID ";
            InfoAutor Autor = new InfoAutor();
            try
            {
                //InfoAutor Autor = new InfoAutor();
                //-- reader = Datos.FuncionesDB.Obtener_DataReader(strProcedure)
                reader = FuncionesDB.GetRecords(strProcedure + IdAutor);

                while (reader.Read())
                {
                    Autor.Id = Convert.ToInt32(reader["id"]);
                    Autor.Nombre = Convert.ToString(reader["nombre_author"]);
                    Autor.Ciudad = Convert.ToString(reader["ciudad"]);
                    Autor.Pais = Convert.ToString(reader["Pais"]);
                    Autor.Email = Convert.ToString(reader["email"]);
                    Autor.Fecha_Desde = Convert.ToDateTime(reader["Fecha_Desde"]);
                    Autor.Resena = Convert.ToString(reader["Resena"]);
                    Autor.FotoAutho = Convert.ToString(reader["picture"]);

                }
                reader.Close();
                return Autor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<InfoLoDelAutor> ObtenerLoDelAutor(int intIdAutor, int IntInicio, int intCantidadRow)
        {
            //Dim intInicio As Integer = 1
            System.Data.SqlClient.SqlDataReader reader = null;
            //Dim strProcedure As String = "PA_ObtieneMasDelAutor " + intInicio.ToString + "," + intIdAutor.ToString()
            string strProcedure = "PA_ObtieneMasDelAutor " + intIdAutor.ToString() + "," + IntInicio.ToString() + "," + intCantidadRow.ToString();
            List<InfoLoDelAutor> ListadoLoDestacado = new List<InfoLoDelAutor>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                //List<InfoLoDelAutor> ListadoLoDestacado = new List<InfoLoDelAutor>();
                while (reader.Read())
                {
                    InfoLoDelAutor resultado = new InfoLoDelAutor();
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
                    resultado.CantidadTotalRegistros = Convert.ToInt32(reader["cantidad_Total"]);
                    ListadoLoDestacado.Add(resultado);
                }
                reader.Close();
                //return ListadoLoDestacado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListadoLoDestacado;
        }


        public static List<InfoPublicacionesDelAutor> BuscarPublicacionesdelAutor(int intIdAutor, int IntInicio, int intCantidadRow)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Obtiene_PublicacionesXAutor " + intIdAutor.ToString() + "," + IntInicio.ToString() + "," + intCantidadRow.ToString();
            List<InfoPublicacionesDelAutor> Listado = new List<InfoPublicacionesDelAutor>();
            try
            {
                
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoPublicacionesDelAutor resultado = new InfoPublicacionesDelAutor();
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