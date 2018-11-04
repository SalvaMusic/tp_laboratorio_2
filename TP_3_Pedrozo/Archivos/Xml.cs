using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T dato)
        {
            XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8);
            XmlSerializer ser = new XmlSerializer(typeof(T));
            ser.Serialize(writer, dato);
            
            
            if (!(writer is null))
            {
                writer.Close();
            }

            return true;
        }

        public bool Leer(string archivo, out T dato)
        {
            XmlTextReader reader = new XmlTextReader(archivo);   
            XmlSerializer ser = new XmlSerializer(typeof(T));
            
            dato = (T)ser.Deserialize(reader);
            reader.Close();

            return true;
        }
    }
}
