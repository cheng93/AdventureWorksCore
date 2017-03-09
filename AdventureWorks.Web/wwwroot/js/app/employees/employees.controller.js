(function () {
    'use strict';

    angular
        .module('app.employees')
        .controller('employeesController', employeesController);

    employeesController.$inject = ['$log', 'employeesService'];

    function employeesController($log, employeesService) {
        /* jshint validthis:true */
        var vm = this;
        vm.loading = true;

        activate();

        function activate() {
            return employeesService.getEmployees()
                .then(function (data) {
                    vm.employees = data;
                    return vm.employees;
                })
                .then(function () {
                    vm.loading = false;
                });
        }
    }
})();
