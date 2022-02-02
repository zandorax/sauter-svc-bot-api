using Microsoft.AspNetCore.Mvc;
using QuickChart;

namespace BotAPI.Controllers;

public class TrendController : ControllerBase
{
    [HttpGet]
    public string GetTrend()
    {
        return GetChart();
    }
    private string GetChart()
    {
        double[] data = new double[24];
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = 1.24*i;
        }
        string requestData = String.Join(",", data);
        
        Chart chart = new Chart
        {
            Width = 250,
            Height = 150,
            Config = "{\r\n"+
                     "type: 'line',\r\n"             +
                     "data: {\r\n"                   +
                     "labels: ['Trend', '24h'],\r\n" +
                     "datasets: [{\r\n"              +
                     "label: 'Temperature',\r\n"     +
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