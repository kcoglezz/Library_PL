using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;
using System.Data.SqlClient;
using Library_PL.Filtros;

namespace Sistema.PL.Datos
{
    public class Pagina
    {
        public static InfoConexion oConex = new InfoConexion();
        public static InfoPagina TraerPagina(int intId_Pagina)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            string strProcedure = "PA_Obtener_PageByID ";
            InfoPagina oResultado = new InfoPagina();
            try
            {
                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros
                cd.Parameters.AddWithValue("@id_page", intId_Pagina);
                reader = cd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    oResultado.Id_Pagina = Convert.ToInt32(reader["page_id"]);
                    oResultado.Id_Seccion = Convert.ToInt32(reader["section_id"]);
                    oResultado.FechaPosteada = Convert.ToDateTime(reader["posted"]);
                    oResultado.TituloPagina = Convert.ToString(reader["page_title"]);
                    oResultado.Reseña = Convert.ToString(reader["blurb"]);
                    oResultado.Contenido = Convert.ToString(reader["body"]);
                    oResultado.EsPosteado = Convert.ToInt32(reader["isposted"]);
                    oResultado.NombreImagen = Convert.ToString(reader["pic"]);
                    oResultado.TipoArticulo = Convert.ToInt32(reader["typeofarticle"]);
                    oResultado.Isfeatured = Convert.ToInt32(reader["isfeatured"]);
                    oResultado.Id_User = Convert.ToInt32(reader["user_id"]);
                    oResultado.NombreAutor = Convert.ToString(reader["nombre_autor"]);
                    oResultado.Etiquetas = Convert.ToString(reader["keywords"]);
                    oResultado.Book = Convert.ToInt32(reader["book"]);
                    oResultado.Chapter = Convert.ToInt32(reader["chapter"]);
                    oResultado.Rating = Convert.ToInt32(reader["rating"]);
                    oResultado.NombreSeccionActual = Convert.ToString(reader["section_name_actual"]);
                    oResultado.NombreSeccionPadre = Convert.ToString(reader["section_name_Padre"]);
                    oResultado.Id_SeccionPadre = Convert.ToInt32(reader["id_section_name_Padre"]);
                    if ((!object.ReferenceEquals(reader["section_name_origen"], DBNull.Value)))
                    {
                        oResultado.NombreSeccionOrigen = Convert.ToString(reader["section_name_origen"]);
                    }
                    if ((!object.ReferenceEquals(reader["id_section_origen"], DBNull.Value)))
                    {
                        oResultado.Id_SeccionOrigen = Convert.ToInt32(reader["id_section_origen"]);
                    }


                    if (object.ReferenceEquals(reader["Estrellas"], DBNull.Value))
                    {
                        oResultado.Estrellas = 0;
                    }
                    else
                    {
                        oResultado.Estrellas = Convert.ToInt32(reader["Estrellas"]);
                    }

                    if (object.ReferenceEquals(reader["picture"], DBNull.Value))
                    {
                        oResultado.FotoAutho = "";
                    }
                    else
                    {
                        oResultado.FotoAutho = Convert.ToString(reader["picture"]);
                    }
                }
                reader.Close();
                cd.Dispose();
                mConn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oResultado;
        }

        public static int RegistrarColaboracion(InfoColaboracion oObjeto)
        {
            int intId = 0;
            try
            {
                string strProcedure = "proc_InsertPages ";
                string strLastProcedure = "";
                strLastProcedure = oObjeto.intSectionId + ",'" + oObjeto.dtPosted.ToString("yyyyMMdd") + "','" + oObjeto.strPageTitle + "','" + oObjeto.strBlurb + "','" + oObjeto.strBody + "','" + oObjeto.btIsposted + "','" + oObjeto.strPic + "'," + oObjeto.intTypeofarticle + "," + oObjeto.btIsfeatured + ",'" + oObjeto.intUserId + "','" + oObjeto.strKeywords + "'," + oObjeto.intBook + ",'" + oObjeto.intChapter + "'," + oObjeto.btRating;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intId;
        }


        public static int RegistrarRecursoDescarga(InfoPaginaDescarga oObjeto)
        {
            int intId = 0;
            try
            {
                string strProcedure = "PA_InsertaUsuarioDescarga ";
                string strLastProcedure = "";
                strLastProcedure = oObjeto.Id_Usuario + ",'" + oObjeto.IpAddress + "'," + oObjeto.Id_Pagina + "," + oObjeto.Valor ;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return intId;
        }

        public static int CantidadDeDescargadeRecurso(int intId_Pagina)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_CantidadDescargaPagina ";
                string strLastProcedure = "";
                strLastProcedure = intId_Pagina.ToString() ;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

        public static List<InfoDescarga> ListaTodasLasDescagadas(int intPagina)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            string strProcedure = "PA_ListaTodasLasDescagadas ";
            List<InfoDescarga> Listado = new List<InfoDescarga>();
            try
            {
                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros

                cd.Parameters.AddWithValue("@StartRow", intPagina);
                reader = cd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    InfoDescarga oResultado = new InfoDescarga();
                    oResultado.IdPagina = Convert.ToInt32(reader["IdPages"]);
                    oResultado.CantidadDescargaPagina = Convert.ToInt32(reader["cantidad_de_descargas"]);
                    oResultado.CantidadTotal = Convert.ToInt32(reader["cantidad_total"]);
                    oResultado.Titulo = Convert.ToString(reader["page_title"]);
                    Listado.Add(oResultado);
                }
                reader.Close();
                cd.Dispose();
                mConn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;
        }

        public static List<InfoDescarga> ListaDescargasXFecha()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            string strProcedure = "PA_ListaDescargasXFecha ";
            List<InfoDescarga> Listado = new List<InfoDescarga>();
            try
            {
                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros
                reader = cd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    InfoDescarga oResultado = new InfoDescarga();
                    oResultado.Fecha = Convert.ToDateTime(reader["fecha"]);
                    oResultado.CantidadTotal = Convert.ToInt32(reader["cantidad_total"]);
                    Listado.Add(oResultado);
                }
                reader.Close();
                cd.Dispose();
                mConn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;
        }

        public static List<InfoDescarga> BuscarDescarga_x_Mes_Anio(InfoFiltroPagina oPagina)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            string strProcedure = "PA_ListaDescargas_X_Mes_Anio ";
            List<InfoDescarga> Listado = new List<InfoDescarga>();
            try
            {
                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros

                cd.Parameters.AddWithValue("@StartRow", Convert.ToInt32(oPagina.IdPagina.ToString()));
                cd.Parameters.AddWithValue("@Mes", Convert.ToInt32(oPagina.Mes.ToString()));
                cd.Parameters.AddWithValue("@Anio", Convert.ToInt32(oPagina.Anio.ToString()));
                reader = cd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    InfoDescarga oResultado = new InfoDescarga();
                    oResultado.IdPagina = Convert.ToInt32(reader["IdPages"]);
                    oResultado.CantidadDescargaPagina = Convert.ToInt32(reader["cantidad_de_descargas"]);
                    oResultado.CantidadTotal = Convert.ToInt32(reader["cantidad_total"]);
                    oResultado.Titulo = Convert.ToString(reader["page_title"]);
                    Listado.Add(oResultado);
                }
                reader.Close();
                cd.Dispose();
                mConn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;
        }


    }
}