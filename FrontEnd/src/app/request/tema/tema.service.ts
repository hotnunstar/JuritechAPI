import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Injectable } from "@angular/core";
import { Tema } from "./tema-api/tema.model";


@Injectable({
  providedIn: "root",
})
export class TemaService {
  baseURL = "https://localhost:7180/api/Tema";

  constructor(private http: HttpClient) {}

  //Consultar Processos do Utilizador
  getAll(idUtilizador: any): Observable<Tema[]> {
    const url = `${this.baseURL}/${idUtilizador}`;
    return this.http.get<Tema[]>(url);
  }

  getTema(idUtilizador: any, id: any): Observable<Tema[]> {
    const url = `${this.baseURL}/${idUtilizador}/${id}`;
    return this.http.get<Tema[]>(url);
  }

  //Criar Tema
  post(idUtilizador: any, tema: Tema): Observable<Tema> {
    const url = `${this.baseURL}/${idUtilizador}`;
    return this.http.post<Tema>(url, tema);
  }

  //Alterar Tema por utilizador
  put(idUtilizador: any, id: any, tema: Tema): Observable<Tema> {
    const url = `${this.baseURL}/${idUtilizador}/${id}`;
    return this.http.put<Tema>(url, tema);
  }
}
