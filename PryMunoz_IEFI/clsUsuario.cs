using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data.OleDb;

namespace PryMunoz_IEFI
{
    internal class clsUsuario
    {
        public static bool RegistrarUsuario(string nombre, string contraseña, string categoria)
        {
            try
            {
                using (OleDbConnection conexion = clsConexion.Conexion()) // Usa tu método que devuelve una conexión abierta
                {
                    string consulta = "INSERT INTO Crear (Nombre, Contraseña, Categoria) VALUES (?, ?, ?)";

                    using (OleDbCommand comando = new OleDbCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("?", nombre);
                        comando.Parameters.AddWithValue("?", contraseña);
                        comando.Parameters.AddWithValue("?", categoria);

                        int filasAfectadas = comando.ExecuteNonQuery();
                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar usuario: " + ex.Message);
                return false;
            }
        }

        public static bool UsuarioExiste(string usuario)
        {
            using (OleDbConnection conexion = clsConexion.Conexion())
            {
                string consulta = "SELECT COUNT(*) FROM Crear WHERE Nombre = ?";
                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                comando.Parameters.AddWithValue("?", usuario);

                int count = (int)comando.ExecuteScalar();
                return count > 0;
            }
        }

        public static bool ActualizarContrasena(string usuario, string nuevaContrasena)
        {
            using (OleDbConnection conexion = clsConexion.Conexion())
            {
                string consulta = "UPDATE Crear SET Contraseña = ? WHERE Nombre = ?";
                OleDbCommand comando = new OleDbCommand(consulta, conexion);
                comando.Parameters.AddWithValue("?", nuevaContrasena);
                comando.Parameters.AddWithValue("?", usuario);

                int filas = comando.ExecuteNonQuery();
                if (filas > 0)
                {
                    MessageBox.Show("Contraseña Reestablecida.");
                    return true;
                }
                else
                {
                    MessageBox.Show("No se pudo Reestablecer la contraseña.");
                    return false;
                }
            }
        }

        public static bool EliminarUsuario(string usuario, string contrasena)
        {
            using (OleDbConnection conexion = clsConexion.Conexion())
            {
                string consulta = "DELETE FROM Crear WHERE Nombre = ? AND Contraseña = ?";
                OleDbCommand comando = new OleDbCommand(consulta, conexion);

                comando.Parameters.AddWithValue("?", usuario);
                comando.Parameters.AddWithValue("?", contrasena);

                int filas = comando.ExecuteNonQuery();
                return filas > 0;
            }
        }







    }
}
