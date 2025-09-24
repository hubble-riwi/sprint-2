using sprint_2.Data;
using sprint_2.Models;

namespace sprint_2.Controllers;

public class UserController
{
    private string Credentials { get; set; }
    
    public UserController(string credentials)
    {
        Credentials = credentials;
    }
    
    // 🔹 READ (todos)
    public List<User> GetAllUsers()
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.ToList();
        }
    }
    public void RegisterUser(User user)
    {
        using (var db = new AppDbContext(credentials: Credentials))
        {
            if (UserNameTaken(user))
            {
                Console.WriteLine("Username already taken");
            }
            else if (EmailTaken(user))
            {
                Console.WriteLine("Email already taken");
            }
            else
            {
                db.users.Add(user);
                Console.WriteLine("User successfully registered");
                Console.WriteLine($"\tFirst name: {user.FirstName}, \n\tLastname = {user.LastName}, \n\tUsername = {user.Username} \n\tEmail = {user.Email}");
                db.SaveChanges();
            }
        }
    }

    public bool UserNameTaken(User user)
    {
        string newUsername = user.Username;
        using (var db = new AppDbContext(credentials: Credentials))
        {
            var result = db.users.FirstOrDefault(user => user.Username == newUsername);
            if (!(result == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    public bool EmailTaken(User user)
    {
        string newEmail = user.Email;
        using (var db = new AppDbContext(credentials: Credentials))
        {
            var result = db.users.FirstOrDefault(user => user.Email == newEmail);
            if (!(result == null))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
    

    public string EmptyInputValidator(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
            else
            {
                Console.WriteLine("Value required, try again");
            }
        }
    }
}