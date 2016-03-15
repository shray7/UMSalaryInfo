
var departmentApp = angular.module('departmentApp', []);
departmentApp.controller('DepartmentController', function ($scope, $http) {
    $scope.Message = "This is a message";

    $http({
        method: "GET",
        url: "/Department/Get"
    }).then(function mySucces(response) {
        $scope.Message = response.data;
    }, function myError(response) {
        $scope.Message = response.statusText;
    });
    
});


//departmentApp.directive('myTable', function () {
//    return {
//        restrict: 'E, A, C',
//        link: function (scope, element, attrs, controller) {
//            var dataTable = element.dataTable(scope.options);

//            scope.$watch('options.aaData', handleModelUpdates, true);

//            function handleModelUpdates(newData) {
//                var data = newData || null;
//                if (data) {
//                    dataTable.fnClearTable();
//                    dataTable.fnAddData(data);
//                }
//            }
//        },
//        scope: {
//            options: "="
//        }
//    };
//});

//function Ctrl($scope) {
//    $scope.options = {
//        aoColumns: [{
//            "sTitle": "Department"
//        }],
//        aoColumnDefs: [{
//            "bSortable": false,
//            "aTargets": [0, 1]
//        }],
//        bJQueryUI: true,
//        bDestroy: true,
//        aaData: [
//            $scope.Message
//        ]
//    };

//    $scope.addData = function () {
//        $scope.counter = $scope.counter + 1;
//        $scope.options.aaData.push([$scope.counter, $scope.counter * 2]);
//    };

//    $scope.counter = 0;
//}

