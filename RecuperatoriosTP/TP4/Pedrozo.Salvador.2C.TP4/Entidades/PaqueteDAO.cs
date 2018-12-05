using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    /// <summary>
    /// Clase estática para manejar base de datos
    /// </summary>
    public static class PaqueteDAO
    {
        #region Atributos
        static SqlCommand comandoSql;
        static SqlConnection conexion;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor por estático, inicializa SqlCommand y SqlConnection
        /// </summary>
        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source =.\\SQLEXPRESS; Initial Catalog = correo-sp-2017; Integrated Security = True");
            comandoSql = new SqlCommand();
            comandoSql.CommandType = System.Data.CommandType.Text;
            comandoSql.Connection = conexion;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Metodo estatico Insertar, recibe un paquete y lo inserta en la base de datos
        /// </summary>
        /// <param name="p">Paquete a insertar</param>
        /// <returns>True si lo logro</returns>
        public static bool Insertar(Paquete p)
        {
            
            try
            {
                String consulta = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno)  VALUES ('{0}', '{1}', '{2}')",
                p.DireccionEntrega, p.TrackingID, "Salvador Pedrozo");
                conexion.Open();
                comandoSql.CommandText = consulta;
                comandoSql.ExecuteNonQuery();
                conexion.Close();
                return true;
            }
            catch(Exception e)
            {
                throw new Exception("Error Base de datos", e);
            }
            finally
            {
                conexion.Close();
            }

        } 
        #endregion



    }
}
