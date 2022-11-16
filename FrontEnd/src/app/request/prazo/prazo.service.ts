import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Prazo } from "./prazo.model";

@Injectable({
    providedIn: 'root',
  })
export class PrazoService {
  baseURL = 'https://localhost:7180/api/Prazo';

  constructor(private http: HttpClient) { }

  //Consultar Prazos do Utilizador pelos parametros
  getAll(idUtilizador: any, prioritarios: any, num: any): Observable<Prazo[]> {
    const url = `${this.baseURL}/${idUtilizador}/parametros/${prioritarios}/${num}`;
    return this.http.get<Prazo[]>(url);
  }

  //Consultar Prazos do Utilizador por Nº Processo
  getByNProc(idUtilizador: any, nrProcesso: any): Observable<Prazo[]> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}`;
    return this.http.get<Prazo[]>(url);
  }

  //Consultar Prazos do Utilizador por Nº Processo e ID Prazo Codigo
  getByPCod(idUtilizador: any, nrProcesso: any, idPrazoCodigo: any): Observable<Prazo[]> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}/${idPrazoCodigo}`;
    return this.http.get<Prazo[]>(url);
  }

  //Cria Prazo
  post(idUtilizador: any, idCodigo: any, nrArtigo: any, nrProcesso: any, tipoPrazo: any, dataInicial: any, prazo: Prazo): Observable<Prazo> {
    const url = `${this.baseURL}/${idUtilizador}/parametros/${idCodigo}/${nrArtigo}/${nrProcesso}/${tipoPrazo}/${dataInicial}`
    return this.http.post<Prazo>(url, prazo);
  }

  //Apaga Prazo
  delete(idUtilizador: any, nrProcesso: any, idPrazoCodigo: any): Observable<Prazo> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}/${idPrazoCodigo}`;
    return this.http.delete<Prazo>(url);
  }
}