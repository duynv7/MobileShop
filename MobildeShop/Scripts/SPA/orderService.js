app.service("orderService", function ($http) {

    this.getCustomerByPhone = function (phone) {
        var request = $http({
            method: "get",
            url: "/customers/GetCustomerByPhone",
            params: { 'phone': phone }
        });
        return request;
    }

    this.putCustomer = function (id, Customer) {
        var request = $http({
            method: "put",
            url: "/api/CustomersAPI/" + id,
            data: Customer
        });
        return request;
    }

    this.postCustomer = function (Customer) {
        var request = $http({
            method: "post",
            url: "/api/CustomersAPI/",
            data: Customer
        });
        return request;
    }

    this.post = function (Order) {
        var request = $http({
            method: "post",
            url: "/api/OrdersAPI/",
            data: Order
        });
        return request;
    }
    
})