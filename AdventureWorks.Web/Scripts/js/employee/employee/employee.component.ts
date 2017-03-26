import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import 'rxjs/add/operator/switchMap';

import { Employee } from './../employee';
import { EmployeeService } from './employee.service';

@Component({
    providers: [
        EmployeeService
    ],
    template: "Hello World"
})

export class EmployeeComponent implements OnInit {
    employee: Employee;

    constructor(
        private employeeService: EmployeeService,
        private route: ActivatedRoute,
        private location: Location
    ) { }

    ngOnInit(): void {
        this.route.params
            .switchMap((params: Params) => this.employeeService.getEmployee(+params['id']))
            .subscribe(e => this.employee = e);
    }
}