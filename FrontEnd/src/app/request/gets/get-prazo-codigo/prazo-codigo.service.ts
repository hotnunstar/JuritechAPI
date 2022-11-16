import { PrazoCodigo } from "./prazo-codigo.model";
import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";


@Injectable({
  providedIn: 'root',
})
export class PrazoCodigoService {
    baseURL = 'https://localhost:7180/api/PrazoCodigo';

    constructor(private http: HttpClient) { }

    get(): Observable<PrazoCodigo[]> {
      return this.http.get<PrazoCodigo[]>(this.baseURL);
    }
}