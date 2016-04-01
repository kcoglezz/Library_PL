using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoEquipoRecursoProposito
    {
        //============================
        // Variables
        //============================
        public int ID_EQUIPO_RECURSO = 0;
        public int ID_EQUIPO = 0;
        public int PAGE_ID = 0;
        public int ID_USUARIO_QUE_COMPARTIO = 0;
        public string NOMBRE_EQUIPO = string.Empty;
        public string NOMBRE_RECURSO = string.Empty;
        public string RESENA_COMENTARIO = string.Empty;
        public string FECHA_APORTE = string.Empty;
        public string ES_ADMINISTRADOR = string.Empty;
        public int COMENTARIO_INI_POR =0;
        public string NOMBRE_INICIA_POR = string.Empty;
        public int CANTIDAD_COMENTARIO =0;



        //============================
        // Constructores
        //============================
        public InfoEquipoRecursoProposito()
        {

        }

    }



}
