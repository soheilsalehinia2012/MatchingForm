roomMateMatchingApp.factory('authenticationService',
    function () {
        var isAuthenticated = false;
        var stdNum = null;
        var isAuthenticatedAsAdmin = false;

        function setIsAuthenticated(isauth) {
            isAuthenticated = isauth;
        }

        function getIsAuthenticated() {
            return isAuthenticated;
        }

        function setIsAuthenticatedAsAdmin(isauth) {
            isAuthenticatedAsAdmin = isauth;
        }

        function getIsAuthenticatedAsAdmin() {
            return isAuthenticatedAsAdmin;
        }

        function setStdNum(stdnum) {
            stdNum = stdnum;
        }

        function getStdNum() {
            return stdNum;
        }

        return {
            setIsAuthenticated: setIsAuthenticated,
            getIsAuthenticated: getIsAuthenticated,
            setStdNum: setStdNum,
            getStdNum: getStdNum,
            setIsAuthenticatedAsAdmin: setIsAuthenticatedAsAdmin,
            getIsAuthenticatedAsAdmin: getIsAuthenticatedAsAdmin
        };

    });