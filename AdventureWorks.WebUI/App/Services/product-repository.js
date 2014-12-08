'use strict';

(function() {
    var app = angular.module("main");

    app.factory('productRepository', function ($http, $q) {
        var vm = {};

        vm.getProductSummaries = function() {
            var deferred = $q.defer();
            var url = '../api/product/getproductsummaries';

            $http.get(url).success(deferred.resolve).error(deferred.reject);

            return deferred.promise;
        };

        vm.getProductDetail = function (productId) {
            var deferred = $q.defer();
            var url = '../api/product/getproductdetail?productId=' + productId;

            $http.get(url).success(deferred.resolve).error(deferred.reject);

            return deferred.promise;
        };

        return {
            getProductSummaries: vm.getProductSummaries,
            getProductDetail: vm.getProductDetail
        };
    });
})();
