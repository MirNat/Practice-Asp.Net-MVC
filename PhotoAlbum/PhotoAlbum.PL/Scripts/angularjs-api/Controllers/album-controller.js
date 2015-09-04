(function () {
    angular.module('photoAlbumApp').controller("albumController", function ($scope, $rootScope, $state, $stateParams, $modal,  $window, albumService, categoryService, userService) {
        $scope.totalNumberOfAlbums = 0;
        $scope.currentPageNumber = 1;
        $scope.maxSizeOfPage = 5;
        $scope.albumsPerPage = 5;
        $scope.numberOfPageButtons = 5;
        $scope.albums = [];
        $scope.currentUserAlbums = [];
        $scope.album = {};
        $scope.selectedCategoryName = categoryService.getSelectedCategoryName();
        $scope.categories = [];
        $scope.isEditMode = null;
        $scope.isCurrentUserOwnerOfProfile = null;
        $scope.isDeleted = null;

        $scope.setOrUpdateAlbums = function () {
            switch ($state.$current.name) {
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
                        $scope.currentUserAlbums = data;
                        $scope.albums = $scope.currentUserAlbums;
                        $scope.isCurrentUserOwnerOfProfile = true;
                    });
                    break;
                }
                case 'Authorized.Album.Photos': {
                    albumService.getAlbumById($stateParams.id).success(function (data) {
                        $scope.album = data;
                        userService.isCurrentUserOwnerOfProfile($scope.album.AuthorId).success(function (data) {
                            $scope.isCurrentUserOwnerOfProfile = data;
                        });
                    });
                    break;
                }
                case 'Authorized.AddAlbum': {
                    $scope.isEditMode = false;
                    categoryService.getAll().success(function (data) {
                        $scope.categories = data;
                    });
                    break;
                }
                case 'Authorized.EditAlbum': {
                    $scope.isEditMode = true;
                    albumService.getAlbumById($stateParams.id).success(function (data) {
                        $scope.album = data;
                    });
                    categoryService.getAll().success(function (data) {
                        $scope.categories = data;
                    });
                    break;
                }
                default: { }
            }
        }

        $scope.setOrUpdateAlbums();
        $scope.pageChanged = function () {
            this.setOrUpdateAlbums();
        };

        $scope.$watch(function () {
            return categoryService.getSelectedCategoryName();
        }, function (newValue, oldValue) {
            if (newValue != null) {
                $scope.selectedCategoryName = newValue;
                $scope.setOrUpdateAlbums();
            }
        }, true);

        $scope.createAlbum = function (addEditAlbum) {
            if (addEditAlbum.$valid) {
                albumService.createAlbum($scope.album).success(function (createdAlbumId) {
                    if (createdAlbumId) {
                        $scope.album.Id = createdAlbumId;
                        $scope.currentUserAlbums.push($scope.album);
                        $state.go("Authorized.MyProfile.Albums");
                    }
                });
            }
        };

        $scope.updateAlbum = function (addEditAlbum) {
            if (addEditAlbum.$valid) {
                albumService.updateAlbum($scope.album).success(function (updatedAlbumId) {
                    if (updatedAlbumId) {
                        $scope.album.Id = updatedAlbumId;
                        userService.getCurrentUserAlbums().success(function (data) {
                            $scope.currentUserAlbums = data;
                        });
                        for (var i = 0; i < $scope.currentUserAlbums.length; i++) {
                            if ($scope.currentUserAlbums[i].Id == updatedAlbumId) {
                                $scope.currentUserAlbums[i] = $scope.album;
                                break;
                            }
                        };

                        for (var i = 0; i < $scope.albums.length; i++) {
                            if ($scope.albums[i].Id == deletedAlbumId) {
                                $scope.albums[i] = $scope.album;
                                break;
                            }
                        };
                    }
                });
            }
        };
        
        $scope.deleteAlbum = function (deletedAlbumId) {
            albumService.deleteAlbum(deletedAlbumId).then(function (isDeleted) {
                if (isDeleted) {
                    userService.getCurrentUserAlbums().success(function (data) {
                        $scope.currentUserAlbums = data;
                    });
                    for (var i = 0; i < $scope.currentUserAlbums.length; i++) {
                        if ($scope.currentUserAlbums[i].Id == deletedAlbumId) {
                            $scope.currentUserAlbums.splice(i, 1);
                            break;
                        }
                    };

                    for (var i = 0; i < $scope.albums.length; i++) {
                        if ($scope.albums[i].Id == deletedAlbumId) {
                            $scope.albums.splice(i, 1);
                            break;
                        }
                    };
                }
            }, function () {
               // console.log('Error. Can`t delete album.');
            });
        };
    });
})();