using Microsoft.EntityFrameworkCore;
using User.DAL.Repositories;

namespace User.API.Extensions
{
    public static class MigrationExtensions
    {
        public static void ApplyMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<UserDbContext>();
            context.Database.Migrate();
        }
    }
}
