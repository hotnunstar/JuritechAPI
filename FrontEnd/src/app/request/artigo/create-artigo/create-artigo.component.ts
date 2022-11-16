import { ArtigoService } from './../artigo.service';
import { Artigo } from './../artigo.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CodigoService } from '../../gets/get-codigo/codigo.service';
import { UsersService } from 'src/app/components/auth/users.service';
import { Codigo } from '../../gets/get-codigo/codigo.model';

@Component({
  selector: 'app-create-artigo',
  templateUrl: './create-artigo.component.html',
  styleUrls: ['./create-artigo.component.css']
})
export class CreateArtigoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Artigo";

  artigo: Artigo[] = [];
  codigo: Codigo[] = [];

  ArtigoOBJ: Artigo = {
    idUtilizador: 0,
    nrArtigo: 0,
    idCodigo: 0,
    nome: '',
    dias: 0,
    meses: 0,
    anos: 0,
    ferias: false,
    diasNaoUteis: false
  };

  constructor(private artigoService: ArtigoService,
              private codigoService: CodigoService,
              private usersService: UsersService,
              private router: Router) { }

  ngOnInit(): void {
    this.codigoService.get().subscribe((result) => {
      this.codigo = result;
      console.log(this.codigo);
    })
  }

  postArtigo(): void {
    let id = this.usersService.getUserId();
    this.artigoService.post(id, this.ArtigoOBJ).subscribe((artigo) => {
      this.ArtigoOBJ = artigo;
      console.log("post:", this.ArtigoOBJ);
      alert("Artigo Criado com SUCESSO!");
      this.router.navigate(["/get-artigos"]);
    })
  }

  cancel(): void {
    this.router.navigate(["/get-artigos"]);
  }

  validaCodigo(id: any) {
    this.ArtigoOBJ.idCodigo = id;
    console.log("-->", this.ArtigoOBJ.idCodigo);
  }
}
