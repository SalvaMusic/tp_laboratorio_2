using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        private const int cantidadMaximaJugadores = 6;
        private DirectorTecnico directorTecnico;
        private List<Jugador> jugadores;
        private string nombre;


        /// <summary>
        /// Constructor: instancia la lista de jugadores
        /// </summary>
        private Equipo()
        {
            jugadores = new List<Jugador>();
        }
        /// <summary>
        /// Constructor publico
        /// <param name="nombre"></param>
        /// </summary>
        public Equipo(string nombre)
            : this()
        {
            this.nombre = nombre;
        }

        /// <summary>
        /// Otorga un DT al equipo, si este es valido
        /// </summary>
        public DirectorTecnico DirectorTecnico
        {
            set
            {
                if (value.ValidarAptitud())
                {
                    this.directorTecnico = value;
                }
            }
        }
        /// <summary>
        /// Valida si el Equipo es apto
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static bool ValidarEquipo(Equipo e)
        {
            bool delantero = false;
            bool defensor = false;
            bool central = false;
            int arquero = 0;

            if (!(e.directorTecnico is null))
            {
                foreach (Jugador jugador in e.jugadores)
                {
                    switch (jugador.Posicion)
                    {
                        case Posicion.Delantero:
                            delantero = true;
                            break;
                        case Posicion.Central:
                            central = true;
                            break;
                        case Posicion.Defensor:
                            defensor = true;
                            break;
                        case Posicion.Arquero:
                            arquero++;
                            break;
                    }

                    if ((delantero) && (defensor) && (central) && (arquero == 1) && (Equipo.cantidadMaximaJugadores == 6))
                    {
                        return true;
                    }                
                }
            }
 
            return false;
        }
        /// <summary>
        /// Muestro el Equipo y todos sus datos
        /// </summary>
        /// <returns></returns>
        public static explicit operator string(Equipo e)
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("Equipo: {0}\n", e.Nombre);
            if (e.directorTecnico is null)
            {
                datos.AppendLine("Sin DT asignado");
            }
            else
            {
                datos.AppendFormat("Director Tecnico: {0}\n", e.directorTecnico.Mostrar());
            }
            datos.AppendLine("\n\tJUGADORES:");
            foreach (Jugador jugador in e.jugadores)
            {
                datos.AppendLine(jugador.Mostrar());
            }
            datos.Append("\n");

            return datos.ToString();
        }

        /// <summary>
        /// El jugador está en el equipo
        /// </summary>
        /// <param name="e"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool operator ==(Equipo e, Jugador j)
        {
            if (e.jugadores.Count > 0)
            {
                foreach (Jugador jugador in e.jugadores)
                {
                    if (jugador == j)
                    {
                        return true;
                    }
                }
            }
            
            return false;
        }
        /// <summary>
        /// El jugador no está en el equipo
        /// </summary>
        /// <param name="e"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        /// <summary>
        /// Agrega un jugador al equipo 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static Equipo operator +(Equipo e, Jugador j)
        {
            if((e != j) && (e.jugadores.Count < Equipo.cantidadMaximaJugadores) && (j.ValidarAptitud()))
            {
                e.jugadores.Add(j);
            }
            return e;
        }

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }

    }
}
