
roomMateMatchingApp.controller('lgiController',
    ['$scope', '$location', 'userDataService', 'authenticationService',
        function ($scope, $location, userDataService, authenticationService) {

        authenticationService.setIsAuthenticated(false);;
        authenticationService.setStdNum(null);

        $scope.user = userDataService.getUser();
        $scope.editableUser = angular.copy($scope.user);

        $scope.login = function (id) {

            userDataService.getStdPass($scope.editableUser).then(
                function (results) {
                    if (!results.data.isFilledForm && results.data.role == "user") {
                        //on success    
                        $scope.user = angular.copy($scope.editableUser);
                        authenticationService.setIsAuthenticated(true);
                        authenticationService.setStdNum($scope.user.stdNum);
                        $location.path('/matchingForm');
                    } else if (results.data.role == "admin") {
                        authenticationService.setIsAuthenticatedAsAdmin(true);
                        $location.path('/groupResults');
                    } else {
                        alert("You already filled the form...")
                    }
                },
                function(results) {
                    //on error
                    alert("Std Number or Password is wrong...");
                });

            
        };
        
    }]);