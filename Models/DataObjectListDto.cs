using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class DataObjectListDto
{
    public List<DataObjectList> Objects { get; set; }
    [JsonIgnore]
    public int PageCount { get; set; }
}

public class DataObjectList
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
    public string BindingType { get; set; }
    public string ObjectType { get; set; }
    public string Connection { get; set; }
    public string ConnectionDescription { get; set; }
    public string Device { get; set; }
    public string DeviceDescription { get; set; }
    public string Unit { get; set; }
    public bool AlarmConditionsEnabled { get; set; } 
}