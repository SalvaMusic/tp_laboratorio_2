using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{

    /// <summary>
    /// Tipo de excepcion.
    /// </summary>
    public class DniInvalidoException : Exception
    {
        #region Atributos
        /// <summary>
        /// Constante mensaje base.
        /// </summary>
        private const string mensajeBase = "Dni inválido";
        #endregion
        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public DniInvalidoException() : base (mensajeBase) { }

        /// <summary>
        /// Constructor en base a otra excepción.
        /// </summary>
        /// <param name="e">Excepción captada por la cual se crea esta excepcion.</param>
        public DniInvalidoException(Exception e) : base(mensajeBase, e) { }

        /// <summary>
        /// Constructor con su propio mensaje.
        /// </summary>
        /// <param name="message">Mensaje de la excepcion creada.</param>
        public DniInvalidoException(string message) : base (message) { }

        /// <summary>
        /// Constructor en base a otra excepción.
        /// </summary>
        /// <param name="message">Mensaje de la excepcion creada.</param>
        /// <param name="e">Excepción captada por la cual se crea esta excepcion.</param>
        public DniInvalidoException(string message, Exception e) : base(message, e) { }
        #endregion
    }
}
