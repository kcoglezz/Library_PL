using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Datos;
using Sistema.PL.Entidad;


namespace Sistema.PL.Datos
{
    public class DatEquipo
    {
        public static int CrearEquipo(InfoEquipo oEquipo)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_InsertaEquipo ";
                string strLastProcedure = "";
                strLastProcedure = "'" + oEquipo.NOMBRE_EQUIPO.ToString() + "'," + oEquipo.ID_USUARIO_ADMINISTRADOR + ",'" + oEquipo.ESTADO + "'," + oEquipo.USUARIO_CREACION + ",'" + oEquipo.DESCRIPCION_EQUIPO + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ModificarEquipo(InfoEquipo oEquipo)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_Modifica_Equipo ";
                string strLastProcedure = "";
                strLastProcedure = oEquipo.ID_EQUIPO + "," + oEquipo.ID_USUARIO_ADMINISTRADOR + ",'" + oEquipo.NOMBRE_EQUIPO + "','" + oEquipo.DESCRIPCION_EQUIPO + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

        public static int EliminarEquipo(InfoEquipo oEquipo)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_Eliminar_Equipo ";
                string strLastProcedure = "";
                strLastProcedure = oEquipo.ID_EQUIPO + "," + oEquipo.ID_USUARIO_ADMINISTRADOR;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }



        public static int RegistrarEquipoUsuario(InfoEquipoUsuario oEquipoUsuario)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_InsertaEquipoUsuario ";
                string strLastProcedure = "";
                strLastProcedure = oEquipoUsuario.ID_USUARIO + "," + oEquipoUsuario.ID_EQUIPO + ",'" + oEquipoUsuario.ES_ADMINISTRADOR + "'," + oEquipoUsuario.USUARIO_CREACION;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<InfoEquipoRecursoCompartido> Existe_Recurso_Compartido(InfoEquipoRecurso oEquipoRecurso)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Existe_Proposito_Compartido ";
            List<InfoEquipoRecursoCompartido> oListado = new List<InfoEquipoRecursoCompartido>();
            try
            {
                reader = FuncionesDB.GetRecords(strProcedure + oEquipoRecurso.ID_EQUIPO + ',' + oEquipoRecurso.PAGE_ID);
               
                while (reader.Read())
                {
                    InfoEquipoRecursoCompartido Resultado = new InfoEquipoRecursoCompartido();
                    Resultado.ID_EQUIPO_RECURSO = Convert.ToInt32(reader["ID_EQUIPO_RECURSO"]);
                    Resultado.EXISTE_RECURSO_COMPARTIDO = Convert.ToInt32(reader["EXISTE_RECURSO_COMPARTIDO"]);
                    oListado.Add(Resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oListado;
        }

        public static int RegistrarEquipoRecurso(InfoEquipoRecurso oEquipoRecurso)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_InsertaEquipoRecurso ";
                string strLastProcedure = "";
                strLastProcedure = oEquipoRecurso.ID_EQUIPO + "," + oEquipoRecurso.PAGE_ID + "," + oEquipoRecurso.ID_USUARIO_QUE_COMPARTIO + ",'" + oEquipoRecurso.RESENA_RECURSO.ToString() + "'" + ",'" + oEquipoRecurso.TIPO.ToString() + "'," + oEquipoRecurso.ESTADO_CONVERSACION;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int RegistrarEquipoRecursoComentario(InfoEquipoRecursoComentario oEquipoRecursoComentario)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_InsertaEquipoRecursoComenratio ";
                string strLastProcedure = "";
                strLastProcedure = oEquipoRecursoComentario.ID_EQUIPO + "," + oEquipoRecursoComentario.ID_USUARIO_QUE_COMENTO + ",'" + oEquipoRecursoComentario.COMENTARIO.ToString() + "'," + oEquipoRecursoComentario.ID_EQUIPO_RECURSO + "," + oEquipoRecursoComentario.PAGE_ID + ",'"+ oEquipoRecursoComentario.TIPO + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static InfoPaginaEquipo ObtieneDatosRecursoEquipo(int PageId, int Id_Equipo)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Obtiene_Datos_Recurso ";
            InfoPaginaEquipo oPaginaEquipo = new InfoPaginaEquipo();
            try
            {
                reader = FuncionesDB.GetRecords(strProcedure + PageId + ',' + Id_Equipo);

                while (reader.Read())
                {
                    oPaginaEquipo.EXISTE_RESENA = Convert.ToInt32(reader["ExisteResena"]);
                    oPaginaEquipo.EXISTE_COMENTARIO = Convert.ToInt32(reader["ExisteComentario"]);
                    oPaginaEquipo.ID_EQUIPO = Id_Equipo;
                    oPaginaEquipo.PAGE_ID = PageId;
                }
                reader.Close();
                return oPaginaEquipo;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<InfoResenaComentarios> ObtieneResenaComentarios(int PageId, int Id_Equipo, string Tipo)
        {
            System.Data.SqlClient.SqlDataReader reader = null;

            string strProcedure = "PA_Obtiene_ResenasComentarios " + PageId + ',' + Id_Equipo + ",'" + Tipo + "'";
            List<InfoResenaComentarios> ListadoResenaComentario = new List<InfoResenaComentarios>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoResenaComentarios resultado = new InfoResenaComentarios();
                    resultado.ID_EQUIPO_RECURSO = Convert.ToInt32(reader["id_equipo_recurso"]);
                    resultado.RESENA_COMENTARIO = Convert.ToString(reader["Resena_Comentario"]);
                    resultado.USUARIO = Convert.ToString(reader["Usuario"]);
                    resultado.FOTOAUTOR = Convert.ToString(reader["picture"]);
                    resultado.FECHA_APORTE = Convert.ToString(reader["fecha_de_aporte"]);
                    resultado.Tipo = Convert.ToString(reader["Tipo"]);
                    ListadoResenaComentario.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListadoResenaComentario;


        }

        public static int RegistrarInvitacion_A_Equipo(InfoInvitacionEquipo oInvitacionEquipo)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_InsertaInvitacion_a_Grupo ";
                string strLastProcedure = "";
                strLastProcedure = oInvitacionEquipo.ID_USUARIO_INVITADOR + "," + oInvitacionEquipo.ID_EQUIPO + ",'" + oInvitacionEquipo.EMAIL_USUARIO_INVITADO + "','" + oInvitacionEquipo.INV_ENVIADA + "'," + oInvitacionEquipo.ID_USUARIO_INVITADOR;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int RegistrarInvitacion_Pendiente(InfoInvitacionEquipo oInvitacionEquipo)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_InsertaInvitacion_Pendiente ";
                string strLastProcedure = "";
                strLastProcedure = oInvitacionEquipo.ID_USUARIO_INVITADOR + "," + oInvitacionEquipo.ID_EQUIPO + ",'" + oInvitacionEquipo.EMAIL_USUARIO_INVITADO + "','" + oInvitacionEquipo.INV_ENVIADA + "'," + oInvitacionEquipo.ID_USUARIO_INVITADOR + ",'" + oInvitacionEquipo.ENVIADO_A_ADMINISTRADOR + "','" + oInvitacionEquipo.ESTADO + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int Obtiene_IdUsuario_x_Email(string strEmail)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_Obtiene_IdUsuario_x_Email ";
                string strLastProcedure = "";
                strLastProcedure = "'" + strEmail + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static int Aceptar_Invitacion_A_Equipo(InfoInvitacionEquipo oInvitacionEquipo)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_Update_AceptaInvitacion ";
                string strLastProcedure = "";
                strLastProcedure = oInvitacionEquipo.ID_INVITACION_A_EQUIPO + "," + oInvitacionEquipo.ID_USUARIO_INVITADOR + ",'" + oInvitacionEquipo.EMAIL_USUARIO_INVITADO + "','" + oInvitacionEquipo.INV_ACEPTADA + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        


        public static int Rechazar_Invitacion_A_Equipo(InfoInvitacionEquipo oInvitacionEquipo)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_Update_RechazaInvitacion ";
                string strLastProcedure = "";
                strLastProcedure = oInvitacionEquipo.ID_INVITACION_A_EQUIPO + "," + oInvitacionEquipo.ID_USUARIO_INVITADOR + ",'" + oInvitacionEquipo.EMAIL_USUARIO_INVITADO + "','" + oInvitacionEquipo.INV_RECHAZADA + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<InfoInvitacionEquipo> Listar_Invitaciones_Pendientes(int Id_usuario)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Lista_Invitaciones_Pendientes ";
            List<InfoInvitacionEquipo> oListado = new List<InfoInvitacionEquipo>();
            try
            {
                reader = FuncionesDB.GetRecords(strProcedure + Id_usuario);

                while (reader.Read())
                {
                    InfoInvitacionEquipo Resultado = new InfoInvitacionEquipo();
                    Resultado.ID_INVITACION_A_EQUIPO = Convert.ToInt32(reader["id_invitacion_a_equipo"]);
                    Resultado.ID_EQUIPO = Convert.ToInt32(reader["id_equipo"]);
                    Resultado.NOMBRE_EQUIPO = Convert.ToString(reader["nombre_equipo"]);
                    Resultado.FECHA_INV_ENVIADA = Convert.ToString(reader["fecha_inv_enviada"]);
                    oListado.Add(Resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return oListado;
        }


        public static int Actualiza_Invitacion_Pendiente(InfoInvitacionEquipo oInvitacionEquipo)
        {
            try
            {
                int intId = 0;
                string strProcedure = "PA_Update_Invitacion_Equipo ";
                string strLastProcedure = "";
                strLastProcedure = oInvitacionEquipo.ID_INVITACION_A_EQUIPO + "," + oInvitacionEquipo.ID_USUARIO_INVITADO + ",'" + oInvitacionEquipo.INV_ACEPTADA + "','" + oInvitacionEquipo.INV_RECHAZADA + "'";
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));
                return intId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static InfoEquipoUsuario esDuenoEquipo(InfoUsuario oUsuario)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Consulta_es_dueno_de_Equipo ";
            InfoEquipoUsuario oEquipoUsuario = new InfoEquipoUsuario();
            try
            {
                //InfoAutor Autor = new InfoAutor();
                //-- reader = Datos.FuncionesDB.Obtener_DataReader(strProcedure)
                reader = FuncionesDB.GetRecords(strProcedure + oUsuario.IdUsuario);

                while (reader.Read())
                {
                    oEquipoUsuario.ES_ADMINISTRADOR = Convert.ToString(reader["es_administrador"]);
                    oEquipoUsuario.NOMBRE_EQUIPO = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                    oEquipoUsuario.ID_USUARIO = oUsuario.IdUsuario;
                    oEquipoUsuario.ID_EQUIPO_USUARIO = Convert.ToInt32(reader["ID_EQUIPO_USUARIO"]);
                    oEquipoUsuario.ID_EQUIPO = Convert.ToInt32(reader["id_equipo"]);
                }
                reader.Close();
                return oEquipoUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static List<InfoUsuarioEquipo> Traer_Usuarios_Del_Equipo(int Id_Equipo)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Listar_Usuarios_del_Equipo " + Id_Equipo;
            List<InfoUsuarioEquipo> Listado = new List<InfoUsuarioEquipo>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoUsuarioEquipo resultado = new InfoUsuarioEquipo();
                    resultado.IdEquipo = Id_Equipo;
                    resultado.IdUsuario = Convert.ToInt32(reader["ID"]);
                    resultado.Nombre = Convert.ToString(reader["Nombre"]);
                    //resultado.FOTOAUTOR = 
                    if (Convert.ToString(reader["Es_administrador"]) == "S")
                    {
                        resultado.Es_Administrador = true;
                        resultado.Es_Adm = "S";
                    }
                    else
                    {
                        resultado.Es_Administrador = false;
                        resultado.Es_Adm = "N";
                    }

                    Listado.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;
        }

        public static int Es_Administrador_de_algun_Equipo(int Id_Usuario)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Consulta_Es_ADM_de_un_Equipo ";
            int es_administrador = 0;
            try
            {
                //InfoAutor Autor = new InfoAutor();
                //-- reader = Datos.FuncionesDB.Obtener_DataReader(strProcedure)
                reader = FuncionesDB.GetRecords(strProcedure + Id_Usuario);

                while (reader.Read())
                {
                    es_administrador = Convert.ToInt32(reader["Es_Administrador"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return es_administrador;
        }

        public static string MostrarNombreEquipo(int Id_Equipo)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Mostrar_NombreEquipo ";
            string resultado = "";
            try
            {
                reader = FuncionesDB.GetRecords(strProcedure + Id_Equipo);

                while (reader.Read())
                {
                    resultado = Convert.ToString(reader["nombre_equipo"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }






        public static int DelegarEquipo(int IdUsuarioActual, int IdUsuarioNuevo, int IdEquipo)
        {
            int intId = 0;

            try
            {
                string strProcedure = "PA_Delega_UsuarioEquipo ";
                string strLastProcedure = "";
                strLastProcedure = IdUsuarioActual + "," + IdUsuarioNuevo + "," + IdEquipo;
                try
                {
                    FuncionesDB.ExecScalar(strProcedure + strLastProcedure);
                    intId = IdUsuarioNuevo;
                }
                catch (Exception ex)
                {
                    intId = 0;
                    throw ex;
                }




            }
            catch (Exception ex)
            {
                throw ex;

            }
            return intId;
        }

        public static List<InfoTimeLineEquipo> ListaTimeLineEquipo(int Id_Equipo)
        {
            System.Data.SqlClient.SqlDataReader reader = null;

            string strProcedure = "PA_ListaTimeLineEquipo " + Id_Equipo;
            List<InfoTimeLineEquipo> Listado = new List<InfoTimeLineEquipo>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoTimeLineEquipo resultado = new InfoTimeLineEquipo();
                    resultado.PAGE_ID = Convert.ToInt32(reader["page_id"]);
                    resultado.ARTICULO = Convert.ToString(reader["page_title"]);
                    resultado.CANTIDAD_COMENTARIOS = Convert.ToInt32(reader["cantidad_comentarios"]);
                    resultado.FECHA_ULTIMO_POST = Convert.ToString(reader["Fecha_ultimo_aporte"]);
                    Listado.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;


        }

        public static List<InfoTimeLineEquipo> ListaTimeLineTodoslosEquipos(int Id_Usuario)
        {
            System.Data.SqlClient.SqlDataReader reader = null;

            string strProcedure = "PA_ListaTimeLineEquipos " + Id_Usuario;
            List<InfoTimeLineEquipo> Listado = new List<InfoTimeLineEquipo>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoTimeLineEquipo resultado = new InfoTimeLineEquipo();
                    resultado.ID_EQUIPO = Convert.ToInt32(reader["ID_EQUIPO"]);
                    resultado.NOMBRE_EQUIPO = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                    resultado.PAGE_ID = Convert.ToInt32(reader["page_id"]);
                    resultado.ARTICULO = Convert.ToString(reader["page_title"]);
                    resultado.CANTIDAD_COMENTARIOS = Convert.ToInt32(reader["cantidad_comentarios"]);
                    resultado.FECHA_ULTIMO_POST = Convert.ToString(reader["Fecha_ultimo_aporte"]);
                    resultado.ID_EQUIPO_RECURSO = Convert.ToInt32(reader["ID_EQUIPO_RECURSO"]);
                    Listado.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;


        }


        public static int Es_Administrador_de_este_Equipo(int Id_Usuario, int Id_Equipo)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Es_Administrador_del_Equipo ";
            int es_administrador = 0;
            try
            {
                //InfoAutor Autor = new InfoAutor();
                //-- reader = Datos.FuncionesDB.Obtener_DataReader(strProcedure)
                reader = FuncionesDB.GetRecords(strProcedure + Id_Usuario + ',' + Id_Equipo);

                while (reader.Read())
                {
                    es_administrador = Convert.ToInt32(reader["ES_ADMINISTRADOR"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return es_administrador;
        }

        public static List<InfoEquipoUsuario> ObtieneEquiposDelUsuario(int Id_Usuario)
        {
            System.Data.SqlClient.SqlDataReader reader = null;

            string strProcedure = "PA_Ver_Info_del_Equipo " + Id_Usuario;
            List<InfoEquipoUsuario> Listado = new List<InfoEquipoUsuario>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoEquipoUsuario resultado = new InfoEquipoUsuario();
                    resultado.ID_EQUIPO = Convert.ToInt32(reader["ID_EQUIPO"]);
                    resultado.ID_EQUIPO_USUARIO = Convert.ToInt32(reader["ID_EQUIPO_USUARIO"]);
                    resultado.ID_USUARIO = Convert.ToInt32(reader["ID_USUARIO"]);
                    resultado.TIPO = Convert.ToInt32(reader["TIPO"]);
                    resultado.ES_ADMINISTRADOR = Convert.ToString(reader["ES_ADMINISTRADOR"]);
                    resultado.CANTIDAD_USUARIOS = Convert.ToInt32(reader["CANTIDAD_USUARIOS"]);
                    resultado.NOMBRE_EQUIPO = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                    resultado.FECHA_CREACION = Convert.ToString(reader["FECHA_CREACION"]);
                    Listado.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;
        }




        public static int Existe_Nombre_Equipo(int Id_Usuario, string strNombre)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Existe_El_NombreEquipo ";
            int Existe = 0;
            try
            {
                reader = FuncionesDB.GetRecords(strProcedure + Id_Usuario + ",'" + strNombre + "'");

                while (reader.Read())
                {
                    Existe = Convert.ToInt32(reader["EXISTE_EQUIPO"]);

                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Existe;
        }

        public static List<InfoEquipo> ObtieneListadoEquiposSinResena(int Id_Usuario, int PageId)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_ListaEquiposUsuario_SinResena ";
            List<InfoEquipo> Listado = new List<InfoEquipo>();
            try
            {
                reader = FuncionesDB.GetRecords(strProcedure + Id_Usuario + ',' + PageId);

                while (reader.Read())
                {
                    InfoEquipo resultado = new InfoEquipo();
                    resultado.ID_EQUIPO = Convert.ToInt32(reader["ID_EQUIPO"]);
                    resultado.NOMBRE_EQUIPO = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                    Listado.Add(resultado);
                }
                reader.Close();
                return Listado;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public static List<InfoLibretaUsuarioEquipo> Lista_Libreta_Usuarios_Del_Equipo(int Id_UsuarioAdmin)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_ListaLibretaEquipo " + Id_UsuarioAdmin;
            List<InfoLibretaUsuarioEquipo> Listado = new List<InfoLibretaUsuarioEquipo>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoLibretaUsuarioEquipo resultado = new InfoLibretaUsuarioEquipo();
                    resultado.ID = Convert.ToInt32(reader["ID"]);
                    resultado.NOMBRE = Convert.ToString(reader["NOMBRE_USUARIO"]);
                    Listado.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;
        }



        public static List<InfoEquipoUsuario> VerEquipos(int Id_Usuario)
        {
            System.Data.SqlClient.SqlDataReader reader = null;

            string strProcedure = "PA_Ver_Info_del_Equipo " + Id_Usuario;
            List<InfoEquipoUsuario> Listado = new List<InfoEquipoUsuario>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoEquipoUsuario resultado = new InfoEquipoUsuario();
                    resultado.ID_EQUIPO = Convert.ToInt32(reader["ID_EQUIPO"]);
                    resultado.ID_EQUIPO_USUARIO = Convert.ToInt32(reader["ID_EQUIPO_USUARIO"]);
                    resultado.ID_USUARIO = Convert.ToInt32(reader["ID_USUARIO"]);
                    resultado.TIPO = Convert.ToInt32(reader["TIPO"]);
                    resultado.ES_ADMINISTRADOR = Convert.ToString(reader["ES_ADMINISTRADOR"]);
                    resultado.CANTIDAD_USUARIOS = Convert.ToInt32(reader["CANTIDAD_USUARIOS"]);
                    resultado.NOMBRE_EQUIPO = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                    resultado.FECHA_CREACION = Convert.ToString(reader["FECHA_CREACION"]);
                    Listado.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Listado;
        }



        public static List<InfoEquipo> DatosDelEquipo(int Id_Equipo)
        {
            System.Data.SqlClient.SqlDataReader reader = null;

            string strProcedure = "PA_Ver_info_de_un_Equipo " + Id_Equipo;
            List<InfoEquipo> listado = new List<InfoEquipo>();
            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);
                while (reader.Read())
                {
                    InfoEquipo resultado = new InfoEquipo();
                    resultado.ID_EQUIPO = Convert.ToInt32(reader["ID_EQUIPO"]);
                    resultado.NOMBRE_EQUIPO = Convert.ToString(reader["NOMBRE_EQUIPO"]);
                    resultado.DESCRIPCION_EQUIPO = Convert.ToString(reader["DESCRIPCION"]);
                    listado.Add(resultado);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listado;
        }


        public static string Elimina_Usuario_del_Equipo(int idUsuarioADM, int IdUsuario, int IdEquipo)
        {
            string result = "";
            int intId = 0;

            try
            {
                string strProcedure = "PA_Elimina_UsuarioEquipo ";
                string strLastProcedure = "";
                strLastProcedure = idUsuarioADM + "," + IdUsuario + "," + IdEquipo;
                intId = Convert.ToInt32(FuncionesDB.ExecScalar(strProcedure + strLastProcedure));



            }
            catch (Exception ex)
            {
                intId = -1;

            }
            if (intId >= 0)
            {
                result = "OK";
            }
            else
            {
                result = "ERROR";
            }

            return result;
        }

    }







}
