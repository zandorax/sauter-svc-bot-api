using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class DataObjectDto
{
     public long ObjectId { get; set; }
     public long PropertyId { get; set; }
     public int Priority { get; set; }
     public string NewValue { get; set; }
     public string Password { get; set; }
     public string? Comments { get; set; }
}