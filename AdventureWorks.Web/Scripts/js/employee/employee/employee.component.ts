import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

import 'rxjs/add/operator/switchMap';

import { Employee } from './../employee';
import { EmployeeService } from './employee.service';

@Component({
    templateUrl: './employee.template.html'
})

export class EmployeeComponent implements OnInit {
    employee: Employee;

    constructor(
        private employeeService: EmployeeService,
        private route: ActivatedRoute
    ) { 
        this.employee = new Employee();
    }

    ngOnInit(): void {
        let id = +this.route.snapshot.params['id'];
        this.employeeService.getEmployee(id)
            .then((e : Employee) => this.employee = e);
    }
}