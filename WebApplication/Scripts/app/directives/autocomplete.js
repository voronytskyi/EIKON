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
                    autoSelect: true,
                    afterSelect: function (item) {
                        var a1 = scope;
                        var a2 = dataContext;
                        //trigger load grid from heres
                        scope.$broadcast(settings.events.autocomplete, item);
                    }
                });
            }
        };
    }]);
})();