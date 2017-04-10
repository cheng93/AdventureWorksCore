import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DataTableModule, SharedModule } from 'primeng/primeng';

import { EmployeeRoutingModule } from './employee-routing.module';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeComponent } from './employee/employee.component';
import { EmployeeDepartmentHistoryComponent } from './employee-department-histories/employee-department-histories.component';
import { EmployeeGridComponent } from './employee-grid/employee-grid.component';

@NgModule({
    imports: [
        CommonModule,
        EmployeeRoutingModule,
        DataTableModule,
        SharedModule
    ],
    declarations: [
        EmployeesComponent,
        EmployeeComponent,
        EmployeeDepartmentHistoryComponent,
        EmployeeGridComponent
    ]
})

export class EmployeeModule { }