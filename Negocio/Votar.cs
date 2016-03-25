using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sistema.PL.Entidad;

namespace Sistema.PL.Negocio
{
    public class Votar
    {
        public static int RegistrarVotacion(InfoVotar oVotar)
        {
            return Sistema.PL.Datos.Votar.RegistrarVotacion(oVotar);
        }
        public static int ModificarVotacion(InfoVotar oVotar)
        {
            return Sistema.PL.Datos.Votar.ModificarVotacion(oVotar);
        }
        public static int EliminarVotacion(InfoVotar oVotar)
        {
            return Sistema.PL.Datos.Votar.EliminarVotacion(oVotar);
        }

        public static int ExisteVotacionIpPaginaMegusta(InfoVotar oVotar)
        {
            return Sistema.PL.Datos.Votar.ExisteVotacionIpPaginaMegusta(oVotar);
        }
        public static int ExisteVotacionIpPaginaNoMegusta(InfoVotar oVotar)
        {
            return Sistema.PL.Datos.Votar.ExisteVotacionIpPaginaNoMegusta(oVotar);
        }
        public static int ExisteVotacion(InfoVotar oVotar)
        {
            return Sistema.PL.Datos.Votar.ExisteVotacion(oVotar);
        }
    }
}
