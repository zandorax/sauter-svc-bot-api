using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlarmController : ControllerBase
{

    /// <summary>
    /// The active acknowledgeable alarms are requested.
    /// </summary>
    /// <returns>An object of the ResponseAlarm type is returned. It shows the number of pending alarms and their properties</returns>
    [HttpGet]
    public async Task<ActionResult<ResponseAlarm>> GetActiveAlarm()
    {
        try
        {
            var response = SvcConnector.SvcGetAsync("ActiveAlarm");
            //Prüft die Rückgabe der SVC API auf Fehler
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
