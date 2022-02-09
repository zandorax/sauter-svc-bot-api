using System.Windows;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR.Client;


namespace BotAPI.Utility;

public class SvcNotifyR
{
    private readonly HubConnection? _connection;

    public SvcNotifyR()
    {
        DotNetEnv.Env.Load();
        _connection = new HubConnectionBuilder()
                    .WithUrl(Environment.GetEnvironmentVariable("SVC_SignalR_URL"))
                    .Build();
        _connection.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0, 5) * 1000);
            await _connection.StartAsync();
        };
    }

    public async Task ReceiveMessage()
    {
        _connection.On("NotifyFlaggedAlarms", () => Console.WriteLine("A new Alarm"));
        
    }
    
    
}