using System.Threading.Tasks;
using Alimentos.Dominio;

namespace Alimentos.Repositorio
{
    public interface IAlimentosRepositorio
    {
        //GERAL
         decimal CalculaValorLanchePromocao(int idIngrediente, decimal valor, int qtd, int idLanche);
         Task<Cardapio[]> RetornaCardapio();
         Task<Ingrediente[]> RetornaIngredientes();
         Task<Cardapio[]> RetornaCardapioById(int idCardapio);
         
    }
}