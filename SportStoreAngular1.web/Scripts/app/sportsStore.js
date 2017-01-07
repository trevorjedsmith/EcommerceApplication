﻿/// <reference path="../angular.js" />
//get module
angular.module("sportsStore")
.controller("sportsStoreCtrl", function ($scope) {

    console.log('In the controller for SportsStore');

    $scope.data = {
        products: [
        {
            name: "Product #1", description: "A product",
            category: "Category #1", price: 100
        },
        {
            name: "Product #2", description: "A product",
            category: "Category #1", price: 110
        },
        {
            name: "Product #3", description: "A product",
            category: "Category #2", price: 210
        },
        {
            name: "Product #4", description: "A product",
            category: "Category #3", price: 202
        }]
    };

    console.log($scope.data);

});

//app module is the main module for the applciation