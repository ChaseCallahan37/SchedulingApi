using api.Models;
using System.Collections.Generic;

namespace api.DataAccess
{
    public class CourseData
    {
        public List<Course> GetAllCourses()
        {
            List<Course> myCourses = new List<Course>();
            myCourses.Add(new Course() { Name = "MIS221", Time = "10:00-12:00" });
            myCourses.Add(new Course() { Name = "MIS321", Time = "10:00-11:00" });
            return myCourses;
        }
    }
}