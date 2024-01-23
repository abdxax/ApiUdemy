using APICourseUdemy.Data;
using APICourseUdemy.DOTS;
using APICourseUdemy.Interface;
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
        private readonly ITokenService _token;
        public AccountController(AppDbContext db, ITokenService token) 
        { 
        _db= db;
        _token = token;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register([FromBody]RegisterDots registerDots)
        {
            if (await userExit(registerDots.userName))
            {
                return BadRequest("The UserName alrealy eacit ");
            }
            using var hmac = new HMACSHA512();
            var user = new AppUser
            {
               UserName= registerDots.userName,
               PasswordHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDots.password)),
               PasswordSalt=hmac.Key
            };
            _db.appUsers.AddAsync(user);
            _db.SaveChangesAsync();

            return user;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDpts>> login(LogindDots logind)
        {
            var user = _db.appUsers.SingleOrDefault(x => x.UserName == logind.UserName);
            if (user == null) return Unauthorized("inavlid User NAme");

            using var has5 = new HMACSHA512(user.PasswordSalt);
            var computHash = has5.ComputeHash(Encoding.UTF8.GetBytes(logind.Password));
            for(int i =0; i < computHash.Length; i++)
            {
                if (computHash[i] != user.PasswordHash[i]) return Unauthorized("invalid password");
            }
            return new UserDpts
            {
                userName = user.UserName,
                token = _token.createUser(user)

            };



        }

        public async Task<bool> userExit(string userN)
        {
            var user = _db.appUsers.Where(x => x.UserName == userN).FirstOrDefault();

            if (user != null)
            {
                return true;
            }
            return false;

        }
    }
}
