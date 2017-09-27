var app = angular.module("app",[])

        app.controller('productController', controller);

        controller.$inject = ['$scope', 'productService'];

        function controller($scope, productService) {
        // modal button parameters
        $scope.BtnText = "Thêm mới";
        $scope.editable = false;
        //product parameters
        $scope.product;
        $scope.productList;
        // Search parameters
        $scope.searchText;
        $scope.displayNum = 5
        $scope.currentPage = 1;
        $scope.totalPage = [];


            // load product list based on search text, page size and current page number
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
            // load single product to view, enable/disable input edit and change button text
        $scope.loadProduct = function (id, editable, text) {
            var promiseGet = productService.get(id); //The MEthod Call from service
            promiseGet.then(function (pl) {
                $scope.product = pl.data;
                $scope.BtnText = text;
                $scope.editable = editable;
                //console.log($scope.product)
                //console.log($scope.BtnText)
            },
                function (errorPl) {
                    $log.error('failure loading Product', errorPl);
                });

        }
        // handle Action Button inside modal
        $scope.BtnClick = function () {
            if ($scope.BtnText === "Thêm mới") {
                var promisePost = productService.post($scope.product);
                promisePost.then(function (pl) {
                    //loadRecords();
                    $scope.loadProducts($scope.currentPage);
                }, function (err) {
                    console.log("Err" + err);
                });
            } else if ($scope.BtnText === "Sửa") {
                var promisePut = productService.put($scope.product.id, $scope.product);
                promisePut.then(function (pl) {
                    //$scope.Message = "Updated Successfuly";
                    //loadRecords();
                    $scope.loadProducts($scope.currentPage);
                }, function (err) {
                    console.log("Err" + err);
                });
            } else {
                var promiseDelete = productService.delete($scope.product.id);
                promiseDelete.then(function (pl) {
                    //$scope.Message = "Updated Successfuly";
                    //loadRecords();
                    $scope.loadProducts($scope.currentPage);
                }, function (err) {
                    console.log("Err" + err);
                });
            }

        }

            // refresh data when create new
        $scope.create = function () {
            $scope.product = null;
            $scope.BtnText = "Thêm mới";

        }
       
    }
