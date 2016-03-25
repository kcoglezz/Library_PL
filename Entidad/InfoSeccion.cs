using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoSeccion
    {
        public int section_id = 0;
        public string section_name = string.Empty;
        public int section_parent = 0;
        public int post_in_menu = 0;
        public string blurb = string.Empty;
        public string pagetext = string.Empty;
        public int user_id = 0;
        public DateTime last_modified;
        public int mod_by = 0;
        public int show_on_droplist = 0;
        public int article_count = 0;
        public Boolean TieneSubSeccion = false;
        public List<InfoSubSeccion> SubSeccion = null; 
        public string Descripcion_niveles = string.Empty;
        public int id_section_origen = 0;
        public string section_name_origen = string.Empty;




        //============================
        // Constructores
        //============================
        public InfoSeccion()
        {

        }
    }
}
