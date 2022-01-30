using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlarmController : ControllerBase
{

    [HttpGet]
    public async Task<ActionResult<ResponseAlarm>> GetActiveAlarm()
    {
        const int maxAlarm = 5;
        
        Task<string> taskString = SvcConnector.SvcGetAsync("ActiveAlarm");
        string responseString = taskString.Result;
        var alarms = JsonConvert.DeserializeObject<List<AlarmDto>>(responseString);
        var alarmCount = alarms.Count;
        var response = new ResponseAlarm();
        
        //Sortiert die Alarme nach Datum(neuste zuerst)
        alarms.Sort();
        alarms.Reverse();
        
        //entfert alle Alarme die maxAlarm überschreiten
        if (alarmCount > maxAlarm)
        {
            alarms.RemoveRange(maxAlarm, alarmCount - maxAlarm);
        }
        
        //setzt die Alarm Liste zusammen
        response.Alarms = alarms;
        response.size = alarmCount;
        response.name = "Active Alarms";

        return response;
    }
}