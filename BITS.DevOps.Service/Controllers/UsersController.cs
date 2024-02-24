using System.Data.SqlClient;
using System.Xml;
using BITS.DevOps.Service.Models;
using Microsoft.AspNetCore.Mvc;

namespace BITS.DevOps.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly string connectionString = "YourConnectionStringHere";

        public IActionResult GetUserDetails(string userId)
        {
            var query = $"SELECT * FROM Users WHERE UserId = '{userId}'";
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        var userDetails = new
                        {
                            UserId = reader["UserId"].ToString(),
                            UserName = reader["UserName"].ToString(),
                            Email = reader["Email"].ToString()
                        };
                        return Json(userDetails);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (SqlException)
                {
                    return StatusCode(500, "An error occurred while processing your request.");
                }
            }
        }
        
        [HttpPost("UpdateUser")]
        public IActionResult UpdateUser([FromBody] string userData)
        {
            var user = System.Text.Json.JsonSerializer.Deserialize<User>(userData); 
            // Update user logic...
            return Ok();
        }
        
        [HttpGet("GetUserEmail")]
        public IActionResult GetUserEmail(string userId)
        {
            string userEmail = "user@example.com";
            return Ok(userEmail);
        }
        
        [HttpPost("UploadFile")]
        public IActionResult UploadFile([FromBody] XmlElement xmlContent)
        {
            return Ok();
        }
        
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginModel login)
        {
            return Ok("Logged In");
        }
        
        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] User user)
        {
            UserContext _dbContext = new UserContext();
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
            return Ok();
        }
        
        [HttpGet("GetError")]
        public IActionResult GetError()
        {
            try
            {
                throw new NullReferenceException("Required");
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}"); // Exposes sensitive error information
            }
        }
    }
}
