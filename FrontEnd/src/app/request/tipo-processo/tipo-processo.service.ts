import { TipoProcesso } from "./tipo-processo.model";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class TipoProcessoService {
  baseURL = 'https://localhost:7180/api/TipoProcesso';

  constructor(private http: HttpClient) { }

  //Consultar TipoProcesso do Utilizador
  getAll(idUtilizador: any): Observable<TipoProcesso[]> {
    const url = `${this.baseURL}/${idUtilizador}`;
    return this.http.get<TipoProcesso[]>(url);
  }

  getTipo(idUtilizador: any, idTipoProcesso: any): Observable<TipoProcesso[]> {
    const url = `${this.baseURL}/${idUtilizador}/${idTipoProcesso}`;
    return this.http.get<TipoProcesso[]>(url);
  }

  //Criar TipoProcesso por utilizador
  post(idUtilizador: any, tipoProcesso: TipoProcesso): Observable<TipoProcesso> {
    const url = `${this.baseURL}/${idUtilizador}`; 
    return this.http.post<TipoProcesso>(url, tipoProcesso);
  }
    
  //Alterar TipoProcesso por utilizador
  put(idUtilizador: any, idTipoProcesso: any, tipoProcesso: TipoProcesso): Observable<TipoProcesso> {
    const url = `${this.baseURL}/${idUtilizador}/${idUtilizador}/${idTipoProcesso}`;
    return this.http.put<TipoProcesso>(url, tipoProcesso);
  }
}