using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Web;
using Sistema.PL.Entidad;
using System.Net.Mail;

namespace Sistema.PL.Datos
{


	public class FuncionesDB
	{
		#region "Global Variables"

		private static string _project_path = System.Configuration.ConfigurationManager.AppSettings["ProjectPath"];
		private static string _CredentialMail = System.Configuration.ConfigurationManager.AppSettings["CredentialMail"];
		private static string _CrendetialPass = System.Configuration.ConfigurationManager.AppSettings["CrendetialPass"];
		private static string _HabilitaSSL = System.Configuration.ConfigurationManager.AppSettings["HabilitaSSL"];
		private static int _PuertoMail = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PuertoMail"]);
		private static string _Ambiente = System.Configuration.ConfigurationManager.AppSettings["PL_ENVIRONMENT"];
        private static Boolean _IsDebugMode =  Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["IsDebugMode"]);
        private static int _intCommandSecondsTimeout = 240;


		public static InfoConexion oConex = new InfoConexion();
			#endregion
		public static InfoAdminEmails EmailAdmin = new InfoAdminEmails();

		public static SqlDataReader Obtener_DataReader(string sqlString)
		{

			SqlConnection mConn = new SqlConnection(oConex.StringConnection);
			SqlCommand cmd = null;


			try {
				mConn.Open();

				cmd = new SqlCommand(sqlString, mConn);
                cmd.CommandTimeout = _intCommandSecondsTimeout;

                return cmd.ExecuteReader(CommandBehavior.CloseConnection);	


			} catch (Exception ex) {
				InfoLog oLogex = new InfoLog();
				oLogex.Descripcion = ex.Message;
				oLogex.Error = 10;
				oLogex.Url = _Ambiente + " Error en PL : Obtener_DataReader " + sqlString.ToString();
				AdminLog.RegistrarLog(oLogex);


			} finally {
				cmd = null;
				mConn = null;

			}
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);	
		}

		public static object ExecScalar(string mySQL)
		{

			SqlConnection mConn = new SqlConnection(oConex.StringConnection);
			SqlCommand sqlCmd = null;


			try {
				mConn.Open();

				sqlCmd = new SqlCommand(mySQL, mConn);

				return sqlCmd.ExecuteScalar();

			} catch (Exception ex) {

				InfoLog oLogex = new InfoLog();
				oLogex.Descripcion = ex.Message;
				oLogex.Error = 21;
				oLogex.Url = _Ambiente + " Error en PL : ExecScalar " + mySQL.ToString();
				AdminLog.RegistrarLog(oLogex);


			} finally {
				mConn.Close();
				mConn = null;
				sqlCmd = null;

			}
            return sqlCmd.ExecuteScalar();
		}

		public static int ExecSQL(string mySQL)
		{

			//after executing query returns number of rows affected

			SqlConnection mConn = new SqlConnection(oConex.StringConnection);
			SqlCommand sqlCmd = null;


			try {
				mConn.Open();
				sqlCmd = new SqlCommand(mySQL, mConn);

				return sqlCmd.ExecuteNonQuery();


			} catch (Exception ex) {
				InfoLog oLogex = new InfoLog();
				oLogex.Descripcion = ex.Message;
				oLogex.Error = 22;
				oLogex.Url = _Ambiente + " Error en PL : ExecSQL " + mySQL.ToString();
				AdminLog.RegistrarLog(oLogex);


				return -1;


			} finally {
				mConn.Close();
				mConn = null;
				sqlCmd = null;

			}
		}
        
		public static SqlDataReader GetRecords(string sqlString)
		{

			SqlConnection mConn = new SqlConnection(oConex.StringConnection);
			SqlCommand cmd = null;


			try {
				mConn.Open();

				cmd = new SqlCommand(sqlString, mConn);
                cmd.CommandTimeout = _intCommandSecondsTimeout;
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
				

			} catch (Exception ex) {
				InfoLog oLogex = new InfoLog();
				oLogex.Descripcion = ex.Message;
				oLogex.Error = 23;
				oLogex.Url = _Ambiente + " Error en PL : GetRecords " + sqlString.ToString();
				AdminLog.RegistrarLog(oLogex);

			} finally {
				cmd = null;
				mConn = null;

			}
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);

		}

		public static int CountArticles(string strProcedure)
		{

			int intTotalRecords = 0;


			try {

				if ((HttpContext.Current.Cache[strProcedure] == null)) {
					intTotalRecords = Convert.ToInt32(ExecScalar(strProcedure));

					HttpContext.Current.Cache.Insert(strProcedure, intTotalRecords);


				} else {
					intTotalRecords = Convert.ToInt32(HttpContext.Current.Cache.Get(strProcedure));

				}

				return intTotalRecords;


			} catch (Exception ex) {
				throw ex;

			}

		}
        
		public static bool EnviarCorreo(InfoEnvioMail DatosMail)
		{
			bool functionReturnValue = false;


			MailMessage Mail = new MailMessage();
			Mail.From = new System.Net.Mail.MailAddress(DatosMail.De.ToString(), DatosMail.DesplieguedelNombre.ToString());
			Mail.To.Add(DatosMail.Para.ToString());
			if (!string.IsNullOrEmpty(DatosMail.Cc.ToString())) {
				Mail.CC.Add(DatosMail.Cc.ToString());
			}
			if (!string.IsNullOrEmpty(DatosMail.Cco.ToString())) {
				Mail.Bcc.Add(DatosMail.Cco.ToString());
			}
			Mail.Subject = DatosMail.Asunto.ToString();
			Mail.Body = DatosMail.Contenido.ToString();
			Mail.IsBodyHtml = DatosMail.EsHtml;

			Mail.Priority = MailPriority.Normal;

			SmtpClient cliente = new SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServer"]);
			cliente.Credentials = new System.Net.NetworkCredential(_CredentialMail, _CrendetialPass);
			//cliente.EnableSsl = _HabilitaSSL

			if (Convert.ToInt16(_PuertoMail) > 0) {
				cliente.Port = Convert.ToInt16(_PuertoMail.ToString());
			}


			try {
				cliente.Send(Mail);
			} catch (Exception ex) {
				throw ex;
				//functionReturnValue = false;
			}
			functionReturnValue = true;
			return functionReturnValue;

		}






//public static void Mostrar_Error(Exception excError, string strMethod)
        //{
        //    System.Text.StringBuilder sb = new System.Text.StringBuilder("");

        //    ErrorHandler objErr = default(ErrorHandler);


        //    try {
        //        objErr = new ErrorHandler();

        //        sb.Append("<br>" + strMethod);


        //        try {
        //            sb.Append("<br>" + objErr.ReturnHtmlErrorMessage(excError));


        //        } catch (Exception ex) {
        //        }

                    
        //        if (_IsDebugMode) {
        //            HttpContext.Current.Response.Write(sb.ToString());

        //        } else {
        //            InfoLog oLogex = new InfoLog();
        //            oLogex.Descripcion = excError.Message;
        //            oLogex.Error = 24;
        //            oLogex.Url = _Ambiente + " Error en PL : Mostrar_Error " + objErr.ReturnHtmlErrorMessage(excError).ToString;
        //            AdminLog.RegistrarLog(oLogex);
        //        }


        //    } catch (Exception ex) {

        //    } finally {
        //        sb = null;

        //        objErr = null;

        //    }

        //}
        //public static bool SendMail(string sender, string recipient, string subject, string message, string strFiles)
        //{

        //    System.Text.StringBuilder sb = new System.Text.StringBuilder("");
        //    System.Net.Mail.SmtpClient objClient = null;
        //    System.Net.Mail.MailMessage objMessage = new System.Net.Mail.MailMessage();
        //    System.Net.Mail.MailAddress objAddressFrom = null;
        //    System.Net.Mail.MailAddress objAddressTo = null;

        //    string[] arrFiles = null;

        //    int intIndex = 0;

        //    bool blResults = false;

        //    string strUrl = "";



        //    try {
        //        objClient = new System.Net.Mail.SmtpClient(System.Configuration.ConfigurationManager.AppSettings["MailServer"]);

        //        strUrl = "http://" + HttpContext.Current.Request.ServerVariables["HTTP_HOST"];

        //        HttpContext.Current.Trace.Write("BASE URL: " + strUrl);

        //        message = message.Replace("src=/", "src=" + strUrl + "/");
        //        message = message.Replace("src=\"/", "src=\"" + strUrl + "/");
        //        message = message.Replace("src='/", "src='" + strUrl + "/");

        //        message = message.Replace("href=/", "href=" + strUrl + "/");
        //        message = message.Replace("href=\"/", "href=\"" + strUrl + "/");
        //        message = message.Replace("href='/", "href='" + strUrl + "/");

        //        sb.Append("<html><head><title>" + subject + "</title>" + Constants.vbLf);

        //        sb.Append("<script language=\"javascript\" src=\"" + strUrl + _project_path + "ajax.js\" type=\"text/javascript\"></script>" + Constants.vbLf);

        //        sb.Append("<link rel=\"stylesheet\" href=\"" + strUrl + _project_path + "styles.css\" type=\"text/css\">" + Constants.vbLf);
        //        sb.Append("<link rel=\"stylesheet\" href=\"" + strUrl + _project_path + "editor.css\" type=\"text/css\">" + Constants.vbLf);

        //        sb.Append("</head>" + Strings.Chr(13));

        //        sb.Append("<body topmargin=\"0\" leftmargin=\"0\">" + Strings.Chr(13));

        //        sb.Append("<p align=\"center\"><a href=" + strUrl + _project_path + "home.aspx><img src=\"" + strUrl + _project_path + "assets/imgs/pen_06.png\" width=\"530\" height=\"67\" border=0></a></p>");

        //        sb.Append("<p align=\"left\">");

        //        sb.Append(Strings.Replace(message, Strings.Chr(13), "<br>"));

        //        sb.Append("</p>");

        //        sb.Append("</body></html>");



        //        //objClient.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials

        //        objAddressFrom = new System.Net.Mail.MailAddress(sender);
        //        objAddressTo = new System.Net.Mail.MailAddress(recipient);

        //        objMessage.Priority = System.Net.Mail.MailPriority.Normal;
        //        objMessage.From = objAddressFrom;
        //        objMessage.Subject = subject;
        //        objMessage.Body = sb.ToString();
        //        objMessage.IsBodyHtml = true;


        //        if (System.Configuration.ConfigurationManager.AppSettings("IsDebugMode")) {
        //            objMessage.To.Add(System.Configuration.ConfigurationManager.AppSettings("SupportAccount"));


        //        } else {
        //            objMessage.To.Add(objAddressTo);

        //        }


        //        if (!string.IsNullOrEmpty(strFiles)) {
        //            arrFiles = Strings.Split(strFiles, ",");


        //            for (intIndex = 0; intIndex <= Information.UBound(arrFiles); intIndex++) {

        //                if (System.IO.File.Exists(arrFiles[intIndex])) {
        //                    objMessage.Attachments.Add(new System.Net.Mail.Attachment(arrFiles[intIndex]));

        //                }

        //            }

        //        }


        //        try {
        //            HttpContext.Current.Trace.Write("FROM: " + sender);
        //            HttpContext.Current.Trace.Write("TO: " + recipient);
        //            HttpContext.Current.Trace.Write("SUBJECT: " + subject);
        //            HttpContext.Current.Trace.Write("MESSAGE: " + sb.ToString());
        //            HttpContext.Current.Trace.Write("HOST: " + objClient.Host);

        //            //objClient.UseDefaultCredentials = False
        //            objClient.Credentials = new System.Net.NetworkCredential("kcoglezz@gmail.com", "chiquitita1");
        //            //objClient.Port = 587
        //            objClient.Host = "smtp.gmail.com";
        //            objClient.EnableSsl = true;
        //            //objClient.DeliveryMethod = Net.Mail.SmtpDeliveryMethod.Network

        //            objClient.Send(objMessage);

        //            blResults = true;

        //            HttpContext.Current.Trace.Write("E-mail was sent successfully!");


        //        } catch (Exception ex) {
        //            HttpContext.Current.Trace.Warn(ex.ToString());

        //        }

        //        return blResults;


        //    } catch (Exception ex) {
        //        HttpContext.Current.Trace.Warn(ex.ToString());

        //    //ShowError(ex)


        //    } finally {
        //        objMessage = null;

        //        objClient = null;

        //        objAddressFrom = null;

        //        objAddressTo = null;

        //    }

        //}



	}
}