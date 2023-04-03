using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Contexts;
public class MyContext
{
    private static SqlConnection connection;

    private static string connectionString = "Data Source=LAPTOP-G0N22U3G;" +
        "Initial Catalog = db_hr_sibkm;Integrated Security = True; Connect Timeout = 30; Encrypt=False;";
    public static SqlConnection GetConnection() 
    {
        try
        {
            connection = new SqlConnection(connectionString);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return connection;
    }
}

