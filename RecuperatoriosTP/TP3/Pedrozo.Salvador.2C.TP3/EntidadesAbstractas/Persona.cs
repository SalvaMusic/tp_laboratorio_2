using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    /// <summary>
    /// Clase abstracta Persona.
    /// </summary>
    public abstract class Persona
    {
        #region Atributos
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor 1 por defecto. inicializa los atributos en null.
        /// </summary>
        public Persona() { }


        /// <summary>
        /// Constructor 2 de instancia público. Setea los parametros en las propiedades.
        /// </summary>
        /// <param name="nombre">Nombre/s de la persona. </param>
        /// <param name="apellido">Apellido/s de la persona.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona, Argentino o Extranjero.</param>
        public Persona (string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor 3 de instancia público. Hereda de constructor 2 y setea el parametro restante en la propiedad.
        /// </summary>
        /// <param name="nombre">Nombre/s de la persona. </param>
        /// <param name="apellido">Apellido/s de la persona.</param>
        /// <param name="dni">DNI de la persona en formato INT.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona, Argentino o Extranjero.</param
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor 4 de instancia público. Hereda de constructor 2 y setea el parametro restante en la propiedad.
        /// </summary>
        /// <param name="nombre">Nombre/s de la persona. </param>
        /// <param name="apellido">Apellido/s de la persona.</param>
        /// <param name="dni">DNI de la persona en formato STRING.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona, Argentino o Extranjero.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobrescritura del método ToString(). 
        /// </summary>
        /// <returns>Retorna los datos de la Persona en formato string.</returns>
        public override string ToString()
        {
            string datos = String.Format("NOMBRE COMPLETO: {0}, {1}\nNACIONALIDAD: {2}\n", this.Apellido,this.Nombre,this.Nacionalidad);
        
            return datos;
        }


        #region Validaciones
        /// <summary>
        /// Valida que el apellido/nombre sea sólo letras. 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns>Apellido/nombre validado o null.</returns>
        private string ValidarNombreApellido(string dato)
        {
            Regex Val = new Regex(@"/^[a-zA-Z]+$/");
            if (!(Val.IsMatch(dato)))
            {
                return dato;
            }

            return null;
        }

        /// <summary>
        /// Método privado, valida dni según nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>DNI valido o lanza DniInvalidoException caso contrario.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            if (dni.ToString().Length != 8)
            {
                throw new DniInvalidoException("DNI inválido");
            }

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dni >= 1 && dni <= 89999999)
                    {
                        return dni;
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dni >= 90000000 && dni <= 99999999)
                    {
                        return dni;
                    }
                    break;
            }
            throw new NacionalidadInvalidaException("La nacionalidad no se coincide con el número de DNI");

        }

        /// <summary>
        /// Convierte el dni pasado como string a int. Valida que esté correctamente escrito.
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad de la persona.</param>
        /// <param name="dato">DNI de la persona.</param>
        /// <returns>DNI valido o lanza DniInvalidoException caso contrario.</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string strDni)
        {
            int intDni;

            if (!(int.TryParse(strDni, out intDni)))
            {
                throw new DniInvalidoException("Carácteres invalidos");
            }

            return ValidarDni(nacionalidad, intDni);
        }
        #endregion
        #endregion

        #region Propiedades
        /// <summary>
        /// Lectura de nombre y escritura previamente validado en el método "ValidarNombreApellido".
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Lectura de apellido y escritura previamente validado en el método "ValidarNombreApellido".
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Lectura de dni (int) y escritura previamente validado en el método "ValidarDni".
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        /// <summary>
        /// Lectura de dni (string) y escritura previamente validado en el método "ValidarDni".
        /// </summary>
        public string StringToDNI
        {
            set
            { 
                this.dni = ValidarDni(this.Nacionalidad, value);
            }

        }

        /// <summary>
        /// Lectura y escritura de nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }
        #endregion

        #region Enumerados
        /// <summary>
        /// Enumerado, nacionalidad de la persona.
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        #endregion
    }
}
