using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class AggregatedDataDto
{
    public List<AggregatedData> AggregatedDataValues { get; set; }
    [JsonIgnore]
    public int PageCount { get; set; }
}

public class AggregatedData
{
    public int DataObjectID { get; set; }
    public float AggregatedValue { get; set; }
}