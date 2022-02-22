namespace BotAPI.Models;

public class ResponseAlarm
{
    public int Size { get; set; }
    public List<AlarmDto>? Alarms { get; set; }
}