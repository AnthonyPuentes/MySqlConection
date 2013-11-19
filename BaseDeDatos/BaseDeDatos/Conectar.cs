using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace BaseDeDatos
{
    class Conectar
    {
        public MySqlConnection Conexion;
        public Conectar()
        {
        }

        protected void abrirConexion()
        {
            string connectionString =
                "Server=localhost;" +
                "Database=programacioncsharp;" +
                "User ID= root;" +
                "Password=;" +
                "Pooling=false;";
            this.Conexion = new MySqlConnection(connectionString);
            this.Conexion.Open();
        }

        protected void cerrarConexion()
        {
            this.Conexion.Close();
            this.Conexion = null;
        }
    }
}