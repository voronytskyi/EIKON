(function () {
    'use strict';

    angular.module('omdb.services').factory('settings', [function () {
        return {
            apiUrl: '/movieapi/',
            autocompleteTimeout: 1000,
            imagePlaceholder: 'http://placehold.it/400x300',
            events: {
                autocompleteStart: 'autocomplete-start',
                autocompleteEnd: 'autocomplete-end',
                autocompleteItemSelected: 'autocomplete-item-selected'
            }
        }
    }]);
})();