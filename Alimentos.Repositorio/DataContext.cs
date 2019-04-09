using Alimentos.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Alimentos.Repositorio
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Cardapio> Cardapio { get; set; }
    }
}