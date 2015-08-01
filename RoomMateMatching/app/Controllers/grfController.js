roomMateMatchingApp.controller('grfController',
    ['$scope', '$location', 'authenticationService',
        function ($scope, $location, authenticationService) {

            if (!authenticationService.getIsAuthenticatedAsAdmin()) {
                //alert("You are not authenticated!!!");
                $location.path('/login');
            }

            $scope.logout = function() {
                authenticationService.setIsAuthenticatedAsAdmin(false);
                $location.path('/login');
            }
        }])