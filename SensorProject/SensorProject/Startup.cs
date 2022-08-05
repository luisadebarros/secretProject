using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using SensorProject.DataBase;

namespace SensorProject;
public class Startup  {

    
    public Startup(IConfiguration configuration) 
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }


    public void ConfigureServices(IServiceCollection services) {


        services.AddDbContext<SqlLiteDbContext>(opt =>
            opt.UseInMemoryDatabase("SensorList"));
    }


    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAuthorization();

        app.UseEndpoints(endpoints => {
            endpoints.MapControllers();
        });
    }
}

