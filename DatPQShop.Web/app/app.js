/// <reference path="C:\Users\DatPQ\Documents\datpqshop\DatPQShop.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('datpqshop', ['datpqshop.products', 'datpqshop.product_categories', 'datpqshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('home', {
            url: "/admin",
            templateUrl: "/app/components/home/homeView.html",
            controller: "homeController"
        });
        $urlRouterProvider.otherwise('/admin');
    }
})();