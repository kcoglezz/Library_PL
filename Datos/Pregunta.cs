using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;
using Sistema.PL.Filtros;

namespace Sistema.PL.Datos
{

    public class Pregunta
    {

        //Public Shared ORA As InfoConexionORA = New InfoConexionORA

        public static InfoPregunta TraerPreguntaActual()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "proc_GetQuestionsActual ";
            InfoPregunta resultado = new InfoPregunta();

            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure);

                while (reader.Read())
                {
                    resultado.Id_Pregunta = Convert.ToInt32(reader["question_id"]);
                    resultado.Titulo_Pregunta = Convert.ToString(reader["question_desc"]);
                    resultado.FechaInicio = Convert.ToDateTime(reader["date_start"]);
                    resultado.FechaFin = Convert.ToDateTime(reader["date_end"]);
                    resultado.Respuesta_Opcion_1 = Convert.ToString(reader["question_1"]);
                    resultado.Respuesta_Opcion_2 = Convert.ToString(reader["question_2"]);
                    resultado.Respuesta_Opcion_3 = Convert.ToString(reader["question_3"]);
                    resultado.Respuesta_Opcion_4 = Convert.ToString(reader["question_4"]);
                    resultado.Respuesta_Opcion_5 = Convert.ToString(reader["question_5"]);
                    resultado.Respuesta_Opcion_6 = Convert.ToString(reader["question_6"]);
                    resultado.Respuesta_Opcion_7 = Convert.ToString(reader["question_7"]);
                    resultado.Respuesta_Opcion_8 = Convert.ToString(reader["question_8"]);
                    resultado.Respuesta_Opcion_9 = Convert.ToString(reader["question_9"]);
                    resultado.Respuesta_Opcion_10 = Convert.ToString(reader["question_10"]);


                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return resultado;
        }
        public static InfoResultadoEncuesta ResultadoPregunta(int IdPregunta)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Resultado_de_Pregunta ";
            InfoResultadoEncuesta Result = new InfoResultadoEncuesta();

            try
            {
                reader = FuncionesDB.GetRecords(strProcedure + IdPregunta);

                while (reader.Read())
                {
                    Result.Id_Pregunta = Convert.ToInt32(reader["question_id"]);
                    Result.strPregunta = Convert.ToString(reader["question_desc"]);
                    Result.FechaInicio = Convert.ToDateTime(reader["date_start"]);
                    Result.FechaFin = Convert.ToDateTime(reader["date_end"]);
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta1"])))
                    {
                        Result.strRespuesta_1 = Convert.ToString(reader["pregunta1"]);
                        Result.Respuesta_1 = Convert.ToInt32(reader["Expr1"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta2"])))
                    {
                        Result.strRespuesta_2 = Convert.ToString(reader["pregunta2"]);
                        Result.Respuesta_2 = Convert.ToInt32(reader["Expr2"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta3"])))
                    {
                        Result.strRespuesta_3 = Convert.ToString(reader["pregunta3"]);
                        Result.Respuesta_3 = Convert.ToInt32(reader["Expr3"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta4"])))
                    {
                        Result.strRespuesta_4 = Convert.ToString(reader["pregunta4"]);
                        Result.Respuesta_4 = Convert.ToInt32(reader["Expr4"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta5"])))
                    {
                        Result.strRespuesta_5 = Convert.ToString(reader["pregunta5"]);
                        Result.Respuesta_5 = Convert.ToInt32(reader["Expr5"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta6"])))
                    {
                        Result.strRespuesta_6 = Convert.ToString(reader["pregunta6"]);
                        Result.Respuesta_6 = Convert.ToInt32(reader["Expr6"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta7"])))
                    {
                        Result.strRespuesta_7 = Convert.ToString(reader["pregunta7"]);
                        Result.Respuesta_7 = Convert.ToInt32(reader["Expr7"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta8"])))
                    {
                        Result.strRespuesta_8 = Convert.ToString(reader["pregunta8"]);
                        Result.Respuesta_8 = Convert.ToInt32(reader["Expr8"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta9"])))
                    {
                        Result.strRespuesta_9 = Convert.ToString(reader["pregunta9"]);
                        Result.Respuesta_9 = Convert.ToInt32(reader["Expr9"]);
                    }
                    if (!string.IsNullOrEmpty(Convert.ToString(reader["pregunta10"])))
                    {
                        Result.strRespuesta_10 = Convert.ToString(reader["pregunta10"]);
                        Result.Respuesta_10 = Convert.ToInt32(reader["Expr10"]);
                    }

                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Result;
        }

        public static List<InfoPregunta> BuscarByFiltros(FiltroPregunta oFiltro)
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Listado_Preguntas_X_Anio ";
            List<InfoPregunta> Listado = new List<InfoPregunta>();

            try
            {
                reader = Sistema.PL.Datos.FuncionesDB.Obtener_DataReader(strProcedure + oFiltro.Numero.ToString());

                while (reader.Read())
                {
                    InfoPregunta resultado = new InfoPregunta();

                    resultado.Id_Pregunta = Convert.ToInt32(reader["question_id"]);
                    resultado.Titulo_Pregunta = Convert.ToString(reader["question_desc"]);
                    resultado.FechaInicio = Convert.ToDateTime(reader["date_start"]);
                    resultado.FechaFin = Convert.ToDateTime(reader["date_end"]);
                    resultado.Respuesta_Opcion_1 = Convert.ToString(reader["question_1"]);
                    resultado.Respuesta_Opcion_2 = Convert.ToString(reader["question_2"]);
                    resultado.Respuesta_Opcion_3 = Convert.ToString(reader["question_3"]);
                    resultado.Respuesta_Opcion_4 = Convert.ToString(reader["question_4"]);
                    resultado.Respuesta_Opcion_5 = Convert.ToString(reader["question_5"]);
                    resultado.Respuesta_Opcion_6 = Convert.ToString(reader["question_6"]);
                    resultado.Respuesta_Opcion_7 = Convert.ToString(reader["question_7"]);
                    resultado.Respuesta_Opcion_8 = Convert.ToString(reader["question_8"]);
                    resultado.Respuesta_Opcion_9 = Convert.ToString(reader["question_9"]);
                    resultado.Respuesta_Opcion_10 = Convert.ToString(reader["question_10"]);
                    resultado.MesAnno = Convert.ToString(reader["MesAnio"]);

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
    }
}