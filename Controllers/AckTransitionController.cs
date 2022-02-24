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
    public async Task PostAckTransition(int objId, int? toState, string? comment)
    {
        DotNetEnv.Env.Load();
        
        var request = new AckTransitionDto
        {
            ObjectId = objId,
            ToState = toState,
            Password = Environment.GetEnvironmentVariable("SVC_PASSWORD"),
            Comment = comment
        };

        var body = JsonConvert.SerializeObject(request);
        
        SvcConnector.SvcPostAsync("AckTransition", body);
    }
}