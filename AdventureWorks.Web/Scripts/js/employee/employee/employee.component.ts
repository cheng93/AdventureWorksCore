import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import 'rxjs/add/operator/switchMap';

import { Employee } from './../employee';
import { EmployeeService } from './employee.service';

import { TitleService } from '../../title/title.abstract';

@Component({
    templateUrl: './employee.template.html'
})

export class EmployeeComponent implements OnInit {
    employee: Employee;

    constructor(
        private employeeService: EmployeeService,
        private route: ActivatedRoute,
        private titleService: TitleService
    ) { 
        this.employee = new Employee();
        this.titleService.setTitle("Loading");
    }

    ngOnInit(): void {
        let id = +this.route.snapshot.params['id'];
        this.employeeService.getEmployee(id)
            .then((e : Employee) => this.employee = e)
            .then(() => {
                var title = `${this.employee.firstName}${this.employee.lastName}`;
                this.titleService.setTitle(title)
            });
    }
}