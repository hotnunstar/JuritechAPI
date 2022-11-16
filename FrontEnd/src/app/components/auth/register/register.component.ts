import { Users } from "./../users-api/users.model";
import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { UsersService } from "../users.service";

@Component({
  selector: "app-register",
  templateUrl: "./register.component.html",
  styleUrls: ["./register.component.css"],
})
export class RegisterComponent implements OnInit {
  baseURL = "https://localhost:7180/api/Utilizador";
  users: Users[] = [];
  UsersOBJ: Users = {
    nome: "",
    email: "",
    password: "",
    confirmPw: "",
  };

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private usersService: UsersService
  ) {}

  ngOnInit(): void {}

  register(): void {
    console.log("user: ", this.UsersOBJ);
    if (this.UsersOBJ.password != this.UsersOBJ.confirmPw) {
      alert("Passwords não são iguais!");
    } else {
      this.usersService.create(this.UsersOBJ).subscribe((users) => {
        window.location.replace("/login");
        alert("Conta Registada");
      });
    }
  }
}
