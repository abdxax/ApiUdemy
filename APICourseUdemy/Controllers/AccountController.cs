using APICourseUdemy.Data;
using APICourseUdemy.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace APICourseUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AppDbContext _db;
        public AccountController(AppDbContext db) 
        { 
        _db= db;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register(string UserName,string Password)
        {
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
               UserName=UserName,
               PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(Password)),
               PasswordSalt=hmac.Key
            };
            _db.appUsers.AddAsync(user);
            _db.SaveChangesAsync();

            return user;
        }
    }
}
