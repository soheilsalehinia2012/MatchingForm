
roomMateMatchingApp.controller('lgiController',
    ['$scope', '$location', 'mfDataService', function ($scope, $location, mfDataService) {

        $scope.login = function () {
            $location.path('/matchingForm');
        };
        
    }]);