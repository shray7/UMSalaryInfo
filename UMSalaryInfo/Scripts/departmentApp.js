
var departmentApp = angular.module('departmentApp', []);
departmentApp.controller('DepartmentController', function ($scope, $http) {
    $http({
        method: "GET",
        url: "/Department/Get"
    }).then(function mySucces(response) {
        $scope.data = response.data;
        $(document).ready(function () {
            $('#example').DataTable({
                destroy: true,
                data: response.data.data,
                columns: [
                    { data: "title" }
                ]
            });
        });
    });
}, function myError(response) {
    $scope.data = response.statusText;
});

