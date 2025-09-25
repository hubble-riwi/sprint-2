using sprint_2.Controllers;
using sprint_2.Models;

var db = new UserController(
    "Server=168.119.183.3;Database=tren_hubble;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307");

bool flag = true;
string gender;

while (flag)
{
    Console.Write("-- Creacion y gestion de usuarios --\n" +
                  "1. Crear usuario \n" +
                  "2. Actualizar usuario \n" +
                  "3. Eliminar usuario \n" +
                  "4. Consultas\n" +
                  "5. Salir\n" +
                  ">> ");
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            Console.Clear();
            string firstName = db.EmptyInputValidator("Nombre: ");
            string lastName = db.EmptyInputValidator("Apellido: ");
            string userName = db.EmptyInputValidator("Nombre de usuario: ");
            string email = db.EmptyInputValidator("Email: ");
            string password = db.EmptyInputValidator("Contraseña: ");
            DateTime createdAt = DateTime.Now;
            User newUser = new User(firstName, lastName, userName, email, password, createdAt);
            db.RegisterUser(newUser);
            break;
        
        case "2":
        Console.WriteLine("Enter the ID of user if you want Update:");
        int id = int.Parse(Console.ReadLine());
        
        Console.WriteLine("New name:");
        firstName = Console.ReadLine();
        
        Console.WriteLine("New last name:");
         lastName = Console.ReadLine();
        
        Console.WriteLine("New Username:");
        string username = Console.ReadLine();
        
        Console.WriteLine("New email:");
         email = Console.ReadLine();
        
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
         password = Console.ReadLine();
        
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
            break;
        
        case "3":
            Console.Clear();
            db.Delete();
            break;
        
        case "4":
            Console.Clear();
            bool main = true;
            while (main)
            {
                Console.Write("---- Consultas del sistema ----\n" +
                                  "1. Listar usuarios\n" +
                                  "2. Contar usuarios\n" +
                                  "3. Mostrar usuarios\n" +
                                  "4. Volver al menu principal\n" +
                                  ">> ");
                string opt = Console.ReadLine();
                switch (opt)
                {
                    case "1":
                        Console.Clear();
                        bool menuList = true;
                        while (menuList)
                        {
                            Console.Write("---- Listar usuarios ----\n\n" +
                                          "1. Listar nombres y correos\n" +
                                          "2. Listar todos los usuarios\n" +
                                          "3. Listar usuarios por ciudad\n" +
                                          "4. Listar usuarios por edad mínima\n" +
                                          "5. Listar usuarios por género\n" +
                                          "6. Listar usuarios por país\n" +
                                          "7. Últimos usuarios registrados\n" +
                                          "8. Usuarios ordenados por apellido\n" +
                                          "9. Volver al menú anterior\n" +
                                          ">> ");
                            string optList = Console.ReadLine();
                            switch (optList)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("---- Listar nombres y correos ----");
                                    var usersList = db.ListNamesEmails();
                                    foreach (var user in usersList)
                                    {
                                        Console.WriteLine($"\tNombre: {user.FirstName} {user.LastName}, \t\nEmail: {user.Email}");
                                    }
                                    break;
                                
                                case "2":
                                    Console.Clear();
                                    break;
                                case "3":
                                    Console.Clear();
                                    break;
                                case "4":
                                    Console.Clear();
                                    int ageFilter = db.IntegerInputValidator("Age: ");
                                    db.FilterByAge(ageFilter);
                                    break;
                                case "5":
                                    Console.Clear();
                                    Console.Write("---- Listar por género ----" +
                                                  "Ingrese el género: \n" +
                                                  "F. Femenino\n" +
                                                  "M. Masculino\n" +
                                                  ">> ");
                                    string genderInput = Console.ReadLine().ToLower();

                                    if (genderInput == "f" || genderInput == "m")
                                    {
                                        var users = db.ListSpecificGender(genderInput);
                                        foreach (var user in users)
                                        {
                                            Console.WriteLine($"\tNombre: {user.FirstName} {user.LastName}, \t\nEmail: {user.Email}, \t\nGénero: {user.Gender}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Género inválido. Por favor ingrese 'f' o 'm'.");
                                    }
                                    break;
                                case "6":
                                    Console.Clear();
                                    string countryFilter = db.EmptyInputValidator("País: ");
                                    db.FilterByCountry(countryFilter);
                                    break;
                                case "7":
                                    Console.Clear();
                                    break;
                                case "8":
                                    Console.Clear();
                                    break;
                                case "9":
                                    Console.Clear();
                                    menuList = false;
                                    break;
                            }
                        }
                        
                        break;
                    
                    case "2":
                        Console.Clear();
                        bool mainCount = true;
                        while (mainCount)
                        {
                            Console.Write("---- Contar usuarios ----\n" +
                                          "1. Contar usuarios por ciudad\n " +
                                          "2. Contar usuarios por país\n" +
                                          "3. Contar usuarios totales\n" +
                                          "4. Volver al menú anterior\n" +
                                          ">> ");
                            string optCount = Console.ReadLine();
                            switch (optCount)
                            {
                                case "1":
                                    Console.Clear();
                                    var countsByCity = db.CountUsersByCity();
    
                                    Console.WriteLine("---- Usuarios por ciudad ----");
                                    foreach (var entry in countsByCity)
                                    {
                                        Console.WriteLine($"Ciudad: {entry.Key} — {entry.Value} usuarios");
                                    }
                                    break;
                                
                                case "2":
                                    Console.Clear();
                                    var countsByCountry = db.CountUsersByCountry();
    
                                    Console.WriteLine("---- Usuarios por ciudad ----");
                                    foreach (var entry in countsByCountry)
                                    {
                                        Console.WriteLine($"País: {entry.Key} — {entry.Value} usuarios");
                                    }
                                    break;
                                
                                case "3":
                                    Console.Clear();
                                    int totalUsers = db.CountUsers();
                                    Console.WriteLine($"---- Registros ----\n" +
                                                      $"Total de usuarios registrados: {totalUsers}\n");
                                    break;
                                case "4":
                                    mainCount = false;
                                    break;
                            }
                        }
                        break;
                    
                    case "3":
                        Console.Clear();
                        bool menuShow = true;
                        while (menuShow)
                        {
                            Console.Write("---- Mostrar usuarios ----\n\n" +
                                          "1. Usuarios sin dirección\n" +
                                          "2. Usuarios sin teléfono\n" +
                                          "3. Ver usuario por correo\n" +
                                          "4. Ver usuario por Id\n" +
                                          "5. Volver al menú anterior\n" +
                                          ">> ");
                            string optShow = Console.ReadLine();
                            switch (optShow)
                            {
                                case "1":
                                    Console.Clear();
                                    Console.WriteLine("---- Usuarios sin dirección registrada ----");
                                    var usersWithoutAddress = db.GetUsersWithoutAddress();

                                    if (usersWithoutAddress.Count == 0)
                                    {
                                        Console.WriteLine("Todos los usuarios tienen dirección registrada.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Usuarios sin teléfono registrado:");
                                        foreach (var user in usersWithoutAddress)
                                        {
                                            Console.WriteLine($"\tNombre: {user.FirstName} {user.LastName} \t\nEmail: {user.Email}");
                                        }
                                    }
                                    break;
                                
                                case "2":
                                    Console.Clear();
                                    Console.WriteLine("---- Usuarios sin teléfono registrado ----");
                                    var usersWithoutPhone = db.GetUsersWithoutPhone();

                                    if (usersWithoutPhone.Count == 0)
                                    {
                                        Console.WriteLine("Todos los usuarios tienen teléfono registrado.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Usuarios sin teléfono registrado:");
                                        foreach (var user in usersWithoutPhone)
                                        {
                                            Console.WriteLine($"\tNombre: {user.FirstName} {user.LastName} \t\nEmail: {user.Email}");
                                        }
                                    }
                                    break;
                                
                                case "3":
                                    Console.Clear();
                                    break;
                                
                                case "4":
                                    Console.Clear();
                                    break;
                                case "5":
                                    Console.Clear();
                                    menuShow = false;
                                    break;
                            }
                        }
                        break;
                    
                    case "4":
                        Console.Clear();
                        main = false;
                        break;
                }
            }

            break;
        
        case "5":
            Console.WriteLine("Saliendo...");
            flag = false;
            break;
        
        default:
            Console.WriteLine("Ingrese una opcion valida!");
            break;
    }
}


