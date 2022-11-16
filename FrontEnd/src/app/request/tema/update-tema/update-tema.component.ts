import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { Tema } from '../tema-api/tema.model';
import { TemaService } from '../tema.service';

@Component({
  selector: 'app-update-tema',
  templateUrl: './update-tema.component.html',
  styleUrls: ['./update-tema.component.css']
})
export class UpdateTemaComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Tema";

  tema: Tema[] = [];

  TemaOBJ: Tema = {
    id: 0,
    idUtilizador: 0,
    nome: '',
  };
  
  constructor(private temaService: TemaService, 
              private router: Router,
              private route: ActivatedRoute,
              private usersService: UsersService,) {}
  
  ngOnInit(): void {
    let idUtilizador = this.usersService.getUserId();
    this.route.snapshot.paramMap.get("idUtilizador");
    let id = this.route.snapshot.paramMap.get("id");

    this.temaService.getTema(idUtilizador, id).subscribe((tema) => {
      this.TemaOBJ = tema[0];
      console.log("Tema Selecionado -->", this.TemaOBJ);
    })
  }

  putTema(): void {
    let id = this.usersService.getUserId();

    this.temaService.put(id, this.TemaOBJ.id, this.TemaOBJ).subscribe((tema) => {
      this.TemaOBJ = tema;
      console.log("put:", this.TemaOBJ);
      alert("Tema Alterado com SUCESSO!");
      this.router.navigate(["/get-temas"]);
     })
  }

  cancel(): void {
    this.router.navigate(["/get-temas"]);
  }
}
