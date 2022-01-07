using BotAPI.Models;

namespace BotAPI.Services;

public static class UserService
{
    static List<User> Users {get;}
    static int nextId = 3;
    static UserService()
    {
        Users = new List<User>
        {
            new User{Id = 1, Username = "Test1", Email ="test1@mail.com"},
            new User{Id = 2, Username = "Test2", Email ="test2@mail.com"}
        };
    }

    public static List<User> GetAll() => Users;
    public static User? Get(int id) => Users.FirstOrDefault(p => p.Id == id);
    public static void Add(User user)
    {
        user.Id = nextId ++;
        Users.Add(user);
    }
    
}