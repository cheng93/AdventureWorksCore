import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { EmployeesComponent } from './employees/employees.component'
import { EmployeeComponent } from './employee/employee.component'

const employeeRoutes: Routes = [
    { path: 'employees', component: EmployeesComponent },
    { path: 'employees/:id', component: EmployeeComponent },
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
