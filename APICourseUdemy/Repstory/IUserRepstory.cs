using APICourseUdemy.Models;

namespace APICourseUdemy.Repstory
{
    public interface IUserRepstory
    {
         IList<AppUser> users();
        void addUser(AppUser user);
        AppUser getUser(int id);
        bool updateUser(AppUser user,int id) ;
        bool deleteUser(int id);
    }
}
