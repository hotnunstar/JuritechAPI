import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { UsersService } from "src/app/components/auth/users.service";
import { Tema } from "../tema-api/tema.model";
import { TemaService } from "../tema.service";

@Component({
  selector: "app-get-tema",
  templateUrl: "./get-tema.component.html",
  styleUrls: ["./get-tema.component.css"],
})
export class GetTemaComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Tema";

  tema: Tema[] = [];

  TemaOBJ: Tema = {
    id: 0,
    idUtilizador: 0,
    nome: ''
  };

  constructor(private temaService: TemaService, 
              private router: Router,
              private usersService: UsersService,) {}

  ngOnInit(): void {
    let id = this.usersService.getUserId();

    this.temaService.getAll(id).subscribe((tema) => {
      this.tema = tema;
      console.log(this.tema);
    });
  }
}
