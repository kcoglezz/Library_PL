using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
 

    public class InfoInvitacionEquipo
    {

        //============================
        // Variables
        //============================
        public int ID_INVITACION_A_EQUIPO = 0;
        public int ID_USUARIO_INVITADOR = 0;
        public int ID_EQUIPO = 0;
        public string EMAIL_USUARIO_INVITADO = string.Empty;
        public int ID_USUARIO_INVITADO = 0;
        public string INV_ENVIADA = string.Empty;
        public string FECHA_INV_ENVIADA = string.Empty;
        public string INV_ACEPTADA = string.Empty;
        public string FECHA_INV_ACEPTADA = string.Empty;
        public string INV_RECHAZADA = string.Empty;
        public string FECHA_INV_RECHAZADA = string.Empty;

        public string FECHA_CREACION = string.Empty;
        public int USUARIO_CREACION = 0;
        public string FECHA_MODIFICACION = string.Empty;
        public int USAURIO_MODIFICACION = 0;

        public string ENVIADO_A_ADMINISTRADOR = string.Empty;
        public string ESTADO = string.Empty;

        public string NOMBRE_EQUIPO = string.Empty;



        //============================
        // Constructores
        //============================
        public InfoInvitacionEquipo()
        {

        }
    }

}
