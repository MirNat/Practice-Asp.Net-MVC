﻿(function () {
    "use strict";
    angular.module('photoAlbumApp').controller("userController", function ($scope, $state, $stateParams, userService) {
        console.log('userController');
        $scope.user = {};
        $scope.isCurrentUserOwnerOfProfile = null;

        this.setOrUpdateUser = function () {
            switch ($state.$current.name) {
                case 'Authorized.MyProfile.Albums': {
                    userService.getCurrentUser().success(function (data) {
                        $scope.user = data;
                        console.log(JSON.stringify($scope.user));
                        $state.data = $scope.user.albums;
                    });
                    break;
                }
                case 'Authorized.UserProfile.Albums': {
                    userService.getUserById($stateParams.id).success(function (data) {
                        $scope.user = data;
                        console.log(JSON.stringify($scope.user));
                        $scope.albums = $scope.user.Albums;
                    });
                    break;
                }
                default: { }
            }
            userService.isCurrentUserOwnerOfProfile($scope.user.Id).success(function (data) {
                $scope.isCurrentUserOwnerOfProfile = data;
            });
        }

        this.setOrUpdateUser();
    });
})();
