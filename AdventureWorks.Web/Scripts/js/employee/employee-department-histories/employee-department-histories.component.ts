import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { EmployeeDepartmentHistory } from './../employee.models';
import { EmployeeDepartmentHistoryService } from './employee-department-histories.service';

@Component({
    selector: 'employee-department-histories',
    templateUrl: './employee-department-histories.template.html'
})

export class EmployeeDepartmentHistoryComponent implements OnInit {
    departmentHistories : EmployeeDepartmentHistory[];

    constructor(
        private employeeDepartmentHistoryService : EmployeeDepartmentHistoryService,
        private route : ActivatedRoute
    ) { }

    ngOnInit() : void {
        this.getDepartmentHistories();
    }

    getDepartmentHistories() : void {
        let id = +this.route.snapshot.params['id'];
        this.employeeDepartmentHistoryService.getEmployeeDepartmentHistories(id)
            .then((e : EmployeeDepartmentHistory[]) => this.departmentHistories = e);
    }
}