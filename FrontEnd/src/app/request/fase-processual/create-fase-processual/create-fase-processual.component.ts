import { Estado } from './../../gets/get-estado/estado.model';
import { Router } from '@angular/router';
import { EstadoService } from './../../gets/get-estado/estado.service';
import { UsersService } from 'src/app/components/auth/users.service';
import { FaseProcessualService } from './../fase-processual.service';
import { FaseProcessual } from './../fase-processual.model';
import { Component, OnInit } from '@angular/core';
import { ProcessoService } from '../../processo/processo.service';
import { Processo } from '../../processo/processo-api/processo.model';

@Component({
  selector: 'app-create-fase-processual',
  templateUrl: './create-fase-processual.component.html',
  styleUrls: ['./create-fase-processual.component.css']
})
export class CreateFaseProcessualComponent implements OnInit {
  baseURL = "https://localhost:7180/api/FaseProcssual";

  faseProcessual: FaseProcessual[] = [];
  estado: Estado[] = [];
  processo: Processo[] = [];

  FaseOBJ: FaseProcessual = {
    idEstado: 0,
    idUtilizador: 0,
    nrProcesso: '',
    dataEntrada: '',
    nrDias: 0,
    dataSaida: '',
  }

  constructor(private faseProcessualService: FaseProcessualService,
              private usersService: UsersService,
              private estadoService: EstadoService,
              private router: Router,
              private processoService: ProcessoService) { }

  ngOnInit(): void {
    this.estadoService.get().subscribe((result) => {
      this.estado = result;
      console.log(this.estado);
    })
    let id = this.usersService.getUserId();
    this.processoService.getAll(id).subscribe((result) => {
      this.processo = result;
      console.log(this.processo);
    })
  }

  postFase(): void {
    let id = this.usersService.getUserId();

    let a = "/";
    let b = "%2F";
    this.FaseOBJ.nrProcesso = this.FaseOBJ.nrProcesso?.replace(a, b);
    
    this.faseProcessualService.post(id, this.FaseOBJ.nrProcesso, this.FaseOBJ).subscribe((fase) => {
      this.FaseOBJ = fase;
      console.log("post:", this.FaseOBJ);
      alert("Fase Processual Criada com SUCESSO!");
      this.router.navigate(["/get-faseprocessual"]);
    })
  }

  cancel(): void {
    this.router.navigate(["/get-faseprocessual"]);
  }

  validaEstado(id: any) {
    this.FaseOBJ.idEstado = id;
    console.log("-->", this.FaseOBJ.idEstado);
  }

  validaProcesso(id: any) {
    this.FaseOBJ.nrProcesso = id;
    console.log("-->", this.FaseOBJ.nrProcesso);
  }
}
