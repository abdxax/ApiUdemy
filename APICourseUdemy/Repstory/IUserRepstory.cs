using APICourseUdemy.Models;
using System.Collections.Generic;

namespace APICourseUdemy.Repstory
{
    public interface IUserRepstory
    {
         Task<IEnumerable<AppUser>> users();
         Task<bool> addUser(AppUser user);
         AppUser getUser(int id);
         Task<bool> updateUser(AppUser user,int id) ;
          Task<bool> deleteUser(int id);
    }
}
