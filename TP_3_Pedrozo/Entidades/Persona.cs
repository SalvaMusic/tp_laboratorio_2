using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;

        public Persona() { }

        public Persona (string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("{0}, {1}\nDNI: {2}\t{3}",this.Apellido,this,Nombre,this.DNI,this,Nacionalidad);
            
            return datos.ToString();
        }

        private string ValidarNombreApellido (string dato)
        {
            Regex Val = new Regex(@"/^[a-zA-Z]+$/");
            if (Val.IsMatch(dato))
            {
                return dato;
            }

            return null;
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dni)
        {
            if (dni.ToString().Length != 8)
            {
               // throw new DniInvalidoException("DNI debe tener 8 digitos.");
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
            throw new NacionalidadInvalidaException();
            
        }

        private int ValidarDni(ENacionalidad nacionalidad, string strDni)
        {
            int intDni;
            
            if (!(int.TryParse(strDni, out intDni)))
            {
                //throw new DniInvalidoException("Caracteres invalidos.");
            }

            return ValidarDni(nacionalidad, intDni);
        }

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

        public string StringToDNI
        {
            set
            { 
                this.dni = ValidarDni(this.Nacionalidad, value);
            }

        }

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

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
