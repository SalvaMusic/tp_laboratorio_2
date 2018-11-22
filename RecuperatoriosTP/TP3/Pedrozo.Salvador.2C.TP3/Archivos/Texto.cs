using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{

    /// <summary>
    /// Clase que manejará archivo de texto.
    /// </summary>
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guardará una cadena de string en archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo que se guardará</param>
        /// <param name="dato">string a guardar</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string dato)
        {
            try
            {
                StreamWriter sw = new StreamWriter(archivo, true);
                sw.WriteLine(dato);
                sw.Close();
            }
            catch(Exception e)
            {
                new ArchivosException(e);
            }
                
            return true;
        }


        /// <summary>
        /// Leerá una cadena de string en archivo de texto.
        /// </summary>
        /// <param name="archivo">Nombre del archivo que se leerá</param>
        /// <param name="dato">salida de string leído</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string dato)
        {
            
            try
            {
                StreamReader sr = new StreamReader(archivo);
                dato = sr.ReadToEnd();
                sr.Close();
                return true;
            }
            catch (Exception e)
            {
                new ArchivosException(e);
            }

            dato = null;
            return false;
        }
    }
}
