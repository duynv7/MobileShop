var app = angular.module("app", [])

app.controller('orderController', controller);

controller.$inject = ['$scope', 'orderService'];

function controller($scope, orderService) {
    $scope.customer;
    $scope.order;
    $scope.customer.id = 0;

    $scope.getCustomer = function (phone) {
        var promiseGet = orderService.getCustomerByPhone(phone);
        promiseGet.then(function (pl) {
            $scope.customer = pl.data;
        },
            function (errorPl) {
                $log.error('failure loading Product', errorPl);
            });

    }
    // handle Action Button inside modal
    $scope.BtnClick = function () {
        // Check ton tai customer
        $scope.getCustomer(customer.Phone)
        // Neu ton tai
        if ($scope.customer.id > 0) {
            $scope.order.CustomerId = $scope.customer.id
        }
        var promisePost = orderService.post($scope.order);
        promisePost.then(function (pl) {
            //Message successful
        }, function (err) {
            console.log("Err" + err);
        });

    }



}
