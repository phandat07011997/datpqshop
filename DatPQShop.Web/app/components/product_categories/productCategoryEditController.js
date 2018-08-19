﻿/// <reference path="C:\Users\DatPQ\Documents\datpqshop\DatPQShop.Web\Assets/admin/libs/angular/angular.js" />
(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams','commonService'];
    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams,commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true,
            HomeFlag: true
        }
        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;
        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }
        function UpdateProductCategory() {
            apiService.put('/api/productcategory/update', $scope.productCategory, function (result) {
                notificationService.displaySuccess(result.data.Name + ' đã được cập nhật thành công.');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('Cập nhật không thành công.');
            });
        }
        function loadProductCategoryDetail() {
            apiService.get('/api/productcategory/getbyid/'+ $stateParams.id,null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }
        function loadParentCategory() {
            apiService.get('/api/productcategory/getallparents', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log('Can not get list parent');
            });
        }
        loadParentCategory();
        loadProductCategoryDetail();
    }
})(angular.module('datpqshop.product_categories'));