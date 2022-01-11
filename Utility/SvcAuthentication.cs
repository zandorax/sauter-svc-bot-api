using System.Globalization;
namespace BotAPI.Utility;

public static class SvcAuthentication
{
    public static readonly HttpClient Client;

    static SvcAuthentication()
    {
        Client = new HttpClient();
        DotNetEnv.Env.Load();
        
        var body = new Dictionary<string, string>
        {
            { "Login", Environment.GetEnvironmentVariable("SVC_USERNAME")},
            { "Password", Environment.GetEnvironmentVariable("SVC_PASSWORD") }
        };

        var content = new FormUrlEncodedContent(body);
        Client.PostAsync("http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/Login", content);
    }


    
    /*public static async Task LoginAsync()
    {
        DotNetEnv.Env.Load();
        
        var body = new Dictionary<string, string>
        {
           { "Login", Environment.GetEnvironmentVariable("SVC_USERNAME")},
           { "Password", Environment.GetEnvironmentVariable("SVC_PASSWORD") }
        };

        var content = new FormUrlEncodedContent(body);
        await client.PostAsync("http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/Login", content);
        //var responseString = await response.Content.ReadAsStringAsync();
    }*/
}