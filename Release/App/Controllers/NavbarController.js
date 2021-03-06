﻿'use strict';

(function() {
    var app = angular.module("main");

    app.controller('navbarController', function ($location, $scope) {
        $scope.message = "message from navbar controller";

        $scope.links = new Array();

        var homeLink = {
            href: '#/home',
            title: 'Home',
            text: 'Home'
        };

        var productsLink = {
            href: '#/products',
            title: 'Products',
            text: 'Products'
        };

        var contactLink = {
            href: '#/contact',
            title: 'Contact',
            text: 'Contact'
        };

        var aboutLink = {
            href: '#/about',
            title: 'About',
            text: 'About'
        };

        $scope.links.push(homeLink);
        $scope.links.push(productsLink);
        $scope.links.push(contactLink);
        $scope.links.push(aboutLink);

        $scope.$on('$routeChangeStart', function () {
            // set isNavigation to true when the route change starts
            $scope.isNavigating = true;

            //alert('$routeChangeStart');
        });

        $scope.$on('$routeChangeSuccess', function () {
            // set isNavigation to false when the route change succeeds
            $scope.isNavigating = false;

            //alert('$routeChangeSuccess');

            // set active to true for the link that refers to the current page
            //for (var i = 0; i < $scope.links.length; i++) {
            //    var link = $scope.links[i];

            //    if ('#' + $location.path() == link.href)
            //        link.active = true;
            //    else
            //        link.active = false;
            //}
        });

        $scope.$on('$locationChangeStart', function () {
            //alert('$locationChangeStart');
        });

        $scope.$on('$locationChangeSuccess', function () {
            //alert('$locationChangeSuccess');
        });
    });
})();
