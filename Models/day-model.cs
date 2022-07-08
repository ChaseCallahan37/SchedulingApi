namespace Models;

public class Day
{
    public string title { get; set; } = "";

    public Time start { get; set; } = new Time();

    public Time end { get; set; } = new Time();
}