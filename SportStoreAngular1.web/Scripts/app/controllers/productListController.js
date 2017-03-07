/// <reference path="../angular.js" />
angular.module("sportsStore").controller("productListCtrl", function ($scope, $filter, cart) {

    var selectCategory = null;

    var selectedCategoryClass = "btn-primary";

    $scope.selectedCategory = function (newCategory) {
        selectCategory = newCategory;
    }

    $scope.categoryFilterFn = function (product) {
        return selectCategory == null || product.Category == selectCategory;
    }

    $scope.getCategoryClass = function (category) {
        return selectCategory == category ? selectedCategoryClass : "";
    }

    $scope.addProductToCart = function (product) {
        cart.addProduct(product.Id, product.Name, product.Price);
    }

})