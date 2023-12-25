using APICourseUdemy.Data;
using APICourseUdemy.Models;
using APICourseUdemy.Repstory;
using APICourseUdemy.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICourseUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepstory _user;

        public UserController(AppDbContext db)
        {
            _user = new UserService(db); ;
        }

        [HttpGet("getUser")]
        public IList<AppUser> users()
        {
            return _user.users();
        }
        [HttpPost("addUser")]
        public AppUser addUser(AppUser user)
        {
            _user.addUser(user);
            return user;
        }
    }
}
