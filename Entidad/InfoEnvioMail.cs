using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoEnvioMail
    {
        //============================
        // Variables
        //============================
        public string De = string.Empty;
        public string Para = string.Empty;
        public string Cc = string.Empty;
        public string Cco = string.Empty;
        public string Asunto = string.Empty;
        public string Contenido = string.Empty;
        public string DesplieguedelNombre = string.Empty;
        public Boolean EsHtml = true;
        

  

        //============================
        // Constructores
        //============================
        public InfoEnvioMail()
        {

        }
    }
}
