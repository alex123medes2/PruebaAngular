//import { Component } from '@angular/core';

//@Component({
//  selector: 'app-area',
//  templateUrl: './area.component.html',
//  styleUrls: ['./area.component.css']
//})
//export class AreaComponent {

//}
import { Component, OnInit } from '@angular/core';
import { AreaService } from '../../services/area.service';

@Component({
  selector: 'app-area',
  templateUrl: './area.component.html',
  styleUrls: ['./area.component.css']
})
export class AreaComponent implements OnInit {
  areas: any[] = [];

  constructor(private areaService: AreaService) { }

  ngOnInit() {
    console.log('ngOnInit called: Loading areas...');
    this.cargarAreas();
  }

  cargarAreas() {
    this.areaService.getAll().subscribe(
      (response) => {
        if (response.correct) {
          this.areas = response.objects; 
        } else {
          console.error('API returned an error:', response.errorMessage);
        }
      },
      (error) => {
        console.error('Error fetching areas:', error);
      }
    );
  }


  crearArea() {
    const nombreArea = prompt('Ingrese el nombre del área:');
    this.areaService.create(nombreArea).subscribe(
      (res) => {
        console.log('Área creada exitosamente:', res);
        alert('Área creada exitosamente.');
        this.cargarAreas();
      },
      (error) => {
        console.error('Error al crear área:', error);
        alert('Error al crear el área.');
      }
    );
  }

  eliminarArea(id: number) {
    if (confirm('¿Está seguro de eliminar esta área?')) {
      this.areaService.delete(id).subscribe(() => {
        this.cargarAreas();
      });
    }
  }
}
