import { FaseProcessual } from './fase-processual.model';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class FaseProcessualService {
  baseURL = 'https://localhost:7180/api/FaseProcessual';

  constructor(private http: HttpClient) { }

  //Consultar FasesProcessuais do Utilizador de todos os processos por Parametros
  getAll(idUtilizador: any, AtivasNaoAtivas: any, Todas: any, idEstado: any): Observable<FaseProcessual[]> {
    const url = `${this.baseURL}/${idUtilizador}/Parametros/${AtivasNaoAtivas}/${Todas}/${idEstado}`;
    return this.http.get<FaseProcessual[]>(url);
  }

  //Consultar FaseProcessual do Utilizador por nrProcesso
  getByNproc(idUtilizador: any, nrProcesso: any): Observable<FaseProcessual[]> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}`;
    return this.http.get<FaseProcessual[]>(url);
  }

  //Consultar FaseProcessual do Utilizador por nrProcesso e idEstado
  getByIdEst(idUtilizador: any, nrProcesso: any, idEstado: any, dataEntrada: any): Observable<FaseProcessual[]> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}/${idEstado}/${dataEntrada}`;
    return this.http.get<FaseProcessual[]>(url);
  }

  //Criar FaseProcessual por utilizador
  post(idUtilizador: any, nrProcesso: any, faseProcessual: FaseProcessual): Observable<FaseProcessual> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}`; 
    return this.http.post<FaseProcessual>(url, faseProcessual);
  }

  //Alterar Artigo por utilizador
  put(idUtilizador: any, nrProcesso: any, idEstado: any, dataEntrada: any, faseProcessual: FaseProcessual): Observable<FaseProcessual> {
    const url = `${this.baseURL}/${idUtilizador}/${nrProcesso}/${idEstado}/${dataEntrada}`;
    return this.http.put<FaseProcessual>(url, faseProcessual);
  }

}
