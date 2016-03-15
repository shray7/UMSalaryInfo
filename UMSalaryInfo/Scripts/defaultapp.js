
var defaultapp = angular.module('defaultapp', []);
defaultapp.controller('HomeController', function ($scope) {
    $scope.Message = "This is a message";
    //getStudents();
    //function getStudents() {
    //    StudentService.getStudents()
    //        .success(function (studs) {
    //            $scope.students = studs;
    //            console.log($scope.students);
    //        })
    //        .error(function (error) {
    //            $scope.status = 'Unable to load customer data: ' + error.message;
    //            console.log($scope.status);
    //        });
    //}
});

defaultapp.factory('StudentService', ['$http', function ($http) {

    var StudentService = {};
    StudentService.getStudents = function () {
        return $http.get('/Home/GetPersons');
    };
    return StudentService;

}]);