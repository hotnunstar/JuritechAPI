import { UsersService } from './../../../components/auth/users.service';
import { UsersApiComponent } from './../../../components/auth/users-api/users-api.component';
import { Router } from '@angular/router';
import { TipoProcessoService } from './../tipo-processo.service';
import { TipoProcesso } from './../tipo-processo.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-get-tipo-processo',
  templateUrl: './get-tipo-processo.component.html',
  styleUrls: ['./get-tipo-processo.component.css']
})
export class GetTipoProcessoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/FaseProcssual";

  tipoProcesso: TipoProcesso[] = [];

  TipoProcessoOBJ: TipoProcesso = {
    id: 0,
    idTema: 0,
    idUtilizador: 0,
    nome: ""
  }


  constructor(private tipoProcessoService: TipoProcessoService,
              private usersService: UsersService,
              private router: Router) { }

  ngOnInit(): void {
    let id = this.usersService.getUserId();

    this.tipoProcessoService.getAll(id).subscribe((tipo) => {
      this.tipoProcesso = tipo;
      console.log(this.tipoProcesso);
    });
  }

}
