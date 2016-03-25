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
    public class UsuarioEMail
    {
        public static InfoConexion oConex = new InfoConexion();
        //Public Shared EmailAdmin As New InfoAdminEmails()
        private static string _Ambiente = System.Configuration.ConfigurationManager.AppSettings["PL_ENVIRONMENT"];

        private static string _Track_error = System.Configuration.ConfigurationManager.AppSettings["Track_error"];
        public static List<InfoEmail> TraerMaildeUsuarios(int intInicio, int intFin)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            List<InfoEmail> ListaUsuarioMail = new List<InfoEmail>();
            object oObjeto = new object();
            string strProcedure = "PA_TraerMailUsuarios ";


            try
            {

                mConn.Open();
                SqlCommand cd = new SqlCommand(strProcedure, mConn);
                cd.CommandType = CommandType.StoredProcedure;
                ////Parametros
                cd.Parameters.AddWithValue("@InicioRow", intInicio);
                cd.Parameters.AddWithValue("@FinRow", intFin);

                reader = cd.ExecuteReader(CommandBehavior.CloseConnection);

                while (reader.Read())
                {
                    InfoEmail UsuarioMail = new InfoEmail();
                    UsuarioMail.correlativo = Convert.ToInt32(reader["rownum"]);
                    UsuarioMail.id_usuario = Convert.ToInt32(reader["id_user"]);
                    UsuarioMail.email = Convert.ToString(reader["email"]);
                    UsuarioMail.NombreUsuario = Convert.ToString(reader["nombre"]);
                    ListaUsuarioMail.Add(UsuarioMail);

                }
                reader.Close();
                cd.Dispose();
                mConn.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListaUsuarioMail;
        }

        public static int RegistrarUsuarioVer(string valor1, string valor2)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_InsertaVerMail ";
                string strLastProcedure = "";
                strLastProcedure = "'" + valor1.ToString() + "','" + valor2.ToString() + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));




            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

    }
}