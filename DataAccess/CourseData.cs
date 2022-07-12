using Models;
using System.Collections.Generic;

namespace DataAccess
{
    public class CourseData
    {

        public static List<CourseModel> AllCourses { get; set; } = new List<CourseModel>();
        public static List<CourseModel> GetAllCourses()
        {
            return AllCourses;
        }

        public static void AddCourse(CourseModel newCourse)
        {

            AllCourses.Add(newCourse);
        }

        public static void UpdateCourse(string id, CourseModel newCourse)
        {
            int index = AllCourses.FindIndex(c => c.Id.Equals(id));
            AllCourses.RemoveAt(index);
            AllCourses.Add(newCourse);
        }
    }
}