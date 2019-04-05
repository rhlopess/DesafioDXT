using Alimentos.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Alimentos.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options){}

        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Cardapio> Cardapio { get; set; }
    }
}