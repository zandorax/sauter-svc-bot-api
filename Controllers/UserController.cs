using BotAPI.Models;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    /// <summary>
    /// Request all users of SVC
    /// </summary>
    /// <returns>Returns an object of type UserDto. Contains all users</returns>
    [HttpGet]
    public async Task<ActionResult<List<UserDto>>> GetAll()
    {
        try
        {
            Task<HttpResponseMessage> response = SvcConnector.SvcGetAsync("User");
            response.Result.EnsureSuccessStatusCode();
            var responseString = response.Result.Content.ReadAsStringAsync();
            var taskString = responseString.Result;
            
            List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(taskString);
            return users;
        }
        catch (HttpRequestException exception)
        { 
            return BadRequest(exception.Message);
        }
        
    }
    
    /// <summary>
    /// Filtered query of users of the SVC
    /// </summary>
    /// <param name="id">Search by id 1 = name, 2 = email or 3 = phone</param>
    /// <param name="filter">Enter a string to specify the search for example a last name</param>
    /// <returns>Returns an object of type UserDto. Contains filtered users</returns>
    [HttpGet("type{id:int}&filter{filter}")]
    public async Task<ActionResult<List<UserDto>>> GetUser(int id, string filter)
    {
        var option = (UserOption)id;
        var trimFilter = filter.Trim();
        try
        {
            Task<HttpResponseMessage> response =
                SvcConnector.SvcGetAsync("User?options.type=" + option + "&options.value=" + trimFilter);
            response.Result.EnsureSuccessStatusCode();
            var responseString = response.Result.Content.ReadAsStringAsync();
            var taskString = responseString.Result;
            List<UserDto> users = JsonConvert.DeserializeObject<List<UserDto>>(taskString);
           
            return users;
            
        }
        catch (HttpRequestException exception)
        {
            return BadRequest(exception.Message);
        }
    }
}