using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]

public class AckTransitionController : ControllerBase
{
    /// <summary>
    /// Provides the option to acknowledge an alarm.
    /// </summary>
    /// <param name="objId">Object id of the object to be switched</param>
    /// <param name="fromState">from which status the object comes. is used for status transition</param>
    /// <param name="comment">A chance to leave a comment</param>
    /// <returns>HTTP status code</returns>
    /// <exception cref="InvalidOperationException">Detects if the environment variable is loaded</exception>
    [HttpPost]
    public async Task<ActionResult> PostAckTransition(int objId, int? fromState, string? comment)
    {
        DotNetEnv.Env.Load();
        try
        {
            //Status wird von SVC bestimmt. Evt müssen weitere hinzugefügt werden
            //Das Svc hat mehrere Übergangsstaten. Hier wird der richtige Übergang gewählt.
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