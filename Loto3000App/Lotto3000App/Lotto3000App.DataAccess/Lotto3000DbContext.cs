using System.Text.Json;
using Lotto3000App.Domain.Enums;
using Lotto3000App.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lotto3000App.DataAccess
{
    public class Lotto3000DbContext : DbContext
    {
        public Lotto3000DbContext(DbContextOptions<Lotto3000DbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<Winner> Winners { get; set; }
        public DbSet<Prize> Prizes { get; set; }
        protected override void OnModelCreating(ModelBuilder model)
        {
            var jsonListIntConverter =
                new ValueConverter<List<int>, string>(
                    v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                    v => JsonSerializer.Deserialize<List<int>>(v, (JsonSerializerOptions?)null) ?? new List<int>());

            model.Entity<User>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Username).IsRequired().HasMaxLength(64);
                e.Property(x => x.FirstName).HasMaxLength(64);
                e.Property(x => x.LastName).HasMaxLength(64);
                e.HasIndex(x => x.Username).IsUnique();
            });

            model.Entity<Session>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.StartTime).IsRequired();
                e.Property(x => x.IsActive).HasDefaultValue(true);
                e.HasMany(x => x.Tickets).WithOne(t => t.Session).HasForeignKey(t => t.SessionId);
                e.HasMany(x => x.Draws).WithOne(d => d.Session).HasForeignKey(d => d.SessionId);
            });

            model.Entity<Ticket>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Numbers).HasConversion(jsonListIntConverter).HasColumnType("nvarchar(max)");
                e.Property(x => x.SubmittedAt).HasDefaultValueSql("SYSUTCDATETIME()");
                e.HasOne(x => x.User).WithMany(u => u.Tickets).HasForeignKey(x => x.UserId);
                e.HasIndex(x => x.SessionId);
                e.HasIndex(x => x.UserId);
            });

            model.Entity<Draw>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.StartedAt).HasDefaultValueSql("SYSUTCDATETIME()");
                e.Property(x => x.DrawnNumbers).HasConversion(jsonListIntConverter).HasColumnType("nvarchar(max)");
                e.HasOne(x => x.Session).WithMany(s => s.Draws).HasForeignKey(x => x.SessionId);
                e.HasOne(x => x.InitiatedBy).WithMany().HasForeignKey(x => x.InitiatedByUserId).OnDelete(DeleteBehavior.Restrict);
            });

            model.Entity<Prize>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Tier).IsRequired();
                e.Property(x => x.Name).IsRequired().HasMaxLength(64);
                e.HasIndex(x => x.Tier).IsUnique();
                e.HasData(
                    new Prize { Id = 3, Tier = PrizeTier.Three, Name = "50$ Gift Card" },
                    new Prize { Id = 4, Tier = PrizeTier.Four, Name = "100$ Gift Card" },
                    new Prize { Id = 5, Tier = PrizeTier.Five, Name = "TV" },
                    new Prize { Id = 6, Tier = PrizeTier.Six, Name = "Vacation" },
                    new Prize { Id = 7, Tier = PrizeTier.Seven, Name = "Car" }
                );
            });

            model.Entity<Winner>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.CreatedAt).HasDefaultValueSql("SYSUTCDATETIME()");
                e.Property(x => x.WinningNumbers).HasConversion(jsonListIntConverter).HasColumnType("nvarchar(max)");
                e.Property(x => x.FirstName).IsRequired().HasMaxLength(64);
                e.Property(x => x.LastName).IsRequired().HasMaxLength(64);

                e.HasOne(x => x.Draw).WithMany(d => d.Winners).HasForeignKey(x => x.DrawId);
                e.HasOne(x => x.Ticket).WithMany(t => t.Winners).HasForeignKey(x => x.TicketId);
                e.HasOne(x => x.User).WithMany(u => u.Wins).HasForeignKey(x => x.UserId);
                e.HasOne(x => x.Prize).WithMany(p => p.Winners).HasForeignKey(x => x.PrizeId);

                e.HasIndex(x => new { x.DrawId, x.TicketId, x.UserId, x.PrizeId }).IsUnique();
            });
           
        }

    }
}
