using System.Numerics;
namespace BotAPI.Models;

public class User
{
    public int Id {get; set;}
    public bool IsActive {get; set;}
    public bool IsApiUser {get; set;}
    public bool IsExternal {get; set;}
    public string Username {get; set;}
    public string Email {get; set;}
    public string PhoneNumber {get; set;}
    public string FallbackContact {get; set;}
    public DateTime LastActivity {get; set;}
}