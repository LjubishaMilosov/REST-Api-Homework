using Lotto3000App.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace Lotto3000App.Helpers

{
    public static class DependencyInjectionHelper
    {
        public static void InjectDbContext(IServiceCollection services)
            {
                services.AddDbContext<Lotto3000DbContext>(x => x.UseSqlServer("Server=.\\SQLExpress;Database=Lotto3000App;Trusted_Connection=True;TrustServerCertificate=True"));
            }
    }
}
