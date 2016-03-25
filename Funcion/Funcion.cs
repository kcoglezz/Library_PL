using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;
namespace ParaLideres
{
    public class Funcion
    {
        public static int GetRandomNumber(int intLowerBound, int intUpperBound)
        {
            // Returns a random number between intLowerBound and intUpperBound
            System.Random objRandom = new System.Random();
            try
            {
                objRandom = new System.Random();
                return objRandom.Next(intLowerBound, intUpperBound);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                objRandom = null;
            }
        }
        public static string FormatHispanicDateTime(System.DateTime dtValue)
        {
            StringBuilder sb = new StringBuilder("");
            try
            {
                sb.Append(dtValue.Day + "/" + EspMonth(dtValue.Month) + "/" + dtValue.Year);
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sb = null;
            }
        }

        public static string EspMonth(int intMonth)
        {
            if (intMonth > 0 & intMonth < 13)
            {
                string[] arrMes = null;
                string strMeses;
                strMeses = "--,enero,febrero,marzo,abril,mayo,junio,julio,agosto,septiembre,octubre,noviembre,diciembre";
                arrMes = strMeses.Split(',');
                return arrMes[intMonth];
            }
            else
            {
                return "Index out of range";
            }
        }
    }
}