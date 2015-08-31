(function () {
    angular.module('photoAlbumApp').controller("albumController", function ($scope, $state, $stateParams, albumService, categoryService, userService) {
        console.log('albumController');
        $scope.totalNumberOfAlbums = 0;
        $scope.currentPageNumber = 1;
        $scope.maxSizeOfPage = 5;
        $scope.albumsPerPage = 5;
        $scope.numberOfPageButtons = 5;
        $scope.selectedCategory = {};
        $scope.categories = [];//categoryService.getAll();
        $scope.albums = [];
        $scope.album = {};

        $scope.getSelectedAlbum = function () {        
            albumService.getAlbumById(albumService.getSelectedAlbumId()).success(function (data) {
                $scope.album = data;
                console.log(JSON.stringify($scope.album));
            });
        };


        $scope.setSelectedAlbum = function (id) {
            albumService.setSelectedAlbumId(id)
        };

        this.setOrUpdateAlbums = function(){
            switch($state.$current.name){
                case 'Authorized.LatestPublications': {
                    albumService.getLatestAlbums($scope.selectedCategory.Name).success(function (data) {
                        $scope.albums = data;
                        console.log(JSON.stringify($scope.albums));
                    });
                    break;
                }
                case 'Authorized.AllPublications': {
                    albumService.getAllAlbums($scope.currentPageNumber, $scope.albumsPerPage, $scope.selectedCategory.Name).success(function (data) {
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
        
        this.setOrUpdateAlbums();

        categoryService.getAll().success(function (data) {
            $scope.categories = data;
            console.log(JSON.toString($scope.categories));
        });

        $scope.setSelectedCategory = function (category) {
            /*if (category.Name === undefined) {
                $scope.selectedCategory.Name = "";
            }*/
            $scope.selectedCategory = category;
            this.setOrUpdateAlbums();      
        };

        $scope.pageChanged = function () {
            this.setOrUpdateAlbums();
        };
    });
})();