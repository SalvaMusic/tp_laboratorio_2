using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand comandoSql;
        static SqlConnection conexion;

        static PaqueteDAO()
        {
            conexion = new SqlConnection("Data Source = ./SQLEXPRESS;Initial Catalog = Paquetes; Integrated Security = True");
            comandoSql = new SqlCommand();
            comandoSql.Connection = conexion;
            comandoSql.CommandType = System.Data.CommandType.Text;
        }

        public static bool Insertar(Paquete p)
        {
            String consulta = String.Format("INSERT INTO Paquetes (direccionEntrega, trackingID, alumno)  VALUES ('{0}', '{1}', '{2}')", 
                p.DireccionEntrega, p.TrackingID,"Salvador Pedrozo");
            conexion.Open();
            comandoSql.CommandText = consulta;
            comandoSql.ExecuteNonQuery();
            conexion.Close();
            return false;
        }

        

    }
}
