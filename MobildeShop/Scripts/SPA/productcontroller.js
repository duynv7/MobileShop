var app = angular.module("app", [])

        app.controller('productController', controller);

    controller.$inject = ['$scope', 'productService'];

    function controller($scope, productService) {
        $scope.title = 'controller';
        $scope.product;

        $scope.loadProduct = function (id) {
            var promiseGet = productService.get(id); //The MEthod Call from service
            promiseGet.then(function (pl) {
                $scope.product = pl.data
                console.log($scope.product)
            },
                function (errorPl) {
                    $log.error('failure loading Product', errorPl);
                });

        }

        $scope.create = function () {
            $scope.product.Title = ''
            $scope.product.Code = ''
            $scope.product.Price = ''
            $scope.product.Description = ''

        }
       

    }
