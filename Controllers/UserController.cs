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
    
    // UPDATE USERS
    public void UpdateUser(
        int id,
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Phone,
        string CellPhone,
        string Address,
        string City,
        string State,
        string Zipcode,
        string Country,
        string Gender,
        int Age,
        string? Password)
    {
        using (var db = new AppDbContext(Credentials))
        {
            var user = db.users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                user.FirstName = FirstName;
                user.LastName = LastName;
                user.Username = Username;
                user.Email = Email;
                user.Phone = Phone;
                user.CellPhone = CellPhone;
                user.Address = Address;
                user.City = City;
                user.State = State;
                user.Zipcode = Zipcode;
                user.Country = Country;
                user.Gender = Gender;
                user.Age = Age;
                user.Password = Password;

                if (!string.IsNullOrWhiteSpace(Password)) user.Password = Password;
                
                db.SaveChanges();
                Console.WriteLine($"User {id} has been updated");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        
    }
    
}