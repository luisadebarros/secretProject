using Microsoft.EntityFrameworkCore;
using SensorProject.DataBase;
using SensorProject.Model;

namespace TestSensorEvent;
public class TestSensorEventClass 
{

    public TestSensorEventClass() {
    }

    public DatabaseContext TestSensor() {
        var builder = new DbContextOptionsBuilder<DatabaseContext>();
        builder.UseInMemoryDatabase("SensorEventInMemoryTest");

        var context = new DatabaseContext(builder.Options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }

  
}
