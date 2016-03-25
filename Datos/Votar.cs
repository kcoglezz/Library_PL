using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{
    public class Votar
    {
        public static int RegistrarVotacion(InfoVotar oVotar)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_InsertRating2 ";
                string strLastProcedure = "";
                strLastProcedure = "'" + oVotar.IpAdress + "'," + oVotar.IdPagina + "," + oVotar.MeGusta + "," + oVotar.NoMeGusta + "," + oVotar.Valor + "," + oVotar.IdUser;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));




            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

        public static int ModificarVotacion(InfoVotar oVotar)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_UpdateRating2 ";
                string strLastProcedure = "";
                strLastProcedure = "'" + oVotar.IpAdress + "'," + oVotar.IdPagina + "," + oVotar.MeGusta + "," + oVotar.NoMeGusta + "," + oVotar.Valor + "," + oVotar.IdUser;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                intId = 1;



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

        public static int EliminarVotacion(InfoVotar oVotar)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_UpdateRating2 ";
                string strLastProcedure = "";
                strLastProcedure = "'" + oVotar.IpAdress + "'," + oVotar.IdPagina + "," + oVotar.MeGusta + "," + oVotar.NoMeGusta + "," + oVotar.Valor + "," + oVotar.IdUser;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

        public static int ExisteVotacionIpPaginaMegusta(InfoVotar oVotar)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_ExisteVotacionIP_Page_MeGusta ";
                string strLastProcedure = "";
                strLastProcedure = "'" + oVotar.IpAdress + "'," + oVotar.IdPagina + "," + oVotar.MeGusta;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

        public static int ExisteVotacionIpPaginaNoMegusta(InfoVotar oVotar)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_ExisteVotacionIP_Page_NOMeGusta ";
                string strLastProcedure = "";
                strLastProcedure = "'" + oVotar.IpAdress + "'," + oVotar.IdPagina + "," + oVotar.NoMeGusta;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

        public static int ExisteVotacion(InfoVotar oVotar)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_ExisteVotacion ";
                string strLastProcedure = "";
                strLastProcedure = oVotar.IdUser + "," + oVotar.IdPagina;
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
