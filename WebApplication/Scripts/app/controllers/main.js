(function () {
    'use strict';

    angular.module('omdb.controllers').controller('MainCtrl', ['dataContext', '$scope', function (dataContext, $scope) {
        this.movies = [];
        this.searchText = 'james';
        this.isBusy = false;
        this.pageNumber = 1;
        this.totalPages = 1;

        this.showModal = false;
        this.toggleModal = function () {
            this.showModal = !this.showModal;
        };

        this.search = function () {
            dataContext.search(this.searchText, this.pageNumber)
                .then(function (foundMovies) {
                    this.movies = foundMovies;
                }.bind(this));
        };
        this.search();
    }]);
})();