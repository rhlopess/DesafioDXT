using System.Threading.Tasks;
using Alimentos.Dominio;

namespace Alimentos.Repositorio
{
    public interface IAlimentosRepositorio
    {
        //GERAL
         Task<float> CalculaValorLanche(Cardapio model);
         Task<Cardapio[]> RetornaCardapio();
         Task<Ingrediente[]> RetornaIngredientes();
         Task<Cardapio[]> RetornaCardapioById(int idCardapio);
    }
}