/// <reference path="C:\Users\DatPQ\Documents\datpqshop\DatPQShop.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('datpqshop.products', ['datpqshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('products', {
            url: "/products",
            templateUrl: "/app/components/products/productListView.html",
            controller: "productListController"
        }).state('add_product', {
            url: "/add_product",
            templateUrl: "/app/components/products/productAddView.html",
            controller: "productAddController"
        }).state('edit_product', {
            url: "/edit_product/:id",
            templateUrl: "/app/components/products/productEditView.html",
            controller: "productEditController"
        })
    }
})();