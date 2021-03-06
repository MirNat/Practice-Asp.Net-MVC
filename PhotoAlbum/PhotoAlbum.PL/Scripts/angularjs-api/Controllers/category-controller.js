﻿(function () {
    "use strict";
    angular.module('photoAlbumApp').controller("categoryController", function ($scope, categoryService) {
        $scope.categories = [];

        jQuery('.dropdown-toggle').dropdown()

        categoryService.getAll().success(function (data) {
            $scope.categories = data;
        });

        $scope.setSelectedCategoryName = function (categoryName) {
            categoryService.setSelectedCategoryName(categoryName);
        };
    });
})();