namespace BotAPI.Models;

public class ResponseAlarm
{
    public string name { get; set; }
    public int size { get; set; }
    public List<AlarmDto> Alarms { get; set; }
}
