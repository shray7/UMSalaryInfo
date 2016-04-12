var titleSearchapp = angular.module('TitleSearchapp', []);
titleSearchapp.controller('HomeController', function ($scope, $http) {

    $scope.GetMinMax = function (myArray) {
        var lowest = Number.POSITIVE_INFINITY;
        var highest = Number.NEGATIVE_INFINITY;
        var tmp;
        for (var i = myArray.length - 1; i >= 0; i--) {
            tmp = Number(myArray[i].FTR.replace(/[^0-9\.]+/g, ""));
            if (tmp < lowest) lowest = tmp;
            if (tmp > highest) highest = tmp;
        }
        $scope.min = lowest.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
        $scope.max = highest.toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
    }

    $scope.GetAverage = function (array) {
        var length = array.length;
        var sum = 0;
        for (var i = 0; i < length; i++) {
            sum = sum + Number(array[i].FTR.replace(/[^0-9\.]+/g, ""));
        }
        $scope.average = (sum / length).toFixed(2).replace(/(\d)(?=(\d{3})+\.)/g, '$1,');
    }
    $scope.Search = function () {
        var title = document.getElementById('searchTitle').value;
        var select = document.getElementById('searchYear');
        var year = select.value;
        $scope.loading = true;
        $scope.showTable = false;
        $scope.showNoResults = false;
        $http({ method: 'GET', url: '/home/AngularSearchSalaryByTitle', params: { title: title, year: year } }).
            success(function (data, status, headers, config) {
                $scope.resultList = data;
                $scope.GetMinMax($scope.resultList);
                $scope.GetAverage($scope.resultList);
                $scope.loading = false;
                $scope.numberOfPeopleWithTitle = $scope.resultList.length;
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
