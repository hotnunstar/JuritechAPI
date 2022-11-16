import { Users } from "./users-api/users.model";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class UsersService {
  baseURL = "https://localhost:7180/api/Utilizador";

  constructor(private http: HttpClient) {}

  //service para o Register
  create(users: Users): Observable<Users> {
    return this.http.post<Users>(this.baseURL, users);
  }

  //service para o Login
  login(email: any, password: any): Observable<Users> {
    const url = `${this.baseURL}/${email}/${password}`;
    return this.http.get<Users>(url);
  }

  //Update do utilizador com sessao iniciada
  update(users: Users): Observable<Users> {
    const url = `${this.baseURL}/${users.id}`;
    return this.http.put<Users>(url, users);
  }

  //Delete do utilizador
  delete(id: any): Observable<Users> {
    const url = `${this.baseURL}/${id}`;
    return this.http.delete<Users>(url);
  }

  //Guardar o nome do utilizador no local Storage
  saveUserName(nameUser?: string) {
    localStorage.setItem('User', JSON.stringify(nameUser));
  }
  //Guardar o id do utilizador no local Storage /tem erro com number
  saveUserId(idUser?: number) {
    localStorage.setItem('Id', JSON.stringify(idUser));
  }

  //Buscar o utilizador guardado
  getUserSaved(): any {
    let nameUser = localStorage.getItem('User');
    return nameUser;
  }

  getUserId(): any {
    let idUser = localStorage.getItem('Id');
    return idUser;
  }
}
