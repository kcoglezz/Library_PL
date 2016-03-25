using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoEquipoRecursoComentario
    {
        //============================
        // Variables
        //============================
        public int ID_EQUIPO_RECURSO_COMENTARIO = 0;
        public int ID_EQUIPO = 0;
        public int ID_EQUIPO_RECURSO = 0;
        public int PAGE_ID = 0;
        public string COMENTARIO = string.Empty;
        public int ID_USUARIO_QUE_COMENTO = 0;
        public string FECHA_APORTE = string.Empty;
        public string TIPO = string.Empty;
        
        

        //============================
        // Constructores
        //============================
        public InfoEquipoRecursoComentario()
        {

        }


    }
}
