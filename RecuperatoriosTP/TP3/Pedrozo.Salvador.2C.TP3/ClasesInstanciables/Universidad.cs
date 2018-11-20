using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    /// <summary>
    /// Clase instanciable Universidad. Manejara todos los alumnos, jornadas y profesores.
    /// </summary>
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;
        #endregion

        #region Constructores

        /// <summary>
        /// Constructor por defecto. Inicializa las listas.
        /// </summary>
        public Universidad ()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método estático privado. Genera una cadena con los datos de la universidad.
        /// </summary>
        /// <param name="gim">Universidad de la que se quiere mostrar los datos.</param>
        /// <returns>Cadena con los datos de la universidad.</returns>
        private static string MostrarDatos(Universidad g)
        {
            StringBuilder datos = new StringBuilder();
            int s = g.Jornadas.Count;
            int e = g.Instructores.Count;
            int d = g.Alumnos.Count;
            datos.AppendLine("JORNADA:");
            foreach (Jornada j in g.Jornadas)
            {
                datos.Append(j.ToString());
                datos.AppendLine("<------------------------------------------------>\n");
            }
 
            return datos.ToString();
        }

        /// <summary>
        /// Sobreescritura del método ToString(). Hace públicos los datos de la universidad.
        /// </summary>
        /// <returns>Cadena con los datos de la universidad.</returns>
        public override string ToString()
        {
            return MostrarDatos(this);
        }

        /// <summary>
        /// Serializa una universidad en formato XML.
        /// </summary>
        /// <param name="gim">Universidad a serializar.</param>
        /// <returns>True si pudo guardar.</returns>
        public static bool Guardar(Universidad universidad)
        {
            Xml<Universidad> guardar = new Xml<Universidad>();
            if (guardar.Guardar("Universidad.Xml", universidad))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Deserializa una universidad guardada en formato XML.
        /// </summary>
        /// <returns>Objeto tipo Universidad con todos los datos guardados en el XML.</returns>
        public static Universidad Leer()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> leer = new Xml<Universidad>();
            leer.Leer("Universidad.Xml", out universidad);

            return universidad;
        }

        /// <summary>
        /// Una universidad es igual a un alumno si ese alumno está inscripto en la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno está inscripto en la universidad, sino false.</returns>
        public static bool operator == (Universidad g, Alumno a)
        {
            foreach(Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Una universidad es distinta a un alumno si ese alumno NO está inscripto en la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno NO está inscripto en la universidad, sino false.</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Inscribe a un alumno a la universidad (Siempre que no esté ya inscripto).
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="a">Alumno a inscribir.</param>
        /// <returns>Devuelve la universidad con el nuevo alumno cargado. 
        /// En el caso que el alumno ya estuviera inscripto, devuelve AlumnoRepetidoException</returns>
        public static Universidad operator +(Universidad g, Alumno a)
        {
            if (g != a)
            {
                g.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return g;
        }

        /// <summary>
        /// Una universidad es igual a un profesor si ese profesor es parte de la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Profesor a comparar.</param>
        /// <returns>Devuelve true si el profesor es parte de la universidad, sino false.</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor instructor in g.Instructores)
            {
                if (instructor == i)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Una universidad es distinta a un profesor si ese profesor NO es parte de la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Profesor a comparar.</param>
        /// <returns>Devuelve true si el profesor NO es parte de la universidad, sino false.</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// Agrega a un profesor a la universidad (Siempre que éste no sea ya parte de la misma).
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="a">Profesor a agregar.</param>
        /// <returns>Devuelve la universidad con el nuevo profesor cargado. 
        /// En el caso que el profesor ya fuera parte, devuelve ProfesorRepetidoException</returns>
        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
        }

        /// <summary>
        /// Devuelve el primer profesor de esa universidad que de esa clase.
        /// </summary>
        /// <param name="g">Universidad a evaluar.</param>
        /// <param name="clase">Clase que debe dar el profesor.</param>
        /// <returns>Devuelve el primer profesor que de esa clase. Si no hay ninguno lanza 
        /// SinProfesorException.</returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            foreach(Profesor p in g.Instructores)
            {
                if(p == clase)
                {
                    return p;
                }
            }

            throw new SinProfesorException();
        }
        /// <summary>
        /// Devuelve el primer profesor de esa universidad que NO de esa clase.
        /// </summary>
        /// <param name="g">Universidad a evaluar.</param>
        /// <param name="clase">Clase que NO debe dar el profesor.</param>
        /// <returns>Retorna el primer profesor que NO de esa clase. Si no hay ninguno retorna null.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Instructores)
            {
                if (p != clase)
                {
                    return p;
                }
            }

            return null;
        }

        /// <summary>
        /// Agrega una nueva jornada de clase. Asigna un profesor a la misma 
        /// y a los alumnos que tomen esa clase.
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="clase">Clase a agregar.</param>
        /// <returns>La universidad con la nueva jornada de clase cargada.</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada jornada = new Jornada(clase,(g==clase));

            foreach(Alumno a in g.Alumnos)
            {
                if (a == clase)
                {
                    jornada += a;
                }
            }
            g.Jornadas.Add(jornada);
            
            return g;
        }
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
        /// Lectura y escritura de la lista de jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        /// <summary>
        /// Indexador para las jornadas.
        /// </summary>
        /// <param name="i">Índice de la jornada.</param>
        public Jornada this[int i]
        {
            get
            {
                return this.Jornadas[i];
            }
            set
            {
                this.Jornadas[i] = value;
            }
        }

        /// <summary>
        /// Lectura y escritura de la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        #endregion

        #region Enumerados

        /// <summary>
        /// Enumerado de clases.
        /// </summary>
        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
        #endregion

    }
}
