using System.Net;
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
        Task<HttpResponseMessage> response = SvcConnector.SvcGetAsync("User");
        string? responseString = response.Result.Content.ToString();
        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(responseString);
            return users;
        }

        return BadRequest(responseString);


    }
    
    [HttpGet("type{id:int}&filter{filter}")]
    public async Task<ActionResult<List<UserDto>>> GetUser(int id, string filter)
    {
        var option = (UserOption)id;
        var trimFilter = filter.Trim();
        Task<HttpResponseMessage> response = SvcConnector.SvcGetAsync("User?options.type=" + option + "&options.value="+ trimFilter);     
        string responseString = response.Result.Content.ToString();
        if (response.Result.StatusCode == HttpStatusCode.OK)
        {
            List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(responseString);
            return users;
        }

        return BadRequest();


    }
}