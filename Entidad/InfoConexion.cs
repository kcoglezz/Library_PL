using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoConexion 
     {
        public string StringConnection = string.Empty;

        public InfoConexion()
        {
            string strAmbiente = System.Configuration.ConfigurationSettings.AppSettings["PL_ENVIRONMENT"].ToString();

            string strServer ;
            string strDatabase;
            string strUsername ;
            string strPassword ;
            string strMaxPoolSize;

            if (strAmbiente == Enums.Ambiente.DESA.ToString() || strAmbiente == Enums.Ambiente.QA.ToString())
            {

                strServer = System.Configuration.ConfigurationSettings.AppSettings["Server"].ToString();
                strDatabase = System.Configuration.ConfigurationSettings.AppSettings["Database"].ToString();
                strUsername = System.Configuration.ConfigurationSettings.AppSettings["Username"].ToString();
                strPassword = System.Configuration.ConfigurationSettings.AppSettings["Password"].ToString();
                strMaxPoolSize = System.Configuration.ConfigurationSettings.AppSettings["MaxPoolSize"].ToString();
                StringConnection = "User ID=" + strUsername + ";Password=" + strPassword + ";Initial Catalog=" + strDatabase + ";Data Source=" + strServer + ";Max Pool Size=" + strMaxPoolSize + ";";
                //Data Source=tcp:s08.winhost.com;Initial Catalog=DB_96029_pl;User ID=DB_96029_pl_user;Password=******;Integrated Security=False;

            }

            if (strAmbiente == Enums.Ambiente.PRODUCCION_OLD.ToString())
                StringConnection = "User ID=webuser;Password=conmofech;Initial Catalog=paralideres;Data Source=sql2k8a.appliedi.net;Max Pool Size=900;";

            if (strAmbiente == Enums.Ambiente.PRODUCCION.ToString())
                StringConnection = "User ID=DB_67575_pl_user;Password=p4r4l1d3r3sSQL;Initial Catalog=DB_67575_pl;Data Source=s10.winhost.com;Max Pool Size=900;";

        }

    }


}
