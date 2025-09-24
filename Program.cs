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
            db.Delete();
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


