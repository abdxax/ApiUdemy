using APICourseUdemy.Data;
using APICourseUdemy.Models;
using APICourseUdemy.Repstory;
using APICourseUdemy.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APICourseUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserRepstory _user;
        private readonly AppDbContext _db;


        public UserController(AppDbContext db)
        {
            _user = new UserService(db);
            _db = db;
        }

        [HttpGet("getUser")]
        [AllowAnonymous]
        public async Task<IEnumerable<AppUser>> users()
        {
            // return await _user.users();
            return await _db.appUsers.ToListAsync();
        }
        [HttpPost("addUser")]
        public async Task<ActionResult<AppUser>> addUser(AppUser user)
        {
           await _user.addUser(user);
            return user;
        }

        [HttpGet("user/{id}")]
        public ActionResult<AppUser> user(int id)
        {
            return _user.getUser(id);

        }
        //[HttpDelete("delete/{id}")]
        //public 


    }
}
