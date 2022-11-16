import { TipoProcesso } from './../../tipo-processo/tipo-processo.model';
import { TipoProcessoService } from './../../tipo-processo/tipo-processo.service';
import { Processo } from './../processo-api/processo.model';
import { Component, OnInit } from "@angular/core";
import { ProcessoService } from "../processo.service";
import { Router } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';

@Component({
  selector: 'app-create-processo',
  templateUrl: './create-processo.component.html',
  styleUrls: ['./create-processo.component.css']
})
export class CreateProcessoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Processo";

  processo: Processo[] = [];
  tipoProcesso: TipoProcesso[] = [];

  ProcessoOBJ: Processo = {
    idUtilizador: 0,
    nrProcesso: '',
    nome: '',
    idTipo: 0,
    valor: 0,
    notas: '',
    dataEntrada: '',
    estado: false
  };

  constructor(private processoService: ProcessoService,
              private usersService: UsersService,
              private tipoProcessoService: TipoProcessoService,
              private router: Router) { }

  ngOnInit(): void {
    let id = this.usersService.getUserId();
    this.tipoProcessoService.getAll(id).subscribe((result) => {
      this.tipoProcesso = result;
      console.log(this.tipoProcesso);
    })
  }

  postProcesso(): void {
    let id = this.usersService.getUserId();

    this.processoService.post(id, this.ProcessoOBJ).subscribe((processo) => {
      this.ProcessoOBJ = processo;
      console.log("post:", this.ProcessoOBJ);
      alert("Processo criado com SUCESSO!");
      this.router.navigate(["/get-processo"]);
    })
  }

  cancel(): void {
    this.router.navigate(["/get-processo"]);
  }

  validaTipoProcesso(id: any) {
    this.ProcessoOBJ.idTipo = id;
    console.log("-->", this.ProcessoOBJ.idTipo);
  }
}
