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

        $scope.getSelectedAlbum = function () {        
            albumService.getAlbumById(albumService.getSelectedAlbumId()).success(function (data) {
                $scope.album = data;
                console.log(JSON.stringify($scope.album));
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
                        console.log(JSON.stringify($scope.albums));
                    });
                    break;
                }
                case 'Authorized.AllPublications': {
                    albumService.getAllAlbums($scope.currentPageNumber, $scope.albumsPerPage, $scope.selectedCategoryName).success(function (data) {
                        $scope.albums = data.AlbumsToShow;
                        console.log(JSON.stringify($scope.albums));
                        $scope.totalNumberOfAlbums = data.TotalAlbumsCount;
                    });
                    break;
                }
                case 'Authorized.UserProfile.Albums': {
                    userService.getUserAlbumsById($stateParams.id).success(function (data) {
                        $scope.albums = data;
                        console.log(JSON.stringify($scope.albums));
                    });
                    break;
                }
                case 'Authorized.MyProfile.Albums': {
                    userService.getCurrentUserAlbums().success(function (data) {
                        $scope.albums = data;
                        console.log($scope.user.Name);
                        console.log(JSON.stringify($scope.albums));
                    });
                    break;
                }
                case 'Authorized.Album.Photos': {
                        $scope.getSelectedAlbum();                
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