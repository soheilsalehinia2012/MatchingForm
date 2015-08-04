
roomMateMatchingApp.factory('userDataService',
    ['$http', function ($http) {

        var getStdPass = function (user) {
            return $http.post("Login/GetStdPass", user);
        }

        return {
            getStdPass: getStdPass
        };
    }]);