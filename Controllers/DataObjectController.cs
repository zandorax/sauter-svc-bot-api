using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DataObjectController : ControllerBase
{
    [HttpGet("search")]
    public async Task<ActionResult<DataObjectListDto>> GetDataObject(string objectName)
    {
        Task<string> taskString = SvcConnector.SvcGetAsync("DataObjectList?options.type=ObjectName&options.value=" +
                                                           objectName
                                                           + "&options.pageNumber=1&options.itemsPerPage=10000");
        string responseString = taskString.Result;
        var dataObjects = JsonConvert.DeserializeObject<DataObjectListDto>(responseString);
        
        
        return dataObjects;
    }

    [HttpGet]
    public async Task<ActionResult<DataObjectListDto>> GetDataObjectList()
    {
        Task<string> taskString = SvcConnector.SvcGetAsync("DataObjectList?options.pageNumber=1&options.itemsPerPage=10000");
        string responseString = taskString.Result;
        var dataObjects = JsonConvert.DeserializeObject<DataObjectListDto>(responseString);

        return dataObjects;
    }

    [HttpPost]
    public async Task PostDataObject(long objectId, long propertyId, int priority, string newValue, string? comment)
    {
        DotNetEnv.Env.Load();

        var request = new DataObjectDto()
        {
            ObjectId = objectId,
            PropertyId = propertyId,
            Priority = priority,
            NewValue = newValue,
            Password = Environment.GetEnvironmentVariable("SVC_PASSWORD"),
            Comments = comment
        };

        var body = JsonConvert.SerializeObject(request);
        
        SvcConnector.SvcPostAsync("DataObject",body);
        Console.WriteLine(body);
        Console.WriteLine("nice!");

    }



}