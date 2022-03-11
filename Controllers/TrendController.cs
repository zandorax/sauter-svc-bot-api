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
    /// <summary>
    /// Query data over 24 hours. they are hourly averages.
    /// </summary>
    /// <param name="objectId">Datapoint Id</param>
    /// <returns>The return is a URL to the chart with the requested data</returns>
    [HttpGet("day")]
    public async Task<string> GetTrendDay(int? objectId)
    {
        //Generiert die Zeitstempel für die Abfrage
        long dateTo = DateTime.Now.Ticks;
        long dateFrom = dateTo - (TimeSpan.TicksPerHour * 24);
        string apiParam = "AggregatedData?" +
                          "options.objectId="  + objectId +
                          "&options.dateFrom=" + dateFrom +
                          "&options.dateTo="   + dateTo +
                          "&options.pageNumber=1" +
                          "&options.itemsPerPage=30" +
                          "&options.aggregationType=AVG" +
                          "&options.aggregationLevel=Hour";
        try
        {
            var response = SvcConnector.SvcGetAsync(apiParam);
            //Prüft die Rückgabe der SVC API auf Fehler
            response.Result.EnsureSuccessStatusCode();
            Task<string> responseString = response.Result.Content.ReadAsStringAsync();
            var taskString = responseString.Result;
            var dataValues = JsonConvert.DeserializeObject<AggregatedDataDto>(taskString);
            
            //Zusammenstellen der Labels für die X-Achse
            string[] labelArray = new string[24];
            for (int i = 0; i < 24; i++)
            {
                var dateFromTicks = new DateTime(dateTo - (TimeSpan.TicksPerHour * i));
                labelArray[i] = string.Concat("'" + dateFromTicks.ToString("yyyy-M-d HH:mm") + "'");
            }
            
            Array.Reverse(labelArray);
            var labels = String.Join(",", labelArray);
            
            return DrawChart(dataValues, labels);
        }
        catch(HttpRequestException exception)
        {
            return exception.Message;
        }
    }
    
    /// <summary>
    /// Query data over 7 days. they are daily averages.
    /// </summary>
    /// <param name="objectId">Datapoint Id</param>
    /// <returns>The return is a URL to the chart with the requested data</returns>
    [HttpGet("week")]
    public async Task<string> GetTrendWeek(int? objectId)
    {
        long dateTo = DateTime.Now.Ticks;
        long dateFrom = dateTo - (TimeSpan.TicksPerDay * 7);
        string apiParam = "AggregatedData?" +
                          "options.objectId="  + objectId +
                          "&options.dateFrom=" + dateFrom +
                          "&options.dateTo="   + dateTo +
                          "&options.pageNumber=1" +
                          "&options.itemsPerPage=30" +
                          "&options.aggregationType=AVG" +
                          "&options.aggregationLevel=Day";
        try
        {
            var response = SvcConnector.SvcGetAsync(apiParam);
            response.Result.EnsureSuccessStatusCode();
            Task<string> responseString = response.Result.Content.ReadAsStringAsync();
            var taskString = responseString.Result;
            var dataValues = JsonConvert.DeserializeObject<AggregatedDataDto>(taskString);

            //Zusammenstellen der Labels für die X-Achse
            string[] labelArray = new string[7];
            for (int i = 0; i < 7; i++)
            {
                var dateFromTicks = new DateTime(dateTo - (TimeSpan.TicksPerDay * (i + 1)));
                labelArray[i] = string.Concat("'" + dateFromTicks.ToString("d") + "'");
            }
            Array.Reverse(labelArray);
            var labels = String.Join(",", labelArray);

            return DrawChart(dataValues, labels);
        }
        catch (HttpRequestException exception)
        {
            return exception.Message;
        }
    }
    
    //Erstellt die Konfiguration für Chart.js respektive QuickChart
    private string DrawChart(AggregatedDataDto values , string labels)
    {
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