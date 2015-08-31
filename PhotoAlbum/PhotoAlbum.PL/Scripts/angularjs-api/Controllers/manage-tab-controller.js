angular.module('photoAlbumApp').controller("manageTabController", ["$scope", "$state", function ($scope, $state) {
    $scope.tabs = [
            { stateName: "Authorized.Album", active: true },
            { stateName: "Authorized.LatestPublications", active: false },
            { stateName: "Authorized.AllPublications", active: false },
            { stateName: "Authorized.MyProfile.Albums", active: false },
            { stateName: "Authorized.UserProfile.Albums", active: false },
            { stateName: "Authorized.Album", active: false },
            { stateName: "Authorized.Photo", active: false }
    ];

    $scope.$on('$stateChangeSuccess', function () {
        $scope.tabs.forEach(function (tab) {
            tab.active = $state.includes(tab.stateName);
        });
    });
}]);