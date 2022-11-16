import { ProcessoService } from "./../processo.service";
import { Component, OnInit } from "@angular/core";
import { Processo } from "../processo-api/processo.model";
import { ActivatedRoute, Router } from "@angular/router";
import { UsersService } from "src/app/components/auth/users.service";
import { TipoProcessoService } from "../../tipo-processo/tipo-processo.service";
import { TipoProcesso } from "../../tipo-processo/tipo-processo.model";


@Component({
  selector: "app-update-processo",
  templateUrl: "./update-processo.component.html",
  styleUrls: ["./update-processo.component.css"],
})
export class UpdateProcessoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Processo";

  processo: Processo[] = [];
  tipo: TipoProcesso[] = [];

  processoOBJ: Processo = {
    idUtilizador: 0,
    nrProcesso: '',
    nome: '',
    idTipo: 0,
    valor: 0,
    notas: '',
    dataEntrada: '',
    estado: false
  }

  constructor(private router: Router,
              private usersService: UsersService,
              private processoService: ProcessoService,
              private route: ActivatedRoute,
              private tipoProcessoService: TipoProcessoService) {}

  ngOnInit(): void {
    let idUtilizador = this.usersService.getUserId(); 
    this.route.snapshot.paramMap.get("idUtilizador");
    let nrProcesso = this.route.snapshot.paramMap.get("nrProcesso");
    
    this.processoService.getProc(idUtilizador, nrProcesso).subscribe((processo) => {
      this.processoOBJ = processo[0];
      console.log("Processo Selecionado -->", this.processoOBJ);
    })

    this.tipoProcessoService.getAll(idUtilizador).subscribe((tipo) => {
      this.tipo = tipo;
    });
  }

  updateProcesso() {
    let id = this.usersService.getUserId();

    // Atualizar processo
    this.processoService.put(id, this.processoOBJ.nrProcesso, this.processoOBJ).subscribe((processo) => {
        this.processoOBJ = processo;
        console.log("put:", this.processoOBJ);
        alert("Processo Alterado com SUCESSO!");
        this.router.navigate(["/get-processo"]);
      });
  }

  cancel(): void {
    this.router.navigate(["/get-processo"]);
  }

  validaTipoProcesso(id: any) {
    this.processoOBJ.idTipo = id;
    console.log("-->", this.processoOBJ.idTipo);
  }
}
