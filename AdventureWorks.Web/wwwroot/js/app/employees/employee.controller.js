(function () {
    'use strict';

    angular
        .module('app.employees')
        .controller('employeeController', employeeController);

    employeeController.$inject = ['$scope', 'employeeService'];

    function employeeController($scope, employeeService) {
        /* jshint validthis:true */
        var vm = this;
        vm.employee = {};

        activate();
                
        function activate() {
            return employeeService.getEmployee($scope.id)
                .then(function (data) {
                    vm.employee = data;
                })
                .then(function () {
                    console.log(vm.employee);
                });
        }
    }
})();
