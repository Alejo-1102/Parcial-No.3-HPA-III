using MySql.Data.MySqlClient;

namespace Problema3_LoginBCrypt;

public static class Conexion
{
    private const string Cadena =
        "Server=localhost;Port=3306;Database=BD PARCIAL 3;Uid=root;Pwd=11022006Agl*;";

    public static MySqlConnection Obtener()
    {
        return new MySqlConnection(Cadena);
    }
}
