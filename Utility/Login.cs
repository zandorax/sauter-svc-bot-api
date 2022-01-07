using DotNetEnv;

namespace BotAPI.Utility;

public class Login
{
    private static readonly HttpClient client = new HttpClient();
    
    static async Task Auth()
    {
        await LoginAsync();
    }



    private static async Task LoginAsync()
        {
            DotNetEnv.Env.Load();
            /*var Password = Environment.GetEnvironmentVariable("SVC_PASSWORD");
            var Username = Environment.GetEnvironmentVariable("SVC_USERNAME");*/
            var body = new Dictionary<string, string>
            {
                { "Login", Environment.GetEnvironmentVariable("SVC_USERNAME")},
                { "Password", Environment.GetEnvironmentVariable("SVC_PASSWORD") }
            };

            var content = new FormUrlEncodedContent(body);

            var response = await client.PostAsync("http://sautervisioncenter.demo.sauter-bc.com/VisionCenterApiService/api/Login", content);

            var responseString = await response.Content.ReadAsStringAsync();
            
        }
}