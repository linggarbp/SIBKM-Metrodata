using Connection.Contexts;
using Connection.Models;
using Connection.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connection.Repositories;
public class CountryRepository : ICountryRepository
{
    public List<Country> GetAll()
    {
        List<Country> countries = new List<Country>();

        //Create instance SQL Server Connection
        var connection = MyContext.GetConnection();

        //Create instance SQL Command
        SqlCommand command = new SqlCommand
        {
            Connection = connection,
            CommandText = "Select * From countries;"
        };

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Country country= new Country
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Region = reader.GetInt32(2)
                };
                countries.Add(country);
            }
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();

        return countries;
    }

    public Country GetById(string id)
    {
        var country = new Country();

        //Create instance SQL Server Connection
        var connection = MyContext.GetConnection();

        //Create instance SQL Command
        SqlCommand command = new SqlCommand
        {
            Connection = connection,
            CommandText = "Select * From countries Where id = @id;"
        };

        //Create instance SQL Parameter
        SqlParameter pID = new SqlParameter
        {
            ParameterName = "@id",
            SqlDbType = SqlDbType.VarChar,
            Value = id
        };
        command.Parameters.Add(pID);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();
            country.Id = reader.GetString(0);
            country.Name = reader.GetString(1);
            country.Region = reader.GetInt32(2);
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();

        return country;
    }

    public int Insert(Country country)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Insert Into countries (id, name, region) Values (@id, @name, @region)",
                Transaction = transaction
            };

            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = country.Id
            };
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = country.Name
            };
            command.Parameters.Add(pName);

            SqlParameter pRegion = new SqlParameter
            {
                ParameterName = "@region",
                SqlDbType = SqlDbType.Int,
                Value = country.Region
            };
            command.Parameters.Add(pRegion);

            result = command.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();
        }
        catch
        {
            try
            {
                transaction.Rollback();
            }
            catch
            {
                throw;
            }
        }

        return result;
    }

    public int Update(Country country)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Update countries Set name = @name, region = @region Where id = @id;",
                Transaction = transaction
            };

            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = country.Id
            };
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = country.Name
            };
            command.Parameters.Add(pName);

            SqlParameter pRegion = new SqlParameter
            {
                ParameterName = "@region",
                SqlDbType = SqlDbType.Int,
                Value = country.Region
            };
            command.Parameters.Add(pRegion);

            result = command.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();
        }
        catch
        {
            try
            {
                transaction.Rollback();
            }
            catch
            {
                throw;
            }
        }

        return result;
    }

    public int Delete(string id)
    {
        var result = 0;
        var connection = MyContext.GetConnection();
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Delete From countries Where id = @id;",
                Transaction = transaction
            };

            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.VarChar,
                Value = id
            };
            command.Parameters.Add(pId);

            result = command.ExecuteNonQuery();

            transaction.Commit();
            connection.Close();
        }
        catch
        {
            try
            {
                transaction.Rollback();
            }
            catch
            {
                throw;
            }
        }

        return result;
    }
}
