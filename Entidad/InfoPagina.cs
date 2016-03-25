using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoPagina
    {
        //============================
        // Variables
        //============================
        public int Id_Pagina = 0;
        public int Id_Seccion = 0;
        public DateTime FechaPosteada;
        public string TituloPagina = string.Empty;
        public string Reseña = string.Empty; //blurb
        public string Contenido = string.Empty;//body
        public int EsPosteado = 0;
        public string NombreImagen = string.Empty; //pic
        public int TipoArticulo = 0;
        public int Isfeatured = 0;
        public int Id_User = 0;
        public string NombreAutor = string.Empty; 
        public string Etiquetas = string.Empty; //keywords
        public int Book = 0;
        public int Chapter = 0;
        public int Rating = 0;
        public string NombreSeccionPadre = string.Empty; //
        public int Id_SeccionPadre = 0;
        public string NombreSeccionOrigen = string.Empty; //
        public int Id_SeccionOrigen = 0;

        public int Estrellas = 0;

        public string NombreSeccionActual = string.Empty; //
        public string FotoAutho = string.Empty;
 

        //============================
        // Constructores
        //============================
        public InfoPagina()
        {

        }

    }
}
