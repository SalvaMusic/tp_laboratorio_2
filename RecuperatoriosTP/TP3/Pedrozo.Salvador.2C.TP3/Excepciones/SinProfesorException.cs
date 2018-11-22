using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    /// <summary>
    /// Tipo de excepción.
    /// </summary>
    public class SinProfesorException : Exception
    {
        /// <summary>
        /// Constructor por defecto. Pasa un mensaje predeterminado a la base.
        /// </summary>
        public SinProfesorException() : base("No hay Profesor para la clase.") { }
    }
}
