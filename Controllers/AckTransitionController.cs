using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class AckTransitionController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> PostAckTransition(int objId, int? fromState, string? comment)
    {
        DotNetEnv.Env.Load();
        try
        {
            //Status wird von SVC bestimmt. Evt müssen weitere hinzugefügt werden
            int? toState = fromState switch
            {
                3 => null,
                0 => 2,
                _ => 99
            };
            //Ist kein Status angegeben wird ein Fehler produziert
            if (toState == 99)
            {
                return BadRequest("invalid state");
            }

            var request = new AckTransitionDto
            {
                ObjectId = objId,
                ToState = toState,
                Password = Environment.GetEnvironmentVariable("SVC_PASSWORD") ??
                           throw new InvalidOperationException("Umgebungsvariabel ist nicht geladen"),
                Comment = comment
            };

            var body = JsonConvert.SerializeObject(request);

            SvcConnector.SvcPostAsync("AckTransition", body);
            return Ok();
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}