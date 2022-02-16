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
    [JsonIgnore]
    public long Id { get; set; }
    [JsonIgnore]
    public int DataObjectID { get; set; }
    [JsonIgnore]
    public string CalculationTimestamp { get; set; }
    
    public float AggregatedValue { get; set; }
    [JsonIgnore]
    public string AggregationFunctionName { get; set; }
    [JsonIgnore]
    public string AggregationLevelName { get; set; }
    [JsonIgnore]
    public string AggregationTypeName { get; set; }
    [JsonIgnore]
    public int NrOccurrences { get; set; }
    [JsonIgnore]
    public bool IsComplete { get; set; }
}