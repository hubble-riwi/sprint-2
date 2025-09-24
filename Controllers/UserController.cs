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


    public List<User> GetAllUsers()
    {
        using (var db = new AppDbContext(Credentials))
        {
            return db.users.ToList();
        }
    }

    public void Delete()
    {
        using (var db = new AppDbContext(Credentials))
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
                            
                        }

                        if (db.users.Any(x => x.Id == int.Parse(validation)))
                        {
                            
                        }
                        else
                        {
                            
                        }
                        break;

                    case "2":

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
    }

}