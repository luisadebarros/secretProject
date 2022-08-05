namespace SensorProject.Model;
public record SensorRequest 
{
    
    public string Tag { get; set; }
    public long TimeStamp { get; set; }
    public string Value { get; set; }
}

