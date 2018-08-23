/// <reference path="C:\Users\DatPQ\Documents\datpqshop\DatPQShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('loginController', loginController);
    loginController.$inject = ['$scope', '$state'];
    function loginController($scope, $state) {
        $scope.loginSubmit = function () {
            $state.go('home');
        }
    }
})(angular.module('datpqshop'));