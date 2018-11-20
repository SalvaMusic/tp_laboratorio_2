using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {

        private static string ValidarOperador (string operador)
        {
            string retorno = "+";

            if(operador == "-" || operador == "/" || operador == "*")
            {
                retorno = operador;
            }

            return retorno;
        }

        public static double Operar (Numero num1, Numero num2, string operador)
        {
            Numero num0 = new Numero(0);
            double retorno = 0;

            switch (ValidarOperador(operador))
            {
                case "+":
                    retorno = num1 + num2;
                    break;
                case "-":
                    retorno = num1 - num2;
                    break;
                case "*":
                    retorno = num1 * num2;
                    break;
                case "/":
                    try
                    {
                        retorno = num1 / num2;
                    }
                    catch(DivideByZeroException)
                    {
                        retorno = double.MinValue;
                    }
                    break;
            }
            return retorno;
        }
    }
}
