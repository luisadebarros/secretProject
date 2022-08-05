
using Microsoft.EntityFrameworkCore;
using SensorProject.Model;

namespace SensorProject.DataBase;

public class SqlLiteDbContext : DbContext 
{
    public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options) : base(options) {

    }

    public DbSet<SensorEvent> SensorEvent { get; set; }

}

