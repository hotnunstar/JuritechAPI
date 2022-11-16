import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { Prazo } from '../prazo.model';
import { PrazoService } from '../prazo.service';

@Component({
  selector: 'app-delete-prazo',
  templateUrl: './delete-prazo.component.html',
  styleUrls: ['./delete-prazo.component.css']
})
export class DeletePrazoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Prazo";

  prazo: Prazo[] = [];
  
  PrazoOBJ: Prazo = {
    idPrazoCodigo: 0, 
    idUtilizador: 0,
    idCodigo: 0, 
    nrArtigo: 0, 
    nrProcesso: '', 
    dataInicial: '',
    dataFinal: '',
  }
  constructor(private route: ActivatedRoute,
              private usersService: UsersService,
              private prazoService: PrazoService,
              private router: Router) { }

  ngOnInit(): void {
    // // GET OBJ
    let idUtilizador = this.usersService.getUserId();
    this.route.snapshot.paramMap.get("idUtilizador");
    let idPrazoCodigo = this.route.snapshot.paramMap.get("idPrazoCodigo");
    let nrProcesso = this.route.snapshot.paramMap.get("nrProcesso");

    this.prazoService.getByPCod(idUtilizador, nrProcesso, idPrazoCodigo).subscribe((prazo) => {
      this.PrazoOBJ = prazo[0];
      console.log("Prazo Selecionado -->", this.PrazoOBJ);
    })
  }

  deletePrazo(): void {
    let id = this.usersService.getUserId();

    this.prazoService.delete(id, this.PrazoOBJ.nrProcesso, this.PrazoOBJ.idPrazoCodigo).subscribe((prazo) => {
      console.log("delete:", this.PrazoOBJ);
      alert("Prazo Apagado com SUCESSO!");
      this.router.navigate(["/get-prazos"]);
    })
  }

  cancel(): void {
    this.router.navigate(["/get-prazos"]);
  }

}
