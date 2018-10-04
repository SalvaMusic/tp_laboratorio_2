using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace VistaForm
{
    public partial class Form1 : Form
    {
        DirectorTecnico dt;

        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonCrear_Click(object sender, EventArgs e)
        {
            int dni = Convert.ToInt32(numericUpDownDni.Value);
            int edad = Convert.ToInt32(numericUpDownEdad.Value);
            int experiencia = Convert.ToInt32(numericUpDownExperiencia.Value);

            dt = new DirectorTecnico(textBoxNombre.Text,textBoxApellido.Text, edad, dni, experiencia);

            if(!(dt is null))
            {
                MessageBox.Show("Se ha creado el DT!");
            }
        }

        private void buttonValidar_Click(object sender, EventArgs e)
        {
            if (dt is null)
            {
                MessageBox.Show("Aún no se ha creado el DT del formulario");
            }
            else if (dt.ValidarAptitud())
            {
                MessageBox.Show("El DT es apto");
            }
            else
            {
                MessageBox.Show("El DT no es apto");
            }
        }
    }
}
