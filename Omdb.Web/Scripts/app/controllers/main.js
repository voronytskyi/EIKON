﻿(function () {
    'use strict';

    angular.module('omdb.controllers').controller('MainCtrl', ['$scope', 'dataContext', 'settings', function ($scope, dataContext, settings) {
        var that = this;
        this.movies = [];
        this.totalCount = 0;
        this.searchText = 'james';
        this.searchLoading = false;
        this.pageNumber = 1;
        this.showModal = false;
        this.detail = {};
        this.detailsLoading = false;

        this.init = function () {
            this.search();
            //Subscribe on autocomplete updates
            $scope.$on(settings.events.autocompleteItemSelected, function (event, item) {
                that.search();
            });
            $scope.$on(settings.events.autocompleteStart, function (event) {
                that.searchLoading = true;
            });
            $scope.$on(settings.events.autocompleteEnd, function (event) {
                that.searchLoading = false;
            });
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
            this.searchLoading = true;
            dataContext.search(this.searchText, this.pageNumber).then(function (response) {
                ctx.movies = response.Items;
                ctx.totalCount = response.TotalCount;
            }).finally(function () {
                ctx.searchLoading = false;
            });
        };
    }]);
})();