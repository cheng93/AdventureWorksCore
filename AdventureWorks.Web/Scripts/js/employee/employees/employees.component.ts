import { Component, OnInit } from '@angular/core';

import { Employee } from './../employee';
import { EmployeesService } from './employees.service';

@Component({
    providers: [
        EmployeesService
    ],
    templateUrl: './employees.template.html'
})

export class EmployeesComponent implements OnInit {
    employees : Employee[];
    
    constructor(private employeesService : EmployeesService) { }

    ngOnInit() : void {
        this.getEmployees();
    }

    getEmployees() : void {
        this.employeesService.getEmployees()
            .then((e: Employee[]) => this.employees = e);
    }
}