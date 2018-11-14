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
        private List<Paquete> paquetes;

        public Correo()
        {
            this.Paquetes = new List<Paquete>();
        }

        public void FinEntregas()
        {

        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> l = (List<Paquete>)((Correo)elementos).paquetes;

            // Su código            
            return "";
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            foreach(Paquete paquete in c.Paquetes)
            {
                if (paquete == p)
                {
                    //TrackingIdRepetidoException.
                    return c;
                }
            }
            c.Paquetes.Add(p);

            Thread hilo = new Thread(p.MockCicloDeVida);
            //c.Paquetes. += hilo.;
            
            return c;
        }

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
    }
}
