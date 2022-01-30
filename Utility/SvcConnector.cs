using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BotAPI.Utility;

public static class SvcConnector
{
    private static readonly HttpClient Client;

    static SvcConnector()
    {
        Client = new HttpClient();
    }

    public static async Task<string> GetAsync(string apiParam)
    {
        await LoginAsync();
        
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var uri = "http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/" + apiParam;
        var response = await Client.GetAsync(uri);
        
        string responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }

    public static async void PostAsync(string postParam, string content)
    {
        await LoginAsync();
        
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        var uri = "http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/" + postParam;
        var requestContent = new StringContent(content, Encoding.UTF8, "application/json");
        await Client.PostAsync(uri, requestContent);
        
    }
        

    private static async Task LoginAsync()
    {
        DotNetEnv.Env.Load();
        
        var body = new Dictionary<string, string?>
        {
           { "Login", Environment.GetEnvironmentVariable("SVC_USERNAME")},
           { "Password", Environment.GetEnvironmentVariable("SVC_PASSWORD") }
        };

        var content = new FormUrlEncodedContent(body);
        await Client.PostAsync("http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/Login", content);
    }
}