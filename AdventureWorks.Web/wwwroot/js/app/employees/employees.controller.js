(function () {
    'use strict';

    angular
        .module('app.employees')
        .controller('employeesController', employeesController);

    employeesController.$inject = ['$log', 'employeesService'];

    function employeesController($log, employeesService) {
        /* jshint validthis:true */
        var vm = this;

        activate();

        function activate() {
            return employeesService.getEmployees()
                .then(function (data) {
                    vm.employees = data;
                    return vm.employees;
                });
        }
    }
})();
