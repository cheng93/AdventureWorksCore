export class Employee {
    id : number;
    firstName : string;
    lastName : string;
    birthDate : Date;
    gender : string;
    nationalIdNumber : string;
    loginId : string;
    hiredDate : Date;
    vacationHours : number;
    sickLeaveHours : number;
}

export class Department {
    id : number;
    name : string;
    groupName : string;
}

export class EmployeeDepartmentHistory {
    employeeId : number;
    department : Department;
    start : Date;
    end : Date;
}