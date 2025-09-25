using System.Globalization;
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

    public void FilterByCountry(string country)
    {
        using (var db = new AppDbContext(credentials: Credentials))
        {
            var result= db.users.Where(user => user.Country == country).ToList();
            {
                if (result.Count != 0)
                {
                    foreach (var user in result)
                    {
                        Console.Clear();
                        Console.WriteLine($"\tFirst name: {user.FirstName}, \n\tLastname = {user.LastName}, \n\tUsername = {user.Username} \n\tEmail = {user.Email}");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No users found");
                }
            }
        }
    }
    
    public void FilterByAge(int age)
    {
        using (var db = new AppDbContext(credentials: Credentials))
        {
            var result= db.users.Where(user => user.Age > age).ToList();
            {
                if (result.Count != 0)
                {
                    foreach (var user in result)
                    {
                        Console.WriteLine($"\tFirst name: {user.FirstName}, \n\tLastname = {user.LastName}, \n\tUsername = {user.Username} \n\tEmail = {user.Email}, \n\tAge = {user.Age}");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No users found");
                }
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

    public int IntegerInputValidator(string prompt)
    {
        while (true)
        {
            string input = EmptyInputValidator(prompt);
            if (int.TryParse(input, out var result))
            {
                return result;
            }
            else
            {
                Console.WriteLine("Value not a number");
            }
        }
    }
    
    // UPDATE USERS
    public void UpdateUser(
        int id,
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Phone,
        string CellPhone,
        string Address,
        string City,
        string State,
        string Zipcode,
        string Country,
        string Gender,
        int Age,
        string? Password)
    {
        using (var db = new AppDbContext(Credentials))
        {
            var user = db.users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Username = Username;
                user.Email = Email;
                user.Phone = Phone;
                user.CellPhone = CellPhone;
                user.Address = Address;
                user.City = City;
                user.State = State;
                user.Zipcode = Zipcode;
                user.Country = Country;
                user.Gender = Gender;
                user.Age = Age;
                user.Password = Password;

                if (!string.IsNullOrWhiteSpace(Password)) user.Password = Password;
                
                db.SaveChanges();
                Console.WriteLine($"User {id} has been updated");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        
    }
}