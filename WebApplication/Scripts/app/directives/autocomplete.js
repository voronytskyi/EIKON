(function () {
    'use strict';

    angular.module('omdb.directives').directive('omdbAutocomplete', ['dataContext', 'settings', function (dataContext, settings) {
        //throttles argument function to execute not more often then timeSpan argument
        //it queues last throttled function to execute after the timespan, if it was no more calls to the function
        var throttle = function (fn, timespan) {
            var timeoutInstance;
            return function () {
                var args = arguments;
                clearTimeout(timeoutInstance);
                timeoutInstance = setTimeout(function () {
                    fn.apply(this, args);
                }, timespan);
            };
        },
        //Prevent search to be called more often than it's set in settings autocompleteTimeout
        throttledSearch = throttle(function (text, scope) {
            console.log('searching for: ' + text);
            //TODO: Uncomment when autocomplete api is done
            //dataContext.autocomplete(text).then(function (movies) {
            //    scope.movies = movies;
            //});
        }, settings.autocompleteTimeout);

        return {
            replace: true,
            scope: {
                searchText: '='
            },
            link: function (scope, element, attrs) {

                $(element).typeahead({
                    delay: settings.autocompleteTimeout,
                    source: function(query, process) {

                        var text = $(element).val();
                        dataContext.search(text).then(function(response) {
                            var items = [];
                            angular.forEach(response.Items, function(value, key) {
                                this.push({
                                    id: value.ImdbID,
                                    name: value.Title
                                });
                            }, items);
                            process(items);
                        });
                    },
                    autoSelect: true,
                    afterSelect : function(item) {
                        var a1 = scope;
                        var a2 = dataContext;
                        //trigger load grid from heres
                    }
                });
                /*scope.$watch('searchText', function (newValue) {
                    if (newValue) {
                        throttledSearch(newValue, scope);
                    }
                });*/
            }
        };
    }]);
})();