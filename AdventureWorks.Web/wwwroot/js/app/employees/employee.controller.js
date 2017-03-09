(function () {
    'use strict';

    angular
        .module('app.employees')
        .controller('employeeController', employeeController);

    function employeeController() {
        /* jshint validthis:true */
        var vm = this;

        activate();

        function activate() { }
    }
})();
