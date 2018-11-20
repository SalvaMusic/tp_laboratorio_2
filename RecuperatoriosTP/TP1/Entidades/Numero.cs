using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero()
            :this(0)
        { }

        public Numero(double numero)
            : this(numero.ToString())
        { }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        public static string BinarioDecimal(string binario)
        {
            double num = 0;
            char[] array = binario.ToCharArray();
            Array.Reverse(array);

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '0' || array[i] == '1')
                {
                    if (array[i] == '1')
                    {
                        num += Math.Pow(2, i);
                    }
                }
                else
                {
                    return string.Format("Valor inválido");
                }
            }
            return num.ToString();
        }

        public static string DecimalBinario(double numero)
        {
            string binario = "";

            if (numero < 0)
            {
                return "Valor inválido";
            }
            while (numero > 0)
            {
                if (numero % 2 == 0)
                {
                    binario = "0" + binario;
                }
                else
                {
                    binario = "1" + binario;
                }
                numero = (int)numero / 2;
            }

            return binario;
        }

        public static string DecimalBinario(string numeroStr)
        {
            double num = 0;
            if (Double.TryParse(numeroStr, out num))
            {
                return DecimalBinario(num);
            }

            return "Valor inválido";
        }

        private double ValidarNumero(string strNumero)
        {
            double numero;

            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }

            return 0;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            if (!(n1 is null) && !(n2 is null))
            {
                return n1.numero - n2.numero;
            }

            return 0;
        }
        public static double operator +(Numero n1, Numero n2)
        {
            if (!(n1 is null) && !(n2 is null))
            {
                return n1.numero + n2.numero;
            }

            return 0;
        }
        public static double operator /(Numero n1, Numero n2)
        {
            if (!(n1 is null) && !(n2 is null))
            {
                if(n2.numero == 0)
                {
                    return double.MinValue;
                }
                return n1.numero / n2.numero;
            }

            return 0;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            if (!(n1 is null) && !(n2 is null))
            {
                return n1.numero * n2.numero;
            }

            return 0;
        }
    }
}
