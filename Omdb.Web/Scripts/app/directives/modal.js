(function () {
    'use strict';

    angular.module('omdb.directives').directive('omdbModal', [function () {

        var loadingHtml = '<span class="modal-loader"><span class="glyphicon glyphicon-refresh glyphicon-refresh-animate"></span> Loading...</span>';
        return {
            template: '<div class="modal fade">' +
                '<div class="modal-dialog modal-lg">' +
                  '<div class="modal-content">' +
                    '<div class="modal-header">' +
                      '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                      '<h4 class="modal-title">{{ title }}</h4>' +
                    '</div>' +
                    '<div class="modal-body-loader" ng-show="isLoading">' + loadingHtml + '</div>' +
                    '<div class="modal-body" ng-transclude ng-hide="isLoading"></div>' +
                  '</div>' +
                '</div>' +
              '</div>',
            transclude: true,
            replace: true,
            scope: {
                visible: '=omdbModal',
                isLoading: '=',
                title: '@'
            },
            link: function (scope, element, attrs) {
                scope.$watch('visible', function (value) {
                    if (value) {
                        $(element).modal('show');
                    } else {
                        $(element).modal('hide');
                    }
                });

                $(element).on('shown.bs.modal', function () {
                    scope.$apply(function () {
                        scope.visible = true;
                    });
                });

                $(element).on('hidden.bs.modal', function () {
                    scope.$apply(function () {
                        scope.visible = false;
                    });
                });

                //Cleanup subscriptions
                scope.$on('$destroy', function () {
                    $(element).off('.bs.modal');
                });
            }
        };
    }]);
})();