using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoLog
    {
        //============================
        // Variables
        //============================
        public int Id = 0;
        public string Descripcion = string.Empty;
        public int Error = 0;
        public string Url = string.Empty;
        public DateTime Fecha;


        //============================
        // Constructores
        //============================
        public InfoLog()
        {

        }
    }
}
