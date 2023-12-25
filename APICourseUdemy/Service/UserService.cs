using APICourseUdemy.Data;
using APICourseUdemy.Models;
using APICourseUdemy.Repstory;

namespace APICourseUdemy.Service
{
    public class UserService : IUserRepstory
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public void addUser(AppUser user)
        {
            _context.appUsers.Add(user);
            _context.SaveChanges();
        }

        public bool deleteUser(int id)
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

        public bool updateUser(AppUser user, int id)
        {
            var userItem = _context.appUsers.Find(id);
            if(user==null) return false;  
            userItem.UserName= user.UserName;
            _context.SaveChanges();
            return true;
        }

        public IList<AppUser> users()
        {
            return _context.appUsers.ToList();
        }
    }
}
