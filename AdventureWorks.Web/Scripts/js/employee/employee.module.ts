import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeesService } from './employees/employees.service';
import { EmployeeComponent } from './employee/employee.component';
import { EmployeeService } from './employee/employee.service';

import { TableModule } from '../table/table.module';

@NgModule({
    imports: [        
        CommonModule,
        TableModule,
        EmployeeRoutingModule
    ],
    declarations: [
        EmployeesComponent,
        EmployeeComponent
    ]
})

export class EmployeeModule { }