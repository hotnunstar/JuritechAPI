import { TipoPrazo } from "./tipo-prazo.model";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class TipoPrazoService {
    baseURL = 'https://localhost:7180/api/TipoPrazo';

    constructor(private http: HttpClient) { }

    get(): Observable<TipoPrazo[]> {
      return this.http.get<TipoPrazo[]>(this.baseURL);
    }
}