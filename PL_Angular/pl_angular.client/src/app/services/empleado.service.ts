import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {
  private baseUrl = 'https://localhost:7034/api/Empleado';

  constructor(private http: HttpClient) { }

  getAll(): Observable<any> {
    return this.http.get(`${this.baseUrl}/GetAllEmpleado`);
  }

  getById(id: number): Observable<any> {
    return this.http.get(`${this.baseUrl}/GetByIdEmpleado/${id}`);
  }

  create(empleado: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/AddEmpleado`, empleado);
  }

  update(empleado: any): Observable<any> {
    return this.http.put(`${this.baseUrl}/UpdateEmpleado`, empleado);
  }

  delete(id: number): Observable<any> {
    return this.http.delete(`${this.baseUrl}/DeleteEmpleado/${id}`);
  }
}
