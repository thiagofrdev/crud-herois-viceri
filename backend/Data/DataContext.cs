using Microsoft.EntityFrameworkCore;
using Superheroes.Api.Entities;

namespace Superheroes.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Herois> Herois { get; set; }
    public DbSet<Superpoderes> Superpoderes { get; set; }
}
