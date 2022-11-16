import { UsersService } from './../../../components/auth/users.service';
import { Processo } from './../processo-api/processo.model';
import { Component, OnInit } from "@angular/core";
import { ProcessoService } from "../processo.service";
import { Router } from '@angular/router';

@Component({
  selector: "app-get-processo",
  templateUrl: "./get-processo.component.html",
  styleUrls: ["./get-processo.component.css"]
})
export class GetProcessoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Processo";

  processo: Processo[] = [];

  ProcessoOBJ: Processo = {
    idUtilizador: 0,
    nrProcesso: ''
  };

  constructor(private processoService: ProcessoService,
              private usersService : UsersService,
              private router: Router) { }

  ngOnInit(): void {
    let id = this.usersService.getUserId()
    
    this.processoService.getAll(id).subscribe((processo) => {
      this.processo = processo;
      console.log(this.processo);
    })
  }

  getTabela(): void {
    let id = this.usersService.getUserId();

    if (this.ProcessoOBJ.nrProcesso == '') {
      this.processoService.getAll(id).subscribe((processo) => {
        this.processo = processo;
        console.log(this.processo);
      })
    }
    else {
      this.processoService.getProc(id, this.ProcessoOBJ.nrProcesso).subscribe((processo) => {
        this.processo = processo;
        console.log(this.processo);
      })
    }
  }
}
