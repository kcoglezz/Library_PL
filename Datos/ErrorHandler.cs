using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Text;

namespace Sistema.PL.Datos
{

    public class ErrorHandler
    {

        #region "Functions"

        private DataTable GetVariables(System.Collections.Specialized.NameValueCollection inputVarCollection)
        {
            DataTable objTable = new DataTable();
            objTable.Columns.Add("Name", typeof(string));
            objTable.Columns.Add("Value", typeof(string));

            string strItem = null;
            DataRow objRow = null;
            foreach (string strItem_loopVariable in inputVarCollection)
            {
                strItem = strItem_loopVariable;
                objRow = objTable.NewRow();
                objRow["Name"] = strItem;
                objRow["Value"] = inputVarCollection[strItem];
                objTable.Rows.Add(objRow);
            }

            return objTable;
        }

        private DataTable GetCookieVars()
        {
            DataTable objTable = new DataTable();
            objTable.Columns.Add("Name", typeof(string));
            objTable.Columns.Add("Value", typeof(string));

            string strItem = null;
            DataRow objRow = null;
            foreach (string strItem_loopVariable in HttpContext.Current.Request.Cookies)
            {
                strItem = strItem_loopVariable;
                objRow = objTable.NewRow();
                objRow["Name"] = strItem;
                objRow["Value"] = HttpContext.Current.Request.Cookies[strItem].Value;
                objTable.Rows.Add(objRow);
            }

            return objTable;
        }

        //public string ReturnHtmlErrorMessage(Exception ex)
        //{

        //    StringBuilder strMessage = new StringBuilder("");


        //    try
        //    {
        //        strMessage.Append("URL: " + HttpContext.Current.Request.RawUrl() + "<br>");

        //        strMessage.Append("IP ADDRESS: <a href=http://www.ip2location.com/free.asp?ipaddresses=" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] + " target=new>" + HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] + "</a><br>");

        //        strMessage.Append("Error: " + ex.Message + "<br>");


        //        if ((ex.TargetSite != null))
        //        {
        //            strMessage.Append("Method: " + ex.TargetSite.Name + "<br>");

        //        }

        //        strMessage.Append("Error Date/Time: " + System.DateTime.Now + "<br>");

        //        SimpleDataGrid objErrInfoDG = new SimpleDataGrid();

        //        strMessage.Append("<TABLE BORDER=0 WIDTH=100% CELLPADDING=1 CELLSPACING=0><TR><TD STYLE=\"background-color: black; color: white;font-weight: bold;font-family: Arial;\">Error information</TD></TR></TABLE>");

        //        DataTable objTable = new DataTable();
        //        objTable.Columns.Add("Name", typeof(string));
        //        objTable.Columns.Add("Value", typeof(string));

        //        DataRow objRow = null;

        //        objRow = objTable.NewRow();
        //        objRow["Name"] = "Message";
        //        objRow["Value"] = ex.Message;
        //        objTable.Rows.Add(objRow);

        //        objRow = objTable.NewRow();
        //        objRow["Name"] = "Source";
        //        objRow["Value"] = ex.Source;
        //        objTable.Rows.Add(objRow);

        //        objRow = objTable.NewRow();
        //        objRow["Name"] = "TargetSite";
        //        objRow["Value"] = ex.TargetSite.ToString();
        //        objTable.Rows.Add(objRow);

        //        objRow = objTable.NewRow();
        //        objRow["Name"] = "StackTrace";
        //        objRow["Value"] = ex.StackTrace;
        //        objTable.Rows.Add(objRow);

        //        strMessage.Append(objErrInfoDG.RenderToStringSimple(objTable));


        //        strMessage.Append("<BR><BR><TABLE BORDER=0 WIDTH=100% CELLPADDING=1 CELLSPACING=0><TR><TD COLSPAN=2 STYLE=\"background-color: black; color: white;font-weight: bold;font-family: Arial;\">Querystring Collection</TD></TR></TABLE>");

        //        SimpleDataGrid objQSDG = new SimpleDataGrid();

        //        //objQSDG.DataSource = GetVariables(HttpContext.Current.Request.QueryString)
        //        //objQSDG.DataBind()

        //        strMessage.Append(objQSDG.RenderToStringSimple(GetVariables(HttpContext.Current.Request.QueryString)));

        //        strMessage.Append("<BR><BR><TABLE BORDER=0 WIDTH=100% CELLPADDING=1 CELLSPACING=0><TR><TD COLSPAN=2 STYLE=\"background-color: black; color: white;font-weight: bold;font-family: Arial;\">Form Collection</TD></TR></TABLE>");

        //        SimpleDataGrid objFormDG = new SimpleDataGrid();


        //        //objFormDG.DataSource = GetVariables(HttpContext.Current.Request.Form)
        //        //objFormDG.DataBind()
        //        //strMessage.Append(objFormDG.RenderToString)

        //        strMessage.Append(objFormDG.RenderToStringSimple(GetVariables(HttpContext.Current.Request.Form)));

        //        strMessage.Append("<BR><BR><TABLE BORDER=0 WIDTH=100% CELLPADDING=1 CELLSPACING=0><TR><TD COLSPAN=2 STYLE=\"background-color: black; color: white;font-weight: bold;font-family: Arial;\">Cookies Collection</TD></TR></TABLE>");

        //        SimpleDataGrid objCookiesDG = new SimpleDataGrid();

        //        //objCookiesDG.DataSource = GetCookieVars()
        //        //objCookiesDG.DataBind()
        //        strMessage.Append(objCookiesDG.RenderToStringSimple(GetCookieVars()));


        //        strMessage.Append("<BR><BR><TABLE BORDER=0 WIDTH=100% CELLPADDING=1 CELLSPACING=0><TR><TD COLSPAN=2 STYLE=\"background-color: black; color: white;font-weight: bold;font-family: Arial;\">Server Variables</TD></TR></TABLE>");

        //        SimpleDataGrid objServVarDG = new SimpleDataGrid();

        //        //objServVarDG.DataSource = GetVariables(HttpContext.Current.Request.ServerVariables)
        //        //objServVarDG.DataBind()
        //        strMessage.Append(objServVarDG.RenderToStringSimple(GetVariables(HttpContext.Current.Request.ServerVariables)));

        //        return strMessage.ToString();


        //    }
        //    catch (Exception ex1)
        //    {


        //    }
        //    finally
        //    {
        //        strMessage = null;

        //    }

        //}

        #endregion
    }
}