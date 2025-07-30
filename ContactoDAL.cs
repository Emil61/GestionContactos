using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace GestionContactos
{
    public class ContactoDAL : Conexion
    {
        public List<Contacto> ObtenerContactos()
        {
            List<Contacto> lista = new List<Contacto>();
            try
            {
                Abrir();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Contacto", conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Contacto
                    {
                        Id = (int)reader["Id"],
                        Nombre = reader["Nombre"].ToString(),
                        Telefono = reader["Telefono"].ToString(),
                        Email = reader["Email"].ToString()
                    });
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al obtener contactos: " + ex.Message);
            }
            finally
            {
                Cerrar();
            }

            return lista;
        }

        public void AgregarContacto(Contacto c)
        {
            try
            {
                Abrir();
                string query = "INSERT INTO Contacto (Nombre, Telefono, Email) VALUES (@Nombre, @Telefono, @Email)";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al agregar contacto: " + ex.Message);
            }
            finally
            {
                Cerrar();
            }
        }

        public void EditarContacto(Contacto c)
        {
            try
            {
                Abrir();
                string query = "UPDATE Contacto SET Nombre = @Nombre, Telefono = @Telefono, Email = @Email WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", c.Id);
                cmd.Parameters.AddWithValue("@Nombre", c.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", c.Telefono);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al editar contacto: " + ex.Message);
            }
            finally
            {
                Cerrar();
            }
        }

        public void EliminarContacto(int id)
        {
            try
            {
                Abrir();
                string query = "DELETE FROM Contacto WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al eliminar contacto: " + ex.Message);
            }
            finally
            {
                Cerrar();
            }
        }
    }
}
