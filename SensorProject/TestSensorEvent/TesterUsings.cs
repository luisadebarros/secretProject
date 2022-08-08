global using Xunit;
using SensorProject.Model;
using TestSensorEvent;

public class GenericRepositorySensorTest 
{
    // example 1
    [Fact]
    public async void SaveSensorEventorTestOne() 
    {
        var sensorData = new TestSensorEventClass().TestSensor();

        // to add mock data to sensorEvent repository - first example and equal the four
       await sensorData.SensorEvent.AddAsync(
            new SensorEvent 
            {
                Id = Guid.NewGuid(),
                Tag = "brasil.sudeste.sensor01",
                SensorName = "sensor01",
                Region = "sudeste",
                Value = "value about sensor 1",
                Status = "Processando",
                TimeStamp = (DateTimeOffset.FromUnixTimeMilliseconds(1654907415)).UtcDateTime
            });
        await sensorData.SaveChangesAsync();

        var result = sensorData.SensorEvent.ToList().First();

        Assert.NotNull(result);
        Assert.Equal("brasil.sudeste.sensor01", result.Tag);
        Assert.Equal("sensor01", result.SensorName);
        Assert.NotEmpty(result.Value);
        Assert.Equal("sudeste", result.Region);
        Assert.Equal("Processando", result.Status);
        Assert.Equal(1, result.TimeStamp.Month);
    }

    // example 2

    [Fact]
    public async void SaveSensorEventorTestTwo() {
        var sensorData = new TestSensorEventClass().TestSensor();

        // to add mock data to sensorEvent repository - example with empty value and status error
        await sensorData.SensorEvent.AddAsync(
             new SensorEvent {
                 Id = Guid.NewGuid(),
                 Tag = "brasil.sul.sensor02",
                 SensorName = "sensor02",
                 Region = "sudeste",
                 Value = "", 
                 Status = "Erro",
                 TimeStamp = (DateTimeOffset.FromUnixTimeMilliseconds(1654869000)).UtcDateTime
             });

        await sensorData.SaveChangesAsync();

        var result = (sensorData.SensorEvent.ToList())[0];

        Assert.NotNull(result);
        Assert.Equal("brasil.sul.sensor02", result.Tag);
        Assert.Equal("sensor02", result.SensorName);
        Assert.Equal("sudeste", result.Region);
        Assert.Empty(result.Value);
        Assert.Equal("Erro", result.Status);
        Assert.Equal(1, result.TimeStamp.Month);
    }

    // example 3

    [Fact]
    public async void SaveSensorEventorTestTree() {
        var sensorData = new TestSensorEventClass().TestSensor();

        // to add mock data to sensorEvent repository - example tree
        await sensorData.SensorEvent.AddAsync(
             new SensorEvent {
                 Id = Guid.NewGuid(),
                 Tag = "brasil.nordeste.sensor03",
                 SensorName = "sensor03",
                 Region = "nordeste",
                 Value = "value test",
                 Status = "Processado",
                 TimeStamp = (DateTimeOffset.FromUnixTimeMilliseconds(1638366600)).UtcDateTime
             });

        await sensorData.SaveChangesAsync();

        var result = (sensorData.SensorEvent.ToList())[0];

        Assert.NotNull(result);
        Assert.Equal("brasil.nordeste.sensor03", result.Tag);
        Assert.Equal("sensor03", result.SensorName);
        Assert.Equal("nordeste", result.Region);
        Assert.NotEmpty(result.Value);
        Assert.Equal("Processado", result.Status);
        Assert.Equal(1, result.TimeStamp.Month);
    }

    // example 4

    [Fact]
    public async void SaveSensorEventorTestFour() {
        var sensorData = new TestSensorEventClass().TestSensor();

        // to add mock data to sensorEvent repository - equal first example
        await sensorData.SensorEvent.AddAsync(
             new SensorEvent {
                 Id = Guid.NewGuid(),
                 Tag = "brasil.sudeste.sensor01",
                 SensorName = "sensor01",
                 Region = "sudeste",
                 Value = "value about sensor 1",
                 Status = "Processando",
                 TimeStamp = (DateTimeOffset.FromUnixTimeMilliseconds(1654907415)).UtcDateTime
             });
        await sensorData.SaveChangesAsync();

        var result = sensorData.SensorEvent.ToList().First();

        Assert.NotNull(result);
        Assert.Equal("brasil.sudeste.sensor01", result.Tag);
        Assert.Equal("sensor01", result.SensorName);
        Assert.NotEmpty(result.Value);
        Assert.Equal("sudeste", result.Region);
        Assert.Equal("Processando", result.Status);
        Assert.Equal(1, result.TimeStamp.Month);
    }
}