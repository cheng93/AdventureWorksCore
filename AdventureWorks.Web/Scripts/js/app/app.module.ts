import { NgModule } from '@angular/core';
import { Location, LocationStrategy, PathLocationStrategy } from '@angular/common';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { EmployeesService } from '../employee/employees/employees.service';
import { EmployeeService } from '../employee/employee/employee.service';
import { EmployeeDepartmentHistoryService } from '../employee/employee-department-histories/employee-department-histories.service';
import { EmployeeModule } from '../employee/employee.module';

import { TitleService } from '../title/title.abstract';
import { BrowserTitleService } from '../title/title.service';


@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        EmployeeModule,
        AppRoutingModule
    ],
    declarations: [
        AppComponent
    ],
    bootstrap: [
        AppComponent
    ],
    providers: [
        EmployeesService,
        EmployeeService,
        EmployeeDepartmentHistoryService,
        { provide: TitleService, useClass: BrowserTitleService },
        Location,
        { provide: LocationStrategy, useClass: PathLocationStrategy }
    ]
})
export class AppModule { }
