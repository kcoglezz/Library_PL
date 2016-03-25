using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoEquipoUsuario
    {

        //============================
        // Variables
        //============================
        public int ID_EQUIPO_USUARIO = 0;
        public int ID_USUARIO = 0;
        public int ID_EQUIPO = 0;
        public string ES_ADMINISTRADOR = string.Empty;
        public string FECHA_CREACION = string.Empty;
        public int USUARIO_CREACION = 0;
        public string FECHA_MODIFICACION = string.Empty;
        public int USUARIO_MODIFICACION = 0;
        public string NOMBRE_EQUIPO = string.Empty;
        public int CANTIDAD_USUARIOS = 0;
        public int TIPO = 0; //1 ES ADMIN Y 0 ES PARTICIPANTE


        //============================
        // Constructores
        //============================
        public InfoEquipoUsuario()
        {

        }
    }
}
