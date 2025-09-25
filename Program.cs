using sprint_2.Controllers;
using sprint_2.Models;

var db = new UserController(
    "Server=168.119.183.3;Database=tren_hubble;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307");

foreach (var user in db.GetAllUsers())
{
    Console.WriteLine($" UserID:{user.Id} Firstname:{user.FirstName} Lastname:{user.LastName} Username:{user.Username} Email:{user.Email} phone:{user.Phone} cellphone:{user.CellPhone} Address:{user.Address} City:{user.City} State:{user.State} ZipCode:{user.Zipcode} Country:{user.Country} Gender:{user.Gender} Age:{user.Age} Password:{user.Password}");
}

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
    Console.Write("Select an option:");
    string option = Console.ReadLine();
    string gender;
    switch (option)
    {
        case "1":

            break;
        
        case "2":
        Console.WriteLine("Ingresa el ID que deseas actualizar:");
        int id = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Nuevo nombre:");
        string firstName = Console.ReadLine();
        
        Console.WriteLine("Nuevo apellido:");
        string lastName = Console.ReadLine();
        
        Console.WriteLine("Nuevo nombre de usuario:");
        string username = Console.ReadLine();
        
        Console.WriteLine("Nuevo email:");
        string email = Console.ReadLine();
        
        Console.Write("Nuevo numero de telefono:");
        int phone = int.Parse(Console.ReadLine());
        
        Console.Write("Nuevo numero de celular:");
        int cellphone = int.Parse(Console.ReadLine());
        
        Console.Write("Nueva Direccion de residencia:");
        string address = Console.ReadLine();
        
        Console.Write("Nueva ciudad:");
        string city = Console.ReadLine();
        
        Console.Write("Nuevo estado:");
        string state = Console.ReadLine();
        
        Console.Write("Nuevo codigo ZIP:");
        int zipcode = int.Parse(Console.ReadLine());
        
        Console.Write("Nuevo pais:");
        string country = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Nuevo genero (Femenino, masculino):");
            gender = Console.ReadLine().ToLower().Trim();

            if (gender != "masculino" && gender != "femenino")
            {
                Console.WriteLine("Ingresa un genero valido");
                    continue;
            }
            else
            {
                Console.WriteLine("El genero ha sido actualizado");
                    break;
            }
        }

        int age;
        while (true)
        {
            
            Console.Write("Nueva edad:");
            string inputAge = Console.ReadLine();

            if (int.TryParse(inputAge, out age))
            {
                break;
            }
            else
            {
                Console.WriteLine("Ingresa una edad valida en numero entero...");
                continue;
            }
        }
        
        
        Console.Write("Nueva contrasena (OPCIONAL):");
        string password = Console.ReadLine();
        
        Console.Write("Confirma la nueva contrasena");
        string confirmPassword = Console.ReadLine();

        if (password != confirmPassword)
        {
            Console.WriteLine("La contrasenas ingresadas no coinciden");
            password = null;
        }
        else
        {
            Console.WriteLine("La contrasena ha sido actualizada exitosamente ...");
        }
        
        
        //call the controller
        db.UpdateUser(id,firstName,lastName,username,email,phone,cellphone,address,city,state,zipcode,country,gender,age,password);
        break;
        
        case "3":

            break;
        
        case "4":

            break;
        
        case "5":
            flag = false;
            break;
        default:
            Console.WriteLine("Ingresa una opcion valida...");
            break;
    }
}
