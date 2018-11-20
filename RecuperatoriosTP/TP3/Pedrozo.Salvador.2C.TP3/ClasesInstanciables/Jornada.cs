using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase pública Jornada. representa los alumnos, profesores y clases que se dictaran en una jornada. 
    /// </summary>
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por defecto. inicializa la lista "Alumnos".
        /// </summary>
        private Jornada ()
        {
            Alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor público de instancia. Inicializa clase e instructor.
        /// </summary>
        /// <param name="clase">Clase en la que consistirá la jornada.</param>
        /// <param name="instructor">Profesor que dará la clase</param>
        public Jornada(EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Sobreescritura del método ToString(). Informa todos los datos de una jornada.
        /// </summary>
        /// <returns>Retorna una cadena con los datos de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("CLASE DE {0} POR {1}", this.Clase, this.Instructor.ToString());
            datos.AppendLine("\nALUMNOS:");
            foreach(Alumno alumno in this.Alumnos)
            {
                datos.AppendLine(alumno.ToString());
            }

            return datos.ToString();
        }

        /// <summary>
        /// Guarda una jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>Retorna true si pudo guardar.</returns>
        public static bool Guardar(Jornada jornada)
        {
            
            Texto guardar = new Texto();
            if (guardar.Guardar("Jornada.txt", jornada.ToString()))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lee una jornada de un archivo de texto.
        /// </summary>
        /// <returns>Retorna un string con la cadena leida.</returns>
        public static string Leer()
        {
            string datos;
            Texto leer = new Texto();
            leer.Leer("Jornada.txt", out datos);

            return datos;
        }

        #region sobrecargas

        /// <summary>
        /// Una jornada será igual a un alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno participa de la jornada, sino false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach (Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Una jornada será distinto a un alumno si el mismo no participa de la clase.
        /// </summary>
        /// <param name="j">Jornada a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno no participa de la jornada, de lo contrario false.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Agrega un nuevo alumno a la lista de alumnos. 
        /// </summary>
        /// <param name="j">Jornada en cuestión.</param>
        /// <param name="a">Nuevo alumno a agregar.</param>
        /// <returns>La jornada con el nuevo alumno incluído. Si el alumno y7a esta en la jornada no lo agregará</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }

            return j;
        }
        #endregion
        #endregion

        #region Propiedades

        /// <summary>
        /// Lectura y escritura de la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Lectura y escritura de la clase.
        /// </summary>
        public EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Lectura y escritura del instructor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

    }
}
