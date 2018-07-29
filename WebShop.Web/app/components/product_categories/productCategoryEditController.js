(function (app) {
    app.controller('productCategoryEditController', productCategoryEditController);
    productCategoryEditController.$inject = ['apiService', '$scope', 'notificationService', '$state','$stateParams','commonService'];

    function productCategoryEditController(apiService, $scope, notificationService, $state, $stateParams, commonService) {
        $scope.productCategory = {
            CreatedDate: new Date(),
            Status: true
        }
        $scope.UpdateProductCategory = UpdateProductCategory;
        $scope.GetSeoTitle = GetSeoTitle;

        function GetSeoTitle() {
            $scope.productCategory.Alias = commonService.getSeoTitle($scope.productCategory.Name);
        }
        function loadProductCategoryDetail() {
            apiService.get('api/productcategory/GetById/' + $stateParams.id,null, function (result) {
                $scope.productCategory = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        function UpdateProductCategory() {
            apiService.put('api/productcategory/update', $scope.productCategory,
                function (result) {
                notificationService.displaySuccess(result.data.Name + ' da duoc sua.');
                $state.go('product_categories');
            }, function (error) {
                notificationService.displayError('khong thanh cong');
            });
        }

        function loadParentCategory() {
            apiService.get('api/productcategory/GetAllParent', null, function (result) {
                $scope.parentCategories = result.data;
            }, function () {
                console.log("Cannot get list parent");
            });
        }
        loadParentCategory();
        loadProductCategoryDetail();
    }
})(angular.module('webshop.product_categories'));