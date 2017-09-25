app.service("productService", function ($http) {
    this.get = function (id) {
        return $http.get("/products/JsonDetails/" + id);
    }

})