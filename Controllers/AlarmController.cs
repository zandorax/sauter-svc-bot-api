using System.Collections.Generic;
using System.Threading.Tasks;
using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class AlarmController : ControllerBase
{
    public AlarmController()
    {

    }

    [HttpGet]
    public async Task<ActionResult<ResponseBody>> GetActiveAlarm()
    {
        
        Task<string> taskString = SvcConnector.GetAsync("ActiveAlarm");
        string responseString = taskString.Result;
        List<Alarm> alarms = JsonConvert.DeserializeObject<List<Alarm>>(responseString);
        var alarmCount = alarms.Count;

        var response = new ResponseBody();
        
        if (alarmCount > 5)
        {
            alarms.RemoveRange(5, alarmCount - 5);
        }
        
        
        response.Alarms = alarms;
        response.size = alarmCount;
        response.name = "NinjaCat hits critical";

        return response;
    }
}