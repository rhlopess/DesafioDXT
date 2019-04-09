import { Ingrediente } from './Ingrediente';

export interface Cardapio {
    cardapioId: number;
    lanche: string;
    ingredientes: Ingrediente[];
}
