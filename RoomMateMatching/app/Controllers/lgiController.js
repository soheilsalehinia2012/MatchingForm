
roomMateMatchingApp.controller('lgiController',
    ['$scope', '$location', 'userDataService', 'authenticationService',
        function ($scope, $location, userDataService, authenticationService) {

        authenticationService.setIsAuthenticated(false);;


        $scope.login = function (id) {

            userDataService.getStdPass($scope.user).then(
                function(results) {
                    //on success    
                    authenticationService.setStdNum(results.data);
                    authenticationService.setIsAuthenticated(true);
                    $location.path('/matchingForm');
                },
                function(results) {
                    //on error
                    alert("Std Number or Password is wrong...");
                });


        };
        
    }]);