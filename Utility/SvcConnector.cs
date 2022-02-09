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
        Client.DefaultRequestHeaders.Accept.Clear();
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public static async Task<string> SvcGetAsync(string apiParam)
    {
        await SvcLoginAsync();
        
        DotNetEnv.Env.Load();
        var uri = Environment.GetEnvironmentVariable("SVC_API_URI") + apiParam;
        var response = await Client.GetAsync(uri);
        
        string responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }

    public static async void SvcPostAsync(string apiParam, string content)
    {
        await SvcLoginAsync();
        
        DotNetEnv.Env.Load();
        var uri = Environment.GetEnvironmentVariable("SVC_API_URI") + apiParam;
        var requestContent = new StringContent(content, Encoding.UTF8, "application/json");
        await Client.PostAsync(uri, requestContent);
        
    }
        

    private static async Task SvcLoginAsync()
    {
        DotNetEnv.Env.Load();
        
        var body = new Dictionary<string, string?>
        {
           { "Login", Environment.GetEnvironmentVariable("SVC_USERNAME")},
           { "Password", Environment.GetEnvironmentVariable("SVC_PASSWORD") }
        };

        var content = new FormUrlEncodedContent(body);
        await Client.PostAsync(Environment.GetEnvironmentVariable("SVC_API_URI")+"/Login", content);
    }
}