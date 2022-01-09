using System.Globalization;
namespace BotAPI.Utility;

public static class Login
{
    public static readonly HttpClient client = new HttpClient();

    public static async Task LoginAsync()
    {
        DotNetEnv.Env.Load();
        
        var body = new Dictionary<string, string>
        {
           { "Login", Environment.GetEnvironmentVariable("SVC_USERNAME")},
           { "Password", Environment.GetEnvironmentVariable("SVC_PASSWORD") }
        };

        var content = new FormUrlEncodedContent(body);
        var response = await client.PostAsync("http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/Login", content);
        var responseString = await response.Content.ReadAsStringAsync();
    }

    /*public static void Logout()
    {
        client = null;

    }*/
}