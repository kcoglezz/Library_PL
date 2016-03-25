﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoLoPopular
    {
        //============================
        // Variables
        //============================
        public int IdFila = 0;
        public int PageId = 0;
        public DateTime Fecha;
        public string Titulo = string.Empty;
        public string Contenido = string.Empty;
        public int Rating = 0;
        public string Autor = string.Empty;
        public int IdSeccion = 0;
        public string Nombre_Seccion = string.Empty;
        public int AuthorId = 0;


        //============================
        // Constructores
        //============================
        public InfoLoPopular()
        {

        }
    }
}
