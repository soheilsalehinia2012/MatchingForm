
var roomMateMatchingApp = angular.module('roomMateMatchingApp', ['ngRoute' , 'ui.bootstrap']);

roomMateMatchingApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when("/login", {
            templateUrl: "app/Views/lgiTemplate.html",
            controller: "lgiController"
        })
        .when("/matchingForm", {
            templateUrl: "app/Views/mfTemplate.html",
            controller: "mfController"
        })
        .otherwise({
            redirectTo: "/login"
        });
    
}]);

