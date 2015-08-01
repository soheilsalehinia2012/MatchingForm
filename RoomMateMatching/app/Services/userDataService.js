
roomMateMatchingApp.factory('userDataService',
    ['$http', function ($http) {

        var getStdPass = function (user) {
            return $http.post("Login/GetStdPass", user);
        }

        var getUser = function () {
            return {
                stdNum: null,
                password: null
            };
        };

        return {
            getStdPass: getStdPass,
            getUser: getUser
        };
    }]);