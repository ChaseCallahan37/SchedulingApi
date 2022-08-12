using MySql.Data.MySqlClient;

namespace Database
{
    public class Connection
    {
        // public static string connectionString = "server=scheduling-db.cjmckd98ubrp.us-east-2.rds.amazonaws.com;uid=admin;pwd=13153Lakearnedra!;database=scheduling";
        public static string connectionString = "server=127.0.0.1;uid=admin;pwd=password;database=scheduling";

        public static MySqlConnection instance = new MySqlConnection(connectionString);
    }
}