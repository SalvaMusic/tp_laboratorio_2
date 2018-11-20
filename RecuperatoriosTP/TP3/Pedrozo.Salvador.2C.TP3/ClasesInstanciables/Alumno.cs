using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Excepciones;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        #region Atributos
        private EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor 1 por defecto. inicializa los atributos en null.
        /// </summary>
        public Alumno() { }

        /// <summary>
        /// Constructor 2 público de instancia. Hereda de constructor clase base.
        /// </summary>
        /// <param name="legajo">Legajo del universitario.</param>
        /// <param name="nombre">Nombre/s del universitario.</param>
        /// <param name="apellido">Apellido/s del universitario.</param>
        /// <param name="dni">DNI del universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del universitario. Argentino o Extranjero.</param>
        /// <param name="claseQueToma">Clase que toma el universitario.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor 2 público de instancia. Hereda de constructor 2 de la clase.
        /// </summary>
        /// <param name="legajo">Legajo del universitario.</param>
        /// <param name="nombre">Nombre/s del universitario.</param>
        /// <param name="apellido">Apellido/s del universitario.</param>
        /// <param name="dni">DNI del universitario.</param>
        /// <param name="nacionalidad">Nacionalidad del universitario. Argentino o Extranjero.</param>
        /// <param name="claseQueToma">Clase que toma el universitario.</param>
        /// <param name="estadoCuenta">estado de cuenta del universitario.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del método de clase base. Retorna todos los datos del universitario.
        /// </summary>
        /// <returns>Estado de cuenta y datos del universitario en formato string.</returns>
        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("{0}\n\nESTADO DE CUENTA: {1}\n{2}", base.MostrarDatos(), this.estadoCuenta, this.ParticiparEnClase());

            return datos.ToString();
        }

        /// <summary>
        /// Método protegido. Muestra la clase que toma el alumno.
        /// </summary>
        /// <returns>Retorna una cadena "TOMA CLASE DE" junto al nombre de la clase que toma el alumno.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("TOMA CLASES DE {0}", this.claseQueToma);

            return datos.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString(). Hace públicos los datos del alumno.
        /// </summary>
        /// <returns>Devuelve una cadena con todos los datos del alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el alumno toma la clase y su estado de cuenta es distinto de Deudor, sino false.</returns>
        public static bool operator ==(Alumno a, EClases clase)
        {
            if ((a.claseQueToma == clase) && (a.estadoCuenta != EEstadoCuenta.Deudor))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el alumno no toma la clase, sino false.</returns>
        public static bool operator !=(Alumno a, EClases clase)
        {
            if ((a.claseQueToma != clase))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region Enumerados
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        } 
        #endregion
    }
}
