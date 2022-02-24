namespace BotAPI.Models;

public class AckTransitionDto
{
    public int ObjectId { get; set; }
    public int? ToState { get; set; }
    public string Password { get; set; }
    public string? Comment { get; set; }
}