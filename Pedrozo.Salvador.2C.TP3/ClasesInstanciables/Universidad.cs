using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace ClasesInstanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public Universidad ()
        {
            this.Alumnos = new List<Alumno>();
            this.Jornadas = new List<Jornada>();
            this.Instructores = new List<Profesor>();
        }

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

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        public static bool Guardar(Universidad universidad)
        {
            Xml<Universidad> guardar = new Xml<Universidad>();
            guardar.Guardar("Universidad.Xml", universidad);
            return true;
        }

        public static Universidad Leer()
        {
            Universidad universidad = new Universidad();
            Xml<Universidad> leer = new Xml<Universidad>();
            leer.Leer("Universidad.Xml", out universidad);

            return universidad;
        }

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

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

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

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            if (g != i)
            {
                g.Instructores.Add(i);
            }

            return g;
        }

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

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornadas; }
            set { this.jornadas = value; }
        }

        public Jornada this[int i]
        {
            get { return this.Jornadas[i]; }
            set { this.Jornadas[i] = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

       
    }
}
