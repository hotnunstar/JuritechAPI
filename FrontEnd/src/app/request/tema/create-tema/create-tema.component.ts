import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UsersService } from 'src/app/components/auth/users.service';
import { Tema } from '../tema-api/tema.model';
import { TemaService } from '../tema.service';

@Component({
  selector: 'app-create-tema',
  templateUrl: './create-tema.component.html',
  styleUrls: ['./create-tema.component.css']
})
export class CreateTemaComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Tema";

  tema: Tema[] = [];

  TemaOBJ: Tema = {
    id: 0,
    idUtilizador: 0,
  };
  
  constructor(private temaService: TemaService, 
              private router: Router,
              private usersService: UsersService,) {}

  ngOnInit(): void {
  }

  postTema(): void {
    let id = this.usersService.getUserId();

    this.temaService.post(id, this.TemaOBJ).subscribe((tema) => {
      this.TemaOBJ = tema;
      console.log("post:", this.TemaOBJ);
      alert("Tema criado com SUCESSO!");
      this.router.navigate(["/get-temas"]);
    })
  }

  cancel(): void {
    this.router.navigate(["/get-temas"]);
  }

}
