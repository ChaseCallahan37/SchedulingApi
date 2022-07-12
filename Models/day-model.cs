using System.Collections.Generic;

namespace Models;

public class DayModel
{
    public string title { get; set; } = "";

    public List<TimeModel> times {get; set;} = new List<TimeModel>();

}