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
        //Definiert die maximale Anzahl von Alarmen die im Bot dargestellt werden
        const int maxAlarm = 5;
        try
        {
            var response = SvcConnector.SvcGetAsync("ActiveAlarm");
            response.Result.EnsureSuccessStatusCode();
            Task<string> responseString = response.Result.Content.ReadAsStringAsync();
            var taskString = responseString.Result;
            var alarms = JsonConvert.DeserializeObject<List<AlarmDto>>(taskString);
            var responseAlarm = new ResponseAlarm();

            //Sucht nach allen Alarmen die noch nicht Quittiert wurden
            alarms = alarms.FindAll(ackObject => ackObject.Acknowledged == false);
            responseAlarm.Size = alarms.Count;

            //Sortiert die Alarme nach Datum(neuste zuerst)
            alarms.Sort();
            alarms.Reverse();


            /* Es wird kein Limit mehr benötigt
            //entfert alle Alarme die maxAlarm überschreiten
            if (alarms.Count > maxAlarm)
            {
                alarms.RemoveRange(maxAlarm, alarms.Count - maxAlarm);
            }*/

            //setzt die Alarm Liste zusammen
            responseAlarm.Alarms = alarms;


            return responseAlarm;
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
