using APICourseUdemy.Models;

namespace APICourseUdemy.Interface
{
    public interface ITokenService
    {
        string createUser(AppUser user);
    }
}
