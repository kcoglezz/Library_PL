using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
   
    public class InfoEquipo
    {

        //============================
        // Variables
        //============================
        public int ID_EQUIPO = 0;
        public string NOMBRE_EQUIPO = string.Empty;
        public int ID_USUARIO_ADMINISTRADOR = 0;
        public string ESTADO = string.Empty;
        public string FECHA_CREACION = string.Empty;
        public int USUARIO_CREACION = 0;
        public string FECHA_MODIFICACION = string.Empty;
        public int USAURIO_MODIFICACION = 0;
        public string DESCRIPCION_EQUIPO = string.Empty;
       


       


        //============================
        // Constructores
        //============================
        public InfoEquipo()
        {

        }
    }
}
