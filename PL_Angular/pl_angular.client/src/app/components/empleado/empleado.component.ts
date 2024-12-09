//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-empleado',
//  templateUrl: './empleado.component.html',
//  styleUrls: ['./empleado.component.css']
//})
//export class EmpleadoComponent {

//}
import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from '../../services/empleado.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-empleado',
  templateUrl: './empleado.component.html',
  styleUrls: ['./empleado.component.css']
})
export class EmpleadoComponent implements OnInit {
  empleados: any[] = [];

  constructor(private empleadoService: EmpleadoService, private router: Router) { }

  ngOnInit(): void {
    this.cargarEmpleados();
  }

  cargarEmpleados() {
    this.empleadoService.getAll().subscribe((response) => {
      if (response.correct) {
        this.empleados = response.objects;
      } else {
        console.error('API returned an error:', response.errorMessage);
      }
    },
      (error) => {
        console.error('Error fetching areas:', error);
      });
  }

  crearEmpleado() {
    this.router.navigate(['/form']);
  }

  editarEmpleado(idEmpleado: number) {
    this.router.navigate(['/form', idEmpleado]);
  }

  eliminarEmpleado(idEmpleado: number) {
    if (confirm('¿Está seguro de eliminar este empleado?')) {
      this.empleadoService.delete(idEmpleado).subscribe(() => {
        this.cargarEmpleados();
      });
    }
  }
}

