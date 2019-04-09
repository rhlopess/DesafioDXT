using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alimentos.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Alimentos.Repositorio
{
    public class AlimentosRepositorio : IAlimentosRepositorio
    {
        public readonly DataContext _context;
        public AlimentosRepositorio(DataContext context)
        {
            _context = context;
        }
        public Task<Cardapio[]> RetornaCardapio()
        {
           IQueryable<Cardapio> query = _context.Cardapio
           .Include(x => x.Ingredientes);

           return query.ToArrayAsync();
        }      

        public Task<float> CalculaValorLanche(Cardapio model)
        {
            throw new System.NotImplementedException();
        }

        Task<Ingrediente[]> IAlimentosRepositorio.RetornaIngredientes()
        {
            IQueryable<Ingrediente> query = _context.Ingredientes;
            query = query.GroupBy(x => x.Nome).Select(x=>x.First()); 
            return query.ToArrayAsync();
        }

         public Task<Cardapio[]> RetornaCardapioById(int idCardapio)
        {
           IQueryable<Cardapio> query = _context.Cardapio
           .Include(x => x.Ingredientes);

            query = query.Where(x => x.CardapioId == idCardapio);

           return query.ToArrayAsync();
        }
    }
}