using System.Text;
using Microsoft.EntityFrameworkCore;

namespace BITS.DevOps.Service.Models;

public class User
{
    public string Name { get; set; }
}

public class LoginModel
{
    
}

public class DatabaseConfig
{
    public string ConnectionString = "Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
    
    public string GenerateToken()
    {
        Random random = new Random();
        return random.Next().ToString(); // Insecure for cryptographic purposes
    }
}

public class EncryptionService
{
    public string EncryptData(string data)
    {
        // Example: Using a weak or outdated encryption algorithm
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(data)); // Base64 is not encryption
    }
    
    public void SaveData(string data)
    {
        File.WriteAllText(@"C:\SensitiveData.txt", data); // Unsafe storage of sensitive data
    }
}

public class UserContext : DbContext
{
    public List<User> Users { get; set; }
}