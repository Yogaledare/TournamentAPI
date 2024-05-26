using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Entities;

namespace TournamentAPI.Data.Data;

public class TournamentApiContext : DbContext {
    public TournamentApiContext(DbContextOptions<TournamentApiContext> options) : base(options) {
    }

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Game> Games { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Game>()
            .HasOne(g => g.Tournament)  // Each Game has one Tournament
            .WithMany(t => t.Game)     // Each Tournament can have many Games
            .HasForeignKey(g => g.TournamentId)  // Foreign key in Game pointing to Tournament
            .IsRequired();  // Indicates that TournamentId is a required field

    }
}