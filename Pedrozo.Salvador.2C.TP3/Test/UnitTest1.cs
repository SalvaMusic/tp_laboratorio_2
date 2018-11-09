using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesInstanciables;
using Archivos;
using Excepciones;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        
        /// <summary>
        /// Corrobora que el alumno no tenga atributos null
        /// </summary>
        [TestMethod]
        public void TestNewAlumno()
        {
            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);

            Assert.IsNotNull(a4.Apellido);
            Assert.IsNotNull(a4.Nombre);
            Assert.IsNotNull(a4.Nacionalidad);
        }

        /// <summary>
        /// En caso de no tener profesor para la clase, lanzará la excepción SinProfesorException
        /// </summary>
        [TestMethod]
        public void TestSinProfesorException()
        {
            Universidad gim = new Universidad();
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i1;

            try
            {
                gim += Universidad.EClases.Laboratorio;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(SinProfesorException));
            }
        }

        /// <summary>
        /// en caso de ingresar mas de 8 digitos, lanzará la excepción DniInvalidoException
        /// </summary>
        [TestMethod]

        public void TestDniInvalidoException()
        {
            try
            {
                Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234421556",
                EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(DniInvalidoException));
            }
        }

        /// <summary>
        /// Corrobora que el alumno tenga valor numerico en DNI
        /// </summary>
        [TestMethod]
        public void TestDniAlumno()
        {
            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);

            Assert.IsInstanceOfType(a4.DNI, typeof(int));
        }
    }
}
