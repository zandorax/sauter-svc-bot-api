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
        await BotAPI.Utility.Login.LoginAsync();

        BotAPI.Utility.Login.client.DefaultRequestHeaders.Accept.Clear();
        BotAPI.Utility.Login.client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        string uri = "http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/User";
        var response = await BotAPI.Utility.Login.client.GetAsync(uri);
        
        string responseString = await response.Content.ReadAsStringAsync();
        List<User> users = JsonConvert.DeserializeObject<List<User>>(responseString);
        
        return users;
    }
    [HttpGet("type{id}&filter{filter}")]
    public async Task<ActionResult<List<User>>> GetUser(int id, string filter)
    {
        await BotAPI.Utility.Login.LoginAsync();

        BotAPI.Utility.Login.client.DefaultRequestHeaders.Accept.Clear();
        BotAPI.Utility.Login.client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
        
        var option = (UserOption)id;
        string uri = "http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/User?options.type=" + option + "&options.value="+ filter;
        var response = await BotAPI.Utility.Login.client.GetAsync(uri);
        
        string responseString = await response.Content.ReadAsStringAsync();
        List<User> users = JsonConvert.DeserializeObject<List<User>>(responseString);

        return users;
    }
}