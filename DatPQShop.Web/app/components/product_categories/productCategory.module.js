/// <reference path="C:\Users\DatPQ\Documents\datpqshop\DatPQShop.Web\Assets/admin/libs/angular/angular.js" />
(function () {
    angular.module('datpqshop.product_categories', ['datpqshop.common']).config(config);
    config.$inject = ['$stateProvider', '$urlRouterProvider'];
    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('product_categories', {
            url: "/product_categories",
            templateUrl: "/app/components/product_categories/productCategoryListView.html",
            controller: "productCategoryListController"
        }).state('add_product_category', {
            url: "/add_product_category",
            templateUrl: "/app/components/product_categories/productCategoryAddView.html",
            controller: "productCategoryAddController"
        })
    }
})();