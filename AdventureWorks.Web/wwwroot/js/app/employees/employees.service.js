﻿(function () {
    'use strict';

    angular
        .module('app.employees')
        .service('employeesService', employeesService);

    employeesService.$inject = ['$http', '$log'];
    
    function employeesService($http, $log) {
        var service = {
            getEmployees: getEmployees
        };

        return service;

        function getEmployees() {
            return $http.get('/api/employees')
                .then(parseEmployeesResult)
                .catch(function (message) {
                    $log.log(message);
                });

            function parseEmployeesResult(data) {
                return data.data;
            }
        }
    }
})();