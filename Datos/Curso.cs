using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using Sistema.PL.Entidad;

namespace Sistema.PL.Datos
{

    public class Curso
    {
        public static List<InfoCurso> TraerCursos()
        {
            System.Data.SqlClient.SqlDataReader reader = null;
            string strProcedure = "PA_Obtener_Todos_los_Cursos ";
            List<InfoCurso> Listado = new List<InfoCurso>();
            try
            {
                reader = FuncionesDB.GetRecords(strProcedure);
                while (reader.Read())
                {
                    InfoCurso oCurso = new InfoCurso();
                    oCurso.curso_id = Convert.ToInt32(reader["curso_id"]);
                    oCurso.title = Convert.ToString(reader["title"]);
                    oCurso.curso_desc = Convert.ToString(reader["curso_desc"]);
                    oCurso.on_line = Convert.ToString(reader["on_line"]);
                    oCurso.zip = Convert.ToString(reader["zip"]);
                    oCurso.type = Convert.ToString(reader["type"]);
                    Listado.Add(oCurso);
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
