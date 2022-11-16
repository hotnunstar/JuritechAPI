import { Estado } from './estado.model';
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class EstadoService {
    baseURL = 'https://localhost:7180/api/Estado';

    constructor(private http: HttpClient) { }

    get(): Observable<Estado[]> {
      return this.http.get<Estado[]>(this.baseURL);
    }
}