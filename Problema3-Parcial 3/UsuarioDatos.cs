using MySql.Data.MySqlClient;

namespace Problema3_LoginBCrypt;

public static class UsuarioDatos
{
    public static bool Registrar(string nombreUsuario, string nombreCompleto, string clave)
    {
        using (MySqlConnection con = Conexion.Obtener())
        {
            con.Open();

            using (MySqlCommand existe = new MySqlCommand(
                "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @u", con))
            {
                existe.Parameters.AddWithValue("@u", nombreUsuario);
                if (Convert.ToInt32(existe.ExecuteScalar()) > 0)
                    return false;
            }

            // Generar hash
            string hash = BCrypt.Net.BCrypt.HashPassword(clave);

            using (MySqlCommand insertar = new MySqlCommand(
                "INSERT INTO usuarios (nombre_usuario, nombre_completo, password_hash) " +
                "VALUES (@u, @n, @h)", con))
            {
                insertar.Parameters.AddWithValue("@u", nombreUsuario);
                insertar.Parameters.AddWithValue("@n", nombreCompleto);
                insertar.Parameters.AddWithValue("@h", hash);
                insertar.ExecuteNonQuery();
            }
            return true;
        }
    }

    public static bool ValidarLogin(string nombreUsuario, string clave, out string nombreCompleto)
    {
        nombreCompleto = "";
        bool exitoso = false;

        using (MySqlConnection con = Conexion.Obtener())
        {
            con.Open();

            using (MySqlCommand buscar = new MySqlCommand(
                "SELECT password_hash, nombre_completo FROM usuarios " +
                "WHERE nombre_usuario = @u", con))
            {
                buscar.Parameters.AddWithValue("@u", nombreUsuario);

                using (MySqlDataReader lector = buscar.ExecuteReader())
                {
                    if (lector.Read())
                    {
                        string hashGuardado = lector.GetString("password_hash");

                        // Verificar clave
                        if (BCrypt.Net.BCrypt.Verify(clave, hashGuardado))
                        {
                            exitoso = true;
                            nombreCompleto = lector.GetString("nombre_completo");
                        }
                    }
                }
            }

            using (MySqlCommand intento = new MySqlCommand(
                "INSERT INTO intentos_login (nombre_usuario, exitoso) VALUES (@u, @e)", con))
            {
                intento.Parameters.AddWithValue("@u", nombreUsuario);
                intento.Parameters.AddWithValue("@e", exitoso ? 1 : 0);
                intento.ExecuteNonQuery();
            }
        }

        return exitoso;
    }
}
