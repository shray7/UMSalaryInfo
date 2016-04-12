
var defaultapp = angular.module('defaultapp', []);
defaultapp.controller('HomeController', function ($scope, $http) {
    
    $scope.Search = function () {
        var name = document.getElementById('searchName').value;
        var select = document.getElementById('searchYear');
        var year = select.value;
        $scope.loading = true;
        $scope.zeroResult = false;
        $http({ method: 'GET', url: '/home/AngularSearch', params: { name: name, year: year } }).
      success(function (data, status, headers, config) {
          $scope.resultList = data;
          $scope.loading = false;
          if ($scope.resultCount.length == 0)
              $scope.zeroResult = true;
          console.log(data);
      }).
      error(function (data, status, headers, config) {
          console.log("error");
      });
    }
});

defaultapp.factory('StudentService', ['$http', function ($http) {

    var StudentService = {};
    StudentService.getStudents = function () {
        return $http.get('/Home/Search');
    };
    return StudentService;

}]);