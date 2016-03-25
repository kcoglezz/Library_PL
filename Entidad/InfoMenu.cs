using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sistema.PL.Entidad
{
    public class InfoMenu
    {
        public int IdMenu = 0;
        public string Descripcion = string.Empty;
        public int IdPadre = 0;
        public int Nivel = 0;
        public int Tipo = 0;
        public int Cantidad_Hijos = 0;
        public List<InfoSeccionPadre> Padres = null;



        //============================
        // Constructores
        //============================
        public InfoMenu()
        {

        }
    }
}
