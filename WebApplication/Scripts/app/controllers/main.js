(function () {
    'use strict';

    angular.module('omdb.controllers').controller('MainCtrl', ['dataContext', '$scope', function (dataContext, $scope) {
        var that = this;
        this.movies = [];
        this.totalCount = 0;
        this.searchText = 'james';
        this.isBusy = false;
        this.pageNumber = 1;

        this.detail = {};

        $scope.showModal = false;
        this.toggleModal = function (id) {
            dataContext.details(id).then(function (response) {
                that.detail = response;
            }.bind(this));
            $scope.showModal = !$scope.showModal;
        };

        this.autocompleteCallback = function() {
            debugger;
        };

        this.search = function () {
            dataContext.search(this.searchText, this.pageNumber).then(function (response) {
                that.movies = response.Items;
                that.totalCount = response.TotalCount;
            }.bind(this));
        };
        this.search();
    }]);
})();