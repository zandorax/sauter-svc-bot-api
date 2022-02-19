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
    public async Task<ActionResult<List<DataObject>>> GetDataObjects(string? objectName, string? objectUnit, string? objectType)
    {
        List<DataObject>? results = null;
        Task<string> taskString;

        if (objectName == null)
        {
            taskString = SvcConnector.SvcGetAsync("DataObjectList?options.pageNumber=1&options.itemsPerPage=10000");
        }
        else
        {
            taskString = SvcConnector.SvcGetAsync("DataObjectList?options.type=ObjectName&options.value=" +
                                                  objectName
                                                  + "&options.pageNumber=1&options.itemsPerPage=10000");
        }

        var responseString = taskString.Result;
        var dataObjects = JsonConvert.DeserializeObject<DataObjectListDto>(responseString);

        //werden keine Objekte vom SVC zurückgegeben wird ein BadRequest angezeigt
        if (dataObjects == null)
        {
            return BadRequest();
        }
        
        if (objectUnit != null)
        {
            var trimUnit = objectUnit.Trim();
            results = dataObjects.Objects.FindAll(svcObject => svcObject.Unit == trimUnit);
        }

        
        if (objectType != null)
        {
            var trimType = objectType.Trim();
            results = dataObjects.Objects.FindAll(svcObject => svcObject.ObjectType == trimType);
        }

        results ??= dataObjects.Objects;
        
        //ist results leer weil die Suchanfrage keine Objekte liefert wird ein BadRequest ausgegeben
        if (results.Count == 0)
        {
            return BadRequest("Keine Daten mit diesen Suchparametern gefunden.");
        }

        return results;
    }

    [HttpGet("value")]
    public async Task<ActionResult<DataObjectDto>> GetDataObjectValue(int objectId)
    {
        //(propertyId=85 entspricht present-value) Vorgabe SVC
        Task<string> taskString = SvcConnector.SvcGetAsync("DataObject?options.objectId=" + objectId + "&options.propertyId=85");
        string responseString = taskString.Result;
        var dataObject = JsonConvert.DeserializeObject<DataObjectDto>(responseString);


        return dataObject;
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