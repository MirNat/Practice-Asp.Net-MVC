(function () {
    "use strict";
    angular.module('photoAlbumApp').service("albumService", ["$http", function ($http) {
        var baseAddress = "/api/Album/";
        var url = "";
        var self = this;
        var selectedAlbumId = null;

        self.setSelectedAlbumId = function (id) {
            selectedAlbumId = id;
        };

        self.getSelectedAlbumId = function () {
            return selectedAlbumId;
        };

        self.getAllAlbums = function (currentPageNumber, numberOfRecordsPerPage, categoryNameForFilter) {
            if (categoryNameForFilter == undefined) {
                categoryNameForFilter = "";
            }
            url = baseAddress + "GetAllAlbums?currentPageNumber=" + currentPageNumber +
                   "&numberOfRecordsPerPage="+ numberOfRecordsPerPage +
                   "&categoryNameForFilter=" + categoryNameForFilter;
            return $http.get(url);
            /* if (categoryNameForFilter == undefined) {
                categoryNameForFilter = "";
            }
            url = baseAddress + "GetAllAlbums/" + currentPageNumber + "/"+ numberOfRecordsPerPage + "/" + categoryNameForFilter;
            return $http.get(url);*/
        };

        self.getLatestAlbums = function (categoryNameForFilter) {
            if (categoryNameForFilter == undefined) {
                categoryNameForFilter = "View All";
            }
            url = baseAddress + "GetLatestAlbums/" + categoryNameForFilter;
            return $http.get(url);
        };

        self.getAlbumById = function (id) {
            url = baseAddress + "GetAlbumById/" + id;
            return $http.get(url);
        };

        self.createAlbum = function (album) {
            url = baseAddress + "CreateAlbum";
            return $http.post(url, album);
        };

        self.updateAlbum = function (album) {
            url = baseAddress + "UpdateAlbum/";
            return $http.post(url, album);
        };

        self.deleteAlbum = function (id) {
            url = baseAddress + "DeleteAlbum/";
            return $http.post(url, id);
        };
    }]);
})();