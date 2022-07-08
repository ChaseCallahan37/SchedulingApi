using Models;
using System.Collections.Generic;

namespace DataAccess
{
    public class CourseData
    {
        public List<Course> GetAllCourses()
        {
            List<Course> myCourses = new List<Course>();
            myCourses.Add(new Course() { Id = "abc 123", Title = "MIS 221", Info = "Covers Coding", Availability = new List<Day>() { new Day() { title = "Monday", start = new Time() { Hour = "12", Minute = "30", Pm = true, Military = 1230 }, end = new Time() { Hour = "4", Minute = "45", Pm = true, Military = 1645 } } }, Resources = new List<string>() { "abc 123", "def 456" } });
            return myCourses;
        }
    }
}