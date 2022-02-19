using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickChart;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class TrendController : ControllerBase
{
    [HttpGet("day")]
    public async Task<string> GetTrendDay(int objectId)
    {
        long dateTo = DateTime.Now.Ticks;
        long dateFrom = dateTo - (TimeSpan.TicksPerHour * 24);
        Task<string> taskString;
        string apiParam = "AggregatedData?" +
                          "options.objectId="  + objectId +
                          "&options.dateFrom=" + dateFrom +
                          "&options.dateTo="   + dateTo +
                          "&options.pageNumber=1" +
                          "&options.itemsPerPage=30" +
                          "&options.aggregationType=AVG" +
                          "&options.aggregationLevel=Hour";
        
        taskString = SvcConnector.SvcGetAsync(apiParam);
        string responseString = taskString.Result;
        var dataValues = JsonConvert.DeserializeObject<AggregatedDataDto>(responseString);
        string[] labelArray = new string[24];
        for (int i = 0; i < 24; i++)
        {
            var dateFromTicks = new DateTime(dateTo - (TimeSpan.TicksPerHour * (i+1)));
            labelArray[i] = string.Concat("'"+ dateFromTicks.ToString("HH:mm")+"'");
        }
        var labels = String.Join(",", labelArray);
        return DrawChart(dataValues, labels);
    }

    [HttpGet("Week")]
    public async Task<string> GetTrendWeek(int objectId)
    {
        long dateTo = DateTime.Now.Ticks;
        long dateFrom = dateTo - (TimeSpan.TicksPerDay * 7);
        Task<string> taskString;
        string apiParam = "AggregatedData?" +
                          "options.objectId="  + objectId +
                          "&options.dateFrom=" + dateFrom +
                          "&options.dateTo="   + dateTo +
                          "&options.pageNumber=1" +
                          "&options.itemsPerPage=30" +
                          "&options.aggregationType=AVG" +
                          "&options.aggregationLevel=Hour";
        
        taskString = SvcConnector.SvcGetAsync(apiParam);
        string responseString = taskString.Result;
        var dataValues = JsonConvert.DeserializeObject<AggregatedDataDto>(responseString);
        
        string[] labelArray = new string[7];
        for (int i = 0; i < 7; i++)
        {
            var dateFromTicks = new DateTime(dateTo - (TimeSpan.TicksPerDay * (i+1)));
            labelArray[i] = string.Concat("'"+ dateFromTicks.ToString("HH:mm")+"'");
        }
        var labels = String.Join(",", labelArray);
        
        return DrawChart(dataValues, labels);
    }
    
    private string DrawChart(AggregatedDataDto values , string labels)
    {

        //string lables = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24";
        string[] requestDataArray = new String[values.AggregatedDataValues.Count];
        string label = "Trend für Objekt";
        for(int i = 0; i < values.AggregatedDataValues.Count; i++)
        {
            requestDataArray[i] = string.Concat(values.AggregatedDataValues[i].AggregatedValue);
        }

        var requestData = String.Join(",", requestDataArray);
        
        Chart chart = new Chart
        {
            Width = 500,
            Height = 300,
            Config = "{\r\n"+
                     "type: 'line',\r\n"             +
                     "data: {\r\n"                   +
                     "labels: ["                     +
                     labels                          +
                     "],\r\n"                        +
                     "datasets: [{\r\n"              +
                     "label: '"+label+"',\r\n"   +
                     "data: ["                       +
                     requestData                     +
                     "]\r\n"                         +
                     "}]\r\n"                        +
                     "}\r\n"                         +
                     "}"
        };
        return chart.GetUrl(); 

    }
}