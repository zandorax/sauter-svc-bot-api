using System.Net;
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
        
        Task<HttpResponseMessage> response = SvcConnector.SvcGetAsync("ActiveAlarm");
        Task<string> responseString = response.Result.Content.ReadAsStringAsync();
        var convertString = responseString.Result;

        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            var alarms = JsonConvert.DeserializeObject<List<AlarmDto>>(convertString);
            var alarmCount = alarms.Count;
            var responseAlarm = new ResponseAlarm();

            //Sortiert die Alarme nach Datum(neuste zuerst)
            alarms.Sort();
            alarms.Reverse();

            //entfert alle Alarme die maxAlarm überschreiten
            if (alarmCount > maxAlarm)
            {
                alarms.RemoveRange(maxAlarm, alarmCount - maxAlarm);
            }

            //setzt die Alarm Liste zusammen
            responseAlarm.Alarms = alarms;
            responseAlarm.size = alarmCount;
            responseAlarm.name = "Active Alarms";

            return responseAlarm;
        }

        return BadRequest(responseString);
    }
}