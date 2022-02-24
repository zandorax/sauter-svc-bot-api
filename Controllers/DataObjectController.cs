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
        try
        {
            Task<HttpResponseMessage> response;
            if (objectName == null)
            {
                response = SvcConnector.SvcGetAsync("DataObjectList?options.pageNumber=1&options.itemsPerPage=10000");
            }
            else
            {
                response = SvcConnector.SvcGetAsync("DataObjectList?options.type=ObjectName&options.value=" +
                                                    objectName
                                                    + "&options.pageNumber=1&options.itemsPerPage=10000");
            }

            response.Result.EnsureSuccessStatusCode();
            
            var responseString = response.Result.Content.ReadAsStringAsync();
            var taskString = responseString.Result;
            var dataObjects = JsonConvert.DeserializeObject<DataObjectListDto>(taskString);

            //wird kein Objekt vom SVC zurückgegeben wird ein BadRequest angezeigt
            if (dataObjects == null)
            {
                return NoContent();
            }

            if (objectUnit != null)
            {
                var trimUnit = objectUnit.Trim();
                results = dataObjects.Objects.FindAll(svcObject => svcObject.Unit == trimUnit);
            }

            if (results == null)
            {
                var trimType = objectType.Trim();
                results = dataObjects.Objects.FindAll(svcObject => svcObject.ObjectType == trimType);
            }
            else
            {
                var trimType = objectType.Trim();
                results = results.FindAll(svcObject => svcObject.ObjectType == trimType);
            }

            results ??= dataObjects.Objects;

            return results.Count switch
            {
                0 => BadRequest("Keine Daten mit diesen Suchparametern gefunden."), //ist results leer weil die Suchanfrage keine Objekte liefert wird ein BadRequest ausgegeben
                > 10 => BadRequest("Zu viele Ergebnisse"),                          //Damit der Benutzer des Chatbot nicht mit Objekten überschwemmt wird gibt es eine Obergrenze
                _ => results
            };
        }
        catch (HttpRequestException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpGet("value")]
    public async Task<ActionResult<DataObjectDto>> GetDataObjectValue(int? objectId)
    {
        try
        {
            //(propertyId=85 entspricht present-value) Vorgabe SVC
            var response = SvcConnector.SvcGetAsync("DataObject?options.objectId=" + objectId + "&options.propertyId=85");
            response.Result.EnsureSuccessStatusCode();
            Task<string> taskString = response.Result.Content.ReadAsStringAsync();
            var responseString = taskString.Result.Replace("\"",""); //Es wird ein String vom SVC übergeben damit keine doppel Anführungszeichen angezeigt werden müssen sie entfernt werden.
            var dataObject = new DataObjectDto
            {
              NewValue = responseString
            };
            return dataObject;
        }
        catch (HttpRequestException exception)
        {
            //Gibt (Objek ID '0' existiert nicht) zurück. Dies kommt vom SVC. Bei einer Abfrage mit objectId = null
            return BadRequest(exception.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> PostDataObject(long objectId, string newValue, string? comment)
    {
        const long propertyId = 85; //Der Wert kommt aus dem SVC und beschreibt welcher Wert überschrieben werden soll.
        const int priority = 8; //Wert aus dem SVC steht für Handeintrag/Handschaltung
        DotNetEnv.Env.Load();
        try
        {
            var request = new DataObjectDto()
            {
                ObjectId = objectId,
                PropertyId = propertyId,
                Priority = priority,
                NewValue = newValue,
                Password = Environment.GetEnvironmentVariable("SVC_PASSWORD") ?? 
                           throw new InvalidOperationException("Umgebungsvariabel ist nicht gealden"),
                Comments = comment
            };
            
            var body = JsonConvert.SerializeObject(request);

            SvcConnector.SvcPostAsync("DataObject", body);
            return Ok();
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}