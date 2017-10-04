app.service("customerService", function ($http) {
    this.get = function (id) {
        return $http.get("/api/CustomersAPI/" + id);
    }

    //this.getAll = function () {
    //    return $http.get("/api/ProductsAPI/");
    //}


    this.getAll = function (stext, num, page, sort, asc) {
        var request = $http({
            method: "get",
            url: "/customers/SearchCustomers",
            params: { 'text': stext, 'number': num, 'page': page, 'sortBy': sort, 'isAsc': asc }
        });
        return request;
    }

    this.put = function (id, Product) {
        var request = $http({
            method: "put",
            url: "/api/CustomersAPI/" + id,
            data: Product
        });
        return request;
    }

    this.post = function (Product) {
        var request = $http({
            method: "post",
            url: "/api/CustomersAPI/",
            data: Product
        });
        return request;
    }

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/CustomersAPI/" + id
        });
        return request;
    }

})