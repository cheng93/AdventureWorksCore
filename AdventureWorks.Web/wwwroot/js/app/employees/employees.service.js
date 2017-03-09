(function () {
    'use strict';

    angular
        .module('app.employees')
        .service('employeesService', employeesService);

    employeesService.$inject = ['$http', '$q'];
    
    function employeesService($http, $q) {
        var service = {
            getEmployees: getEmployees
        };

        return service;

        function getEmployees() {
            return $http.get('/api/employees')
                .then(parseEmployeesResult)
                .catch(function (e) {
                    return $q.reject(e.status + ': ' + e.statusText);
                });

            function parseEmployeesResult(data) {
                return data.data;
            }
        }
    }
})();