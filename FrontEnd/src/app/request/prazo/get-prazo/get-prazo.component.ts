import { PrazoService } from './../prazo.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { Aux, Prazo } from '../prazo.model';

@Component({
  selector: 'app-get-prazo',
  templateUrl: './get-prazo.component.html',
  styleUrls: ['./get-prazo.component.css']
})
export class GetPrazoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Prazo";

  prazo: Prazo[] = [];
  aux: Aux[] = [];

  PrazoOBJ: Prazo = {
    idPrazoCodigo: 0,
    idUtilizador: 0,
    idCodigo: 0,
    nrArtigo: 0,
    nrProcesso: '',
    dataInicial: '',
    dataFinal: '',
  }

  AuxOBJ: Aux = {
    prioritarios: false,
    num: 0,
  }


  constructor(private usersService: UsersService,
              private prazoService: PrazoService) { }

  ngOnInit(): void {
  }

  getByParam(): void {
    let id = this.usersService.getUserId();

    this.prazoService.getAll(id, this.AuxOBJ.prioritarios, this.AuxOBJ.num).subscribe((prazo) => {
      this.prazo = prazo;
      console.log(this.prazo);
    })
  }

  getByNProc(): void {
    let id = this.usersService.getUserId();
    let a = "/";
    let b = "%2F";
    this.PrazoOBJ.nrProcesso = this.PrazoOBJ.nrProcesso?.replace(a, b);
    
    this.prazoService.getByNProc(id, this.PrazoOBJ.nrProcesso).subscribe((prazo) => {
      this.prazo = prazo;
      console.log(this.prazo);
    })
  }
}