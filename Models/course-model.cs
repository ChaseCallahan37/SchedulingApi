using System.Collections.Generic;
using System;

namespace Models
{
    public class CourseModel
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";

        public string Info { get; set; } = "";

        public List<DateTime> Availability { get; set; } = new List<DateTime>();

        public List<string> Resources { get; set; } = new List<string>();

    }
}