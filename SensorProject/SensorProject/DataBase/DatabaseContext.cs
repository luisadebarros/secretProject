using Microsoft.EntityFrameworkCore;
using SensorProject.Model;

namespace SensorProject.DataBase;

public class DatabaseContext : DbContext 
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) {}

    public DbSet<SensorEvent> SensorEvent { get; set; }

}

