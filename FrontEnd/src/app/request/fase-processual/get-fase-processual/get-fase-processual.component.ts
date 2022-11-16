import { Router } from '@angular/router';
import { FaseProcessualService } from './../fase-processual.service';
import { Aux, FaseProcessual } from './../fase-processual.model';
import { Component, OnInit } from '@angular/core';
import { UsersService } from 'src/app/components/auth/users.service';

@Component({
  selector: 'app-get-fase-processual',
  templateUrl: './get-fase-processual.component.html',
  styleUrls: ['./get-fase-processual.component.css']
})
export class GetFaseProcessualComponent implements OnInit {
  baseURL = "https://localhost:7180/api/FaseProcssual";

  faseProcessual: FaseProcessual[] = [];
  aux: Aux[] = [];

  FaseOBJ: FaseProcessual = {
    idUtilizador: 0,
    nrProcesso: '',
    idEstado: 0,
    dataEntrada: '',
  }

  AuxOBJ: Aux = {
    ativasNaoAtivas: false,
    todas: false,
    idEst: 0,
  }

  constructor(private faseProcessualService: FaseProcessualService,
              private usersService: UsersService,
              private router: Router) { }

  ngOnInit(): void {
  }

  getByParam(): void {
    let id = this.usersService.getUserId();

    this.faseProcessualService.getAll(id, this.AuxOBJ.ativasNaoAtivas, this.AuxOBJ.todas, this.AuxOBJ.idEst).subscribe((fase) => {
      this.faseProcessual = fase;
      console.log(this.faseProcessual);
    })
  }

  getByNProc(): void {
    let id = this.usersService.getUserId();
    let a = "/";
    let b = "%2F";
    this.FaseOBJ.nrProcesso = this.FaseOBJ.nrProcesso?.replace(a, b);
    
    this.faseProcessualService.getByNproc(id, this.FaseOBJ.nrProcesso).subscribe((fase) => {
      this.faseProcessual = fase;
      console.log(this.faseProcessual);
    })
  }
}
