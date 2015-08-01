roomMateMatchingApp.factory('authenticationService',
    function () {
        var isAuthenticated = false;
        var stdNum = null;

        function setIsAuthenticated(isauth) {
            isAuthenticated = isauth;
        }

        function getIsAuthenticated() {
            return isAuthenticated;
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
            getStdNum: getStdNum
        };

    });