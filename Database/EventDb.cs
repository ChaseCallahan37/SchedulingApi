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
    public class EventDb
    {

        public static List<EventModel> GetEvents()
        {
            var pulledEvents = new List<EventModel>();
            var connection = new Connection();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("get_events", connection.instance);
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
                        var constraints = !rdr.IsDBNull("constraints") ? (string)rdr["constraints"] : "";


                        var newEvent = new EventModel(id, name, availability, eventSize, constraints);
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
            bool success;
            var connection = new Connection();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("create_event", connection.instance);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("new_id", newEvent.Id));
                cmd.Parameters.Add(new MySqlParameter("new_name", newEvent.Name));
                cmd.Parameters.Add(new MySqlParameter("new_availability",
                    JsonSerializer.Serialize<List<DateTime>>(newEvent.Availability)));
                cmd.Parameters.Add(new MySqlParameter("new_size", newEvent.EventSize));
                cmd.Parameters.Add(new MySqlParameter("new_constraints", newEvent.Constraints));


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
            var connection = new Connection();
            connection.Open();
            try
            {
                var cmd = new MySqlCommand("delete_event", connection.instance);
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
        public static List<string> GetEventSizes()
        {
            var eventSizes = new List<string>();
            var connection = new Connection();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("get_event_sizes", connection.instance);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    try
                    {
                        var name = !rdr.IsDBNull("name") ? (string)rdr["name"] : "";

                        eventSizes.Add(name);
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
            return eventSizes;
        }
    }
}

