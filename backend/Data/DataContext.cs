using Microsoft.EntityFrameworkCore;
using Superheroes.Api.Entities;

namespace Superheroes.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Herois> Herois { get; set; }
    public DbSet<Superpoderes> Superpoderes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Superpoderes>().HasData(
                new Superpoderes { Id = 1, Superpoder = "Voo", Descricao = "Capacidade de voar" },
                new Superpoderes { Id = 2, Superpoder = "Super Força", Descricao = "Força física sobre-humana" },
                new Superpoderes { Id = 3, Superpoder = "Invisibilidade", Descricao = "Capacidade de se tornar invisível" },
                new Superpoderes { Id = 4, Superpoder = "Teletransporte", Descricao = "Capacidade de ir de um lugar a outro instantaneamente" },
                new Superpoderes { Id = 5, Superpoder = "Diminuir de tamanho", Descricao = "Capacidade de reduzir seu tamanho a níveis microscópicos" }
            );
        }
}