using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta Universitario, hereda de Persona
    /// </summary>
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor 1 por defecto. inicializa los atributos en null.
        /// </summary>
        public Universitario() { }

        /// <summary>
        /// Constructor público de instancia. Hereda de constructor clase base.
        /// </summary>
        /// <param name="legajo">Legajo del universitario.</param>
        /// <param name="nombre">Nombre/s del universitario.</param>
        /// <param name="apellido">Apellido/s del universitario.</param>
        /// <param name="dni">DNI del universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del universitario. Argentino o Extranjero.</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del método de clase base. Retorna todos los datos del universitario.
        /// </summary>
        /// <returns>Legajo y datos del universitario en formato string.</returns>
        protected virtual string MostrarDatos()
        {
            string datos = String.Format("{0}\nLEGAJO NÚMERO: {1}", base.ToString(), this.legajo);

            return datos;
        }

        #region Sobrecargas

        /// <summary>
        /// Compara dos objetos. 
        /// </summary>
        /// <param name="obj">Objeto a comparar. </param>
        /// <returns>Si es Universitario es igual al objeto instanciado retorna true, sino false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Universitario && (this == (Universitario)obj))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compara dos objetos tipo Universitario. 
        /// </summary>
        /// <param name="pg1">Objeto tipo Universitario a comparar.</param>
        /// <param name="pg2">Objeto tipo Universitario a comparar.</param>
        /// <returns>Si su DNI y Legajo son iguales devuelve true, sino false.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if ((pg1.DNI == pg2.DNI) || (pg1.legajo == pg2.legajo))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Compara dos objetos tipo Universitario. 
        /// </summary>
        /// <param name="pg1">Objeto tipo Universitario a comparar.</param>
        /// <param name="pg2">Objeto tipo Universitario a comparar.</param>
        /// <returns>Si su DNI y Legajo son distintos devuelve true, sino false.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        } 
        #endregion

        /// <summary>
        /// Método abstracto.
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion
    }
}
