/// <reference path="../../angular.js" />
angular.module("cart", [])
.factory("cart", function () {

    var cartData = [];

    return {

        addProduct: function (id, name, price) {
            var addedToExistingCart = false;

            for (var i = 0; i < cartData.length; i++) {
                if (cartData[i].productid == id) {
                    cartData[i].count++;
                    addedToExistingCart = true;
                    break;
                }
            }
            if (!addedToExistingCart) {
                cartData.push({
                    count: 1,
                    productid: id,
                    price: price,
                    name: name
                });
            }
            console.log(cartData)
        },

        removeProduct: function (id) {
            for (var i = 0; i < cartData.length; i++) {
                if (cartData[i].productid == id) {
                    cartData.splice(i, 1);
                    break;
                }
            }
        },

        getProducts: function () {
            return cartData;
        }

    }

})
.directive("cartsummary", function (cart) {

    return {
        restrict: "E",
        templateUrl: "Scripts/app/views/cartSummary.html",
        controller: function ($scope) {

            var cartData = cart.getProducts();

            console.log(cartData);

            $scope.total = function () {
                var total = 0;
                for (var i = 0; i < cartData.length; i++) {
                    total += (cartData[i].price * cartData[i].count);
                }
                return total;
            }

            $scope.itemCount = function () {
                var total = 0;
                for (var i = 0; i < cartData.length; i++) {
                    total += cartData[i].count;
                }
                return total;
            }
        }
    };

})