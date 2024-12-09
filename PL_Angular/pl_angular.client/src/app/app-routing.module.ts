import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AreaComponent } from './components/area/area.component';
import { EmpleadoComponent } from './components/empleado/empleado.component';
import { FormComponent } from './components/form/form.component';

const routes: Routes = [
  { path: 'areas', component: AreaComponent },
  { path: 'empleados', component: EmpleadoComponent },
  { path: 'form', component: FormComponent },
  { path: 'form/:id', component: FormComponent },
  { path: '', redirectTo: '/areas', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
