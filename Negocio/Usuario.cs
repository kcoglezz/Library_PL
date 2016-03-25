using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class Usuario
    {
        public static InfoUsuario TraerUsuario(string strEmail, string strPassword)
        {
            return Sistema.PL.Datos.Usuario.TraerUsuario(strEmail, strPassword);
        }
        public static InfoUsuario Trae_Datos_Basicos_del_Usuario_id(int intUserId)
        {
            return Sistema.PL.Datos.Usuario.Trae_Datos_Basicos_del_Usuario_id(intUserId);
        }
        public static InfoUsuario TraerUsuario_id(int intUserId)
        {
            return Sistema.PL.Datos.Usuario.TraerUsuario_id(intUserId);
        }
        public static int RegistrarUsuario(InfoUsuario Usuario)
        {
            return Sistema.PL.Datos.Usuario.RegistrarUsuario(Usuario);
        }
        public static int ActualizarUsuario(InfoUsuario Usuario)
        {
            return Sistema.PL.Datos.Usuario.ActualizarUsuario(Usuario);
        }

        public static int CambiarEstadoUsuario(int IdUsuario,int Estado)
        {
            return Sistema.PL.Datos.Usuario.CambiarEstadoUsuario(IdUsuario, Estado);   
        }

        public static int ConsultarEstadoUsuario(int IdUsuario)
        {
            return Sistema.PL.Datos.Usuario.ConsultaEstadoUsuario(IdUsuario);
        }

        public static InfoUsuario TraerUsuarioCompleto(int IdUsuario)
        {
            return Sistema.PL.Datos.Usuario.TraerUsuarioCompleto(IdUsuario);
        }
        public static int CambiarPassword(string strEmail, string strPassword)
        {
            return Sistema.PL.Datos.Usuario.CambiarPassword(strEmail, strPassword);
        }
        public static int ExisteUsuarioConMismoEmail(string Email)
        {
            return Sistema.PL.Datos.Usuario.ExisteUsuarioConMismoEmail(Email);
        }

        public static int Identifica_UsuarioXIp(InfoUsuarioIP UsuarioIP)
        {
            return Sistema.PL.Datos.Usuario.Identifica_UsuarioXIp(UsuarioIP);
        }
    }
}
