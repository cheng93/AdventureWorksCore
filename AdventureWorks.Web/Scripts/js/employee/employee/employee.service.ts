import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

import 'rxjs/add/operator/toPromise';

import { Employee } from './../employee.models';


@Injectable()
export class EmployeeService {
    private endpoint = '/api/employees/';

    constructor(private http : Http) { }

    getEmployee(id: number) : Promise<Employee> {
        var url = `${this.endpoint}${id}`;

        return this.http.get(url)
            .toPromise()
            .then(response => response.json() as Employee)
    }
}