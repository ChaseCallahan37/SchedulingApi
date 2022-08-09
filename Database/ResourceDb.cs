using System;
using System.Data;
using System.Collections.Generic;
using System.Text.Json;
using MySql.Data.MySqlClient;
using Models;
using DataAccess;
using Models;

namespace Database
{
    public class ResourceDb
    {

        static string connectionString = "server=scheduling-db.cjmckd98ubrp.us-east-2.rds.amazonaws.com;uid=admin;pwd=13153Lakearnedra!;database=scheduling";
        static MySqlConnection connection = new MySqlConnection(connectionString);

        public static List<ResourceModel> GetResources()
        {
            var pulledResources = new List<ResourceModel>();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("get_resources", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    try
                    {
                        var id = !rdr.IsDBNull("resource_id") ? (string)rdr["Resource_id"] : "";
                        var name = !rdr.IsDBNull("name") ? (string)rdr["name"] : "";
                        var availability = !rdr.IsDBNull("availability")
                            ? JsonSerializer.Deserialize<List<DateTime>>((string)rdr["availability"])
                            : new List<DateTime>();
                        var type = !rdr.IsDBNull("type") ? (string)rdr["type"] : "";
                        var eventSize = !rdr.IsDBNull("event_size") ? (string)rdr["event_size"] : "";


                        var newResource = new ResourceModel(id, name, availability, type, eventSize);
                        pulledResources.Add(newResource);
                    }
                    catch (MySql.Data.MySqlClient.MySqlException ex)
                    {
                        System.Console.WriteLine($"This is the exception: {ex}");

                    }

                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine($"This is the exception: {ex}");
            }
            finally
            {
                connection.Close();
            }
            return pulledResources;
        }

        public static bool CreateResource(ResourceModel newResource)
        {
            bool success;
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("create_resource", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("new_id", newResource.Id));
                cmd.Parameters.Add(new MySqlParameter("new_name", newResource.Name));
                cmd.Parameters.Add(new MySqlParameter("new_availability",
                    JsonSerializer.Serialize<List<DateTime>>(newResource.Availability)));
                cmd.Parameters.Add(new MySqlParameter("new_size", newResource.EventSize));


                cmd.ExecuteNonQuery();

                success = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine($"This is the exception: {ex}");
                success = false;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }

        public static bool DeleteResource(string id)
        {
            bool success;
            connection.Open();
            try
            {
                var cmd = new MySqlCommand("delete_resource", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("id", id));

                cmd.ExecuteNonQuery();

                success = true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Console.WriteLine($"This is the exception: {ex}");
                success = false;
            }
            finally
            {
                connection.Close();
            }
            return success;
        }
    }
}
