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
           .Include(x => x.Lanches);

           return query.ToArrayAsync();
        }      

        public decimal CalculaValorLanchePromocao(int idIngrediente, decimal valor, int qtd, int idLanche)
        {
            var retornoCardapio = RetornaCardapioById(idLanche);
            var retornoIngrediente = RetornaIngredienteById(idIngrediente);
            var ingrediente = retornoIngrediente.FirstOrDefault();            
            
            if((idLanche == 2 || idLanche == 3) && idIngrediente == 1) //ligth
            { 
                valor = valor + (ingrediente.Valor * qtd);               
                decimal desconto = 10;
                desconto = desconto / 100;
                valor = valor-(valor * desconto);
            }
            else if (qtd > 3 && (idIngrediente == 3 || idIngrediente ==5 )) //bacon e queijo
            {
                var desc = (qtd + 1) / 3;
                qtd = qtd - desc;
                valor = valor + (ingrediente.Valor * qtd);  
            }else{

                qtd++;
                valor = valor + (ingrediente.Valor * qtd);
            }

            return valor;            
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
           .Include(x => x.Lanches);

            query = query.Where(x => x.CardapioId == idCardapio);

           return query.ToArrayAsync();
        }

        private Ingrediente[] RetornaIngredienteById(int idIngrediente)
        {
           IQueryable<Ingrediente> query = _context.Ingredientes;

            query = query.Where(x => x.IngredienteId == idIngrediente);

           return query.ToArray();
        }
    }
}