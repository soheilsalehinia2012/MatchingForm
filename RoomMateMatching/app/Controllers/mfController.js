
roomMateMatchingApp.controller('mfController',
    ['$scope', '$window', '$routeParams', 'mfDataService', '$location', 'authenticationService',
    function mfController($scope, $window, $routeParams, mfDataService, $location, authenticationService) {


        if (!authenticationService.getIsAuthenticated()) {
            //alert("You are not authenticated!!!");
            $location.path('/login');
        }

        $scope.answers = mfDataService.getAnswers();

        $scope.editableAnswers = angular.copy($scope.answers);

        $scope.showValidationError = false;
        $scope.isFill = false;

        $scope.submitForm = function () {

            if ($scope.editableAnswers.Answer01 != null &&
                $scope.editableAnswers.Answer02 != null &&
                $scope.editableAnswers.Answer03 != null &&
                $scope.editableAnswers.Answer04 != null &&
                $scope.editableAnswers.Answer05 != null &&
                $scope.editableAnswers.Answer06 != null &&
                $scope.editableAnswers.Answer07 != null &&
                $scope.editableAnswers.Answer08 != null &&
                $scope.editableAnswers.Answer09 != null &&
                $scope.editableAnswers.Answer10 != null) {

                    $scope.isFill = true;
            }
            if ($scope.isFill) {

                $scope.editableAnswers.stdNum = authenticationService.getStdNum();

                mfDataService.insertAnswers($scope.editableAnswers).then(
                    function (results) {
                        //on success    
                        $scope.answers = angular.copy($scope.editableAnswers);
                        alert("You applied the form...");
                        $location.path('/login');
                    },
                    function (results) {
                        //on error
                        alert("Can't done right now, please come back later!!!");
                    });

                
            } else {
                $scope.showValidationError = true;
            }
            
        };

        $scope.cancelForm = function() {
            authenticationService.setIsAuthenticated(false);
            $location.path('/login');
        };

        $scope.totalItems = 100;
        $scope.currentPage = 1;

        $scope.alert = {
            type: 'danger',
            msg: 'You should answer to all questions first!!!'
        };


    }]);