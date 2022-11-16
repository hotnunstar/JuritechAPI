import { UsersService } from "./../users.service";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { Users } from "../users-api/users.model";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"],
})
export class LoginComponent implements OnInit {
  users: Users[] = [];
  UsersOBJ: Users = {
    email: "",
    password: "",
  };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private http: HttpClient,
    private usersService: UsersService
  ) {}

  ngOnInit(): void {}

  login(): void {
    // GET POR USER E PASSWORD
    this.usersService
      .login(this.UsersOBJ.email, this.UsersOBJ.password)
      .subscribe((users) => {
        this.UsersOBJ = users;
        console.log("get_by_data= UsersOBJ ->", users);
        if (
          this.UsersOBJ.email == users.email &&
          this.UsersOBJ.password == users.password
         
        ) {
          this.usersService.saveUserName(users.nome);
          this.usersService.saveUserId(users.id);
          this.UsersOBJ.nome = this.usersService.getUserSaved();
          window.location.replace("/inicio");
          alert(`Bem Vindo ${users.nome}!`);
          console.log(localStorage);
        }
      });
  }
}
