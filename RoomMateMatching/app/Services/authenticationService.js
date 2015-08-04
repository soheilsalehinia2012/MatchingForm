roomMateMatchingApp.factory('authenticationService',
    function () {
        var isAuthenticated = false;

        function setIsAuthenticated(isauth) {
            isAuthenticated = isauth;
        }

        function getIsAuthenticated() {
            return isAuthenticated;
        }

        return {
            setIsAuthenticated: setIsAuthenticated,
            getIsAuthenticated: getIsAuthenticated
        };

    });