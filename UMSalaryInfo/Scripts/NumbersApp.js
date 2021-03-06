﻿var numbersApp = angular.module('NumbersApp', []);
numbersApp.controller('HomeController', function ($scope, $http) {
    $scope.Search = function () {
        var select = document.getElementById('searchYear');
        var year = select.value;
        $scope.loading = true;
        $scope.showTable = false;
        $scope.showNoResults = false;
        $http({ method: 'GET', url: '/home/AngularNumbers', params: { year: year } }).
            success(function (data, status, headers, config) {
                $scope.resultList = data;
                $scope.loading = false;
                if ($scope.resultList.length > 0)
                    $scope.showTable = true;
                else
                    $scope.showNoResults = true;
                console.log(data);
            }).
            error(function (data, status, headers, config) {
                console.log("error");
            });
    }
});

