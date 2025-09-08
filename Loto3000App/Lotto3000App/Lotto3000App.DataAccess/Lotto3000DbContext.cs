using Microsoft.EntityFrameworkCore;

namespace Lotto3000App.DataAccess
{
    public class Lotto3000DbContext : DbContext
    {
        public Lotto3000DbContext(DbContextOptions<Lotto3000DbContext> options) : base(options)
        {
        }
        public DbSet<Lotto3000App.Domain.Models.User> Users { get; set; }
        public DbSet<Lotto3000App.Domain.Models.Ticket> Tickets { get; set; }
        public DbSet<Lotto3000App.Domain.Models.Session> Sessions { get; set; }
        public DbSet<Lotto3000App.Domain.Models.Draw> Draws { get; set; }
        public DbSet<Lotto3000App.Domain.Models.Winner> Winners { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //// Configure the DrawnNumbers property to be stored as a JSON string
            //modelBuilder.Entity<Lotto3000App.Domain.Models.Draw>()
            //    .Property(d => d.DrawnNumbers)
            //    .HasConversion(
            //        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions?)null),
            //        v => System.Text.Json.JsonSerializer.Deserialize<List<int>>(v, (System.Text.Json.JsonSerializerOptions?)null) ?? new List<int>());
            //// Configure the WinningNumbers property to be stored as a JSON string
            //modelBuilder.Entity<Lotto3000App.Domain.Models.Winner>()
            //    .Property(w => w.WinningNumbers)
            //    .HasConversion(
            //        v => System.Text.Json.JsonSerializer.Serialize(v, (System.Text.Json.JsonSerializerOptions?)null),
            //        v => System.Text.Json.JsonSerializer.Deserialize<List<int>>(v, (System.Text.Json.JsonSerializerOptions?)null) ?? new List<int>());
        }

    }
}
