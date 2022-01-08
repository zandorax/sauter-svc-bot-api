using System.Net.Http.Headers;
using Newtonsoft.Json;
using BotAPI.Models;
using BotAPI.Utility;

namespace BotAPI.Services;

public static class UserService
{

    public static async Task<List<User>> GetAll()
    {
        await BotAPI.Utility.Login.LoginAsync();

        BotAPI.Utility.Login.client.DefaultRequestHeaders.Accept.Clear();
        BotAPI.Utility.Login.client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await BotAPI.Utility.Login.client.GetAsync("http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/User");
        
        string responseString = await response.Content.ReadAsStringAsync();
        List<User> users = JsonConvert.DeserializeObject<List<User>>(responseString);
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
            }
        return users;
    }

}