var app = angular.module("app",[])

        app.controller('productController', controller);

        controller.$inject = ['$scope', 'productService'];

        function controller($scope, productService) {
        $scope.BtnText = "Thêm mới";
        //product parameters
        $scope.product;
        $scope.productList;
        $scope.idDetele = {}
        // Search parameters
        $scope.searchText;
        $scope.displayNum = 5
        $scope.currentPage = 1;
        $scope.totalPage = [];


        $scope.loadProducts = function (pageNum) {
            $scope.currentPage = pageNum;
            var promiseGet = productService.getAll($scope.searchText, $scope.displayNum, $scope.currentPage - 1); //The MEthod Call from service
            promiseGet.then(function (pl) {
                $scope.productList = pl.data.list
                //console.log($scope.productList)
                pageCount = Math.ceil(pl.data.count / $scope.displayNum);
                $scope.totalPage = [];
                for (i = 1; i <= pageCount; i++) {
                    $scope.totalPage.push(i);
                }
            },
                function (errorPl) {
                    $log.error('failure loading Product', errorPl);
                });
            console.log("loadproducts called")
        }
        $scope.loadProducts(1);

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
                    $scope.loadProducts($scope.currentPage);
                }, function (err) {
                    console.log("Err" + err);
                });
            } else {
                var promisePut = productService.put($scope.product.id, $scope.product);
                promisePut.then(function (pl) {
                    //$scope.Message = "Updated Successfuly";
                    //loadRecords();
                    $scope.loadProducts($scope.currentPage);
                }, function (err) {
                    console.log("Err" + err);
                });
            }
        }

        // Search
       
        $scope.search = function () {

        }

        $scope.create = function () {
            $scope.product = null;
            $scope.BtnText = "Thêm mới";

        }
       
    }
