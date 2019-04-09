import { Component, OnInit } from '@angular/core';
import { LanchesService } from '../services/lanches.service';
import { Cardapio } from '../models/cardapio';
import { Ingrediente } from '../models/Ingrediente';

@Component({
  selector: 'app-lanches',
  templateUrl: './lanches.component.html',
  styleUrls: ['./lanches.component.css']
})
export class LanchesComponent implements OnInit {

  lanches: Cardapio[];
  ingredientes: Ingrediente[];
  mostrarGrid = false;
  valor: number;
  lanche: Cardapio[];

  constructor(private lancheService: LanchesService) { }

  ngOnInit() {
    this.getLanches();
    this.getIngredientes();
  }

  getLanches() {
      this.lancheService.getLanches().subscribe(
      (_lanches: Cardapio[]) => {
      this.lanches = _lanches;
      console.log(_lanches);
    }, error => {
      console.log(error);
    });
  }

  getIngredientes() {
    this.lancheService.getIngredientes().subscribe(
    (_ingrediente: Ingrediente[]) => {
    this.ingredientes = _ingrediente;
    console.log(_ingrediente);
  }, error => {
    console.log(error);
  });
}
  selecionarLanche(id: number) {
    this.lancheService.getLancheById(id).subscribe(
      ( _lanche: Cardapio[]) => {
        this.lanche = _lanche;
        console.log(_lanche);
      }, error => {
        console.log(error);
      });
    this.mostrarGrid = !this.mostrarGrid;
}
}


