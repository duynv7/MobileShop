app.service("productService", function ($http) {
    this.get = function (id) {
        return $http.get("/api/ProductsAPI/" + id);
    }

    //this.getAll = function () {
    //    return $http.get("/api/ProductsAPI/");
    //}


    this.getAll = function (stext, num, page, sort, asc) {
        var request = $http({
            method: "get",
            url: "/products/SearchProducts",
            params: { 'text': stext, 'number': num, 'page': page, 'sortBy':  sort, 'isAsc' : asc}
        });
        return request;
    }

    this.put = function (id, Product) {
        var request = $http({
            method: "put",
            url: "/api/ProductsAPI/" + id,
            data: Product
        });
        return request;
    }

    this.post = function (Product) {
        var request = $http({
            method: "post",
            url: "/api/ProductsAPI/",
            data: Product
        });
        return request;
    }

    this.delete = function (id) {
        var request = $http({
            method: "delete",
            url: "/api/ProductsAPI/" + id
        });
        return request;
    }

})