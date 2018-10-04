using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Persona no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Persona
    {
        private string apellido;
        private string nombre;
        private int dni;
        private int edad;

        /// <summary>
        /// Constructor Persona
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="dni"></param>
        /// </summary>
        public Persona(string nombre, string apellido, int edad, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.edad = edad;
        }

        /// <summary>
        /// Muestra los campos de Persona
        /// </summary>
        public virtual string Mostrar()
        {
            StringBuilder datos = new StringBuilder();

            return datos.AppendFormat("{0}, {1}\tEdad: {2}\tDNI: {3}", this.Apellido, this.Nombre,this.Edad, this.Dni).ToString();
        }

        /// <summary>
        /// Validará Aptitud de Persona
        /// </summary>
        public abstract bool ValidarAptitud();

        public string Apellido
        {
            get
            {
                return this.apellido;
            }
        }

        /// <summary>
        /// Devuelve el Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
        }
        /// <summary>
        /// Devuelve el DNI
        /// </summary>
        public int Dni
        {
            get
            {
                return this.dni;
            }
        }
        /// <summary>
        /// Devuelve la Edad
        /// </summary>
        public int Edad
        {
            get
            {
                return this.edad;
            }
        }
    }
}
