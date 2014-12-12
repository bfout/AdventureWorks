'use strict';

(function() {
    var app = angular.module("main");

    app.controller('homeController', function ($scope) {
        $scope.message = "message from home controller";
    });
})();
