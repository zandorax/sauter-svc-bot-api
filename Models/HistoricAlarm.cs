using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class HistoricAlarm
{
    [JsonPropertyName("HisoricAlarms")]
    public Alarm[] alarms{get; set;}
    
    [JsonPropertyName("PageCount")]
    public string pageNbr { get; set;}
}
