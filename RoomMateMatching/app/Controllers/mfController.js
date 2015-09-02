
roomMateMatchingApp.controller('mfController',
    ['$scope', '$window', '$routeParams', 'mfDataService', '$location', 'authenticationService',
    function mfController($scope, $window, $routeParams, mfDataService, $location, authenticationService) {


        if (!authenticationService.getIsAuthenticated()) {
            //alert("You are not authenticated!!!");
            $location.path('/login');
        }

        $scope.answers = mfDataService.getAnswers();

        $scope.showValidationError = false;
        $scope.isFill = false;

        $scope.submitForm = function () {

            if ($scope.answers.Answer01 != null &&
                $scope.answers.Answer02 != null &&
                $scope.answers.Answer03 != null &&
                $scope.answers.Answer04 != null &&
                $scope.answers.Answer05 != null &&
                $scope.answers.Answer06 != null &&
                $scope.answers.Answer07 != null &&
                $scope.answers.Answer08 != null &&
                $scope.answers.Answer09 != null &&
                $scope.answers.Answer10 != null) {

                    $scope.isFill = true;
            }
            if ($scope.isFill) {

                $scope.answers.stdNum = authenticationService.getStdNum();

                $scope.answers.answersString = $scope.answers.Answer01 +
                    $scope.answers.Answer02 +
                    $scope.answers.Answer03 +
                    $scope.answers.Answer04 +
                    $scope.answers.Answer05 +
                    $scope.answers.Answer06 +
                    $scope.answers.Answer07 +
                    $scope.answers.Answer08 +
                    $scope.answers.Answer09 +
                    $scope.answers.Answer10;

                mfDataService.insertAnswers($scope.answers).then(
                    function (results) {
                        //on success    
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