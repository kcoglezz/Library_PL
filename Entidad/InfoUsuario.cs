using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoUsuario
    {
        //============================
        // Variables
        //============================
        public int IdUsuario = 0;
        public string Nombre = string.Empty;
        public string RegNombre = string.Empty;
        public string RegApellido = string.Empty;
        public string Email = string.Empty;
        public string VEmail = string.Empty;
        public int IdPais = 0;
        public string Pais = string.Empty;
        public string Estado = string.Empty;
        public string Ciudad = string.Empty;
        public int FirstVisit = 0;
        public DateTime Bday;
        public int Sexo = 0;
        public int MStatus = 0; //estadocivil
        public int WorkType = 0;
        public string MainLanguage = string.Empty;
        public string Phone = string.Empty;
        public int SecurityLevel = 0;
        public string Picture = string.Empty;
        public string OtherInfo = string.Empty;
        public DateTime LastLog;
        public int PublicarPerfil = 0; //aqui puede ser 1=SI, 2=NO
        public int RecibirNoticias = 0; //aqui puede ser 1=SI, 2=NO
        public string Clave = string.Empty;
        public int EstadoUsuario = 0; //0=Inactivo; 1=Activo; 2=dado de Baja; 3=Eliminado; 
        public Boolean Encontrado = false;
        public int Cantidad_Publicaciones = 0;
        public string Dia = string.Empty;
        public string Mes = string.Empty;
        public string Anno = string.Empty;
        public string FechaNac = string.Empty;

        public List<InfoEquipoUsuario> EQUIPOS;
        

        //public Boolean Es_Administrador_Equipo = false;
        //public int ID_Equipo = 0;
        //public int ID_Equipo_Usuario = 0;
        public Boolean Esta_En_Equipo = false;
        //public int A_Cuantos_Equipos_Pertenece = 0;
        //public int Cantidad_Usuarios = 0;
        //public string Nombre_Equipo = string.Empty;
       
       



        //============================
        // Constructores
        //============================
        public InfoUsuario()
        {

        }
    }
}
