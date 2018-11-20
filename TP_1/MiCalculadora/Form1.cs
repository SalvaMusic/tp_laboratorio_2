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

namespace MiCalculadora
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();

        }
        private void Limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox1.Text = "";
            lblResultado.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(textBox1.Text);
            Numero num2 = new Numero(textBox2.Text);
            lblResultado.Text = Calculadora(num1,num2,comboBox1.Text).ToString();
        }

        private double Calculadora (Numero num1,Numero num2, string operador)
        {
            return Entidades.Calculadora.Operar(num1, num2, operador);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.DecimalBinario(textBox2.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Numero.BinarioDecimal(textBox2.Text);
        }

        private void btnCerrar_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
