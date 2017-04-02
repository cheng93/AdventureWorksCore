import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { EmployeeDepartmentHistory } from './../employee.models';

@Injectable()
export class EmployeeDepartmentHistoryService {
    private endpoint = function (employeeId: number) {
        return `/api/employees/${employeeId}/department-histories/`;
    }

    constructor(private http: Http) { }

    getEmployeeDepartmentHistories(employeeId : number) : Promise<EmployeeDepartmentHistory[]> {
        var url = this.endpoint(employeeId);

        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as EmployeeDepartmentHistory[]);
    }
}