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
    public async Task<ActionResult<List<User>>> GetAll() => await UserService.GetAll();

}