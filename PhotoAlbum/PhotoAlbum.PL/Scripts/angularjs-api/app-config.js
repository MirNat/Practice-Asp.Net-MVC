(function () {
    "use strict";
    angular.module('photoAlbumApp').config(function ($stateProvider, $urlRouterProvider) {

        $stateProvider.state('Authorized', {
            abstract: true,
            template: '<div ui-view />',
            controller: "photoController"
        })
        .state('Authorized.About', {
            url: '/About',
            templateUrl: '/Home/About/',//'Views/About.html',
            controller: "manageTabController"
        })
        .state("Authorized.LatestPublications", {
            url: "/LatestPublications",//:categoryNameForFilter",
            templateUrl: "/Album/LatestPublications/",//Views/LatestPublications",
            controller: "albumController",
            data: {
                pageTitle: 'Latest Publications'
            }
        })
          .state("Authorized.AllPublications", {
              url: "/AllPublications",///:currentPageNumber/:numberOfRecordsPerPage/:categoryNameForFilter",
              templateUrl: "/Album/AllPublications/",
              controller: "albumController",
              data: {
                  pageTitle: 'All Publications'
              }
          })
          .state("Authorized.MyProfile", {
              abstract: true,
              url: "MyProfile",
              templateUrl: "/User/Profile/",
              controller: "userController",
              data: {
                  pageTitle: 'My Profile'
              }
          })
          .state("Authorized.MyProfile.Albums", {
                url: "/Albums",
                templateUrl: "/Album/GetUserAlbums/",
                controller: "albumController",
                data: {
                    pageTitle: 'My Albums'
                }
          })
          .state("Authorized.AddAlbum", {
              url: "/MyProfile/Albums/AddAlbum",
              templateUrl: "/Album/AddAlbum/",
              controller: "albumController",
              data: {
                  pageTitle: 'Add Album'
              }
          })
          .state("Authorized.EditAlbum", {
              url: "/MyProfile/Albums/EditAlbum",
              templateUrl: "/Album/EditAlbum/",
              controller: "albumController",
              data: {
                  pageTitle: 'Edit Album'
              }
          })
          .state("Authorized.UserProfile", {
              abstract: true,
              url: "/UserProfile/:id",
              templateUrl: "/User/Profile/",
              controller: "userController",
              data: {
                  pageTitle: 'User Profile'
              }
          })
          .state("Authorized.UserProfile.Albums", {
              url: "/Albums",
              templateUrl: "/Album/GetUserAlbums/",
              controller: "albumController",
              data: {
                  pageTitle: 'User albums'
              }
          })
          .state("Authorized.Album", {
              abstract: true,
              url: "/Album/:id",
              templateUrl: "/Album/GetAlbumInfoById",
              controller: "albumController",
              data: {
                  pageTitle: 'Album'
              }
          })
          .state("Authorized.Album.Photos", {
              url: "/Photos",
              templateUrl: "/Album/GetAlbumPhotosById/",
              controller: "albumController",
              data: {
                  pageTitle: 'Album Photos'
              }
          })
          .state("Authorized.Album.Photo", {
              url: "/Photo/:id",
              templateUrl: "/Photo/GetFullSizePhotoById/",
              controller: "photoController",
              data: {
                  pageTitle: 'Photo'
              }
          })
          .state("404", {
              url: "/404",
              templateUrl: "/Home/NotFoundForAngularPages/"
          })
          .state("403", {
              url: "/403",
              templateUrl: "/Home/ForbiddenForAngularPages/"
          });

        //$urlRouterProvider.when("", "/About");
        //$urlRouterProvider.when("/", "/About");
        //$urlRouterProvider.otherwise("/About");//"/404");
        //$locationProvider.html5Mode(true).hashPrefix('!')
    });
})();
