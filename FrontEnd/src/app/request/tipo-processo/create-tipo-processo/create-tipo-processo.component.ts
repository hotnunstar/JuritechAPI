import { Tema } from './../../tema/tema-api/tema.model';
import { TemaService } from './../../tema/tema.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { TipoProcesso } from '../tipo-processo.model';
import { TipoProcessoService } from '../tipo-processo.service';

@Component({
  selector: 'app-create-tipo-processo',
  templateUrl: './create-tipo-processo.component.html',
  styleUrls: ['./create-tipo-processo.component.css']
})
export class CreateTipoProcessoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/FaseProcssual";

  tema: Tema[] = [];
  tipoProcesso: TipoProcesso[] = [];

  TipoProcessoOBJ: TipoProcesso = {
    idUtilizador: 0,
    id: 0,
    nome: '',
    idTema: 0
  }

  constructor(private tipoProcessoService: TipoProcessoService,
              private usersService: UsersService,
              private temaService: TemaService,
              private router: Router) { }

  ngOnInit(): void {
    let id = this.usersService.getUserId();

    this.temaService.getAll(id).subscribe((result) => {
      this.tema = result;
      console.log(this.tema);
    })
  }

  postTipoProcesso(): void {
    let id = this.usersService.getUserId();

    this.tipoProcessoService.post(id, this.TipoProcessoOBJ).subscribe((tipo) => {
      this.TipoProcessoOBJ = tipo;
      console.log("post", this.TipoProcessoOBJ);
      alert("Tipo Processo Criado com SUCESSO!");
      this.router.navigate(["/get-tipoprocesso"]);
    })
  }

  cancel(): void {
    this.router.navigate(["/get-tipoprocesso"]);
  }

  validaTipoProcesso(id: any) {
    this.TipoProcessoOBJ.idTema = id;
    console.log("-->", this.TipoProcessoOBJ.idTema);
  }
}
