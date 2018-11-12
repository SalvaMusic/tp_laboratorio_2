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

        private double ValidarNumero (string strNumero)
        {
            double retorno = 0;

                Convert.ToDouble(strNumero);

            return retorno;
        }

        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }

        public Numero(double numero)
        {
            this.numero = numero;
        }

        public Numero(string numero)
        {
            this.SetNumero = numero;
        }

        public static string BinarioDecimal(string binario)
        {
            int i;
            double num = 0;

            for (i = 0; i < binario.Length; i++)
            {
                if (binario[i] == '0' || binario[i] == '1')
                {
                    if (binario[i] == '1')
                    {
                        num = num + Math.Pow(2, i);
                    }
                }
                else
                {
                    return string.Format("Valor Invalido");
                }
                
            }
            return num.ToString();
        }

        public static string DecimalBinario(double numero)
        {
            string binario = "";
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
            double num = Convert.ToDouble(numeroStr);
            return DecimalBinario(num);
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
