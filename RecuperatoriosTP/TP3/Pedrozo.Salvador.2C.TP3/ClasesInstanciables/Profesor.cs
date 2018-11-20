using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase sellada Profesor. Hereda de Universitario
    /// </summary>
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor estático. inicializa el atributo estático "random".
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto. inicializa los atributos en null.
        /// </summary>
        public Profesor() { }

        /// <summary>
        /// Constructor público de instancia. Hereda de constructor clase base. instancia el atributo "clasesDelDia", otorgándole 2 clases a travéz del método "randomClases()".
        /// </summary>
        /// <param name="legajo">Legajo del universitario.</param>
        /// <param name="nombre">Nombre/s del universitario.</param>
        /// <param name="apellido">Apellido/s del universitario.</param>
        /// <param name="dni">DNI del universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del universitario. Argentino o Extranjero.</param>
        /// <param name="claseQueToma">Clase que toma el universitario.</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            _randomClases();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del método de clase base. Retorna todos los datos del profesor.
        /// </summary>
        /// <returns>Retorna las clases del día y datos del universitario en formato string.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("{0}\n{1}", base.MostrarDatos(), this.ParticiparEnClase());

            return datos.ToString();
        }
        /// <summary>
        /// Muestra las clases que da el profesor.
        /// </summary>
        /// <returns>Devuelve una cadena "TOMA CLASE DE" junto al nombre de las clases que da el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("CLASES DEL DIA:");

            foreach (EClases clase in this.clasesDelDia)
            {
                datos.AppendLine(clase.ToString());
            }

            return datos.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString(). Hace públicos los datos del profesor.
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del profesor.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Asigna dos clases al azar a la cola de clases del día del profesor. 
        /// </summary>
        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((EClases)random.Next(3));
                System.Threading.Thread.Sleep(250);
            }
        }

        #region sobrecargas

        /// <summary>
        /// Será igual si el profesor da la clase.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el profesor da la clase, sino false.</returns>
        public static bool operator ==(Profesor i, EClases clase)
        {
            foreach(EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Será distinto si el profesor no da la clase.
        /// </summary>
        /// <param name="i">Profesor a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el profesor NO da la clase, sino false.</returns>
        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
        #endregion
        #endregion
    }
}
