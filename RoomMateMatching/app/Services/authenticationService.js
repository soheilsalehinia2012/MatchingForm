roomMateMatchingApp.factory('authenticationService',
    function () {
        var isAuthenticated = false;

        function set(data) {
            isAuthenticated = data;
        }

        function get() {
            return isAuthenticated;
        }

        return {
            set: set,
            get: get
        };

    });