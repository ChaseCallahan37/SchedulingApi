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

        public static List<ResourceModel> GetResources()
        {
            var pulledResources = new List<ResourceModel>();
            var connection = new Connection();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("get_resources", connection.instance);
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
                        var constraints = !rdr.IsDBNull("constraints") ? (string)rdr["constraints"] : "";


                        var newResource = new ResourceModel(id, name, availability, type, eventSize, constraints);
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
            var connection = new Connection();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("create_resource", connection.instance);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("new_id", newResource.Id));
                cmd.Parameters.Add(new MySqlParameter("new_name", newResource.Name));
                cmd.Parameters.Add(new MySqlParameter("new_availability",
                    JsonSerializer.Serialize<List<DateTime>>(newResource.Availability)));
                cmd.Parameters.Add(new MySqlParameter("new_type", newResource.Type));
                cmd.Parameters.Add(new MySqlParameter("new_size", newResource.EventSize));
                cmd.Parameters.Add(new MySqlParameter("new_constraints", newResource.Constraints));


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
            var connection = new Connection();
            connection.Open();
            try
            {
                var cmd = new MySqlCommand("delete_resource", connection.instance);
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

        public static List<string> GetResourceTypes()
        {
            var resourceTypes = new List<string>();
            var connection = new Connection();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("get_resource_types", connection.instance);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    try
                    {
                        var name = !rdr.IsDBNull("name") ? (string)rdr["name"] : "";

                        resourceTypes.Add(name);
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
            return resourceTypes;
        }
    }
}

