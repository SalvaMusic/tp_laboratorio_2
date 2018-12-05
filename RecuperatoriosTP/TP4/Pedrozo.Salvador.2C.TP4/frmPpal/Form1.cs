using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmPpal
{
    public partial class FrmPpal : Form
    {
        Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            try
            {
                Paquete paquete = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);
                paquete.InformaEstado += paq_InformaEstado;
                correo += paquete;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ActualizarEstados();
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarInformacion<T>(IMostrar<T> elementos)
        {
            if (!(elementos is null))
            {
                try
                { 
                    rtbMostrar.Text = elementos.MostrarDatos(elementos);
                    GuardaString.Guardar(elementos.MostrarDatos(elementos), "salida.txt");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }

        }

        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            foreach (Paquete p in correo.Paquetes)
            {
                switch (p.Estado)
                {
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(p);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(p);
                        break;
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(p);
                        break;
                }
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
