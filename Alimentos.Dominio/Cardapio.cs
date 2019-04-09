using System.Collections.Generic;

namespace Alimentos.Dominio
{
    public class Cardapio
    {
        public int CardapioId { get; set; }
        public string Lanche {get; set;} 
        public decimal Valor {get;set;}
        public List<Ingrediente> Ingredientes {get ; set;}
    }
}