import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { HttpService } from './../../common/http-service';

import { EmployeeDepartmentHistory } from './../employee.models';

@Injectable()
export class EmployeeDepartmentHistoryService extends HttpService {
    private endpoint = (employeeId: number) => `api/employees/${employeeId}/department-histories/`;
    
    constructor(private http: Http, location: Location) {
        super(location);
     }

    getEmployeeDepartmentHistories(employeeId : number) : Promise<EmployeeDepartmentHistory[]> {
        var url = this.getEndPoint(this.endpoint(employeeId));

        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as EmployeeDepartmentHistory[]);
    }
}