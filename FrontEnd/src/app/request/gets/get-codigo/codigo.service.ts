import { Codigo } from './codigo.model';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class CodigoService {
    baseURL = 'https://localhost:7180/api/Codigo';

    constructor(private http: HttpClient) { }

    get(): Observable<Codigo[]> {
      return this.http.get<Codigo[]>(this.baseURL);
    }
}