using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuickChart;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class TrendController : ControllerBase
{
    [HttpGet]
    /*public string GetTrend()
    {
        
        return DrawChart(2);
    }*/
    public async Task<string> GetTrendList()
    {
        long dateTo = 637803936000000000;//DateTime.Now.Ticks;
        long dateFrom = 637802208000000000;//dateTo;
        Task<string> taskString;
        string apiParam = "AggregatedData?" +
                          "options.objectId=120" +
                          "&options.dateFrom=" + dateFrom +
                          "&options.dateTo=" + dateTo +
                          "&options.pageNumber=1" +
                          "&options.itemsPerPage=1000" +
                          "&options.aggregationType=AVG" +
                          "&options.aggregationLevel=Hour";
        taskString = SvcConnector.SvcGetAsync(apiParam);
        string responseString = taskString.Result;
        var dataValues = JsonConvert.DeserializeObject<AggregatedDataDto>(responseString);
        
        
        
        
        return DrawChart(dataValues);
    }
    private string DrawChart(AggregatedDataDto values)
    {

        string lables = "'1','2','3','4,'5','6','7','8','9','10','11','12','13','14','15','16','17','18','19','20','21','22','23','24'";
        string requestData = string.Join(",", values);

      
        
        Chart chart = new Chart
        {
            Width = 500,
            Height = 300,
            Config = "{\r\n"+
                     "type: 'line',\r\n"             +
                     "data: {\r\n"                   +
                     "labels: ["                     +
                     lables                          +
                     "],\r\n"                        +
                     "datasets: [{\r\n"              +
                     "label: 'Mein Beispiel',\r\n"   +
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