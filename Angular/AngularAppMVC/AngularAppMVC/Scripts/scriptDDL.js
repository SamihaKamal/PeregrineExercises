var app = angular.module('ScriptDDL', []);
app.controller('MyController', function ($scope) {
    $scope.MyVal = "Welcome welcome!";

    $scope.MyFun = function () {
        alert("Hello world! ");
    }
    $scope.MyFun2 = function (val) {
        alert("Para: " + val);
    }
});