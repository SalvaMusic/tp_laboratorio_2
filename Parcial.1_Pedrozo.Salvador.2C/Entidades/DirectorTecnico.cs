using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico : Persona
    {
        private int aniosExperiencia;

        /// <summary>
        /// Constructor Director Tectino
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="dni"></param>
        /// <param name="aniosExperiencia"></param>
        /// </summary>
        public DirectorTecnico(string nombre, string apellido, int edad, int dni, int aniosExperiencia)
            :base(nombre,apellido,edad,dni)
        {
            this.AniosExperiencia = aniosExperiencia;
        }
        /// <summary>
        /// Devuelve el Anios de Experiencia
        /// </summary>
        public int AniosExperiencia
        {
            get
            {
                return this.aniosExperiencia;
            }
            set
            {
                if (value >= 0)
                {
                    this.aniosExperiencia = value;
                }
                else
                {
                    this.aniosExperiencia = 0;
                }
            }
        }
        /// <summary>
        /// Muestra los campos de Director Tecnico
        /// </summary>
        public override string Mostrar()
        {
            StringBuilder datos = new StringBuilder();

            return datos.AppendFormat("{0}, {1}\tEdad: {2}\tDNI: {3}\t Anios de Experiencia: {4}", this.Apellido, this.Nombre, this.Edad, this.Dni,this.AniosExperiencia).ToString();
        }
        /// <summary>
        /// Valida Aptitud
        /// </summary>
        public override bool ValidarAptitud()
        {
            if (this.AniosExperiencia >= 2 && this.Edad < 65)
            {
                return true;
            }

            return false;
        }
    }
}
