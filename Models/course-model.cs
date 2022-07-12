using System.Collections.Generic;

namespace Models
{
    public class CourseModel
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";

        public string Info { get; set; } = "";

        public List<DayModel> Availability { get; set; } = new List<DayModel>();

        public List<string> Resources { get; set; } = new List<string>();



    }
}