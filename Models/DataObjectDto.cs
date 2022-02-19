using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class DataObjectDto
{
     [JsonIgnore]
     public long ObjectId { get; set; }
     [JsonIgnore]
     public long PropertyId { get; set; }
     [JsonIgnore]
     public int Priority { get; set; }
     [JsonPropertyName("actual-value")]
     public string NewValue { get; set; }
     [JsonIgnore]
     public string Password { get; set; }
     [JsonIgnore]
     public string? Comments { get; set; }
}