'use strict';

(function() {
    var app = angular.module("main");

    app.controller('aboutController', function ($scope) {
        $scope.message = "message from about controller";
    });
})();