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
                  "4. Consultas\n" +
                  "5. Salir\n" +
                  ">> ");
    string option = Console.ReadLine();

    switch (option)
    {
        case "1":
            string firstName = db.EmptyInputValidator("Nombre: ");
            string lastName = db.EmptyInputValidator("Apellido: ");
            string userName = db.EmptyInputValidator("Nombre de usuario: ");
            string email = db.EmptyInputValidator("Email: ");
            string password = db.EmptyInputValidator("Contraseña: ");
            User newUser = new User(firstName, lastName, userName, email, password);
            db.RegisterUser(newUser);
            break;
        case "2":

            break;
        
        case "3":
            db.Delete();
            break;
        
        case "4":
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
                                    break;
                                case "2":
                                    break;
                                case "3":
                                    break;
                                case "4":
                                    break;
                                case "5":
                                    break;
                                case "6":
                                    break;
                                case "7":
                                    break;
                                case "8":
                                    break;
                                case "9":
                                    menuList = false;
                                    break;
                            }
                        }
                        
                        break;
                    
                    case "2":
                        bool mainCount = true;
                        while (mainCount)
                        {
                            Console.Write("---- Contar usuarios ----\n\n" +
                                          "1. Contar usuarios por ciudad\n " +
                                          "2. Contar usuarios por país\n" +
                                          "3. Contar usuarios totales" +
                                          "4. Volver al menú anterior\n" +
                                          ">> ");
                            string optCount = Console.ReadLine();
                            switch (optCount)
                            {
                                case "1":
                                    break;
                                case "2":
                                    break;
                                case "3":
                                    break;
                                case "4":
                                    mainCount = false;
                                    break;
                            }
                        }
                        break;
                    
                    case "3":
                        bool menuShow = true;
                        while (menuShow)
                        {
                            Console.Write("---- Mostrar usuarios ----\n\n" +
                                          "1. Usuarios sin dirección\n" +
                                          "2. Usuarios sin teléfono\n" +
                                          "3. Ver usuario por correo\n" +
                                          "4. Ver usuario por Id" +
                                          "5. Volver al menú anterior\n" +
                                          ">> ");
                            string optShow = Console.ReadLine();
                            switch (optShow)
                            {
                                case "1":
                                    break;
                                case "2":
                                    break;
                                case "3":
                                    break;
                                case "4":
                                    break;
                                case "5":
                                    menuShow = false;
                                    break;
                            }
                        }
                        break;
                    
                    case "4":
                        main = false;
                        break;
                }
            }

            break;
        
        case "5":
            flag = false;
            break;
        
        default:
            Console.WriteLine("Ingrese una opcion valida!");
            break;
    }
}


