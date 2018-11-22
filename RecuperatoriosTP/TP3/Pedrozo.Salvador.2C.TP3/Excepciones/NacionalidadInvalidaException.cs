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
    public class NacionalidadInvalidaException : Exception
    {
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public NacionalidadInvalidaException() { }

        public NacionalidadInvalidaException(string message) : base(message) { }
    }
}
