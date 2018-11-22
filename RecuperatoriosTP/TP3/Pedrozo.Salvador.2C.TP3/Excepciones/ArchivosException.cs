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
    public class ArchivosException : Exception
    { 
        /// <summary>
        /// Constructor de excepcion
        /// </summary>
        /// <param name="inner">Excepcion captada por la cual se crea esta excepcion</param>
        public ArchivosException(Exception inner) { }
    }
}
