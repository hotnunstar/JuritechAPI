import { Component, OnInit } from "@angular/core";
import { Users } from "../../auth/users-api/users.model";
import { UsersService } from "../../auth/users.service";

@Component({
  selector: "app-sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.css"],
})
export class SidebarComponent implements OnInit {
  users: Users[] = [];
  UsersOBJ: Users = {
    nome: "",
    email: "",
    password: ""
   
  };
  constructor(private usersService: UsersService) {

  }

  ngOnInit(): void {
    this.showUserName();
  }

  showUserName(): any{
    // GET POR USER E PASSWORD
    this.UsersOBJ.nome = this.usersService.getUserSaved();
    return this.UsersOBJ.nome;
  }

}
