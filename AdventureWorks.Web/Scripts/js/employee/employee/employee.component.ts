import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import 'rxjs/add/operator/switchMap';

import { Employee } from './../employee';
import { EmployeeService } from './employee.service';

@Component({
    providers: [
        EmployeeService
    ],
    templateUrl: './employee.template.html'
})

export class EmployeeComponent implements OnInit {
    employee: Employee = new Employee();

    constructor(
        private employeeService: EmployeeService,
        private route: ActivatedRoute
    ) { }

    ngOnInit(): void {
        let id = +this.route.snapshot.params['id'];
        this.employeeService.getEmployee(id)
            .then((e : Employee) => this.employee = e);
    }
}