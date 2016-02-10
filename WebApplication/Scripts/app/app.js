(function () {
    'use strict';
    //Initialize application modules and setup dependencies
    angular.module('omdb', ['omdb.controllers', 'omdb.services', 'omdb.directives']);
    angular.module('omdb.controllers', ['omdb.services']);
    angular.module('omdb.directives', ['omdb.services']);
    angular.module('omdb.services', []);
})();