using sprint_2.Controllers;
using sprint_2.Models;

var db = new UserController(
    "Server=168.119.183.3;Database=tren_hubble;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307");

bool flag = true;

while (flag)
{
    Console.Write("-- Creacion y gestion de usuarios --\n" +
                  "1. Crear usuario \n" +
                  "2. Actualizar usuario \n" +
                  "3. Eliminar usuario \n" +
                  "4. Buscar usuario\n" +
                  "5. Salir\n" +
                  ">> ");
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":

            break;
        
        case "2":

            break;
        
        case "3":
            Delete();
            break;
        
        case "4":

            break;
        
        case "5":
            flag = false;
            break;
        
        default:
            Console.WriteLine("Ingrese una opcion valida!");
            break;
    }
}

void Delete()
{
    Console.Clear();
    bool flag = true;

    while (flag)
    {
        Console.Write("1. Eliminar usuario por su Id \n" +
                      "2. Eliminar usuario por su correo \n" +
                      "3. Regresar \n" +
                      ">> ");

        string option = Console.ReadLine();
        string validation;

        switch (option)
        {
            case "1":
                Console.Write("Ingrese el id del usuario: ");
                validation = Console.ReadLine();

                if (!int.TryParse(validation, out int id))
                {
                    Console.WriteLine("Error: Ingrese un campo correcto");
                }

                if (db.GetAllUsers().Any(c => c.Id == id))
                {
                    Console.WriteLine("El usuario existe");
                }
                else
                {
                    Console.WriteLine("El usuario no existe");
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
