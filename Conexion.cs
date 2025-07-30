using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace GestionContactos
{
    public class Conexion
    {
        protected SqlConnection conexion = new SqlConnection(
         "Data Source=localhost;Initial Catalog=ContactosDB;Integrated Security=True");

        public void Abrir()
        {
            if (conexion.State == System.Data.ConnectionState.Closed)
                conexion.Open();
        }

        public void Cerrar()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}