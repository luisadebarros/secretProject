using Microsoft.AspNetCore.Mvc;
using SensorProject.DataBase;
using SensorProject.Model;

namespace SensorProject.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorEventController : ControllerBase {
    private readonly DatabaseContext _context;

    public SensorEventController(DatabaseContext dataBaseContext) {
        _context = dataBaseContext;
    }

    #region GetAsync
    [HttpGet(Name = "GetSensorAsync")]
    public IEnumerable<SensorEvent> GetAllAsync() {
        return _context.SensorEvent.ToList();
    
    }

    #endregion

    #region Save
    [HttpPost(Name = "SaveSensorAsync")]
    public ActionResult SaveAsync(SensorRequest sensorEvent) {
        var hasValue = sensorEvent.Value.Count();
        var sensorObject = new SensorEvent();


        if (hasValue < 1)
        {
            sensorObject = new SensorEvent {
                Id = Guid.NewGuid(),
                Tag = sensorEvent.Tag,
                Region = sensorEvent.Tag.Split(".")[1],
                SensorName = sensorEvent.Tag.Split(".")[2],
                Value = sensorEvent.Value,
                Status = "Erro"
            };

            sensorObject.TimeStamp = sensorObject.UnixToTimeStamp(sensorEvent.TimeStamp);

        } 
        else
        {
            sensorObject = new SensorEvent {
                Id = Guid.NewGuid(),
                Tag = sensorEvent.Tag,
                Region = sensorEvent.Tag.Split(".")[1],
                SensorName = sensorEvent.Tag.Split(".")[2],
                Value = sensorEvent.Value,
                Status = "Processado"
            };

            sensorObject.TimeStamp = sensorObject.UnixToTimeStamp(sensorEvent.TimeStamp);
        }


        try
        {
            _context.SensorEvent.Add(sensorObject);
            _context.SaveChangesAsync();

        } 
        catch (Exception)
        {
            return BadRequest("Occurred an error in the request, please try again!");
        }

        return Ok("Object save in the database with sucess!");
    }

    #endregion

}
