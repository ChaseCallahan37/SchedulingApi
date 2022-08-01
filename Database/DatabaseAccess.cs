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

        public static List<CourseModel> GetCourses()
        {
            var pulledCourses = new List<CourseModel>();
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("get_courses", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    try
                    {
                        var id = !rdr.IsDBNull("course_id") ? (string)rdr["course_id"] : "";
                        var name = !rdr.IsDBNull("name") ? (string)rdr["name"] : "";
                        var teachingStyle = !rdr.IsDBNull("teaching_style") ? (string)rdr["teaching_style"] : "";
                        var info = !rdr.IsDBNull("info") ? (string)rdr["info"] : "";
                        var availability = !rdr.IsDBNull("availability") ? JsonSerializer.Deserialize<List<DateTime>>((string)rdr["availability"]) : new List<DateTime>();
                        var resources = !rdr.IsDBNull("resources") ? JsonSerializer.Deserialize<CourseResource>((string)rdr["resources"]) : new CourseResource(0, 0);

                        var newCourse = new CourseModel(id, name, info, availability, teachingStyle, resources);
                        pulledCourses.Add(newCourse);
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
            return pulledCourses;
        }

        public static bool CreateCourse(CourseModel newCourse)
        {
            bool success;
            connection.Open();
            try
            {
                MySqlCommand cmd = new MySqlCommand("create_course", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("new_id", newCourse.Id));
                cmd.Parameters.Add(new MySqlParameter("new_name", newCourse.Name));
                cmd.Parameters.Add(new MySqlParameter("new_info", newCourse.Info));
                cmd.Parameters.Add(new MySqlParameter("new_availability",
                    JsonSerializer.Serialize<List<DateTime>>(newCourse.Availability)));
                cmd.Parameters.Add(new MySqlParameter("new_teaching_style", newCourse.TeachingStyle));
                cmd.Parameters.Add(new MySqlParameter("new_resources",
                    JsonSerializer.Serialize<CourseResource>(newCourse.Resources)));

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

        public static bool DeleteCourse(string id)
        {
            bool success;
            connection.Open();
            try
            {
                var cmd = new MySqlCommand("delete_course", connection);
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

