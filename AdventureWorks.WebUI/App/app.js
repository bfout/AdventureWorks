'use strict';

(function() {
    var app = angular.module("main", ["ngRoute", "ui.bootstrap"]);

    app.config(function($routeProvider) {
        $routeProvider
            .when("/home", {
                templateUrl: "app/views/home.html",
                controller: "homeController"
            })
            .when("/contact", {
                templateUrl: "app/views/contact.html",
                controller: "contactController"
            })
            .when("/about", {
                templateUrl: "app/views/about.html",
                controller: "aboutController"
            })
            .when("/products", {
                templateUrl: "app/views/products.html",
                controller: "productsController"
            })
            .when("/product/:productId", {
                templateUrl: "app/views/product.html",
                controller: "productController"
            })
            .otherwise({ redirectTo: "/home" });
    });
})();

