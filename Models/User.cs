using System.Text.Json.Serialization;

namespace BotAPI.Models;

public class User
{
    [JsonPropertyName("ID")]
    public string Id {get; set;}

    [JsonPropertyName("IsActive")]
    public string IsActive {get; set;}

    [JsonPropertyName("IsApiUser")]
    public string IsApiUser {get; set;}

    [JsonPropertyName("IsExternal")]
    public string IsExternal {get; set;}
    
    [JsonPropertyName("Username")]
    public string Username {get; set;}

    [JsonPropertyName("Email")]
    public string Email {get; set;}

    [JsonPropertyName("PhoneNumber")]
    public string PhoneNumber {get; set;}

    [JsonPropertyName("FallbackContact")]
    public string FallbackContact {get; set;}

    [JsonPropertyName("LastActivity")]
    public string LastActivity {get; set;}
}