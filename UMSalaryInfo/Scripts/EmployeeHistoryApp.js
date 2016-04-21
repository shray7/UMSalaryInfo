
var employeeHistoryApp = angular.module('employeeHistoryApp', []);
employeeHistoryApp.controller('HomeController', function ($scope, $http) {

    $scope.Search = function () {
        var name = document.getElementById('searchName').value;
        $scope.loading = true;
        $scope.showTable = false;
        $scope.showNoResults = false;
        $http({ method: 'GET', url: '/home/AngularEmployeeSearch', params: { name: name } }).
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
