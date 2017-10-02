var app = angular.module("appOrder", [])

app.controller('orderController', controller);

controller.$inject = ['$scope', 'orderService', '$filter'];

function controller($scope, orderService, $filter) {
    $scope.customer;
    $scope.order;

    $scope.getCustomer = function (phone) {
        var promiseGet = orderService.getCustomerByPhone(phone);
        promiseGet.then(function (pl) {
            $scope.customer = pl.data.c;
            
           // $scope.customer.DOB = $filter('date')($scope.customer.DOB, 'dd-MM-yyyy');
        },
            function (errorPl) {
                $log.error('failure loading Product', errorPl);
            });
        $scope.customer.Phone = phone

    }

    $scope.onBlur = function () {
        $scope.getCustomer($scope.customer.Phone)
        //console.log($scope.customer.Phone)
        console.log($scope.customer)
    };

    // handle Action Button inside modal
    $scope.BtnClick = function () {
        // Check ton tai customer

        // Neu ton tai
        if ($scope.customer.id > 0) {
            $scope.order.CustomerId = $scope.customer.id
            var editCustomer = orderService.putCustomer($scope.customer.id, $scope.customer);
            editustomer.then(function (pl) {
                //Message successful
            }, function (err) {
                console.log("Err" + err);
            });
        }
        else {
            var addCustomer = orderService.postCustomer($scope.customer);
            addCustomer.then(function (pl) {
                //Message successful
                $scope.order.CustomerId = pl.data;
            }, function (err) {
                console.log("Err" + err);
            });
        }
        var promisePost = orderService.post($scope.order);
        promisePost.then(function (pl) {
            //Message successful
        }, function (err) {
            console.log("Err" + err);
        });

    }



}
