using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase estática, simulador de calculadora.
    /// </summary>
    public static class Calculadora
    {
        #region Métodos

        /// <summary>
		/// Método privado, recibe un string y valida que sea un operador (+, -, *, /).
		/// </summary>
		/// <param name="operador"></param>
		/// <returns>Retorna el operador ingresado, en caso de ser inválido retorna "+"</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            }

            return "+";
        }

        /// <summary>
		/// Método estático, recibe 2 objetos Numero y un string operador, realiza la operacion designada.
		/// </summary>
		/// <param name="num1"></param>
		/// <param name="num2"></param>
		/// <param name="operador"></param>
		/// <returns>Retorna el resultado de la operación</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
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
                    retorno = num1 / num2;
                    break;
            }
            return retorno;
        } 
        #endregion
    }
}
