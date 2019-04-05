import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-lanches',
  templateUrl: './lanches.component.html',
  styleUrls: ['./lanches.component.css']
})
export class LanchesComponent implements OnInit {

  lanches: any ;

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getLanches();
  }

  getLanches()
  {
    this.http.get('http://localhost:5001/api/values').subscribe(response => {
      this.lanches = response;
      console.log
    }, error => {
      console.log(error);
    });
  }
}
