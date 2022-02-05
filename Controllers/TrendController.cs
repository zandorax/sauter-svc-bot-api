using Microsoft.AspNetCore.Mvc;
using QuickChart;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]

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
        data[0] = 25;
        for (int i = 1; i < 4; i++)
        {
            data[i] = 20*i;
        }

        data[4] = 80;
        for (int i = 5; i < data.Length; i++)
        {
            data[i] = 1.968*i;
        }
        
        string requestData = String.Join(",", data);
        
        Chart chart = new Chart
        {
            Width = 500,
            Height = 300,
            Config = "{\r\n"+
                     "type: 'line',\r\n"             +
                     "data: {\r\n"                   +
                     "labels: ['0h','3h','6h','9','12h','15h','18','21h','24h'],\r\n" +
                     "datasets: [{\r\n"              +
                     "label: 'Mein Beispiel',\r\n"     +
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