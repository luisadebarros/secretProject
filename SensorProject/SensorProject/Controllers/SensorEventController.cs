
using Microsoft.AspNetCore.Mvc;
using SensorProject.Model;

namespace SensorProject.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorEventController : ControllerBase {
    private readonly InMemoryRepository _context;

    public SensorEventController(InMemoryRepository inMemoryRepository) {
        _context = inMemoryRepository;
    }

    #region GetAsync
    [HttpGet(Name = "GetSensorAsync")]
    public IEnumerable<SensorEvent> GetAllAsync() {

        return _context.GetAll();
    }

    #endregion

    #region Save
    [HttpPost(Name = "SaveSensorAsync")]
    public ActionResult SaveAsync(SensorRequest sensorEvent) {
        var hasTag = sensorEvent.Tag.Split('.').Count();
        var sensorObject = new SensorEvent();

        if (hasTag > 0)
        {
            sensorObject = new SensorEvent {
                Id = new Guid(),
                Tag = sensorEvent.Tag,
                Sensor = {
                    Region = "Erro",
                    SensorName = "Erro"
                },
                Value = sensorEvent.Value,
                Status = "Erro"
            };

            sensorObject.TimeStamp = sensorObject.UnixToTimeStamp(sensorEvent.TimeStamp);
           
        } 
        else
        { 
            sensorObject = new SensorEvent {
                Id = new Guid(),
                Tag = sensorEvent.Tag,
                Sensor = {
                    Region = sensorEvent.Tag.Split(".")[0],
                    SensorName = sensorEvent.Tag[1].ToString()
                },
                Value = sensorEvent.Value,
                Status = "Processado"
            };

            sensorObject.TimeStamp =  sensorObject.UnixToTimeStamp(sensorEvent.TimeStamp);
        }


        try
        {
          _context.Insert(sensorObject);
        } catch (Exception)
        {

            return BadRequest();
        }

        return StatusCode(200);
    }

    #endregion

    #region GetBySensor
    [HttpGet("{sensor}", Name = "GetBySensor")]
    public Task<ActionResult<SensorEvent>> GetBySensor(string sensor) {
        throw new NotImplementedException();
    }
    #endregion

}
