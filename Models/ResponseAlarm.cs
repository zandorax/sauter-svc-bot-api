namespace BotAPI.Models;

public class ResponseAlarm
{
    public int size { get; set; }
    public List<AlarmDto> Alarms { get; set; }
}