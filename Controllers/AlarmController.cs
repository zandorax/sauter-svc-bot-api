using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlarmController : ControllerBase
{
    public AlarmController()
    {

    }

    [HttpGet]
    public async Task<ActionResult<List<Alarm>>> GetActiveAlarm()
    {
        Task<string> taskString = SvcConnector.GetAsync("ActiveAlarm");
        string responseString = taskString.Result;
        List<Alarm> alarms = JsonConvert.DeserializeObject<List<Alarm>>(responseString);
        
        return alarms;
    }
}