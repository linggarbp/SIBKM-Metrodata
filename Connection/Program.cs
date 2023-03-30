using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace Connection;

public class Program
{
    private static SqlConnection connection;
    private static string connectionString = "Data Source=LAPTOP-G0N22U3G;" +
        "Initial Catalog = db_hr_sibkm;Integrated Security = True; Connect Timeout = 30; Encrypt=False;";

    public static void Main()
    {
        connection = new SqlConnection(connectionString);
        try
        {
            connection.Open();
            Console.WriteLine("Connection Open!");
            Console.WriteLine();
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Connection Failed : " + ex);
        }

        GetAllCountry();
        Console.WriteLine();

        GetByIdCountry("AR");
        Console.WriteLine();

        InsertCountry("RU", "Rusia", 1);
        Console.WriteLine();
        GetByIdCountry("RU");
        Console.WriteLine();

        UpdateCountry("RU", "Uni Soviet");
        Console.WriteLine();
        GetByIdCountry("RU");
        Console.WriteLine();

        UpdateCountry("RU", 3);
        Console.WriteLine();
        GetByIdCountry("RU");
        Console.WriteLine();

        DeleteCountry("RU");
        GetByIdCountry("RU");
        Console.WriteLine();
    }

    //GET ALL : Region
    public static void GetAllRegion()
    {
        //Create instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        //Create instance SQL Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From regions;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows)
        {
            while(reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
            }
        }
        else
        {
            Console.WriteLine("Region is empty");
        }
        reader.Close();
        connection.Close();
    }

    //GET BY ID : Region
    public static void GetByIdRegion(int id)
    {
        //Create instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        //Create instance SQL Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From regions Where id = @id;";

        //Create instance SQL Parameter
        SqlParameter pID = new SqlParameter();
        pID.ParameterName = "@id";
        pID.SqlDbType = SqlDbType.Int;
        pID.Value = id;
        command.Parameters.Add(pID);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
            }
        }
        else
        {
            Console.WriteLine($"Id = {id} is not found!");
        }
        reader.Close();
        connection.Close();
    }

    //INSERT : Region
    public static void InsertRegion(string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Insert Into regions (name) Values (@name)";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Wrong! : " + ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
    // UPDATE : Region
    public static void UpdateRegion(int id, string name)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Update regions Set name = @name Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Wrong! : " + ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }

    // DELETE : Region
    public static void DeleteRegion(int id)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Delete From regions Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = SqlDbType.Int;
            pId.Value = id;
            command.Parameters.Add(pId);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Wrong! : " + ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }



    // GET ALL : Country
    public static void GetAllCountry()
    {
        //Create instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        //Create instance SQL Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From countries;";

        //Read data in Countries table
        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine("Region : " + reader[2]);
            }
        }
        else
        {
            Console.WriteLine("Country is empty");
        }
        reader.Close();
        connection.Close();
    }

    // GET BY ID : Country
    public static void GetByIdCountry(string id)
    {
        //Create instance SQL Server Connection
        connection = new SqlConnection(connectionString);

        //Create instance SQL Command
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From countries Where id = @id;";

        //Create instance SQL Parameter
        SqlParameter pID = new SqlParameter();
        pID.ParameterName = "@id";
        pID.SqlDbType = SqlDbType.VarChar;
        pID.Value = id;
        command.Parameters.Add(pID);

        //Read data Countries table by Id
        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("Id : " + reader[0]);
                Console.WriteLine("Name : " + reader[1]);
                Console.WriteLine("Region : " + reader[2]);
            }
        }
        else
        {
                Console.WriteLine($"Id = {id} is not found!");
        }
        reader.Close();
        connection.Close();
    }

    // INSERT : Country
    public static void InsertCountry(string id, string name, int region)
    {
        //Create instance SQL Server Connection
        connection = new SqlConnection(connectionString);
        connection.Open();

        //Transact-SQL Transasction made in SQL Server database
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            //Transact-SQL statement insert data Countries table
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Insert Into countries (id, name, region) Values (@id, @name, @region)",
                Transaction = transaction
            };

            //Parameters Id, Name, & Region
            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = id
            };
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = name
            };
            command.Parameters.Add(pName);

            SqlParameter pRegion = new SqlParameter
            {
                ParameterName = "@region",
                SqlDbType = SqlDbType.Int,
                Value = region
            };
            command.Parameters.Add(pRegion);

            //Execute Transact-SQL statement
            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Wrong! : " + ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }

    // UPDATE : CountryName
    public static void UpdateCountry(string id, string name)
    {
        //Create instance SQL Server Connection
        connection = new SqlConnection(connectionString);
        connection.Open();

        //Transact-SQL Transasction made in SQL Server database
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            //Transact-SQL statement update data nama in Countries table
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Update countries Set name = @name Where id = @id;",
                Transaction = transaction
            };

            //Parameters Id & Name
            SqlParameter pName = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = name
            };
            command.Parameters.Add(pName);

            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = id
            };
            command.Parameters.Add(pId);

            //Execute Transact-SQL statement
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Wrong! : " + ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }

    // UPDATE : CountryRegion
    public static void UpdateCountry(string id, int region)
    {
        //Create instance SQL Server Connection
        connection = new SqlConnection(connectionString);
        connection.Open();

        //Transact-SQL Transasction made in SQL Server database
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            //Transact-SQL statement update data region in Countries table
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Update countries Set region = @region Where id = @id;",
                Transaction = transaction
            };

            //Parameters Id & Region
            SqlParameter pRegion = new SqlParameter
            {
                ParameterName = "@region",
                SqlDbType = SqlDbType.Int,
                Value = region
            };
            command.Parameters.Add(pRegion);

            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = id
            };
            command.Parameters.Add(pId);

            //Execute Transact-SQL statement
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Wrong! : " + ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }

    // DELETE : Country
    public static void DeleteCountry(string id)
    {
        //Create instance SQL Server Connection
        connection = new SqlConnection(connectionString);
        connection.Open();

        //Transact-SQL Transasction made in SQL Server database
        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            //Transact-SQL statement delete data Countries table
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Delete From countries Where id = @id;",
                Transaction = transaction
            };

            //Parameters Id
            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = id
            };
            command.Parameters.Add(pId);

            //Execute Transact-SQL statement
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine("Something Wrong! : " + ex.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }
    }
}