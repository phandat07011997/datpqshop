/// <reference path="C:\Users\DatPQ\Documents\datpqshop\DatPQShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService'];
    function productCategoryListController($scope,apiService) {
        $scope.productCategories = [];
        $scope.getProductCategories = getProductCategories;
        function getProductCategories() {
            apiService.get('/api/productcategory/getall', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log('load product category failed.')
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('datpqshop.product_categories'));