using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using static ClasesInstanciables.Universidad;

namespace ClasesInstanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            random = new Random();
        }

        public Profesor() { }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<EClases>();
            _randomClases();
        }

        protected override string MostrarDatos()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendFormat("{0}\n{1}", base.MostrarDatos(), this.ParticiparEnClase());

            return datos.ToString();
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder datos = new StringBuilder();

            datos.AppendLine("CLASES DEL DIA:");

            foreach (EClases clase in this.clasesDelDia)
            {
                datos.AppendLine(clase.ToString());
            }

            return datos.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }

        private void _randomClases()
        {
            for (int i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((EClases)random.Next(3));
                System.Threading.Thread.Sleep(250);
            }
        }

        public static bool operator ==(Profesor i, EClases clase)
        {
            foreach(EClases c in i.clasesDelDia)
            {
                if (c == clase)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool operator !=(Profesor i, EClases clase)
        {
            return !(i == clase);
        }
    }
}
