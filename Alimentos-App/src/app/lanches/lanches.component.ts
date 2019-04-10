import { Component, OnInit } from '@angular/core';
import { LanchesService } from '../services/lanches.service';
import { Cardapio } from '../models/cardapio';
import { Ingrediente } from '../models/Ingrediente';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { Pedido } from '../models/pedido';

@Component({
  selector: 'app-lanches',
  templateUrl: './lanches.component.html',
  styleUrls: ['./lanches.component.css']
})
export class LanchesComponent implements OnInit {

  lanches: Cardapio[];
  ingredientes: Ingrediente[];
  mostrarGrid = true;
  valor: number;
  lanche: Cardapio[];
  mostrarBotaoCalcular = false;
  registerForm: FormGroup;
  pedido: Pedido;

  constructor(
    private lancheService: LanchesService,
    private fb: FormBuilder,
    ) { }

  ngOnInit() {
    this.getLanches();
    this.getIngredientes();
    this.validacao();
  }

  validacao()  {
    this.registerForm = this.fb.group({
      cardapioid: [],
      adicionalid: []
    });
  }

  CalcularValorLanche() {
    this.pedido = Object.assign({}, this.registerForm.value);
    this.lancheService.postLanches(this.pedido).subscribe();
  }

  CalcularValorLanche2(idIngrediente: number, idLanche: number) {
     this.pedido = Object.assign({}, this.registerForm.value);
     this.lancheService.getValorLanche(idIngrediente, this.pedido.adicionalid, idLanche).subscribe();
  }

  selecionarLanche(id: number) {
    this.lancheService.getLancheById(id).subscribe(
      ( _lanche: Cardapio[]) => {
        this.lanche = _lanche;
        console.log(_lanche);
      }, error => {
        console.log(error);
      });
    this.mostrarGrid = this.mostrarGrid;
    this.mostrarBotaoCalcular = true;
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
// tslint:disable-next-line: variable-name
    (_ingrediente: Ingrediente[]) => {
    this.ingredientes = _ingrediente;
    console.log(_ingrediente);
  }, error => {
    console.log(error);
  });
}
}


