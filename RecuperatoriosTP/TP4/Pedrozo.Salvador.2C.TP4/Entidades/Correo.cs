using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{

    public class Correo : IMostrar<List<Paquete>>
    {
        #region Atributos
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto. Inicializa las listas.
        /// </summary>
        public Correo()
        {
            this.Paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Cierra todos los hilos en ejecución.
        /// </summary>
        public void FinEntregas()
        {
            for(int i = 0; i < mockPaquetes.Count; i++)
            {
                if(mockPaquetes[i].IsAlive)
                {
                    mockPaquetes[i].Abort();
                }
            }
        }

        /// <summary>
        /// Retorna cadena con los datos de todos los paquetes de la lista.
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> l = ((Correo)elementos).paquetes;
            string str = "";

            foreach (Paquete p in l)
            {
                str += string.Format("{0} para {1} ({2})\n", p.TrackingID,p.DireccionEntrega, p.Estado.ToString());
            }
                     
            return str;
        }

        /// <summary>
        /// Sobrecarga operador +. Agrega un paquete al correo. En caso de existir paquete lanzará una excepcion "TrackingIdRepetidoException"
        /// </summary>
        /// <param name="c">Correo al cual se le agregará el paquete</param>
        /// <param name="p">Paquete a agregar</param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya existe");
                    
                }
            }
            c.Paquetes.Add(p);
            Thread hilo = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(hilo);
            hilo.Start();
            
            return c;
        }
        #endregion

        #region Propiedades

        /// <summary>
        /// Lectura y escritura de las listas de paquetes.
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
        #endregion
    }
}
