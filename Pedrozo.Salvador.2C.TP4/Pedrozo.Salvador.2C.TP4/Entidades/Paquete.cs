using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Atributos
        public delegate void DelegadoEstado(object sender, EventArgs e);
        private string direccionEntrega;
        private string trackingID;
        private EEstado estado;
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Constructores
        public Paquete(string direccionEntrega, string trackingId)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }
        #endregion

        #region Métodos
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete p = (Paquete)elemento;
            return String.Format("{0} para {1}", p.TrackingID,p.direccionEntrega);
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public void MockCicloDeVida()
        {
            do
            {
                Thread.Sleep(4000);
                this.Estado++;
                InformaEstado(this, EventArgs.Empty);
            } while (this.Estado == EEstado.Entregado);
            
        }


        #region Sobrecargas
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if(p1.trackingID == p2.trackingID)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        #endregion
        #endregion

        #region Propiedades
        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }
            set
            {
                this.direccionEntrega = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }
            set
            {
                this.trackingID = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado= value;
            }
        }
        #endregion

        #region Enumerados
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
        #endregion

    }
}
