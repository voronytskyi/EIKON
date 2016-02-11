(function () {
    'use strict';

    angular.module('omdb.directives').directive('omdbAutocomplete', ['dataContext', 'settings', function (dataContext, settings) {

        return {
            replace: true,
            scope: {
                searchText: '='
            },
            link: function (scope, element, attrs) {

                $(element).typeahead({
                    delay: settings.autocompleteTimeout,
                    source: function (query, process) {

                        var text = $(element).val();
                        dataContext.search(text).then(function (response) {
                            var items = [];
                            angular.forEach(response.Items, function (value, key) {
                                this.push({
                                    id: value.ImdbID,
                                    name: value.Title
                                });
                            }, items);
                            process(items);
                        });
                    },
                    showHintOnFocus : true,
                    autoSelect: true,
                    afterSelect: function (item) {
                        //trigger load grid from heres
                        scope.$root.$broadcast(settings.events.autocomplete, item);
                    }
                });
            }
        };
    }]);
})();