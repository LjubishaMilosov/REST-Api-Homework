using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DataAccess;
using MoviesApp.DataAccess.Implementation;
using MoviesApp.DataAccess.Interfaces;

namespace MoviesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services)
        {
            services.AddDbContext<MoviesDbContext>
                (x => x.UseSqlServer("Server=.\\SQLExpress;Database=MoviesApp;Trusted_Connection=True;TrustServerCertificate=True"));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
    }
}
