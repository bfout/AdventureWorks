'use strict';

(function() {
    var app = angular.module("main");

    app.controller('contactController', function ($scope, $location) {
        $scope.message = "message from contact controller";
    });
})();