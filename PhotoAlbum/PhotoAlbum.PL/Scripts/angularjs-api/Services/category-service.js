(function () {
    "use strict";
    angular.module('photoAlbumApp').service("categoryService", ["$http", function ($http) {
        var baseAddress = "/api/Category/";
        var url = "";
        var self = this;

        self.getAll = function () {
            url = baseAddress + "GetAllCategories/";
            return $http.get(url);
        };

        self.getCategoryById = function (id) {
            url = baseAddress + "GetCategoryById/";
            return $http.get(url, id);
        };
    }]);
})();