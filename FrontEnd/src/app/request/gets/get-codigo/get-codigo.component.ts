import { Component, OnInit } from '@angular/core';
import { Codigo } from './codigo.model';

@Component({
  selector: 'app-get-codigo',
  templateUrl: './get-codigo.component.html',
  styleUrls: ['./get-codigo.component.css']
})
export class GetCodigoComponent implements OnInit {

  codigo: Codigo[] = [];

  constructor() { }

  ngOnInit(): void {
  }

}
