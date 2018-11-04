using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private EClases clase;
        private Profesor instructor;

        private Jornada ()
        {
            Alumnos = new List<Alumno>();
        }

        public Jornada(EClases clase, Profesor instructor)
            :this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            foreach(Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j != a)
            {
                j.Alumnos.Add(a);
            }

            return j;
        }

        public override string ToString()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("CLASE DE {0} POR {1}",this.Clase, this.Instructor.ToString());
            datos.AppendLine("ALUMNOS:");
            foreach(Alumno alumno in this.Alumnos)
            {
                datos.AppendLine(alumno.ToString());
            }

            return datos.ToString();
        }

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value;  }
        }
    }
}
