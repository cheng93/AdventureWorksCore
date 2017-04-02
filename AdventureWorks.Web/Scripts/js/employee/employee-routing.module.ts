import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmployeesComponent } from './employees/employees.component'
import { EmployeeGridComponent } from './employee-grid/employee-grid.component'

const employeeRoutes: Routes = [
    { path: 'employees', component: EmployeesComponent },
    { path: 'employees/:id', component: EmployeeGridComponent },
    { path: 'employees/**', redirectTo: 'employees'}
];

@NgModule({
  imports: [
    RouterModule.forChild(employeeRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class EmployeeRoutingModule { }
