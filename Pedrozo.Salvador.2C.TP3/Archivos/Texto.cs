using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;
namespace Archivos
{
    public class Texto : IArchivo<string>
    {
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
