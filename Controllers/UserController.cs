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

    public async void Delete()
    {
        
        
            Console.Clear();
            bool flag = true;

            while (flag)
            {
                Console.Write("1. Eliminar usuario por su Id \n" +
                              "2. Eliminar usuario por su correo \n" +
                              "3. Regresar \n" +
                              ">> ");

                string optionDelete = Console.ReadLine();
                string validation;

                switch (optionDelete)
                {
                    case "1":
                        Console.Write("Ingrese el id del usuario: ");
                        validation = Console.ReadLine();

                        if (int.TryParse(validation, out int id))
                        {
                            using (var db = new AppDbContext(Credentials))
                            {
                                if (db.users.Any(x => x.Id == int.Parse(validation)))
                                {
                                    Console.Write($"¿Está seguro de eliminar este usuario? (S/N)");
                                    string delete = Console.ReadLine();

                                    if (delete != "N")
                                    {
                                        User user = db.users.First(x => x.Id == id); 
                                        db.users.Remove(user);
                                        db.SaveChangesAsync();
                                        Console.WriteLine("Usuario eliminado!");
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Usuario no encontrado!");
                                }
                            }   
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un campo valido!");
                        }
                        break;

                    case "2":
                        Console.Write("Ingrese el correo del usuario: ");
                        string email = Console.ReadLine();


                        using (var db = new AppDbContext(Credentials))
                        {
                            if (db.users.Any(x => x.Email == email))
                            {
                                Console.Write($"¿Está seguro de eliminar este usuario? (S/N)");
                                string delete = Console.ReadLine();

                                if (delete != "N")
                                {
                                    User user = db.users.First(x => x.Email == email);
                                    db.users.Remove(user);
                                    db.SaveChangesAsync();
                                    Console.WriteLine("Usuario eliminado!");
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Usuario no encontrado!");
                            }
                        }
                        break;

                    case "3":
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Ingrese una opcion valida!");
                        break;
                }
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

    public List<User> ListSpecificGender(string gender)
    {
        using (var db = new AppDbContext(Credentials))
        {
            if (gender == "f")
            {
                return db.users.Where(g => g.Gender == "female").ToList();
            }
            else
            {
                return db.users.Where(g => g.Gender == "male").ToList();
            }
        }
    }
    
    public List<User> ListNamesEmails()
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.Select(u => new User(u.FirstName, u.LastName, u.Email)).ToList();
        }
    }
    
    public int CountUsers()
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.Count();
        }
    }

    public Dictionary<string, int> CountUsersByCity()
    {
        using (var db = new AppDbContext(Credentials))
        {
            var users = db.users
                .Select(u => new
                {
                    City = u.City == null || u.City.Trim() == "" ? "Sin ciudad" : u.City
                }).ToList();
            
            return users
                .GroupBy(u => u.City)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
    
    public Dictionary<string, int> CountUsersByCountry()
    {
        using (var db = new AppDbContext(Credentials))
        {
            var users = db.users
                .Select(u => new
                {
                    Country = u.Country == null || u.Country.Trim() == "" ? "Sin ciudad" : u.Country
                }).ToList();

            return users
                .GroupBy(u => u.Country)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
    
    public List<User> GetUsersWithoutPhone()
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users
                .Where(u => string.IsNullOrEmpty(u.Phone))
                .ToList();
        }
    }
    
    public List<User> GetUsersWithoutAddress()
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.Where(u => string.IsNullOrEmpty(u.Address)).ToList();
        }
    }

    public List<User> LastedRegisteredUsers()
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.OrderByDescending(u => u.CreatedAt).Take(10).ToList();
        }
    }

    public List<User> UsersOrderByLastName()
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.OrderBy(u => u.LastName).ToList();
        }
    }

    public User? GetUserByEmail(String email)
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.FirstOrDefault(u => u.Email == email);
        }
    }

    public List<User> GetUserByCity(string city)
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.Where(u => u.City.ToLower() == city.ToLower()).ToList();
        }
    }
}