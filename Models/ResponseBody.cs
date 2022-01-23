namespace BotAPI.Models;

public class ResponseBody
{
    public string name { get; set; }
    public int size { get; set; }
    public List<Alarm> Alarms { get; set; }
}
