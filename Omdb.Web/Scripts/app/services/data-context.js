(function () {
    'use strict';

    angular.module('omdb.services').factory('dataContext', ['$http', 'settings', 'messenger', function ($http, settings, messenger) {
        var url = function (method) {
            return settings.apiUrl + method;
        },
        processResponse = function (response) {
            // validate response
            if (response.data.IsSuccess === false) {
                // show error
                messenger.error(response.data.ErrorMessage);
            }
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