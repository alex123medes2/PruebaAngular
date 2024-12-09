//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-form',
//  templateUrl: './form.component.html',
//  styleUrls: ['./form.component.css']
//})
//export class FormComponent {

//}
import { Component, OnInit } from '@angular/core';
import { EmpleadoService } from '../../services/empleado.service';
import { AreaService } from '../../services/area.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  areas: any[] = [];
  idEmpleado: number | null = null;
  empleado: any = {
    area: {
      idArea: null,
      nombreArea: ''
    },
    nombreEmpleado: '',
    edad: null,
  };
  

  constructor(
    private empleadoService: EmpleadoService,
    private areaService: AreaService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.idEmpleado = this.route.snapshot.params['id'];
    this.cargarAreas().then(() => {
      if (this.idEmpleado) {
        this.cargarEmpleado(this.idEmpleado);
      }
    });
  }

  cargarAreas(): Promise<void> {
    return new Promise((resolve) => {
      this.areaService.getAll().subscribe((response: any) => {
        this.areas = response.objects ||[];
        resolve();
      });
    });
  }

  cargarEmpleado(idEmpleado: number): void {
    this.empleadoService.getById(idEmpleado).subscribe((response: any) => {
      this.empleado = response.object;
    });
  }


  guardarEmpleado() {
    if (this.idEmpleado) {
      this.empleadoService.update(this.empleado).subscribe(() => {
        alert('Empleado actualizado correctamente');
        this.router.navigate(['/empleados']);
      });
    } else {
      this.empleadoService.create(this.empleado).subscribe(() => {
        alert('Empleado creado correctamente');
        this.router.navigate(['/empleados']);
      });
    }
  }

  regresar() {
    this.router.navigate(['/empleados']);
  }
}

