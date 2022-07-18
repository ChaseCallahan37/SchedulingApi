using System.Collections.Generic;
using System;

namespace Models
{
    public class CourseModel : IComparable<CourseModel>
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        public string Info { get; set; } = "";

        public List<DateTime> Availability { get; set; } = new List<DateTime>();

        public List<ResourceModel> Resources { get; set; } = new List<ResourceModel>();

        public int CompareTo(CourseModel other)
        {
            return this.Name.CompareTo(other.Name);
        }

    }
}