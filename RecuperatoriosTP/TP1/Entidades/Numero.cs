using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// Clase de instancia para trabajar con numeros del tipo de la clase.
    /// </summary>
    public class Numero
    {
        #region Atributos
        private double numero;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto, reutiliza su recarga para double pasandole un 0.
        /// </summary>
        public Numero()
            : this(0)
        { }

        /// <summary>
        /// Constructor para recibir un double como parametro, reutiliza su recarga para string pasandole "numero" previa conversión.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(double numero)
            : this(numero.ToString())
        { }

        /// <summary>
        /// Constructor para recibir un string como parametro, setea el parametro recibido a la propiedad.
        /// </summary>
        /// <param name="numero"></param>
        public Numero(string numero)
        {
            this.SetNumero = numero;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de escritura, utiliza el metodo validarnumero para setear.
        /// </summary>
        public string SetNumero
        {
            set { this.numero = ValidarNumero(value); }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método estático, recibe un binario como string y lo convierte a decimal.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Si el parámetro ingresado es binario válido retonra su conversión, sino retorna "Valor inválido".</returns>
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

        /// <summary>
        /// Método estático, recibe un decimal como double y lo convierte a binario.
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>Si el parámetro ingresado es positivo retonra su binario como string, sino retorna "Valor inválido".</returns>
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

        /// <summary>
		/// Metodo estático, recibe un string y lo convierte a binario.
		/// </summary>
		/// <param name="strDecim"></param>
		/// <returns>Si el parámetro ingresado es número retonra su binario como string, sino retorna "Valor inválido".</returns>
        public static string DecimalBinario(string numeroStr)
        {
            double num = 0;
            if (Double.TryParse(numeroStr, out num))
            {
                return DecimalBinario(num);
            }

            return "Valor inválido";
        }

        /// <summary>
		/// Metodo privado, valida que el string sea numérico.
		/// </summary>
		/// <param name="strNumero"></param>
		/// <returns>Si el parámetro ingresado es número, retorna su conversión a double, sino retorna 0.</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;

            if (double.TryParse(strNumero, out numero))
            {
                return numero;
            }

            return 0;
        }
        
        /// <summary>
		/// Sobrecarga operador -, recibe dos objetos Numero y los resta.
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <returns>Retorna la resta si son los dos válidos, 0 si alguno es null.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            if (!(n1 is null) && !(n2 is null))
            {
                return n1.numero - n2.numero;
            }

            return 0;
        }

        /// <summary>
		/// Sobrecarga operador +, recibe dos objetos Numero y los suma.
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <returns>Retorna la suma si son los dos válidos, 0 si alguno es null.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            if (!(n1 is null) && !(n2 is null))
            {
                return n1.numero + n2.numero;
            }

            return 0;
        }

        /// <summary>
		/// Sobrecarga operador /, recibe dos objetos Numero y los divide.
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <returns>Retorna la división si son los dos válido, 0 si alguno es null, y double.MinValue si trató de dividir por 0</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (!(n1 is null) && !(n2 is null))
            {
                if (n2.numero == 0)
                {
                    return double.MinValue;
                }
                return n1.numero / n2.numero;
            }

            return 0;
        }


        /// <summary>
		/// Sobrecarga operador *, recibe dos objetos Numero y los multiplica
		/// </summary>
		/// <param name="n1"></param>
		/// <param name="n2"></param>
		/// <returns>Retorna la multiplicación si son los dos válidos, 0 si alguno es null</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            if (!(n1 is null) && !(n2 is null))
            {
                return n1.numero * n2.numero;
            }

            return 0;
        } 
        #endregion
    }
}
