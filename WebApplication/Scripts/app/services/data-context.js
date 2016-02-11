(function () {
    'use strict';

    angular.module('omdb.services').factory('dataContext', ['$http', 'settings', function ($http, settings) {
        var url = function (method) {
            return settings.apiUrl + method;
        },
        processResponse = function (response) {
            //Validate response here, then pass it forward
            if (response.data.IsSuccess === false) {
                // show error
                return null;
            }

            toastr.error('Tada!');

            return response.data;
        };

        return {
            search: function (title, pageNumber) {
                return $http.get(url('search'), {
                    params: {
                        title: title,
                        page: pageNumber
                    }
                }).then(function (response) {
                    return processResponse(response);
                });
            },
            details: function (id) {
                return $http.get(url('details'), {
                    params: {
                        id: id
                    }
                }).then(function (response) {
                    return processResponse(response);
                });
            }
        }
    }]);
})();