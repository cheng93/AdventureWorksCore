import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DataTableModule, SharedModule } from 'primeng/primeng';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeesService } from './employees/employees.service';
import { EmployeeComponent } from './employee/employee.component';
import { EmployeeService } from './employee/employee.service';

@NgModule({
    imports: [
        CommonModule,
        EmployeeRoutingModule,
        DataTableModule,
        SharedModule
    ],
    declarations: [
        EmployeesComponent,
        EmployeeComponent
    ]
})

export class EmployeeModule { }