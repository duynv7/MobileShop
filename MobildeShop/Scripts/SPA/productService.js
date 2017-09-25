app.service("productService", function ($http) {
    this.get = function (id) {
        return $http.get("/products/JsonDetails/" + id);
    }

    this.post = function (Product) {
        var request = $http({
            method: "post",
            url: "/products/JsonCreate",
            data: Product
        });
        return request;
    }

    this.put = function (Product) {
        var request = $http({
            method: "put",
            url: "/products/JsonUpdate/" + Product.id,
            data: Product
        });
        return request;
    }

})