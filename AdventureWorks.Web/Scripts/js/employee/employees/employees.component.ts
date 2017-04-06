import { Component, OnInit } from '@angular/core';

import { Employee } from './../employee.models';
import { EmployeesService } from './employees.service';

import { TitleService } from '../../title/title.abstract';

@Component({
    templateUrl: './employees.template.html'
})

export class EmployeesComponent implements OnInit {
    employees : Employee[];
    
    constructor(
        private employeesService : EmployeesService, 
        private titleService : TitleService
    ) { }

    ngOnInit() : void {
        this.titleService.setTitle("Loading");
        this.getEmployees();
    }

    getEmployees() : void {
        this.employeesService.getEmployees()
            .then((e: Employee[]) => this.employees = e)
            .then(() => this.titleService.setTitle('Employees'));
    }

    getRowClass(rowData : any, index : number) : string {
        return "anchor";
    }
}