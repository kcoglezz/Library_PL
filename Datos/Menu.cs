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
    public class Menu
    {
        public static InfoConexion oConex = new InfoConexion();
        public static List<InfoMenu> BuscarMenuPrincipal()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            string strProcedure = "PA_Obtener_Menu ";
            int intIdSeccion = 21;
            int intNivel = 1;
            int intIdPadre = 0;
            List<InfoMenu> oListaMenu = new List<InfoMenu>();
            try
            {
                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros
                cd.Parameters.AddWithValue("@IdSeccion", intIdSeccion);
                cd.Parameters.AddWithValue("@Nivel", intNivel);
                cd.Parameters.AddWithValue("@IdPadre", intIdPadre);
                reader = cd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    InfoMenu oResultado = new InfoMenu();
                    oResultado.IdMenu = Convert.ToInt32(reader["IdMenu"]);
                    oResultado.Descripcion = Convert.ToString(reader["Descripcion"]);
                    oResultado.IdPadre = Convert.ToInt32(reader["IdPadre"]);
                    oResultado.Nivel = Convert.ToInt32(reader["Nivel"]);
                    oResultado.Tipo = Convert.ToInt32(reader["Tipo"]);
                    oResultado.Cantidad_Hijos = Convert.ToInt32(reader["Hijos"]);
                    List<InfoSeccionPadre> ListadoElementosPadre = new List<InfoSeccionPadre>();
                    ListadoElementosPadre = BuscarMenuPadre(oResultado.IdMenu, intNivel + 1, oResultado.IdMenu);
                    oResultado.Padres = ListadoElementosPadre;
                    oListaMenu.Add(oResultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oListaMenu;
        }
        public static List<InfoSeccionPadre> BuscarMenuPadre(int intIdSeccion, int intNivel, int intIdPadre)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            string strProcedure = "PA_Obtener_Menu ";
            List<InfoSeccionPadre> oListaPadre = new List<InfoSeccionPadre>();
            try
            {
                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros
                cd.Parameters.AddWithValue("@IdSeccion", intIdSeccion);
                cd.Parameters.AddWithValue("@Nivel", intNivel);
                cd.Parameters.AddWithValue("@IdPadre", intIdPadre);
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

                    List<InfoSeccionHijos> ListadoElementosHijos = new List<InfoSeccionHijos>();
                    ListadoElementosHijos = BuscarMenuHijos(intIdSeccion, oResultado.Nivel + 1, oResultado.IdMenu);
                    oResultado.Hijos = ListadoElementosHijos;

                    oListaPadre.Add(oResultado);

                }
                reader.Close();
                cd.Dispose();
                mConn.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oListaPadre;
        }



        public static List<InfoSeccionHijos> BuscarMenuHijos(int intIdSeccion, int intNivel, int intIdPadre)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            string strProcedure = "PA_Obtener_Menu ";
            List<InfoSeccionHijos> oListaSeccion = new List<InfoSeccionHijos>();
            try
            {
                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros
                cd.Parameters.AddWithValue("@IdSeccion", intIdSeccion);
                cd.Parameters.AddWithValue("@Nivel", intNivel);
                cd.Parameters.AddWithValue("@IdPadre", intIdPadre);

                reader = cd.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    InfoSeccionHijos oResultado = new InfoSeccionHijos();
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
    }
}