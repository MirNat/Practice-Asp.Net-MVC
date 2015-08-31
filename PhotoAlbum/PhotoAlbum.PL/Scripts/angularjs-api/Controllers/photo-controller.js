(function () {
    "use strict";
    angular.module('photoAlbumApp').controller("photoController", ["$scope", "$state", 'photoService', '$stateParams', function ($scope, $state, photoService, $stateParams) {
        this.setOrUpdatePhoto = function () {
            switch ($state.$current.name) {
                case 'Authorized.Album.Photo': {
                    $scope.photo = photoService.getFullSizePhotoById($scope.currentUserId);
                    $scope.styleFullSizePhoto = function () {
                        return { "background-image": "url('http://ufatum.com/data_images/city/city2.jpg')" };
                    }
                    break;
                }
                case '': {
                }
            }
        };
        this.setOrUpdatePhoto();
        /*if ($state.$current.name == "Authorized.Album.Photo")
        {
            $scope.photo = photoService.getFullSizePhotoById($scope.currentUserId);
            $scope.styleFullSizePhoto = function () {
                return { "background-image": "url('http://ufatum.com/data_images/city/city2.jpg')" };
            }
        }
        $scope.albumId;
        console.log("albumId " + $scope.album.Id);
        $scope.getSelectedAlbumId = function (newValue) {
            $scope.albumId = newValue;
        }*/


    }]);
})();
