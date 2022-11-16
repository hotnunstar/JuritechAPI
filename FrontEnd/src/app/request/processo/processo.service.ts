import { Processo } from "./processo-api/processo.model";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class ProcessoService {
  baseURL = 'https://localhost:7180/api/Processo';

  constructor(private http: HttpClient) { }

  //Consultar Processos do Utilizador
  getAll(idUtilizador: any): Observable<Processo[]> {
    const url = `${this.baseURL}/${idUtilizador}`;
    return this.http.get<Processo[]>(url);
  }

  getProc(idUtilizador: any, nrProcesso: any): Observable<Processo[]> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}`;
    return this.http.get<Processo[]>(url);
  }

  //Criar Processo por utilizador
  post(idUtilizador: any, processo: Processo): Observable<Processo> {
    const url = `${this.baseURL}/${idUtilizador}`; 
    return this.http.post<Processo>(url, processo);
  }

  //Alterar Processo por utilizador
  put(idUtilizador: any, nrProcesso: any, processo: Processo): Observable<Processo> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}`;
    return this.http.put<Processo>(url, processo);
  }
}
