'use strict';

(function() {
    var app = angular.module("main");

    app.controller('productController', function ($scope, productRepository, $routeParams) {
        $scope.message = "message from product controller";

        $scope.productId = $routeParams.productId;

        var loadProductDetail = function (productDetail) {
            $scope.productDescription = productDetail.productDescription;
            $scope.productId = productDetail.productId;
            $scope.productName = productDetail.productName;
            $scope.productPhotoId = productDetail.productPhotoId;
            $scope.listPrice = productDetail.listPrice;
        };

        var exceptionHandler = function (error) {
            alert(error);
        };

        productRepository.getProductDetail($scope.productId).then(loadProductDetail, exceptionHandler);
    });
})();