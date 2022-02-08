using System;

namespace BotAPI.Utility;

public sealed class SvcConnect
{
    private SvcConnect(){}

    private static SvcConnect _instance;
    private static HttpClient Client = new();

    public static SvcConnect GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SvcConnect();
        }

        return _instance;
    }

    private static void SvcLogin()
    {
        
    } 

}