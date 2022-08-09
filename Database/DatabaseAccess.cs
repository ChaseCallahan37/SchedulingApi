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
    public class DatabaseAccess
    {

        static string connectionString = "server=scheduling-db.cjmckd98ubrp.us-east-2.rds.amazonaws.com;uid=admin;pwd=13153Lakearnedra!;database=scheduling";
        static MySqlConnection connection = new MySqlConnection(connectionString);

        public static List<EventModel> GetEvents()
        {
            var pulledEvents = new List<EventModel>();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("get_events", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    try
                    {
                        var id = !rdr.IsDBNull("event_id") ? (string)rdr["event_id"] : "";
                        var name = !rdr.IsDBNull("name") ? (string)rdr["name"] : "";
                        var availability = !rdr.IsDBNull("availability") ? JsonSerializer.Deserialize<List<DateTime>>((string)rdr["availability"]) : new List<DateTime>();
                        var eventSize = !rdr.IsDBNull("event_size") ? (string)rdr["event_size"] : "";


                        var newEvent = new EventModel(id, name, availability, eventSize);
                        pulledEvents.Add(newEvent);
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
            return pulledEvents;
        }

        public static bool CreateEvent(EventModel newEvent)
        {
            // newEvent.Id = "be3a5483-7b05-4b56-962e-13fe36c5e3ca";
            // newEvent.Name = "MIS 421";
            // newEvent.Availability = new List<DateTime> { DateTime.Now, DateTime.Now };
            // newEvent.EventSize = "medium";
            bool success;
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("create_event", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("new_id", newEvent.Id));
                cmd.Parameters.Add(new MySqlParameter("new_name", newEvent.Name));
                cmd.Parameters.Add(new MySqlParameter("new_availability",
                    JsonSerializer.Serialize<List<DateTime>>(newEvent.Availability)));
                cmd.Parameters.Add(new MySqlParameter("new_size", newEvent.EventSize));


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

        public static bool DeleteEvent(string id)
        {
            bool success;
            connection.Open();
            try
            {
                var cmd = new MySqlCommand("delete_event", connection);
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

