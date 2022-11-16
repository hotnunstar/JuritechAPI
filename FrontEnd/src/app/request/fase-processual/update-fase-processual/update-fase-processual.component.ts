import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { FaseProcessual } from '../fase-processual.model';
import { FaseProcessualService } from '../fase-processual.service';

@Component({
  selector: 'app-update-fase-processual',
  templateUrl: './update-fase-processual.component.html',
  styleUrls: ['./update-fase-processual.component.css']
})
export class UpdateFaseProcessualComponent implements OnInit {
  baseURL = "https://localhost:7180/api/FaseProcssual";

  faseProcessual: FaseProcessual[] = [];

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
              private route: ActivatedRoute,
              private router: Router) { }
              
  ngOnInit(): void {
    let idUtilizador = this.usersService.getUserId();
    this.route.snapshot.paramMap.get("idUtilizador");
    let nrProcesso = this.route.snapshot.paramMap.get("nrProcesso");
    let idEstado = this.route.snapshot.paramMap.get("idEstado");
    let dataEntrada = this.route.snapshot.paramMap.get("dataEntrada");

    this.faseProcessualService.getByIdEst(idUtilizador, nrProcesso, idEstado, dataEntrada)
      .subscribe((fase) => {
        this.FaseOBJ = fase[0];
        console.log("Fase Selecionada -->", this.FaseOBJ);
      })
  }

  putFase(): void {
    let id = this.usersService.getUserId();

    this.faseProcessualService.put(id, this.FaseOBJ.nrProcesso, this.FaseOBJ.idEstado, this.FaseOBJ.dataEntrada, this.FaseOBJ)
      .subscribe((fase) => {
        this.FaseOBJ = fase;
        console.log("put:", this.FaseOBJ);
        alert("Fase Alterada com SUCESSO!");
        this.router.navigate(["/get-faseprocessual"]);
      })
  }

  cancel(): void {
    this.router.navigate(["/get-artigos"]);
  }
}
