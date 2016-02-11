(function () {
    'use strict';

    angular.module('omdb.directives').directive('modal', ['dataContext', 'settings', function (dataContext, settings) {

        var loadingHtml = '<span class="modal-loader"><span class="glyphicon glyphicon-refresh glyphicon-refresh-animate"></span> Loading...</span>';
        return {
            template: '<div class="modal fade">' +
                '<div class="modal-dialog modal-lg">' +
                  '<div class="modal-content">' +
                    '<div class="modal-header">' +
                      '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                      '<h4 class="modal-title">{{ title }}</h4>' +
                    '</div>' +
                    '<div class="modal-body-loader">' + loadingHtml + '</div>' +
                    '<div class="modal-body" ng-transclude></div>' +
                  '</div>' +
                '</div>' +
              '</div>',
            restrict: 'E',
            transclude: true,
            replace: true,
            scope: true,
            link: function postLink(scope, element, attrs) {
                scope.title = attrs.title;
                scope.$watch(attrs.visible, function (value) {
                    if (value == true) {
                        $(element).find('.modal-body').hide();
                        $(element).find('.modal-body-loader').show();
                        $(element).modal('show');
                    } else {
                        $(element).modal('hide');
                    }
                });

                $(element).on('shown.bs.modal', function () {
                    $(element).find('.modal-body').show();
                    $(element).find('.modal-body-loader').hide();
                    scope.$apply(function () {
                        scope.$parent[attrs.visible] = true;
                    });
                });

                $(element).on('hidden.bs.modal', function () {
                    scope.$apply(function () {
                        scope.$parent[attrs.visible] = false;
                    });
                });
            }
        };
    }]);
})();