import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AreaService {
  private baseUrl = 'https://localhost:7034/api/Area';

  constructor(private http: HttpClient) { }

  getAll(): Observable<any> {
    return this.http.get(`${this.baseUrl}/GetAllArea`);
  }

  create(nombreArea: string): Observable<any> {
    const area = { nombreArea: nombreArea }; 
    return this.http.post(`${this.baseUrl}/AddArea`, area);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/DeleteArea/${id}`);
  }
}

