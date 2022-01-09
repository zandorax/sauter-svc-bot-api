using System.Net.Http.Headers;
using BotAPI.Models;
using BotAPI.Services;
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

        var response = await BotAPI.Utility.Login.client.GetAsync("http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/User");
        
        string responseString = await response.Content.ReadAsStringAsync();
        List<User> users = JsonConvert.DeserializeObject<List<User>>(responseString);
        /*zum debugen
        foreach(User Username in users)
            {
                Console.WriteLine(Username.Id);
                Console.WriteLine(Username.IsActive);
                Console.WriteLine(Username.IsApiUser);
                Console.WriteLine(Username.IsExternal);
                Console.WriteLine(Username.Username);
                Console.WriteLine(Username.Email);
                Console.WriteLine(Username.PhoneNumber);
                Console.WriteLine(Username.FallbackContact);
                Console.WriteLine(Username.LastActivity);
                Console.WriteLine();
                Console.WriteLine("*****************************");
                Console.WriteLine();
            }*/
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