var app = angular.module("appcustomer", [])

app.controller('customerController', controller);

controller.$inject = ['$scope', 'customerService'];

function controller($scope, customerService) {
    // modal button parameters
    $scope.BtnText = "Thêm mới";
    $scope.editable = true;
    //customer parameters
    $scope.customer;
    $scope.customerList;
    // Search parameters
    $scope.searchText;
    $scope.displayNum = 5
    $scope.currentPage = 1;
    $scope.totalPage = [];
    // Sort parameters
    $scope.sortString = '';
    $scope.isAsc = true;


    // load customer list based on search text, page size and current page number
    $scope.loadCustomers = function (pageNum) {
        $scope.currentPage = pageNum;
        var promiseGet = customerService.getAll($scope.searchText, $scope.displayNum, $scope.currentPage - 1,
            $scope.sortString, $scope.isAsc); //The MEthod Call from service
        promiseGet.then(function (pl) {
            $scope.customerList = pl.data.list
            //console.log($scope.customerList)
            pageCount = Math.ceil(pl.data.count / $scope.displayNum);
            $scope.totalPage = [];
            for (i = 1; i <= pageCount; i++) {
                $scope.totalPage.push(i);
            }
        },
            function (errorPl) {
                $log.error('failure loading Customer', errorPl);
            });
        console.log("loadcustomers called")
    }
    $scope.loadCustomers(1);
    // load single customer to view, enable/disable input edit and change button text
    $scope.loadCustomer = function (id, editable, text) {
        var promiseGet = customerService.get(id); //The MEthod Call from service
        promiseGet.then(function (pl) {
            $scope.customer = pl.data;
            $scope.BtnText = text;
            $scope.editable = editable;
            //console.log($scope.customer)
            //console.log($scope.BtnText)
        },
            function (errorPl) {
                $log.error('failure loading Customer', errorPl);
            });

    }
    // handle Action Button inside modal
    $scope.BtnClick = function () {
        if ($scope.BtnText === "Thêm mới") {
            console.log($scope.customer)
            var promisePost = customerService.post($scope.customer);
            promisePost.then(function (pl) {
                //loadRecords();
                $scope.loadCustomers($scope.currentPage);
            }, function (err) {
                console.log("Err" + err);
            });
        } else if ($scope.BtnText === "Sửa") {
            var promisePut = customerService.put($scope.customer.id, $scope.customer);
            promisePut.then(function (pl) {
                //$scope.Message = "Updated Successfuly";
                //loadRecords();
                $scope.loadCustomers($scope.currentPage);
            }, function (err) {
                console.log("Err" + err);
            });
        } else {
            var promiseDelete = customerService.delete($scope.customer.id);
            promiseDelete.then(function (pl) {
                //$scope.Message = "Updated Successfuly";
                //loadRecords();
                $scope.loadCustomers($scope.currentPage);
            }, function (err) {
                console.log("Err" + err);
            });
        }

    }

    // sorting function
    $scope.sort = function (propName) {
        $scope.isAsc = !$scope.isAsc;
        $scope.sortString = propName;
        $scope.loadCustomers($scope.currentPage);
    }

    // refresh data when create new
    $scope.create = function () {
        $scope.customer = null;
        $scope.BtnText = "Thêm mới";
        $scope.editable = true;

    }

}
