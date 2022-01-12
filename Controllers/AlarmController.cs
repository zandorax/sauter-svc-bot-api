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
        var uri = "ActiveAlarm";
        Task<string> taskString = SvcConnector.GetAsync(uri);
        string responseString = taskString.Result;
        List<Alarm> alarms = JsonConvert.DeserializeObject<List<Alarm>>(responseString);
        
        return alarms;
    }

    [HttpGet("dateFrom{unixFrom:long}&dateTo{unixTo:long}&pageNumber{pageNbr:int}&itemsPerPage{items:int}")]
    public async Task<ActionResult<List<Alarm>>> GetHistoricAlarm(long? unixFrom = null, long? unixTo = null, int? pageNbr = null, int? items = null)
    {
        var uri =
            "HistoricAlarm?options.dateFrom="+unixFrom+"&options.dateTo="+unixTo+"&options.pageNumber="+pageNbr+"&options.itemsPerPage="+items;
        Task<string> taskString = SvcConnector.GetAsync(uri);
        string responseString = taskString.Result;
        List<Alarm> alarms = JsonConvert.DeserializeObject<List<Alarm>>(responseString);
        
        return alarms;
        
    }
}