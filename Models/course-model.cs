using System.Collections.Generic;

namespace Models
{
    public class Course
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";

        public string Info { get; set; } = "";

        public List<Day> Availability { get; set; } = new List<Day>();

        public List<string> Resources { get; set; } = new List<string>();



    }
}