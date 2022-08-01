namespace Models
{
    public class CourseResource
    {
        public int Instructors { get; set; }

        public int Tas { get; set; }

        public CourseResource() { }
        public CourseResource(int instructors, int tas)
        {
            Instructors = instructors;
            Tas = tas;
        }
    }
}