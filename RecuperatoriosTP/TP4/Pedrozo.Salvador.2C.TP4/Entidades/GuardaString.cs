using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        /// <summary>
		/// Metodo de extencion Guardar, recibe una string y un path, guarda la string en el archivo
		/// </summary>
		/// <param name="texto">texto a guadrdar</param>
		/// <param name="archivo">path del archivo</param>
		/// <returns>true si lo logro</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + archivo, true);
                sw.Write(texto);
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!(sw is null))
                {
                    sw.Close();
                }
            }
        }
           

    }
}
