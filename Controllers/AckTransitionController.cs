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
    public async Task PostAckTransition(int objId, int fromState, string? comment)
    {
        DotNetEnv.Env.Load();
        int? toState = fromState switch
        {
            3 => 2,
            0 => null,
            _ => null
        };

        var request = new AckTransitionDto
        {
            ObjectId = objId,
            ToState = toState,
            Password = Environment.GetEnvironmentVariable("SVC_PASSWORD") ?? throw new InvalidOperationException("Umgebungsvariabel ist nicht erreichbar"),
            Comment = comment
        };

        var body = JsonConvert.SerializeObject(request);
        
        SvcConnector.SvcPostAsync("AckTransition", body);
    }
}