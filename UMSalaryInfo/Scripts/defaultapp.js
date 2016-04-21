
var defaultapp = angular.module('defaultapp', []);
defaultapp.controller('HomeController', function ($scope, $http) {
    
    $scope.Search = function () {
        var name = document.getElementById('searchName').value;
        var select = document.getElementById('searchYear');
        var year = select.value;
        $scope.loading = true;
        $scope.showTable = false;
        $scope.showNoResults = false;
        $http({ method: 'GET', url: '/home/AngularSearch', params: { name: name, year: year } }).
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
    $scope.showModal = false;
    $scope.childName = "";
    $scope.PopModal = function (name) {
        $scope.childResultList = null;
        $scope.childName = name;
        $scope.showModal = true;
        console.log(name);
        $http({ method: 'GET', url: '/home/AngularEmployeeSearch', params: { name: name } }).
            success(function (data, status, headers, config) {
                $scope.childResultList = data;
                $scope.loading = false;
                if ($scope.childResultList.length > 0)
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
