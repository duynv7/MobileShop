var app = angular.module("app", [])

        app.controller('productController', controller);

    controller.$inject = ['$scope', 'productService'];

    function controller($scope, productService) {
        $scope.BtnText = "Thêm mới";
        $scope.product;

        $scope.loadProduct = function (id) {
            var promiseGet = productService.get(id); //The MEthod Call from service
            promiseGet.then(function (pl) {
                $scope.product = pl.data
                $scope.BtnText = "Sửa"
                console.log($scope.product)
            },
                function (errorPl) {
                    $log.error('failure loading Product', errorPl);
                });

        }

        $scope.BtnClick = function () {
            if ($scope.BtnText === "Thêm mới") {
                var promisePost = productService.post($scope.product);
                promisePost.then(function (pl) {
                    //loadRecords();
                }, function (err) {
                    console.log("Err" + err);
                });
            } else {
                var promisePut = productService.put($scope.product);
                promisePut.then(function (pl) {
                    //$scope.Message = "Updated Successfuly";
                    //loadRecords();
                }, function (err) {
                    console.log("Err" + err);
                });
            }
        }

        $scope.create = function () {
            //$scope.product.Title = ''
            //$scope.product.Code = ''
            //$scope.product.Price = ''
            //$scope.product.Description = ''
            $scope.product = null;
            $scope.BtnText = "Thêm mới";

        }
       

    }
