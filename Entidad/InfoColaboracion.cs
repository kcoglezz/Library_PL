using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoColaboracion
    {
        //============================
        // Variables
        //============================
        public int intPageId= 0;
        public int intSectionId= 0;
        public DateTime dtPosted;
        public string strPageTitle =  string.Empty;
        public string strBlurb =  string.Empty;
        public string strBody =  string.Empty;
        public int btIsposted = 0;
        public string strPic =  string.Empty;
        public int intTypeofarticle = 0;
        public int btIsfeatured = 0;
        public int intUserId = 0;
        public string strKeywords =  string.Empty;
        public int intBook = 0;
        public int intChapter = 0;
        public int btRating = 0;

        //============================
        // Constructores
        //============================
        public InfoColaboracion()
        {

        }
    }
}
