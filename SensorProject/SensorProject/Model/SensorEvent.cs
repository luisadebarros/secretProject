
using System.ComponentModel.DataAnnotations;

namespace SensorProject.Model;
public record SensorEvent 
{
    [Required]
    public Guid Id { get; init; }
    [Required]
    public string Tag { get; set; }
    public DateTime TimeStamp { get; set; }
    public string? Value { get; set; }
    [Required]
    public string Status { get; set; }
    public string SensorName { get; set; }
    public string Region { get; set; }
    public DateTime UnixToTimeStamp(string unix) {
        long longUnix = 0;

        long.TryParse(unix, out longUnix);

        return (DateTimeOffset.FromUnixTimeMilliseconds(longUnix)).UtcDateTime;
    }

}

