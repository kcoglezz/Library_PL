using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoAdminEmails
    {
        public string EmailSupportAccount = System.Configuration.ConfigurationSettings.AppSettings["SupportAccount"].ToString();
        public string EmailContactAccount = System.Configuration.ConfigurationSettings.AppSettings["ContactAccount"].ToString();
        public string EmailDeveloperAccount = System.Configuration.ConfigurationSettings.AppSettings["DeveloperAccount"].ToString();

       
    }
}
