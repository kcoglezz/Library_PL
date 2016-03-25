using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoSeccionPadre
    {
        public int IdMenu = 0;
        public string Descripcion = string.Empty;
        public int IdPadre = 0;
        public int Nivel = 0;
        public int Tipo = 0;
        public int Cantidad_Hijos = 0;
        public List<InfoSeccionHijos> Hijos = null;



        //============================
        // Constructores
        //============================
        public InfoSeccionPadre()
        {

        }
    }
}
