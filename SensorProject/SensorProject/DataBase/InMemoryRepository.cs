using SensorProject.DataBase;
using SensorProject.Model;

public class InMemoryRepository 
{
    private readonly SqlLiteDbContext _context;

    public InMemoryRepository(SqlLiteDbContext sqlLiteDbContext) 
    {
        _context = sqlLiteDbContext;
    }

    public SensorEvent Insert(SensorEvent sensorEvent) 
    {
        _context.Add(sensorEvent);
        _context.SaveChanges();
        return sensorEvent; 
    }

    public IEnumerable<SensorEvent> GetAll() 
    {
        return _context.SensorEvent.ToList();
    }
}
