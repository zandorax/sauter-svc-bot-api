using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        Task<string> taskString = SvcConnector.SvcGetAsync("User");
        string responseString = taskString.Result;
        List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(responseString);
        
        return users;
    }
    
    [HttpGet("type{id:int}&filter{filter}")]
    public async Task<ActionResult<List<UserDto>>> GetUser(int id, string filter)
    {
        var option = (UserOption)id;
        Task<string> taskString = SvcConnector.SvcGetAsync("User?options.type=" + option + "&options.value="+ filter);     
        string responseString = taskString.Result;
        List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(responseString);

        return users;
    }
}