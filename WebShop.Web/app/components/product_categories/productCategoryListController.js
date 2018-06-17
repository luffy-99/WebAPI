(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope','apiService'];
    function productCategoryListController($scope, apiService) {
        $scope.productCategories = [];
        $scope.getProductCategories = getProductCategories;
        function getProductCategories() {
            apiService.get('/api/productcategory/GetAllParent', null, function (result) {
                $scope.productCategories = result.data;
            }, function () {
                console.log("load product category failed.");
               });
        }
        $scope.getProductCategories();
    }
})(angular.module('webshop.product_categories'));