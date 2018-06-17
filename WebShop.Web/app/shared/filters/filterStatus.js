(function (app) {
    app.filter('statusFilter', function () {
        return function (input) {
            if (input == true) {
                return 'Kich hoat';
            } else {
                return 'Khoa';
            }
        }
    });
})(angular.module('webshop.common'));