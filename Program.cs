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
        Console.WriteLine("Enter the ID of user if you want Update:");
        int id = int.Parse(Console.ReadLine());
        
        Console.WriteLine("New name:");
        string firstName = Console.ReadLine();
        
        Console.WriteLine("New last name:");
        string lastName = Console.ReadLine();
        
        Console.WriteLine("New Username:");
        string username = Console.ReadLine();
        
        Console.WriteLine("New email:");
        string email = Console.ReadLine();
        
        Console.Write("New phone:");
        string phone = Console.ReadLine();
        
        Console.Write("New cellphone:");
        string cellphone = Console.ReadLine();
        
        Console.Write("New address:");
        string address = Console.ReadLine();
        
        Console.Write("New city:");
        string city = Console.ReadLine();
        
        Console.Write("New state:");
        string state = Console.ReadLine();
        
        Console.Write("New zipcode:");
        string zipcode = Console.ReadLine();
        
        Console.Write("New country:");
        string country = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("New gender (Female, Male):");
            gender = Console.ReadLine().ToLower().Trim();

            if (gender != "male" && gender != "female")
            {
                Console.WriteLine("Enter a valid gender");
                    continue;
            }
            else
            {
                Console.WriteLine("The gender has updated ");
                    break;
            }
        }
        
        Console.Write("New age:");
        int age = int.Parse(Console.ReadLine());
        
        Console.Write("New password (OPTIONAL):");
        string password = Console.ReadLine();
        
        Console.Write("Confirm the new password:");
        string confirmPassword = Console.ReadLine();

        if (password != confirmPassword)
        {
            Console.WriteLine("The password dont match...dont update the password");
            password = null;
        }
        else
        {
            Console.WriteLine("The password has been update for the user ...");
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
            Console.WriteLine("Enter a valid option...");
            break;
    }
}
