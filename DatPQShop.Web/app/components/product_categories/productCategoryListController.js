/// <reference path="C:\Users\DatPQ\Documents\datpqshop\DatPQShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService','notificationService'];
    function productCategoryListController($scope, apiService, notificationService) {
        $scope.page = 0;
        $scope.pageCount = 0;
        $scope.productCategories = [];
        $scope.keyword = '';
        $scope.getProductCategories = getProductCategories;
        $scope.search = search;
        function search() {
            getProductCategories();
        }
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 10
                }
            }
            apiService.get('/api/productcategory/getall', config, function (result) {
                if (result.data.TotalCount == 0) {
                    notificationService.displayWarning('Không có bản ghi nào được tìm thấy.');
                }
                else {
                    notificationService.displaySuccess('Đã tìm thấy ' + result.data.TotalCount + ' bản ghi.');
                }
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
                

            }, function () {
                console.log('load product category failed.')
            });
        }
        $scope.getProductCategories();
    }
})(angular.module('datpqshop.product_categories'));