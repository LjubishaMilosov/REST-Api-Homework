using Lotto3000App.DataAccess;
using Lotto3000App.DataAccess.Implementation;
using Lotto3000App.DataAccess.Interfaces;
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
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IDrawRepository, DrawRepository>();
            services.AddTransient<IWinnerRepository, WinnerRepository>();
            services.AddTransient<ISessionRepository, SessionRepository>();
            services.AddTransient<IPrizeRepository, PrizeRepository>();

        }

        public static void InjectServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITicketService, TicketService>();
            services.AddTransient<IDrawService, DrawService>();
            services.AddTransient<IWinnerService, WinnerService>();
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IPrizeService, PrizeService>();
        }
    }
}
