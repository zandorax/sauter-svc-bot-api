using System.Net.Http.Headers;

namespace BotAPI.Utility;

public static class GetRequest
{
    public static async Task<string> getAsync(string apiParam)
    {
        SvcAuthentication.Client.DefaultRequestHeaders.Accept.Clear();
        SvcAuthentication.Client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));

        string uri = "http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/" + apiParam;
        var response = await BotAPI.Utility.SvcAuthentication.Client.GetAsync(uri);
        
        string responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    } 
}