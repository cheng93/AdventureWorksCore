import { Injectable } from '@angular/core';
import { Headers, Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Employee } from './../employee';

@Injectable()
export class EmployeesService {
    private endpoint = '/api/employees';

    constructor(private http: Http) { }

    getEmployees(): Promise<Employee[]> {
        return this.http.get(this.endpoint)
            .toPromise()
            .then(response => response.json() as Employee[]);
    }
}