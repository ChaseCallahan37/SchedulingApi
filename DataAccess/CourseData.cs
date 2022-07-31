using Models;
using System.Collections.Generic;
using Database;

namespace DataAccess
{
    public class CourseData
    {

        public static List<CourseModel> AllCourses { get; set; } = new List<CourseModel>();
        public static List<CourseModel> GetAllCourses()
        {
            AllCourses = DatabaseAccess.GetCourses();
            AllCourses.Sort();
            return AllCourses;
        }

        public static CourseModel AddCourse(CourseModel newCourse)
        {
            DatabaseAccess.CreateCourse(newCourse);
            return newCourse;
        }

        public static bool CheckIsPresent(CourseModel newCourse)
        {
            foreach (CourseModel course in AllCourses)
            {
                if (newCourse == course)
                {
                    return true;
                }
            }
            return false;
        }

        public static CourseModel UpdateCourse(string id, CourseModel newCourse)
        {
            int index = AllCourses.FindIndex(c => c.Id.Equals(id));
            AllCourses.RemoveAt(index);
            DatabaseAccess.DeleteCourse(id);
            DatabaseAccess.CreateCourse(newCourse);
            return newCourse;
        }


        public static CourseModel DeleteCourse(string id)
        {
            CourseModel toDelete = AllCourses.Find(c => c.Id.Equals(id));
            bool success = DatabaseAccess.DeleteCourse(id);
            if (success)
            {
                return toDelete;
            }
            return new CourseModel();
        }
    }
}