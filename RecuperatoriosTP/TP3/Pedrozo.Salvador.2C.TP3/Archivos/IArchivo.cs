using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    /// <summary>
    /// Interfaz genérica para guardar objetos
    /// </summary>
    /// <typeparam name="T">Variable del Tipo genérico</typeparam>
    public interface IArchivo<T>
    {
        /// <summary>
        /// Guardará objeto
        /// </summary>
        /// <param name="archivo">Nombre del archivo que se guardará</param>
        /// <param name="dato">Objeto a guardar</param>
        /// <returns>True si pudo guardar. Sino false</returns>
        bool Guardar(string archivo, T dato);

        /// <summary>
        /// Leerá objeto
        /// </summary>
        /// <param name="archivo">Nombre del archivo que se leerá</param>
        /// <param name="dato">Objeto a leer</param>
        /// <returns>True si pudo leer. Sino false</returns>
        bool Leer(string archivo, out T dato);
    }
}
