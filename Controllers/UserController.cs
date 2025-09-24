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
                        // Console.Write("Ingrese el correo del usuario: ");
                        // validation = Console.ReadLine();
                        //
                        // if (int.TryParse(validation, out int id))
                        // {
                        //     using (var db = new AppDbContext(Credentials))
                        //     {
                        //         if (db.users.Any(x => x.Id == int.Parse(validation)))
                        //         {
                        //             Console.Write($"¿Está seguro de eliminar este usuario? (S/N)");
                        //             string delete = Console.ReadLine();
                        //
                        //             if (delete != "N")
                        //             {
                        //                 User user = db.users.First(x => x.Id == id); 
                        //                 db.users.Remove(user);
                        //                 db.SaveChangesAsync();
                        //                 Console.WriteLine("Usuario eliminado!");
                        //             }
                        //             else
                        //             {
                        //                 continue;
                        //             }
                        //         }
                        //         else
                        //         {
                        //             Console.WriteLine("Usuario no encontrado!");
                        //         }
                        //     }   
                        // }
                        // else
                        // {
                        //     Console.WriteLine("Ingrese un campo valido!");
                        // }

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