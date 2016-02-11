(function () {
    'use strict';

    angular.module('omdb.services').factory('settings', [function () {
        return {
            apiUrl: '/movieapi/',
            autocompleteTimeout: 700,
            imagePlaceholder: 'http://placehold.it/400x300',
            events: {
                autocomplete: 'autocomplete'
            }
        }
    }]);
})();