using Lotto3000App.DataAccess;
using Lotto3000App.DataAccess.Implementation;
using Lotto3000App.DataAccess.Interfaces;
using Lotto3000App.Domain.Models;
using Lotto3000App.Services.Implementation;
using Lotto3000App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Lotto3000App.Helpers

{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Lotto3000DbContext>(x => x.UseSqlServer(connectionString));
        }

        public static void InjectRepositories(IServiceCollection services)
        {
            services.AddTransient<IUserRepository<User>, UserRepository>();
            services.AddTransient<ITicketRepository<Ticket>, TicketRepository>();
            services.AddTransient<IDrawRepository<Draw>, DrawRepository>();
            services.AddTransient<IWinnerRepository<Winner>, WinnerRepository>();
            services.AddTransient<ISessionRepository<Session>, SessionRepository>();

        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserService<User>, UserService>();
            services.AddTransient<ITicketService<Ticket>, TicketService>();
            services.AddTransient<IDrawService<Draw>, DrawService>();
            services.AddTransient<IWinnerService<Winner>, WinnerService>();
            services.AddTransient<ISessionService<Session>, SessionService>();
        }
    }
}
