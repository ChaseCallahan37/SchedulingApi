namespace Models
{
    public class Time
    {
        public string Hour { get; set; } = "";
        public string Minute { get; set; } = "";

        public bool Pm { get; set; } = false;

        public int Military { get; set; } = 0;

    }
}