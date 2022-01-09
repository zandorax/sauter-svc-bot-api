using System.Net.Http.Headers;
using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {

    }

    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        Task<string> taskString = BotAPI.Utility.GetRequest.getAsync("User");
        string responseString = taskString.Result;
        List<User> users = JsonConvert.DeserializeObject<List<User>>(responseString);
        
        return users;
    }
    [HttpGet("type{id}&filter{filter}")]
    public async Task<ActionResult<List<User>>> GetUser(int id, string filter)
    {
        var option = (UserOption)id;
        Task<string> taskString = BotAPI.Utility.GetRequest.getAsync("User?options.type=" + option + "&options.value="+ filter);     
        string responseString = taskString.Result;
        List<User> users = JsonConvert.DeserializeObject<List<User>>(responseString);

        return users;
    }
}