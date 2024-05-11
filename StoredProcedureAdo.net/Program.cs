using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;

class Program
{
    public static void Main(string[] args)
    {
        //Program.SP_WithoutInput_and_Output();
        Program.SP_WithInput_and_Without_Output(2);
    }
    public static void SP_WithoutInput_and_Output()
    {
        string connectionString = "data source= SALEEJK; database= master;integrated security=SSPI;TrustServerCertificate=True";
        using(SqlConnection connection=new SqlConnection(connectionString))
        {
            connection.Open();
            SqlCommand command = new SqlCommand("getFromStudent", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader=command.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"{reader[0]}{reader[1]}{reader[2]}");
            }
        }
    }
    //public static void SP_WithInput_and_Without_Output(int id)
    //{
    //    string connectionString= "data source= SALEEJK; database= master;integrated security=SSPI;TrustServerCertificate=True";
    //    using(SqlConnection connection=new SqlConnection(connectionString))
    //    {
    //        connection.Open();
    //        SqlCommand command = new SqlCommand("getById", connection);
    //        command.CommandType = CommandType.StoredProcedure;
    //        command.Parameters.AddWithValue("id", id);
    //        SqlDataReader reader=command.ExecuteReader();
    //        while(reader.Read())
    //        {
    //            Console.WriteLine($"{reader[0]}{reader[1]}{reader[2]}");
    //        }
    //    }
    //}
    public static void SP_WithInput_and_Without_Output(int id)
    {
        try
        {
            string connectionString= "data source= SALEEJK; database= master;integrated security=SSPI;TrustServerCertificate=True";
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("getById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader[0]}{reader[1]}");
                }
            }
        }catch(Exception ex)
        {
            Console.WriteLine($"failed to read {ex}");
        }
    }
}