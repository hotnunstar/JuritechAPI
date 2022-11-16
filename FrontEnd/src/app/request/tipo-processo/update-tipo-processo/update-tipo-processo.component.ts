import { Tema } from './../../tema/tema-api/tema.model';
import { TemaService } from './../../tema/tema.service';
import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { TipoProcesso } from '../tipo-processo.model';
import { TipoProcessoService } from '../tipo-processo.service';

@Component({
  selector: 'app-update-tipo-processo',
  templateUrl: './update-tipo-processo.component.html',
  styleUrls: ['./update-tipo-processo.component.css']
})
export class UpdateTipoProcessoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/FaseProcssual";

  tema: Tema[] = [];
  tipoProcesso: TipoProcesso[] = [];

  TipoProcessoOBJ: TipoProcesso = {
    idUtilizador: 0,
    idTema: 0,
    nome: '',
    id: 0
  }

  constructor(private tipoProcessoService: TipoProcessoService,
              private usersService: UsersService,
              private route: ActivatedRoute,
              private router: Router,
              private temaService: TemaService) { }

  ngOnInit(): void {
    let idUtilizador = this.usersService.getUserId();
    this.route.snapshot.paramMap.get("idUtilizador");
    let id = this.route.snapshot.paramMap.get("id");

    this.tipoProcessoService.getTipo(idUtilizador, id).subscribe((tipo) => {
      this.TipoProcessoOBJ = tipo[0];
      console.log("Tipo Processo -->", this.TipoProcessoOBJ);
    });

    this.temaService.getAll(idUtilizador).subscribe((result) => {
      this.tema = result;
      console.log(this.tema);
    })
  }

  putTipoProcesso(): void {
    let id = this.usersService.getUserId();

    this.tipoProcessoService.put(id, this.TipoProcessoOBJ.id, this.TipoProcessoOBJ).subscribe((tipo) => {
      this.TipoProcessoOBJ = tipo;
      console.log("put:", this.TipoProcessoOBJ);
      alert("Tipo Processo Alterado com SUCESSO!");
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
