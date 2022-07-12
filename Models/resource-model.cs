namespace Models;

public class ResourceModel
{
    public string Id { get; set; } = "";
    public string Type { get; set; } = "";

    public string Name { get; set; } = "";

    public string Availability { get; set; } = "";

    public List<string> Constraints { get; set; } = new List<string>();
}