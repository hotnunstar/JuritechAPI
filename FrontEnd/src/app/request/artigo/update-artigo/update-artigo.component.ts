import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { Artigo } from '../artigo.model';
import { ArtigoService } from '../artigo.service';


@Component({
  selector: 'app-update-artigo',
  templateUrl: './update-artigo.component.html',
  styleUrls: ['./update-artigo.component.css']
})
export class UpdateArtigoComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Artigo";

  artigo: Artigo[] = [];

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
              private usersService: UsersService,
              private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit(): void {
    
    // // GET OBJ
    let idUtilizador = this.usersService.getUserId();
    this.route.snapshot.paramMap.get("idUtilizador");
    let idCodigo = this.route.snapshot.paramMap.get("idCodigo");
    let nrArtigo = this.route.snapshot.paramMap.get("nrArtigo");

    this.artigoService.getByArt(idUtilizador, idCodigo, nrArtigo).subscribe((artigo) => {
      this.ArtigoOBJ = artigo[0];
      console.log("Artigo Selecionado -->", this.ArtigoOBJ);
    })

    // // GET OBJ
    // let idUtilizador = this.route.snapshot.paramMap.get("idUtilizador");
    // let url = `${this.baseURL}/${idUtilizador}/${idCodigo}/${nrArtigo}`;
    // this.http.get<Artigo>(url).subscribe((artigo) => {
    //   this.ArtigoOBJ = artigo;
    //   console.log('git/id UsersOBJ->', this.ArtigoOBJ);
    // });
    
  }

  putArtigo(): void {
    let id = this.usersService.getUserId();

    this.artigoService.put(id, this.ArtigoOBJ.idCodigo, this.ArtigoOBJ.nrArtigo, this.ArtigoOBJ)
     .subscribe((artigo) => {
       this.ArtigoOBJ = artigo;
       console.log("put:", this.ArtigoOBJ);
       alert("Artigo Alterado com SUCESSO!");
       this.router.navigate(["/get-artigos"]);
     })
  }

  cancel(): void {
    this.router.navigate(["/get-artigos"]);
  }
}
