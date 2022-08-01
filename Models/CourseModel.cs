using System.Collections.Generic;
using System;

namespace Models
{
    public class CourseModel : IComparable<CourseModel>
    {
        public string Id { get; set; } = "";
        public string TeachingStyle { get; set; } = "";
        public string Name { get; set; } = "";

        public string Info { get; set; } = "";

        public List<DateTime> Availability { get; set; } = new List<DateTime>();


        public CourseResource Resources { get; set; }

        public CourseModel()
        {

        }

        public CourseModel(string id, string name, string info, List<DateTime> availability, string teachingStyle, CourseResource resources)
        {
            Id = id;
            Name = name;
            Info = info;
            Availability = availability;
            TeachingStyle = teachingStyle;
            Resources = resources;
        }



        public int CompareTo(CourseModel other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public string ToString()
        {
            return $"ID: {this.Id} Name: {this.Name} Info: {this.Info} Teaching Style: {this.TeachingStyle}";
        }

    }
}