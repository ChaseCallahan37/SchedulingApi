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

        public static CourseModel AddCourse(CourseModel newCourse)
        {

            AllCourses.Add(newCourse);
            return newCourse;
        }

        public static CourseModel UpdateCourse(string id, CourseModel newCourse)
        {
            int index = AllCourses.FindIndex(c => c.Id.Equals(id));
            AllCourses.RemoveAt(index);
            AllCourses.Add(newCourse);
            return newCourse;
        }

        public static CourseModel DeleteCourse(string id)
        {
            CourseModel toDelete = AllCourses.Find(c => c.Id.Equals(id));
            AllCourses.Remove(toDelete);
            return toDelete;
        }
    }
}