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
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public Correo()
        {
            this.Paquetes = new List<Paquete>();
        }

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
