using Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    /// <summary>
    /// Clase que manejará archivos Xml.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Serializará objeto en un archivo Xml.
        /// </summary>
        /// <param name="archivo">Nombre del archivo en el que se guardará</param>
        /// <param name="dato">Objeto a guardar</param>
        /// <returns>True si pudo guardar. Sino false</returns>
        public bool Guardar(string archivo, T dato)
        {
            try
            {
                XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
                XmlSerializer ser = new XmlSerializer(typeof(T));
                ser.Serialize(writer, dato);

                if (!(writer is null))
                {
                    writer.Close();
                }
            }
            catch(Exception e)
            {
                new ArchivosException(e);
            }

            return true;
        }


        /// <summary>
        /// Leerá objeto de un archivo Xml
        /// </summary>
        /// <param name="archivo">Nombre del archivo del que se leerá</param>
        /// <param name="dato">Salida de objeto a leído</param>
        /// <returns>True si pudo leer. Sino false</returns>
        public bool Leer(string archivo, out T dato)
        {
            try
            { 
                XmlTextReader reader = new XmlTextReader(archivo);   
                XmlSerializer ser = new XmlSerializer(typeof(T));
            
                dato = (T)ser.Deserialize(reader);
                reader.Close();
            }
            catch (Exception e)
            {
                new ArchivosException(e);
            }

            dato = default (T);
            return true;
        }
    }
}
