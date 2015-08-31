(function () {
    angular.module('photoAlbumApp').controller("albumController", function ($scope, $state, $stateParams, albumService, categoryService, userService) {
        console.log('albumController');
        $scope.totalNumberOfAlbums = 0;
        $scope.currentPageNumber = 1;
        $scope.maxSizeOfPage = 5;
        $scope.albumsPerPage = 5;
        $scope.numberOfPageButtons = 5;
        $scope.albums = [];
        $scope.album = {};
        $scope.selectedCategoryName = categoryService.getSelectedCategory().Name;
        $scope.categories = [];
        $scope.isEditMode = null;
        $scope.isCurrentUserOwnerOfProfile = null;

        $scope.getSelectedAlbum = function () {        
            albumService.getAlbumById(albumService.getSelectedAlbumId()).success(function (data) {
                $scope.album = data;
            });
        };

        $scope.setSelectedAlbum = function (id) {
            albumService.setSelectedAlbumId(id)
        };

        $scope.setOrUpdateAlbums = function () {
            switch($state.$current.name){
                case 'Authorized.LatestPublications': {
                    albumService.getLatestAlbums($scope.selectedCategoryName).success(function (data) {
                        $scope.albums = data;
                    });
                    $scope.isCurrentUserOwnerOfProfile = false;
                    break;
                }
                case 'Authorized.AllPublications': {
                    albumService.getAllAlbums($scope.currentPageNumber, $scope.albumsPerPage, $scope.selectedCategoryName).success(function (data) {
                        $scope.albums = data.AlbumsToShow;
                        $scope.totalNumberOfAlbums = data.TotalAlbumsCount;
                    });
                    $scope.isCurrentUserOwnerOfProfile = false;
                    break;
                }
                case 'Authorized.UserProfile.Albums': {
                    userService.getUserAlbumsById($stateParams.id).success(function (data) {
                        $scope.albums = data;
                        userService.isCurrentUserOwnerOfProfile($stateParams.id).success(function (data) {
                            $scope.isCurrentUserOwnerOfProfile = data;
                        });
                    });
                    break;
                }
                case 'Authorized.MyProfile.Albums': {
                    userService.getCurrentUserAlbums().success(function (data) {
                        $scope.albums = data;
                        $scope.isCurrentUserOwnerOfProfile = true;
                    });
                    break;
                }
                case 'Authorized.Album.Photos': {
                    $scope.getSelectedAlbum();
                    $scope.isCurrentUserOwnerOfProfile = false;
                }
                case 'Authorized.AddAlbum': {
                    $scope.isEditMode = false;
                    categoryService.getAll().success(function (data) {
                        $scope.categories = data;
                    });
                }
                case 'Authorized.EditAlbum': {
                    $scope.isEditMode = true;
                    albumService.getAlbumById($stateParams.id).success(function (data) {
                        $scope.album = data;
                    });
                    categoryService.getAll().success(function (data) {
                        $scope.categories = data;
                    });
                }
                default: {}      
            }
        }
        
        $scope.setOrUpdateAlbums();

        $scope.pageChanged = function () {
            this.setOrUpdateAlbums();
        };

        $scope.$watch(function () {
            return categoryService.getSelectedCategory().Name;
        }, function (newValue, oldValue) {
            if (newValue != null) {
                $scope.selectedCategoryName = newValue;
                $scope.setOrUpdateAlbums();
            }
        }, true);
    });
})();