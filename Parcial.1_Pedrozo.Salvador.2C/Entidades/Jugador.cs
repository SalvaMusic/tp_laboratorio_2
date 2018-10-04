using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador : Persona
    {
        private float altura;
        private float peso;
        private Posicion posicion;

        /// <summary>
        /// Constructor Jugador
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="edad"></param>
        /// <param name="dni"></param>
        /// <param name="peso"></param>
        /// <param name="altura"></param>
        /// <param name="posicion"></param>
        /// </summary>
        public Jugador(string nombre, string apellido, int edad, int dni, float peso, float altura, Posicion posicion)
            : base(nombre, apellido, edad, dni)
        {
            this.peso = peso;
            this.altura = altura;
            this.posicion = posicion;
        }
        /// <summary>
        /// Valida Estado Fisico
        /// </summary>
        public bool ValidarEstadoFisico()
        {
            float imc = (this.Peso / (this.Altura * this.Altura));

            if (imc >= 18.5 && imc <= 25)
            {
                return true;
            }

            return false;
        }


        /// <summary>
        /// Valida Aptitud
        /// </summary>
        public override bool ValidarAptitud()
        {
            if (this.Edad <= 40 && ValidarEstadoFisico())
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Devuelve el Peso
        /// </summary>
        public float Peso
        {
            get
            {
                return this.peso;
            }
        }
        /// <summary>
        /// Devuelve Altura
        /// </summary>
        public float Altura
        {
            get
            {
                return this.altura;
            }
        }
        /// <summary>
        /// Devuelve Posicion
        /// </summary>
        public Posicion Posicion
        {
            get
            {
                return this.posicion;
            }
        }
    }
}
