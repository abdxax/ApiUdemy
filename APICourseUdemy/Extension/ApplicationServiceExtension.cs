using APICourseUdemy.Data;
using APICourseUdemy.Interface;
using APICourseUdemy.Repstory;
using APICourseUdemy.Service;
using Microsoft.EntityFrameworkCore;

namespace APICourseUdemy.Extension
{
    public static class ApplicationServiceExtension
    {

        public static IServiceCollection ApplicationService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("myConnection"));
            });
            services.AddCors();
            //Add Services
            services.AddScoped<IUserRepstory, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
