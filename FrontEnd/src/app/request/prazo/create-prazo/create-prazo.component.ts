import { Processo } from './../../processo/processo-api/processo.model';
import { PrazoCodigo } from './../../gets/get-prazo-codigo/prazo-codigo.model';
import { PrazoCodigoService } from './../../gets/get-prazo-codigo/prazo-codigo.service';
import { ProcessoService } from './../../processo/processo.service';
import { ArtigoService } from './../../artigo/artigo.service';
import { CodigoService } from './../../gets/get-codigo/codigo.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { Aux, Prazo } from '../prazo.model';
import { PrazoService } from '../prazo.service';
import { Artigo } from '../../artigo/artigo.model';
import { Codigo } from '../../gets/get-codigo/codigo.model';

@Component({
  selector: 'app-create-prazo',
  templateUrl: './create-prazo.component.html',
  styleUrls: ['./create-prazo.component.css']
})
export class CreatePrazoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Prazo";

  prazo: Prazo[] = [];
  aux: Aux[] = [];
  prazoCodigo: PrazoCodigo[] = [];
  codigo: Codigo[] = [];
  artigo: Artigo[] = [];
  processo: Processo[] = [];

  PrazoOBJ: Prazo = {
    idPrazoCodigo: 0, 
    idUtilizador: 0,
    idCodigo: 0, 
    nrArtigo: 0, 
    nrProcesso: '', 
    dataInicial: '',
    dataFinal: '',
  }

  AuxOBJ: Aux = {
    prioritarios: false,
    num: 0,
  }

  constructor(private route: ActivatedRoute,
              private usersService: UsersService,
              private prazoService: PrazoService,
              private codigoService: CodigoService,
              private artigoService: ArtigoService,
              private processoService: ProcessoService,
              private prazoCodigoService: PrazoCodigoService,
              private router: Router) { }

  ngOnInit(): void {
    let id = this.usersService.getUserId();

    this.codigoService.get().subscribe((result) => {
      this.codigo = result;
      console.log(this.codigo);
    })

    this.prazoCodigoService.get().subscribe((result) => {
      this.prazoCodigo = result;
      console.log(this.prazoCodigo);
    })

    this.artigoService.getAll(id).subscribe((result) => {
      this.artigo = result;
      console.log(this.artigo);
    })

    this.processoService.getAll(id).subscribe((result) => {
      this.processo = result;
      console.log(this.processo);
    })
  }

  postPrazo(): void {
    let id = this.usersService.getUserId();

    this.prazoService.post(id, this.PrazoOBJ.idCodigo, this.PrazoOBJ.nrArtigo, this.PrazoOBJ.nrProcesso,
      this.PrazoOBJ.idPrazoCodigo, this.PrazoOBJ.dataInicial, this.PrazoOBJ).subscribe((prazo) => {
        this.PrazoOBJ = prazo;
        console.log("post:", this.PrazoOBJ);
        alert("Prazo Criado com SUCESSO!");
        this.router.navigate(["/get-prazos"]);
      })
  }

  cancel(): void {
    this.router.navigate(["/get-prazos"]);
  }

  validaCodigo(id: any) {
    this.PrazoOBJ.idCodigo = id;
    console.log("-->", this.PrazoOBJ.idCodigo);
  }

  validaPrazoCodigo(id: any) {
    this.PrazoOBJ.idPrazoCodigo = id;
    console.log("-->", this.PrazoOBJ.idPrazoCodigo);
  }

  validaArtigo(id: any) {
    this.PrazoOBJ.nrArtigo = id;
    console.log("-->", this.PrazoOBJ.nrArtigo);
  }

  validaProcesso(id: any) {
    this.PrazoOBJ.nrProcesso = id;
    console.log("-->", this.PrazoOBJ.nrProcesso);
  }
  
}