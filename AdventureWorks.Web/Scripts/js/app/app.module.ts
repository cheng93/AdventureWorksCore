﻿import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';

import { EmployeesService } from '../employee/employees/employees.service';
import { EmployeeService } from '../employee/employee/employee.service';
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
        { provide: TitleService, useClass: BrowserTitleService }
    ]
})
export class AppModule { }
