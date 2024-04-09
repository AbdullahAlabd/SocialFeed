using Microsoft.EntityFrameworkCore;
using User.Business.Services;
using User.DAL.Repositories;

namespace User.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Register DbContext
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
            #endregion

            #region Register Services
            services.AddScoped<IUserService, UserService>();
            #endregion

            #region Register Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion

            return services;
        }
    }
}
