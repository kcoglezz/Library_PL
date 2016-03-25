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
	public class Usuario
	{
		public static InfoConexion oConex = new InfoConexion();
		public static InfoAdminEmails EmailAdmin = new InfoAdminEmails();
		private static string _Ambiente = System.Configuration.ConfigurationManager.AppSettings["PL_ENVIRONMENT"];

		private static string _Track_error = System.Configuration.ConfigurationManager.AppSettings["Track_error"];
		public static InfoUsuario TraerUsuario(string strEmail, string strPassword)
		{
			System.Data.SqlClient.SqlDataReader reader = null;
			int intUserId = 0;
			SqlConnection mConn = new SqlConnection(oConex.StringConnection);
			InfoUsuario Usuario = new InfoUsuario();
			object oObjeto = new object();
			string strProcedure = "proc_CheckLogon ";
			string strProcedure2 = "PA_Get_User ";
            string strProcedure3 = "PA_Ver_Info_del_Equipo ";

			try {
				oObjeto = FuncionesDB.ExecScalar(strProcedure + "'" + strEmail + "','" + strPassword + "'");
				if (object.ReferenceEquals(oObjeto, DBNull.Value)) {
					intUserId = 0;
				} else {
					intUserId = Convert.ToInt32(oObjeto);
				}

				if (intUserId > 0) {
					mConn.Open();
					SqlCommand cd = new SqlCommand(strProcedure2, mConn);
					cd.CommandType = CommandType.StoredProcedure;
					////Parametros
					cd.Parameters.AddWithValue("@user_id", intUserId);

					reader = cd.ExecuteReader(CommandBehavior.CloseConnection);

					while (reader.Read()) {
						string[] strnombres = null;
						string[] strapellidos = null;
						string strNombreFinal = "";
						Usuario.IdUsuario = Convert.ToInt32(reader["id"]);
						strnombres = Convert.ToString(reader["first_name"]).Split(' ');
						strapellidos = Convert.ToString(reader["last_name"]).Split(' ');
						if (strnombres.Length > 1) {
							strNombreFinal = strNombreFinal + strnombres[0];
						} else {
							strNombreFinal = strNombreFinal + Convert.ToString(reader["first_name"]);
						}
						if (strapellidos.Length > 1) {
							strNombreFinal = strNombreFinal + " " + strapellidos[0];
						} else {
							strNombreFinal = strNombreFinal + " " + Convert.ToString(reader["last_name"]);
						}

						Usuario.Nombre = strNombreFinal;
						Usuario.Email = Convert.ToString(reader["email"]);
						Usuario.Encontrado = true;
						Usuario.EstadoUsuario = Convert.ToInt32(reader["status_user"]);

                        /* //cambios 15-02-2016
                        Usuario.Es_Administrador_Equipo = Convert.ToBoolean(Convert.ToInt32(reader["ES_ADMINISTRADOR"]));
                        Usuario.ID_Equipo = Convert.ToInt32(reader["ID_EQUIPO"]);
                        Usuario.ID_Equipo_Usuario = Convert.ToInt32(reader["ID_EQUIPO_USUARIO"]);
                        Usuario.Esta_En_Equipo = Convert.ToBoolean(Convert.ToInt32(reader["ESTA_EN_UN_EQUIPO"]));
                        Usuario.A_Cuantos_Equipos_Pertenece = Convert.ToInt32(reader["A_CUANTOS_EQUIPOS_PERTENCE"]);
                        Usuario.Cantidad_Usuarios = Convert.ToInt32(reader["CANTIDAD_USUARIOS"]);
                        Usuario.Nombre_Equipo = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                        //cambios 15-02-2016
                         
                         */



                        // Inicio Cambios RGM 20-02-2016
                        // Esto se cambio completamente por lo siguientes casos
                        // 1) un usuario es admin de un equipo o varios equipos
                        // 2) un usuario puede ser solo un participante de un equipo o varios equipos sin ser admin
                        // 3) un usuario puede ser admin de un(os) equipo(s) y partipante de otros equipos
                        // 4) un usuario no sea ni partcipante, ni admin de nigun equipo(este ve el sitio tanl cual como hoy esta)
                        
                        
                        
                        // Fin Cambios RGM 20-02-2016

                        //USAR NUEVAS VARIABLES PARA DEFINIR SI SE ACTIVAN O NO LOS BOTONES DE COMPARTIR CON EL GRUPO

                        //PUEDE SER Que SEA UN USUARIO QUE ES ADMIN
                        // PERO TAMBIEN PUEDE SER UNO QUE No ES ADMIN, PERO QUE ESTA EN UN EQUIPO
                        // SINO ES NIGUNA CATEGORIA, ENTONCES NO TIENE NI EQUIPO, NI NADA.

                        //AQUI LAS VARIABLES

                        //@ES_ADMIN AS ES_ADMINISTRADOR,
                         ////@ID_EQUIPO, 
                            ////@ESTA_EN_UN_EQUIPO, 
                                                            ////@A_CUANTOS_EQUIPOS_PERTENCE,
    ////@CANTIDAD_USUARIOS, 
    ////@NOMBRE_EQUIPO

                        //if (Convert.ToInt32(reader["id"]) == 1)
                        //{
                        //    Usuario.Es_Administrador_Equipo 
                        //}
                        //else
                        //{
                        //    Usuario.Es_Administrador_Equipo 
                        //}
                        
					}
					reader.Close();
					cd.Dispose();
                    //if (Usuario.Es_Administrador_Equipo == true)
                    //{
                        mConn.Open();
					    SqlCommand cd2 = new SqlCommand(strProcedure3, mConn);
					    cd2.CommandType = CommandType.StoredProcedure;
					    ////Parametros
                        cd2.Parameters.AddWithValue("@ID_USUARIO", intUserId);
                        List<InfoEquipoUsuario> Listado = new List<InfoEquipoUsuario>();
					    reader = cd2.ExecuteReader(CommandBehavior.CloseConnection);
                        
                        while (reader.Read())
                        {
                            InfoEquipoUsuario resultado = new InfoEquipoUsuario();
                            resultado.ID_EQUIPO = Convert.ToInt32(reader["ID_EQUIPO"]);
                            resultado.ID_EQUIPO_USUARIO = Convert.ToInt32(reader["ID_EQUIPO_USUARIO"]);
                            resultado.ID_USUARIO = Convert.ToInt32(reader["ID_USUARIO"]);
                            resultado.TIPO = Convert.ToInt32(reader["TIPO"]);
                            resultado.ES_ADMINISTRADOR = Convert.ToString(reader["ES_ADMINISTRADOR"]);
                            resultado.CANTIDAD_USUARIOS = Convert.ToInt32(reader["CANTIDAD_USUARIOS"]);
                            resultado.NOMBRE_EQUIPO = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                            resultado.FECHA_CREACION = Convert.ToString(reader["FECHA_CREACION"]);
                            Listado.Add(resultado);
                        }

                        reader.Close();
                        cd2.Dispose();

                        Usuario.EQUIPOS = Listado;

                        if (Listado.Count == 0)
                        {
                            Usuario.Esta_En_Equipo = false;
                        }
                        else
                        {
                            Usuario.Esta_En_Equipo = true;
                        }


                    //}
				} else {
					Usuario.Encontrado = false;
				}


				mConn.Close();


			} catch (Exception ex) {
				throw ex;
			}
			return Usuario;
		}
        public static InfoUsuario TraerUsuario_id(int intUserId)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            InfoUsuario Usuario = new InfoUsuario();
            object oObjeto = new object();
            string strProcedure2 = "PA_Get_User ";
            string strProcedure3 = "PA_Ver_Info_del_Equipo ";

            try
            {
                if (intUserId > 0)
                {
                    mConn.Open();
                    SqlCommand cd = new SqlCommand(strProcedure2, mConn);
                    cd.CommandType = CommandType.StoredProcedure;
                    ////Parametros
                    cd.Parameters.AddWithValue("@user_id", intUserId);

                    reader = cd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        string[] strnombres = null;
                        string[] strapellidos = null;
                        string strNombreFinal = "";
                        Usuario.IdUsuario = Convert.ToInt32(reader["id"]);
                        strnombres = Convert.ToString(reader["first_name"]).Split(' ');
                        strapellidos = Convert.ToString(reader["last_name"]).Split(' ');
                        if (strnombres.Length > 1)
                        {
                            strNombreFinal = strNombreFinal + strnombres[0];
                        }
                        else
                        {
                            strNombreFinal = strNombreFinal + Convert.ToString(reader["first_name"]);
                        }
                        if (strapellidos.Length > 1)
                        {
                            strNombreFinal = strNombreFinal + " " + strapellidos[0];
                        }
                        else
                        {
                            strNombreFinal = strNombreFinal + " " + Convert.ToString(reader["last_name"]);
                        }

                        Usuario.Nombre = strNombreFinal;
                        Usuario.Email = Convert.ToString(reader["email"]);
                        Usuario.Encontrado = true;
                        Usuario.EstadoUsuario = Convert.ToInt32(reader["status_user"]);
                    }
                    reader.Close();
                    cd.Dispose();
                    //if (Usuario.Es_Administrador_Equipo == true)
                    //{
                    mConn.Open();
                    SqlCommand cd2 = new SqlCommand(strProcedure3, mConn);
                    cd2.CommandType = CommandType.StoredProcedure;
                    ////Parametros
                    cd2.Parameters.AddWithValue("@ID_USUARIO", intUserId);
                    List<InfoEquipoUsuario> Listado = new List<InfoEquipoUsuario>();
                    reader = cd2.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        InfoEquipoUsuario resultado = new InfoEquipoUsuario();
                        resultado.ID_EQUIPO = Convert.ToInt32(reader["ID_EQUIPO"]);
                        resultado.ID_EQUIPO_USUARIO = Convert.ToInt32(reader["ID_EQUIPO_USUARIO"]);
                        resultado.ID_USUARIO = Convert.ToInt32(reader["ID_USUARIO"]);
                        resultado.TIPO = Convert.ToInt32(reader["TIPO"]);
                        resultado.ES_ADMINISTRADOR = Convert.ToString(reader["ES_ADMINISTRADOR"]);
                        resultado.CANTIDAD_USUARIOS = Convert.ToInt32(reader["CANTIDAD_USUARIOS"]);
                        resultado.NOMBRE_EQUIPO = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                        resultado.FECHA_CREACION = Convert.ToString(reader["FECHA_CREACION"]);
                        Listado.Add(resultado);
                    }

                    reader.Close();
                    cd2.Dispose();

                    Usuario.EQUIPOS = Listado;

                    if (Listado.Count == 0)
                    {
                        Usuario.Esta_En_Equipo = false;
                    }
                    else
                    {
                        Usuario.Esta_En_Equipo = true;
                    }


                    //}
                }
                else
                {
                    Usuario.Encontrado = false;
                }


                mConn.Close();


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Usuario;
        }

        public static InfoUsuario Trae_Datos_Basicos_del_Usuario_id(int intUserId)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            SqlConnection mConn = new SqlConnection(oConex.StringConnection);
            InfoUsuario Usuario = new InfoUsuario();
            object oObjeto = new object();
            string strProcedure2 = "PA_Get_User ";
            try
            {
                if (intUserId > 0)
                {
                    mConn.Open();
                    SqlCommand cd = new SqlCommand(strProcedure2, mConn);
                    cd.CommandType = CommandType.StoredProcedure;
                    ////Parametros
                    cd.Parameters.AddWithValue("@user_id", intUserId);

                    reader = cd.ExecuteReader(CommandBehavior.CloseConnection);

                    while (reader.Read())
                    {
                        string[] strnombres = null;
                        string[] strapellidos = null;
                        string strNombreFinal = "";
                        Usuario.IdUsuario = Convert.ToInt32(reader["id"]);
                        strnombres = Convert.ToString(reader["first_name"]).Split(' ');
                        strapellidos = Convert.ToString(reader["last_name"]).Split(' ');
                        if (strnombres.Length > 1)
                        {
                            strNombreFinal = strNombreFinal + strnombres[0];
                        }
                        else
                        {
                            strNombreFinal = strNombreFinal + Convert.ToString(reader["first_name"]);
                        }
                        if (strapellidos.Length > 1)
                        {
                            strNombreFinal = strNombreFinal + " " + strapellidos[0];
                        }
                        else
                        {
                            strNombreFinal = strNombreFinal + " " + Convert.ToString(reader["last_name"]);
                        }

                        Usuario.Nombre = strNombreFinal;
                        Usuario.Email = Convert.ToString(reader["email"]);
                        Usuario.Encontrado = true;
                        Usuario.EstadoUsuario = Convert.ToInt32(reader["status_user"]);
                    }
                    reader.Close();
                    cd.Dispose();
                    mConn.Open();
                }
                else
                {
                    Usuario.Encontrado = false;
                }
                mConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Usuario;
        }
		public static int RegistrarUsuario(InfoUsuario Usuario)
		{
			string strLastProcedureOrignal = null;
			int intId = 0;

			try {
				string strProcedure = "proc_InsertRegUsers ";
				string strLastProcedure = "";
				strLastProcedure = "'" + Usuario.RegNombre + "','" + Usuario.RegApellido + "','" + Usuario.Clave + "','" + Usuario.Email + "'," + Usuario.FirstVisit + ",'" + Usuario.Anno + Usuario.Mes + Usuario.Dia + "'," + Usuario.Sexo + "," + Usuario.MStatus + "," + Usuario.WorkType + ",'" + Usuario.Ciudad + "','" + Usuario.Estado + "'," + Usuario.IdPais + ",'" + Usuario.MainLanguage + "','" + Usuario.Phone + "'," + Usuario.SecurityLevel + ",'" + Usuario.Picture + "','" + Usuario.OtherInfo + "','" + Usuario.LastLog + "'," + Usuario.PublicarPerfil + "," + Usuario.RecibirNoticias + "," + Usuario.EstadoUsuario;
				strLastProcedureOrignal = strLastProcedure;
				intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
			} catch (Exception ex) {
				strLastProcedureOrignal = "'" + Usuario.RegNombre + "','" + Usuario.RegApellido + "','" + Usuario.Clave + "','" + Usuario.Email + "'," + Usuario.FirstVisit + ",'" + Usuario.Anno + Usuario.Mes + Usuario.Dia + "'," + Usuario.Sexo + "," + Usuario.MStatus + "," + Usuario.WorkType + ",'" + Usuario.Ciudad + "','" + Usuario.Estado + "'," + Usuario.IdPais + ",'" + Usuario.MainLanguage + "','" + Usuario.Phone + "'," + Usuario.SecurityLevel + ",'" + Usuario.Picture + "','" + Usuario.OtherInfo + "','" + Usuario.LastLog + "'," + Usuario.PublicarPerfil + "," + Usuario.RecibirNoticias + "," + Usuario.EstadoUsuario;
				InfoLog oLog = new InfoLog();
				oLog.Descripcion = "proc_InsertRegUsers :  " + ex.Message.ToString();
				oLog.Error = 1;
				oLog.Url = "Error proc_InsertRegUsers " + strLastProcedureOrignal;
				AdminLog.RegistrarLog(oLog);

				//Throw ex

			}
			return intId;
		}
		public static int ActualizarUsuario(InfoUsuario Usuario)
		{
			int intId = 0;


			try {
				string strProcedure = "PA_Actualizar_Usuario ";
				string strLastProcedure = "";
				strLastProcedure = Usuario.IdUsuario + ",'" + Usuario.RegNombre + "','" + Usuario.RegApellido + "','" + Usuario.Clave + "','" + Usuario.Email + "'," + Usuario.FirstVisit + ",'" + Usuario.Anno + Usuario.Mes + Usuario.Dia + "'," + Usuario.Sexo + "," + Usuario.MStatus + "," + Usuario.WorkType + ",'" + Usuario.Ciudad + "','" + Usuario.Estado + "'," + Usuario.IdPais + ",'" + Usuario.MainLanguage + "','" + Usuario.Phone + "','" + Usuario.Picture + "','" + Usuario.OtherInfo + "','" + Usuario.LastLog + "'," + Usuario.PublicarPerfil + "," + Usuario.RecibirNoticias;

				if (_Ambiente == "PRODUCCION" & _Track_error == "True") {
					string strLastProcedureOrignal = strLastProcedure;

					InfoLog oLog = new InfoLog();
					oLog.Descripcion = _Ambiente + " PA_Actualizar_Usuario, Antes de Ejecutar Procedmiento : " + strProcedure;
					oLog.Error = 3;
					oLog.Url = _Ambiente + " Antes de Ejecutar Procedmiento : " + strProcedure + " <p> Envio de Parametros 1: " + strLastProcedureOrignal.Replace("'", "") + " </p>";
					AdminLog.RegistrarLog(oLog);

				}
				//strLastProcedure = Usuario.IdUsuario & ",'" & Usuario.RegNombre & "','" & Usuario.RegApellido & "','" & Usuario.Clave & "','" & Usuario.Email & "'," & Usuario.FirstVisit & ",'" & Usuario.Bday & "'," & Usuario.Sexo & "," & Usuario.MStatus & "," & Usuario.WorkType & ",'" & Usuario.Ciudad & "','" & Usuario.Estado & "'," & Usuario.IdPais & ",'" & Usuario.MainLanguage & "','" & Usuario.Phone & "','" & Usuario.Picture & "','" & Usuario.OtherInfo & "','" & Usuario.LastLog & "'," & Usuario.PublicarPerfil & "," & Usuario.RecibirNoticias

				intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));


			} catch (Exception ex) {
				InfoLog oLog = new InfoLog();
				oLog.Descripcion = _Ambiente + " PA_Actualizar_Usuario, Antes de Ejecutar Procedmiento : " + ex.Message;
				oLog.Error = 3;
				oLog.Url = "Error";
				AdminLog.RegistrarLog(oLog);
				throw ex;

			}
			return intId;

		}

		public static int EliminarUsuario(InfoUsuario Usuario)
		{

			try {
				string strProcedure = "proc_DeleteRegUsers ";
				string strLastProcedure = "";
				strLastProcedure = Usuario.IdUsuario.ToString();
				FuncionesDB.ExecSQL(strProcedure + strLastProcedure);




			} catch (Exception ex) {
				throw ex;

			}
			return 0;
		}

		public static int CambiarEstadoUsuario(int IdUsuario, int Estado)
		{
			int intId = 0;

			try {
				string strProcedure = "PA_Actualizar_Estado_Usuario ";
				string strLastProcedure = "";
				strLastProcedure = "'" + IdUsuario + "','" + Estado + "'";
				intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



			} catch (Exception ex) {
				throw ex;

			}
			return intId;
		}

		public static int ConsultaEstadoUsuario(int idUsuario)
		{
			System.Data.SqlClient.SqlDataReader reader = null;
			string strProcedure = "PA_Consulta_Estado_Usuario ";
			InfoUsuario Resultado = new InfoUsuario();

			try {
				reader = FuncionesDB.GetRecords(strProcedure + idUsuario);

				while (reader.Read()) {
					Resultado.IdUsuario = Convert.ToInt32(reader["id"]);
					Resultado.RegNombre = Convert.ToString(reader["first_name"]);
					Resultado.RegApellido = Convert.ToString(reader["last_name"]);
					Resultado.Email = Convert.ToString(reader["email"]);
					Resultado.EstadoUsuario = Convert.ToInt32(reader["status_user"]);

				}
				reader.Close();



			} catch (Exception ex) {
				throw ex;
			}
			return Resultado.EstadoUsuario;
		}

        public static InfoUsuario TraerUsuarioCompleto(int IdUsuario)
		{
			System.Data.SqlClient.SqlDataReader reader = null;
			SqlConnection mConn = new SqlConnection(oConex.StringConnection);
			InfoUsuario Usuario = new InfoUsuario();
			object oObjeto = new object();
			string strProcedure2 = "PA_Get_User_Completo ";

			try {
				mConn.Open();
				SqlCommand cd = new SqlCommand(strProcedure2, mConn);
				cd.CommandType = CommandType.StoredProcedure;
				////Parametros
				cd.Parameters.AddWithValue("@user_id", IdUsuario);

				reader = cd.ExecuteReader(CommandBehavior.CloseConnection);


				//id()
				//first_name()
				//last_name()
				//password()
				//email()
				//first_visit()
				//bday()
				//sex()
				//m_status()
				//work_type()
				//city()
				//state()
				//country()
				//main_languaje()
				//phone()
				//security_level()
				//picture()
				//otherinfo()
				//last_log()
				//show_info()
				//receive_emails()
				//status_user()
				DateTime dtFechaCumple = default(DateTime);

				while (reader.Read()) {
					Usuario.IdUsuario = Convert.ToInt32(reader["id"]);
					Usuario.RegNombre = Convert.ToString(reader["first_name"]);
					Usuario.RegApellido = Convert.ToString(reader["last_name"]);
					Usuario.Clave = Convert.ToString(reader["password"]);
					Usuario.Email = Convert.ToString(reader["email"]);
					Usuario.FirstVisit = Convert.ToInt32(reader["first_visit"]);
					dtFechaCumple = Convert.ToDateTime(reader["bday"]);
					if (dtFechaCumple.Year == 1900) {
						Usuario.Bday = DateTime.Now;
					} else {
						Usuario.Bday = dtFechaCumple;
					}
					Usuario.Sexo = Convert.ToInt32(reader["sex"]);
					Usuario.MStatus = Convert.ToInt32(reader["m_status"]);
					Usuario.WorkType = Convert.ToInt32(reader["work_type"]);
					Usuario.Ciudad = Convert.ToString(reader["city"]);
					Usuario.Estado = Convert.ToString(reader["state"]);
					Usuario.Pais = Convert.ToString(reader["country"]);
					Usuario.MainLanguage = Convert.ToString(reader["main_language"]);
					if (object.ReferenceEquals(reader["phone"], DBNull.Value)) {
						Usuario.Phone = "";
					} else {
						Usuario.Phone = Convert.ToString(reader["phone"]);
					}
					Usuario.SecurityLevel = Convert.ToInt32(reader["security_level"]);
					Usuario.Picture = Convert.ToString(reader["picture"]);
					Usuario.OtherInfo = Convert.ToString(reader["otherinfo"]);
					Usuario.LastLog = Convert.ToDateTime(reader["last_log"]);
					Usuario.PublicarPerfil = Convert.ToInt32(reader["show_info"]);
					Usuario.RecibirNoticias = Convert.ToInt32(reader["receive_emails"]);
					Usuario.EstadoUsuario = Convert.ToInt32(reader["status_user"]);
					Usuario.Cantidad_Publicaciones = Convert.ToInt32(reader["Cantidad_Publicaciones"]);
				}
				reader.Close();
				cd.Dispose();
				mConn.Close();


			} catch (Exception ex) {
				throw ex;
			}
			return Usuario;
		}

		public static int CambiarPassword(string strEmail, string strPassword)
		{
			int intId = 0;

			try {
				string strProcedure = "PA_Actualizar_Clave_Usuario ";
				string strLastProcedure = "";
				strLastProcedure = "'" + strEmail + "','" + strPassword + "'";
				intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



			} catch (Exception ex) {
				throw ex;

			}
			return intId;
		}

		public static int ExisteUsuarioConMismoEmail(string Email)
		{
			int intId = 0;

			try {
				string strProcedure = "PA_Existe_EMail ";
				string strLastProcedure = "";
				strLastProcedure = "'" + Email + "'";
				intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



			} catch (Exception ex) {
				throw ex;

			}
			return intId;
		}

		public static int Identifica_UsuarioXIp(InfoUsuarioIP UsuarioIP)
		{
			int intId = 0;

			try {
				string strProcedure = "PA_Identifica_UsuarioXIp ";
				string strLastProcedure = "";
				strLastProcedure = UsuarioIP.IdUsuario + ",'" + UsuarioIP.IpAddress + "'";
				intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



			} catch (Exception ex) {
				throw ex;

			}
			return intId;
		}
	}
}