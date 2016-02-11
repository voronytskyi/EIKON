(function () {
    'use strict';

    angular.module('omdb.services').factory('messenger', [function () {

        toastr.options = {
            closeButton: true,
            debug: false,
            positionClass: 'toast-top-right',
            showDuration: 300,
            hideDuration: 1000,
            timeOut: 5000
        }

        return {
            error: function (text) {
                toastr.error(text, 'Error');
            },
            success: function (text) {
                toastr.success(text);
            },
            info: function (text) {
                toastr.info(text);
            }
        }
    }]);
})();