
roomMateMatchingApp.controller('lgiController',
    ['$scope', '$location', 'userDataService', 'authenticationService',
        function ($scope, $location, userDataService, authenticationService) {

        $scope.isAuthenticate = false;

        $scope.user = userDataService.getUser();
        $scope.editableUser = angular.copy($scope.user);

        $scope.login = function () {

            userDataService.getStdPass($scope.editableUser).then(
                function (results) {
                    //on success    
                    $scope.user = angular.copy($scope.editableUser);
                    authenticationService.set(results.data);
                    $location.path('/matchingForm');
                },
                function(results) {
                    //on error
                    alert("Std Number or Password is wrong...");
                });

            
        };
        
    }]);