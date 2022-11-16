import { CodigoService } from './../../gets/get-codigo/codigo.service';
import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Artigo } from '../artigo.model';
import { ArtigoService } from '../artigo.service';
import { UsersService } from 'src/app/components/auth/users.service';
import { Codigo } from '../../gets/get-codigo/codigo.model';

@Component({
  selector: 'app-get-artigo',
  templateUrl: './get-artigo.component.html',
  styleUrls: ['./get-artigo.component.css']
})
export class GetArtigoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Artigo";

  artigo: Artigo[] = [];
  codigo: Codigo[] = [];

  ArtigoOBJ: Artigo = {
    idUtilizador: 0,
    idCodigo: 0,
    nrArtigo: 0
  };

  constructor(private artigoService: ArtigoService,
              private usersService: UsersService,
              private codigoService: CodigoService,
              private route: ActivatedRoute) { }

  ngOnInit(): void {
    let id = this.usersService.getUserId();
    
    this.artigoService.getAll(id).subscribe((artigo) => {
      this.artigo = artigo;
      console.log(this.artigo);
    })

    this.codigoService.get().subscribe((result) => {
      this.codigo = result;
      console.log(this.codigo);
    })
  }

  //Campo onde posso inserir o idCOdigo e nrArtigo para filtrar por utilizador
  getTabela(): void {
    let id = this.usersService.getUserId();

    if (this.ArtigoOBJ.idCodigo == 0 && this.ArtigoOBJ.nrArtigo == 0){
      this.artigoService.getAll(id).subscribe((artigo) => {
        this.artigo = artigo;
        console.log(this.artigo);
      })
    }
    if (this.ArtigoOBJ.idCodigo != 0 && this.ArtigoOBJ.nrArtigo == 0) {
      this.artigoService.getByCod(id, this.ArtigoOBJ.idCodigo).subscribe((artigo) => {
        this.artigo = artigo;
        console.log(this.artigo);
      })
    }
    if (this.ArtigoOBJ.idCodigo != 0 && this.ArtigoOBJ.nrArtigo != 0) {
      this.artigoService.getByArt(id, this.ArtigoOBJ.idCodigo, this.ArtigoOBJ.nrArtigo).subscribe((artigo) => {
        this.artigo = artigo;
        console.log(this.artigo);
      })
    }
    if (this.ArtigoOBJ.idCodigo == 0 && this.ArtigoOBJ.nrArtigo != 0) {
      alert("Campo do idCodigo Vazio");
    }
  }

  validaCodigo(id: any) {
    this.ArtigoOBJ.idCodigo = id;
    console.log("-->", this.ArtigoOBJ.idCodigo);
  }
}
