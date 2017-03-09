(function () {
    'use strict';

    angular
        .module('app.employees')
        .factory('employeeService', employeeService);

    employeeService.$inject = ['$http', '$q'];

    function employeeService($http, $q) {
        var service = {
            getEmployee: getEmployee
        };

        return service;

        function getEmployee(id) {
            return $http.get('/api/employees/' + id)
                .then(parseEmployeeResult)
                .catch(function (e) {
                    return $q.reject(e.status + ': ' + e.statusText);
                });

            function parseEmployeeResult(data) {
                return data.data;
            }
        }
    }
})();