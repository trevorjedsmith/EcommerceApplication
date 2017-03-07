angular.module("sportsStore")
.constant("dataUrl", "http://localhost:59743/api/products")
.constant("orderUrl","http://localhost:59743/api/orders")
.controller("sportsStoreCtrl", function ($scope, $http, dataUrl, orderUrl, cart, $location) {

    $scope.data = {};

    $http.get(dataUrl)
        .success(function (data) {
        console.log(data);
        $scope.data.products = data;
        })
        .error(function (error) {
            console.log(error);
            $scope.data.error = error;
        });

    $scope.sendOrder = function (shippingDetails) {


        var order = angular.copy(shippingDetails);
        order.Lines = cart.getProducts();

        $http.post(orderUrl, order)
                  .success(function (data) {
                      console.log(data);
                      $scope.data.orderId = data;
                      cart.getProducts().length = 0;
                  })
                   .error(function (error) {
                       $scope.data.orderError = error;
                   }).finally(function () {
                       $location.path("/complete")
                   });
    }
});