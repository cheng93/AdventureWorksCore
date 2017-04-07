import { Injectable } from '@angular/core';
import { Location } from '@angular/common';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { HttpService } from './../../common/http-service';

import { Employee } from './../employee.models';

@Injectable()
export class EmployeesService extends HttpService {
    private endpoint = 'api/employees';

    constructor(private http: Http, location : Location) {
        super(location);
     }

    getEmployees(): Promise<Employee[]> {
        return this.http.get(this.getEndPoint(this.endpoint))
            .toPromise()
            .then(response => response.json() as Employee[]);
    }
}