using System;
using System.ComponentModel.DataAnnotations;

namespace SensorProject.Model;
public record SensorEvent 
{
    [Required]
    public Guid Id { get; init; }
    [Required]
    public string Tag { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Value { get; set; }
    public Sensor? Sensor { get; set; }
    [Required]
    public string Status { get; set; }
    public DateTime UnixToTimeStamp (long unix) {
       
        return (DateTimeOffset.FromUnixTimeSeconds(unix)).UtcDateTime;
        
    }

}

