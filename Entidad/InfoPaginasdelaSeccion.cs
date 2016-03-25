using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoPaginasdelaSeccion
    {

            //============================
            // Variables
            //============================
            public int PageId = 0;
            public DateTime posted;
            public string Titulo = string.Empty;
            public string Contenido = string.Empty;
            public int Rating = 0;
            public string NombreAutor = string.Empty;
            public int CantidadTotalRegistros = 0;
            public int AuthorId =0;

            //============================
            // Constructores
            //============================
            public InfoPaginasdelaSeccion()
            {

            }

    }
}
