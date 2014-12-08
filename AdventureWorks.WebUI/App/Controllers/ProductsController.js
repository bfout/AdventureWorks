'use strict';

(function () {
    var app = angular.module("main");

    app.controller('productsController', function ($scope, productRepository) {
        $scope.message = "message from products controller";

        var loadProductSummaries = function (productSummaries) {
            $scope.productSummaries = productSummaries;
        };

        var exceptionHandler = function(error) {
            alert(error);
        };

        productRepository.getProductSummaries().then(loadProductSummaries, exceptionHandler);
    });
})();
