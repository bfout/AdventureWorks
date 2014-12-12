'use strict';

(function () {
    var app = angular.module("main");

    app.controller('productsController', function ($scope, blockUI, productRepository) {
        $scope.message = "message from products controller";

        var activate = function () {
            // manually block page
            //blockUI.start('test');

            productRepository.getProductSummaries().then(loadProductSummaries, exceptionHandler);
        };

        var exceptionHandler = function (exception) {
            // manually unblock page
            //blockUI.stop();

            alert(exception);
        };

        var loadProductSummaries = function (productSummaries) {
            // manually unblock page
            //blockUI.stop();

            $scope.productSummaries = productSummaries;
        };

        activate();
    });
})();
