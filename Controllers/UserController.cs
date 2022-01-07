using BotAPI.Models;
using BotAPI.Services;
using BotAPI.Utility;
using Microsoft.AspNetCore.Mvc;

namespace BotAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    public UserController()
    {

    }

    [HttpGet]
    public ActionResult<List<User>> GetAll() => UserService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = UserService.Get(id);

        if(user == null)
            return NotFound();
        
        return user;
    }
}