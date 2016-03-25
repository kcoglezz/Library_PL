using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;
using System.Data.SqlClient;

namespace Sistema.PL.Datos
{
    public class Seccion
    {
        public static InfoConexion oConex = new InfoConexion();
        public static List<InfoSeccionPadre> BuscarSeccionRecursos(string strNombreOpcion)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            string strProcedure = "PA_Obtener_Elementos_de_un_Nivel ";
            List<InfoSeccionPadre> oListaSeccion = new List<InfoSeccionPadre>();
            try
            {
                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros
                cd.Parameters.AddWithValue("@NombreSeccionMenu", strNombreOpcion);

                reader = cd.ExecuteReader(CommandBehavior.CloseConnection);


                while (reader.Read())
                {
                    InfoSeccionPadre oResultado = new InfoSeccionPadre();
                    oResultado.IdMenu = Convert.ToInt32(reader["IdMenu"]);
                    oResultado.Descripcion = Convert.ToString(reader["Descripcion"]);
                    oResultado.IdPadre = Convert.ToInt32(reader["IdPadre"]);
                    oResultado.Nivel = Convert.ToInt32(reader["Nivel"]);
                    oResultado.Tipo = Convert.ToInt32(reader["Tipo"]);
                    oResultado.Cantidad_Hijos = Convert.ToInt32(reader["Hijos"]);
                    oListaSeccion.Add(oResultado);
                }
                reader.Close();
                cd.Dispose();
                mConn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oListaSeccion;
        }

        public static InfoSeccion ObtenerInformacionSeccion(int intIdSeccion)
        {

            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_ObtieneInfoSectionXID " + intIdSeccion.ToString();
            InfoSeccion resultado = new InfoSeccion();

            try
            {
                List<InfoSubSeccion> Listado = new List<InfoSubSeccion>();

                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);

                while (reader.Read())
                {
                    resultado.section_id = Convert.ToInt32(reader["section_id"]);
                    resultado.section_name = Convert.ToString(reader["section_name"]);
                    resultado.section_parent = Convert.ToInt32(reader["section_parent"]);
                    resultado.post_in_menu = Convert.ToInt32(reader["post_in_menu"]);
                    resultado.blurb = Convert.ToString(reader["blurb"]);
                    resultado.pagetext = Convert.ToString(reader["pagetext"]);
                    resultado.user_id = Convert.ToInt32(reader["user_id"]);
                    if ((!object.ReferenceEquals(reader["last_modified"], DBNull.Value)))
                    {
                        resultado.last_modified = Convert.ToDateTime(reader["last_modified"]);
                    }
                    if ((!object.ReferenceEquals(reader["mod_by"], DBNull.Value)))
                    {
                        resultado.mod_by = Convert.ToInt32(reader["mod_by"]);
                    }

                    resultado.show_on_droplist = Convert.ToInt32(reader["show_on_droplist"]);
                    resultado.article_count = Convert.ToInt32(reader["article_count"]);

                    if (Convert.ToInt32(reader["Tiene_SubSeccion"]) > 0)
                    {
                        resultado.TieneSubSeccion = true;
                    }
                    else
                    {
                        resultado.TieneSubSeccion = false;
                    }
                    resultado.Descripcion_niveles = Convert.ToString(reader["Descripcion_niveles"]);
                    resultado.id_section_origen = Convert.ToInt32(reader["id_section_origen"]);
                    resultado.section_name_origen = Convert.ToString(reader["section_name_origen"]);


                }
                reader.Close();

                if (resultado.TieneSubSeccion)
                {
                    strProcedure = "proc_GetSubSectionsBySectionID " + intIdSeccion.ToString();

                    reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                    while (reader.Read())
                    {
                        InfoSubSeccion Result = new InfoSubSeccion();
                        Result.section_id = Convert.ToInt32(reader["section_id"]);
                        Result.section_name = Convert.ToString(reader["section_name"]);
                        Result.pagetext = Convert.ToString(reader["pagetext"]);
                        Result.article_count = Convert.ToInt32(reader["article_count"]);
                        Listado.Add(Result);
                    }
                }
                resultado.SubSeccion = Listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }

        public static List<InfoPaginasdelaSeccion> BuscarPaginasPorSeccion(int intSeccion, int IntInicio, int intCantidadRow)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Obtiene_SeccionPaginas " + intSeccion.ToString() + "," + IntInicio.ToString() + "," + intCantidadRow.ToString();
            List<InfoPaginasdelaSeccion> Listado = new List<InfoPaginasdelaSeccion>();

            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoPaginasdelaSeccion resultado = new InfoPaginasdelaSeccion();
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