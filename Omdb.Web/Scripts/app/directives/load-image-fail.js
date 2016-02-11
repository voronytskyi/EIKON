(function () {
    'use strict';

    angular.module('omdb.directives').directive('omdbImgFallback', ['settings', function (settings) {

        return {
            restrict: 'A',
            link: function (scope, element, attr) {
                // Listen for errors on the element and if there are any replace the source with the fallback source
                var errorHanlder = function () {
                    element.off('error', errorHanlder);
                    var newSrc = attr.fallbackSrc || settings.imagePlaceholder;
                    if (element[0].src !== newSrc) {
                        element[0].src = newSrc;
                    }
                };
                element.on('error', errorHanlder);
            }
        };
    }]);
})();