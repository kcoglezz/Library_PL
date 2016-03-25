using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;


namespace Sistema.PL.Negocio
{
    public class NegEquipo
    {
        public static int CrearEquipo(InfoEquipo oEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.CrearEquipo(oEquipo);
        }

        public static int ModificarEquipo(InfoEquipo oEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.ModificarEquipo(oEquipo);
        }

        public static int EliminarEquipo(InfoEquipo oEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.EliminarEquipo(oEquipo);
        }

        public static List<InfoEquipo> DatosDelEquipo(int Id_Equipo)
        {
            return Sistema.PL.Datos.DatEquipo.DatosDelEquipo(Id_Equipo);
        }



        
        public static int RegistrarEquipoUsuario(InfoEquipoUsuario oEquipoUsuario)
        {
            return Sistema.PL.Datos.DatEquipo.RegistrarEquipoUsuario(oEquipoUsuario);
        }

        public static List<InfoEquipoRecursoCompartido> Existe_Recurso_Compartido(InfoEquipoRecurso oEquipoRecurso)
        {
            return Sistema.PL.Datos.DatEquipo.Existe_Recurso_Compartido(oEquipoRecurso);
        }


        public static int RegistrarEquipoRecurso(InfoEquipoRecurso oEquipoRecurso)
        {
            return Sistema.PL.Datos.DatEquipo.RegistrarEquipoRecurso(oEquipoRecurso);
        }

        public static int RegistrarEquipoRecursoComentario(InfoEquipoRecursoComentario oEquipoRecursoComentario)
        {
            return Sistema.PL.Datos.DatEquipo.RegistrarEquipoRecursoComentario(oEquipoRecursoComentario);
        }

        public static InfoPaginaEquipo ObtieneDatosRecursoEquipo(int PageId, int Id_Equipo)
        {
            return Sistema.PL.Datos.DatEquipo.ObtieneDatosRecursoEquipo(PageId,Id_Equipo);
        }

        public static List<InfoResenaComentarios>  ObtieneResenaComentarios(int PageId, int Id_Equipo, string Tipo)
        {
            return Sistema.PL.Datos.DatEquipo.ObtieneResenaComentarios(PageId,Id_Equipo,Tipo);
        }
        
        public static int RegistrarInvitacion_A_Equipo(InfoInvitacionEquipo oInvitacionEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.RegistrarInvitacion_A_Equipo(oInvitacionEquipo);
        }

        public static int RegistrarInvitacion_Pendiente(InfoInvitacionEquipo oInvitacionEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.RegistrarInvitacion_Pendiente(oInvitacionEquipo);
        }

        public static int Obtiene_IdUsuario_x_Email(string strEmail)
        {
            return Sistema.PL.Datos.DatEquipo.Obtiene_IdUsuario_x_Email(strEmail);
        }



        public static int Aceptar_Invitacion_A_Equipo(InfoInvitacionEquipo oInvitacionEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.Aceptar_Invitacion_A_Equipo(oInvitacionEquipo);
        }

        public static int Rechazar_Invitacion_A_Equipo(InfoInvitacionEquipo oInvitacionEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.Rechazar_Invitacion_A_Equipo(oInvitacionEquipo);
        }

        public static List<InfoInvitacionEquipo> Listar_Invitaciones_Pendientes(int Id_usuario)
        {
            return Sistema.PL.Datos.DatEquipo.Listar_Invitaciones_Pendientes(Id_usuario);
        }

        public static int Actualiza_Invitacion_Pendiente(InfoInvitacionEquipo oInvitacionEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.Actualiza_Invitacion_Pendiente(oInvitacionEquipo);
        }

        public static InfoEquipoUsuario esDuenoEquipo(InfoUsuario oUsuario)
        {
            return Sistema.PL.Datos.DatEquipo.esDuenoEquipo(oUsuario);
        }



        public static List<InfoUsuarioEquipo> Traer_Usuarios_Del_Equipo(int Id_Equipo)
        {
            return Sistema.PL.Datos.DatEquipo.Traer_Usuarios_Del_Equipo(Id_Equipo);
        }


        public static int Es_Administrador_de_algun_Equipo(int IdUsuario)
        {
            return Sistema.PL.Datos.DatEquipo.Es_Administrador_de_algun_Equipo(IdUsuario);
        }

        public static string MostrarNombreEquipo(int IdEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.MostrarNombreEquipo(IdEquipo);
        }
      
        public static int DelegarEquipo(int IdUsuarioActual, int IdUsuarioNuevo, int IdEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.DelegarEquipo(IdUsuarioActual, IdUsuarioNuevo, IdEquipo);
        }

        public static List<InfoTimeLineEquipo> ListaTimeLineEquipo(int Id_Equipo)
        {
            return Sistema.PL.Datos.DatEquipo.ListaTimeLineEquipo(Id_Equipo);
        }

        public static List<InfoTimeLineEquipo> ListaTimeLineTodoslosEquipos(int Id_Usuario)
        {
            return Sistema.PL.Datos.DatEquipo.ListaTimeLineTodoslosEquipos(Id_Usuario);
        }
        public static int Es_Administrador_de_este_Equipo(int Id_Usuario, int Id_Equipo)
        {
            return Sistema.PL.Datos.DatEquipo.Es_Administrador_de_este_Equipo(Id_Usuario, Id_Equipo);
        }
    
        public static List<InfoEquipoUsuario> ObtieneEquiposDelUsuario(int Id_Usuario)
        {
            return Sistema.PL.Datos.DatEquipo.ObtieneEquiposDelUsuario(Id_Usuario);
        }

        public static int Existe_Nombre_Equipo(int Id_Usuario, string strNombre)
        {
            return Sistema.PL.Datos.DatEquipo.Existe_Nombre_Equipo(Id_Usuario, strNombre);
        }

        public static List<InfoEquipo> ObtieneListadoEquiposSinResena(int Id_Usuario, int PageId)
        {
            return Sistema.PL.Datos.DatEquipo.ObtieneListadoEquiposSinResena(Id_Usuario, PageId);
        }

        public static List<InfoLibretaUsuarioEquipo> Lista_Libreta_Usuarios_Del_Equipo(int Id_UsuarioAdmin)
        {
            return Sistema.PL.Datos.DatEquipo.Lista_Libreta_Usuarios_Del_Equipo(Id_UsuarioAdmin);
        }

        

        public static string Elimina_Usuario_del_Equipo(int idUsuarioADM, int IdUsuario, int IdEquipo)
        {
            return Sistema.PL.Datos.DatEquipo.Elimina_Usuario_del_Equipo(idUsuarioADM,IdUsuario,IdEquipo);
        }
    }

   
}
