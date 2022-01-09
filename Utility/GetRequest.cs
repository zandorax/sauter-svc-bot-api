using System.Net.Http.Headers;

namespace BotAPI.Utility;

public static class GetRequest
{
    public static async Task<string> getAsync(string apiParam)
    {
        await BotAPI.Utility.Login.LoginAsync();

        BotAPI.Utility.Login.client.DefaultRequestHeaders.Accept.Clear();
        BotAPI.Utility.Login.client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        string uri = "http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/"+apiParam;
        var response = await BotAPI.Utility.Login.client.GetAsync(uri);
        
        string responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    } 
}