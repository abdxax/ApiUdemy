using APICourseUdemy.Data;
using APICourseUdemy.Models;
using APICourseUdemy.Repstory;
using Microsoft.EntityFrameworkCore;

namespace APICourseUdemy.Service
{
    public class UserService : IUserRepstory
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> addUser(AppUser user)
        {
           await _context.appUsers.AddAsync(user);
             await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> deleteUser(int id)
        {
           var user=_context.appUsers.Find(id);
            if(user==null) return false;
            _context.appUsers.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public AppUser getUser(int id)
        {
           var user= _context.appUsers.Find(id);
            if(user==null) return null;
            return user;
        }

        public async Task<bool> updateUser(AppUser user, int id)
        {
            var userItem = _context.appUsers.Find(id);
            if(user==null) return false;  
            userItem.UserName= user.UserName;
            _context.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<AppUser>> users()
        {
            return await _context.appUsers.ToListAsync();
        }
    }
}
