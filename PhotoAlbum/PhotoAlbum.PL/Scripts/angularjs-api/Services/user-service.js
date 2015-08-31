(function () {
    "use strict";
    angular.module('photoAlbumApp').service("userService", ["$http", function ($http) {
        var baseAddress = "/api/User/";
        var url = "";
        var self = this;

        self.getUserById = function (id) {
            url = baseAddress + "GetUserById/"+id;
            return $http.get(url);
        };

        self.getCurrentUser = function () {
            url = baseAddress + "GetCurrentUser/";
            return $http.get(url);
        };

        self.getUserAlbumsById = function (id) {
            url = baseAddress + "GetUserAlbumsById/"+id;
            return $http.get(url);
        };

        self.getCurrentUserAlbums = function () {
            url = baseAddress + "GetCurrentUserAlbums/";
            return $http.get(url);
        };
    }]);
})();