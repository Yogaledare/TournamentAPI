using Microsoft.EntityFrameworkCore;
using TournamentAPI.Core.Entities;

namespace TournamentAPI.Data.Data;

public class TournamentApiContext : DbContext {
    public TournamentApiContext(DbContextOptions<TournamentApiContext> options) : base(options) {
    }

    public DbSet<Tournament> Tournaments { get; set; }
    public DbSet<Game> Games { get; set; }
}