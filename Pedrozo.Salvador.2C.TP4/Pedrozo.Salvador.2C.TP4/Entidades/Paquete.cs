using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public delegate void DelegadoEstado(object sender, EventArgs e);
    public class Paquete : IMostrar<Paquete>
    {
        public event DelegadoEstado InformaEstado;

        public Paquete(string direccionEntrega, string trackingId)
        {
            
        }
            
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            throw new NotImplementedException();
        }

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }
    }
}
