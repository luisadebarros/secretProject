namespace SensorProject.Model;
public record SensorRequest 
{

    public string TimeStamp { get; set; }
    public string Tag { get; set; }
    public string Value { get; set; }
}

