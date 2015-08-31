(function () {
    "use strict";
    angular.module('photoAlbumApp').service("photoService", ["$http", function ($http) {
        var baseAddress = "/api/Photo/";
        var url = "";
        var self = this;

        self.getFullSizePhotoById = function (id) {
            url = baseAddress + "GetFullSizePhotoById?id=" + id;
            return $http.get(url);
        };
        
        self.createPhoto = function (model) {
            url = baseAddress + "CreatePhoto/";
            return $http.post(url, model);
        };

        self.deletePhoto = function (id) {
            url = baseAddress + "DeletePhoto/";
            return $http.post(url, id);
        };
    }]);
})();
