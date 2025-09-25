using sprint_2.Controllers;
using sprint_2.Models;

var db = new UserController(
    "Server=168.119.183.3;Database=tren_hubble;User=root;Password=g0tIFJEQsKHm5$34Pxu1;Port=3307");

bool flag = true;
string gender;

while (flag)
{
    Console.Write("\t---- Creacion y gestion de usuarios ----\n" +
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
        Console.Write("Ingrese el id del usuario que desea actualizar: ");
        int id = int.Parse(Console.ReadLine());
        
        Console.Write("Nuevo nombre:");
        firstName = Console.ReadLine();
        
        Console.Write("Nuevo apellido:");
         lastName = Console.ReadLine();
        
        Console.Write("Nuevo nombre usuario:");
        string username = Console.ReadLine();
        
        Console.Write("Nuevo email:");
         email = Console.ReadLine();
        
        Console.Write("Nuevo telefono:");
        string phone = Console.ReadLine();
        
        Console.Write("Nuevo numero de celular:");
        string cellphone = Console.ReadLine();
        
        Console.Write("Nueva direccion:");
        string address = Console.ReadLine();
        
        Console.Write("Nuevo ciudad:");
        string city = Console.ReadLine();
        
        Console.Write("Nuevo estado:");
        string state = Console.ReadLine();
        
        Console.Write("Nuevo codigo postal:");
        string zipcode = Console.ReadLine();
        
        Console.Write("Nuevo pais:");
        string country = Console.ReadLine();

        while (true)
        {
            Console.WriteLine("Nuevo genero (masculino, femenino):");
            string gen = Console.ReadLine().ToLower().Trim();

            if (gen != "masculino" && gen != "femenino")
            {
                Console.WriteLine("Enter a valid gender");
                    continue;
            }
            else
            {
                gender = gen == "male" ? "male" : "female";
                break;
            }
        }
        
        Console.Write("Nueva edad:");
        int age = int.Parse(Console.ReadLine());
        
        Console.Write("Nueva contraseña (opcional): ");
         password = Console.ReadLine();
        
        Console.Write("Confirme la contraseña: ");
        string confirmPassword = Console.ReadLine();

        if (password != confirmPassword)
        {
            Console.WriteLine("Las contraseñas no coinciden");
            password = null;
        }
        else
        {
            Console.WriteLine("Las contraseñas han sido actualizadas");
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
                Console.Write("\t---- Consultas del sistema ----\n" +
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
                            Console.Write("\t---- Listar usuarios ----\n\n" +
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
                                    Console.WriteLine("\t---- Listar nombres y correos ----");
                                    var usersList = db.ListNamesEmails();
                                    foreach (var user in usersList)
                                    {
                                        Console.WriteLine($"\tNombre: {user.FirstName} {user.LastName}, \t\nEmail: {user.Email}");
                                    }
                                    break;
                                
                                case "2":
                                    var listUser = db.GetAllUsers();
                                    Console.WriteLine("List of the all users");
                                    foreach (User user in listUser)
                                    {
                                        Console.WriteLine($"- Id: {user.Id} \n" +
                                                          $"- Nombres: {user.FirstName}\n" +
                                                          $"- Apellidos: {user.LastName}\n" +
                                                          $"- Nombre de usuario: {user.Username}\n" +
                                                          $"- Correo: {user.Email} \n" +
                                                          $"- Telefono: {user.Phone} \n" +
                                                          $"- Numero de celular: {user.CellPhone} \n" +
                                                          $"- Direccion: {user.Address} \n" +
                                                          $"- Ciudad: {user.City} \n" +
                                                          $"- Estado: {user.State} \n" +
                                                          $"- Codigo postal: {user.Zipcode} \n" +
                                                          $"- Pais: {user.Country} \n" +
                                                          $"- Genero: {user.Gender} \n" +
                                                          $"- Edad: {user.Age} \n" +
                                                          $"- Contraseña: {user.Password?? "Sin contraseña"}");
                                    }
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
                                    Console.Write("\t---- Listar por género ----" +
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
                                    Console.Write("\t---- Últimos usuarios registrados ----\n");
                                    var recentUsers = db.LastedRegisteredUsers();
                                    foreach (var user in recentUsers)
                                    {
                                        Console.WriteLine($"Nombre: {user.FirstName} {user.LastName},\nEmail: {user.Email},\nFecha de registro: {user.CreatedAt}\n\n");
                                    }
                                    break;
                                
                                case "8":
                                    Console.Clear();
                                    Console.Write("\t---- Todos los usuarios ----\n");
                                    var usersOrder = db.UsersOrderByLastName();
                                    foreach (var user in usersOrder)
                                    {
                                        Console.WriteLine($"Nombre: {user.LastName} {user.FirstName},\nEmail: {user.Email}\n");
                                    }
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
                            Console.Write("\t---- Contar usuarios ----\n" +
                                          "1. Contar usuarios por ciudad\n" +
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
    
                                    Console.WriteLine("\t---- Usuarios por ciudad ----");
                                    foreach (var entry in countsByCity)
                                    {
                                        Console.WriteLine($"Ciudad: {entry.Key} — {entry.Value} usuarios");
                                    }
                                    break;
                                
                                case "2":
                                    Console.Clear();
                                    var countsByCountry = db.CountUsersByCountry();
    
                                    Console.WriteLine("\t---- Usuarios por ciudad ----");
                                    foreach (var entry in countsByCountry)
                                    {
                                        Console.WriteLine($"País: {entry.Key} — {entry.Value} usuarios");
                                    }
                                    break;
                                
                                case "3":
                                    Console.Clear();
                                    int totalUsers = db.CountUsers();
                                    Console.WriteLine($"\t---- Registros ----\n" +
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
                            Console.Write("\t---- Mostrar usuarios ----\n\n" +
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
                                    Console.WriteLine("\t---- Usuarios sin dirección registrada ----");
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
                                    Console.WriteLine("\t---- Usuarios sin teléfono registrado ----");
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


