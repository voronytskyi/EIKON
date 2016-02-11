(function () {
    'use strict';

    angular.module('omdb.controllers').controller('MainCtrl', ['$scope', 'dataContext', 'settings', function ($scope, dataContext, settings) {
        this.movies = [];
        this.totalCount = 0;
        this.searchText = 'james';
        this.isBusy = false;
        this.pageNumber = 1;
        this.showModal = false;
        this.detail = {};
        this.detailsLoading = false;

        this.init = function () {
            this.search();
            //Subscribe on autocomplete updates
            $scope.$on(settings.events.autocomplete, function (event, item) {
                console.log(item);
            });

            toastr.options = {
                closeButton: true,
                debug: false,
                positionClass: 'toast-bottom-right',
                showDuration: 300,
                hideDuration: 1000,
                timeOut: 5000
            }
        };

        this.toggleModal = function (id) {
            var ctx = this;

            this.detailsLoading = true;

            dataContext.details(id).then(function (response) {
                ctx.detail = response;
            }).finally(function () {
                ctx.detailsLoading = false;
            });

            this.showModal = !this.showModal;
        };

        this.search = function () {
            var ctx = this;

            this.isBusy = true;
            dataContext.search(this.searchText, this.pageNumber).then(function (response) {
                ctx.movies = response.Items;
                ctx.totalCount = response.TotalCount;
            }).finally(function () {
                ctx.isBusy = false;
            });
        };
    }]);
})();