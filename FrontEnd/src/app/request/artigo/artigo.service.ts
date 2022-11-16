import { Artigo } from './artigo.model';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class ArtigoService {
  baseURL = 'https://localhost:7180/api/Artigo';

  constructor(private http: HttpClient) { }

  //Consultar Artigos do Utilizador
  getAll(idUtilizador: any): Observable<Artigo[]> {
    const url = `${this.baseURL}/${idUtilizador}`;
    return this.http.get<Artigo[]>(url);
  }

  //Consultar Artigos do Utilizador por idCodigo
  getByCod(idUtilizador: any, idCodigo: any): Observable<Artigo[]> {
    const url = `${this.baseURL}/${idUtilizador}/${idCodigo}`;
    return this.http.get<Artigo[]>(url);
  }

  //Consultar Artigos do Utilizador por idCodigo e por nrArtigo
  getByArt(idUtilizador: any, idCodigo: any, nrArtigo: any): Observable<Artigo[]> {
    const url = `${this.baseURL}/${idUtilizador}/${idCodigo}/${nrArtigo}`;
    return this.http.get<Artigo[]>(url);
  }

  //Criar Artigo por utilizador
  post(idUtilizador: any, artigo: Artigo): Observable<Artigo> {
    const url = `${this.baseURL}/${idUtilizador}`; 
    return this.http.post<Artigo>(url, artigo);
  }

  //Alterar Artigo por utilizador
  put(idUtilizador: any, idCodigo: any, nrArtigo: any, artigo: Artigo): Observable<Artigo> {
    const url = `${this.baseURL}/${idUtilizador}/${idCodigo}/${nrArtigo}`;
    return this.http.put<Artigo>(url, artigo);
  }

  //Delete Artigo
  delete(idUtilizador: any, idCodigo: any, nrArtigo: any): Observable<Artigo> {
    const url= `${this.baseURL}/${idUtilizador}/${idCodigo}/${nrArtigo}`;
    return this.http.delete<Artigo>(url);
  }
}
