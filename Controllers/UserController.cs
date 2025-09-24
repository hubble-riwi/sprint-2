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