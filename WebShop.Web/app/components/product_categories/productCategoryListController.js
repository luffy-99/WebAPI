(function (app) {
    app.controller('productCategoryListController', productCategoryListController);
    productCategoryListController.$inject = ['$scope', 'apiService', 'notificationService','$ngBootbox','$filter'];
    function productCategoryListController($scope, apiService, notificationService, $ngBootbox, $filter) {
        $scope.productCategories = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.getProductCategories = getProductCategories;
        $scope.search = search;
        $scope.keyword = '';
        function search() {
            getProductCategories();
        }
        $scope.selectAll = selectAll;
        $scope.deleteMultiple = deleteMultiple;
        function deleteMultiple() {
            var config = {
                params: {
                    listId: $scope.selected
                }
            }
            apiService.del('api/productCategory/deletemulti', config, function (result) { },
                function (error) { })
        }
        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.productCategories, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }
        $scope.$watch("productCategories", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                console.log(checked.length);
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);
        $scope.deleteProductCategory = deleteProductCategory;
        function deleteProductCategory(id) {
            $ngBootbox.confirm('Bạn có chắc muốn xóa?').then(function () {
                var config = {
                    params: {
                        id: id
                    }
                }
                apiService.del('api/productcategory/delete', config, function () {
                    notificationService.displaySuccess('Xóa thành công');
                    search();
                }, function () {
                    notificationService.displayError('Xóa không thành công');
                })
            });
        }
        function getProductCategories(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize:20
                }
            }
            apiService.get('/api/productcategory/GetAll', config, function (result) {
                $scope.productCategories = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPages;
                $scope.totalCount = result.data.TotalCount;
            }, function () {
                console.log("load product category failed.");
               });
        }
        $scope.getProductCategories(); 
    }
})(angular.module('webshop.product_categories'));