import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { HttpService } from './../../common/http-service';

import { Employee } from './../employee.models';


@Injectable()
export class EmployeeService extends HttpService {
    private endpoint = `/api/employees/`;

    constructor(private http : Http, location : Location) {
        super(location);
     }

    getEmployee(id: number) : Promise<Employee> {
        var url = this.getEndPoint(`${this.endpoint}${id}`);

        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as Employee)
    }
}