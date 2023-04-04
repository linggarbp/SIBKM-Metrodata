using Connection.Contexts;
using Connection.Models;
using Connection.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connection.Repositories;
public class RegionRepository : IRegionRepository
{
    public List<Region> GetAll()
    {
        List<Region> regions = new List<Region>();

        //Create instance SQL Server Connection
        var connection = MyContext.GetConnection();

        //Create instance SQL Command
        SqlCommand command = new SqlCommand
        {
            Connection = connection,
            CommandText = "Select * From regions;"
        };

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Region region = new Region
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                };
                regions.Add(region);
            }
        }
        else
        {
            return null;
        }
        reader.Close();
        connection.Close();

        return regions;
    }

    public Region GetById(int id)
    {
        var region = new Region();

        //Create instance SQL Server Connection
        var connection = MyContext.GetConnection();

        {
            //Create instance SQL Command
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandText = "Select * From regions Where id = @id;"
            };

            //Create instance SQL Parameter
            SqlParameter pID = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = id
            };
            command.Parameters.Add(pID);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                region.Id = reader.GetInt32(0);
                region.Name = reader.GetString(1);
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();
        }

        return region;
    }

    public int Insert(Region region)
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
                CommandText = "Insert Into regions (name) Values (@name)",
                Transaction = transaction
            };

            SqlParameter pName = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = region.Name
            };
            command.Parameters.Add(pName);

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

    public int Update(Region region)
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
                CommandText = "Update regions Set name = @name Where id = @id;",
                Transaction = transaction
            };

            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Value = region.Id
            };
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter
            {
                ParameterName = "@name",
                SqlDbType = SqlDbType.VarChar,
                Value = region.Name
            };
            command.Parameters.Add(pName);

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

    public int Delete(int id)
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
                CommandText = "Delete From regions Where id = @id;",
                Transaction = transaction
            };

            SqlParameter pId = new SqlParameter
            {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
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
