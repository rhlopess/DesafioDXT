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
  novoValor: number;
  mostraValor = false;

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

  CalcularValorLanche2(idIngrediente: number, valor: number, idLanche: number) {
     this.pedido = Object.assign({}, this.registerForm.value);
     this.lancheService.getValorLanche(idIngrediente, valor, this.pedido.adicionalid, idLanche).subscribe(
       (newvalue: number) => {
         this.novoValor = newvalue;
         this.mostraValor = true;
         console.log(newvalue);
        }, error => {
          console.log(error);
       });
  }

  selecionarLanche(id: number) {
    this.lancheService.getLancheById(id).subscribe(
      ( newlanche: Cardapio[]) => {
        this.lanche = newlanche;
        this.mostraValor = false;
        console.log(newlanche);
      }, error => {
        console.log(error);
      });
    this.mostrarGrid = this.mostrarGrid;
    this.mostrarBotaoCalcular = true;
}

  getLanches() {
      this.lancheService.getLanches().subscribe(
      (newlanches: Cardapio[]) => {
      this.lanches = newlanches;
      console.log(newlanches);
    }, error => {
      console.log(error);
    });
  }

  getIngredientes() {
    this.lancheService.getIngredientes().subscribe(
    (newingrediente: Ingrediente[]) => {
    this.ingredientes = newingrediente;
    console.log(newingrediente);
  }, error => {
    console.log(error);
  });
}
}
