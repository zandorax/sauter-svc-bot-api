using System.Collections.Generic;
using System.Threading.Tasks;
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

        var alarmCount = alarms.Count;

        if (alarmCount > 5)
        {
            alarms.RemoveRange(5, alarmCount - 5);                                                                          
        }

        var alarmCountObj = new Alarm(alarmCount);
        alarms.Add(alarmCountObj);
        
        return alarms;
    }
}